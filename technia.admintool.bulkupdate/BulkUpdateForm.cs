using ds.authentication;
using ds.enovia.change;
using ds.enovia.dseng.service;
using ds.enovia.dslc.service;
using System.Data;
using System.Dynamic;
using technia.admintool.bulkupdate.helper;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate
{
    public partial class BulkUpdateForm : Form
    {
        private BindingSource bindingSource;

        private List<ExpandoObject> csvData = new();

        public IPassportAuthentication Passport { get; set; }

        public AuthenticationInfo authInfo { get; set; }

        private EngineeringServices engServices;

        private CollaborativeLifecycleService collabLifecycleServices;

        private ChangeControlServices changeControlServices;

        public BulkUpdateForm(IPassportAuthentication Passport, AuthenticationInfo authInfo)
        {
            InitializeComponent();
            bindingSource = new BindingSource
            {
                AllowNew = false
            };
            Logger.Info($"INSIDE Bulk Update : {authInfo}");
            if (!authInfo.IsValidAuthentication) return;
            this.Passport = Passport;
            this.authInfo = authInfo;

            engServices = new EngineeringServices(authInfo.EnoviaURL, Passport)
            {
                SecurityContext = authInfo.SecurityContext,
                Tenant = authInfo.Tenant
            };
            collabLifecycleServices = new CollaborativeLifecycleService(authInfo.EnoviaURL, Passport)
            {
                SecurityContext = authInfo.SecurityContext,
                Tenant = authInfo.Tenant
            };
            changeControlServices = new ChangeControlServices(authInfo.EnoviaURL, Passport)
            {
                SecurityContext = authInfo.SecurityContext,
                Tenant = authInfo.Tenant
            };
        }

        private void BulkUpdateForm_Load(object sender, EventArgs e)
        {
            Logger.Info("Initializing Data Grid View...");
            m_searchResultGridView.AutoGenerateColumns = true;
            m_searchResultGridView.DataSource = bindingSource;
        }

        #region browse and add table data

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bindingSource.DataSource = null;
                CsvFileReader csvFileReader = new();
                if (!csvFileReader.TryGetFileContent()) Logger.Info("File selection canceled.");
                filePathTextbox.Text = csvFileReader.GetFileName();
                csvData = csvFileReader.ReadCsvLines();

                DataTable dataTable = TableUtils.GetTable(csvData);
                bindingSource.DataSource = dataTable;
                UpdateButton.Cursor = Cursors.Default;
                UpdateButton.Enabled = true;
                Logger.Info("Table created after reading file...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("Error reading the file: " + ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion

        #region update table data into 3DX

        private async void UpdateButton_ClickAsync(object sender, EventArgs e)
        {
            Logger.Info("Starting update of data from table into 3DX");
            try
            {
                Cursor = Cursors.WaitCursor;
                List<string> commentsColumn = new(); // create error and comments
                List<string> errorsColumn = new(); // to store results of processed OK or failed with error
                                                   // and add it in final table
                foreach (var record in csvData)
                {
                    string rowErrors = "";
                    string rowComments = "";
                    // fetch engItem details using title and revision 
                    var (engItem, error, comment) = await EngUtils.GetEngItemDetailAsync(engServices, record);
                    string id = engItem.id;
                    rowComments += comment;
                    if (error != null) rowErrors += error;
                    else
                    {
                        // Unreserve part
                        var (reservedBy, error2, comment2) = await EngUtils.UnreserveEngItemAsync(collabLifecycleServices, id);
                        rowComments += $", {comment2}";
                        if (error2 != null) rowErrors += error2;
                        else
                        {
                            // Check if change control exists on part
                            var (isChangeControlExists, error3, comment3) = await ChangeUtils.GetChangeControlAsync(changeControlServices, id);
                            rowComments += $", {comment3}";
                            if (error3 != null) rowErrors += error3;
                            else if (isChangeControlExists)
                            {
                                // Removing change control if change control exists
                                var (error4, comment4) = await ChangeUtils.DeactivateChangeControlAsync(changeControlServices, id);
                                rowComments += $", {comment4}";
                                if (error4 != null) rowErrors += error4;
                                else
                                {
                                    // Update part with the data from csv back to 3DX
                                    var (error5, comment5) = await EngUtils.UpdateEngItemAsync(engServices, record, id);
                                    rowComments += $", {comment5}";
                                    if (error5 != null) rowErrors += error5;
                                }
                            }
                            else
                            {
                                // Update part with the data from csv back to 3DX
                                var (error5, comment5) = await EngUtils.UpdateEngItemAsync(engServices, record, id);
                                rowComments += $", {comment5}";
                                if (error5 != null) rowErrors += error5;
                            }
                        }
                    }
                    errorsColumn.Add(rowErrors);
                    commentsColumn.Add(rowComments);
                }
                bindingSource.DataSource = null;
                DataTable dataTable = TableUtils.GetTableWithExtraCols(csvData, commentsColumn, errorsColumn);
                bindingSource.DataSource = dataTable;
                Logger.Info("Table updated into 3DX after reading file...");
                MessageBox.Show("Bulk update completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("Error reading the file: " + ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion
    }
}
