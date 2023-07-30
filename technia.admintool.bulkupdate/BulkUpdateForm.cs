using ds.authentication;
using ds.enovia.dseng.service;
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

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Starting update of data from table into 3DX");
            try
            {
                Cursor = Cursors.WaitCursor;
                bindingSource.DataSource = null;
                // create error and comments to store results of processed OK or failed with error and add it in final table
                List<string> commentsColumn = new();
                List<string> errorsColumn = new();

                foreach (var record in csvData)
                {
                    // fetch engItem details using title and revision 
                    var (engItem, error) = await EngUtils.GetEngItemDetailAsync(engServices, record);
                    if (error != null)
                    {
                        errorsColumn.Add(error);
                    }
                    else
                    {
                        // Unreserve part

                        // Check if change control exists on part

                        // Removing change control

                        // Update part with the data from csv back to 3DX 
                    }
                }

                DataTable dataTable = TableUtils.GetTableWithComments(csvData);
                bindingSource.DataSource = dataTable;
                Logger.Info("Table updated into 3DX after reading file...");
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
