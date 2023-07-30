using ds.authentication;
using ds.delmia.dsmfg.model;
using ds.delmia.dsmfg.service;
using ds.enovia.common.collection;
using ds.enovia.common.model;
using ds.enovia.common.search;
using ds.enovia.dseng.model;
using ds.enovia.dseng.service;
using technia.admintool.settings;

namespace technia.admintool.engineeringitems
{
    public partial class EngineeringItemForm : Form
    {
        public IPassportAuthentication Passport { get; set; }

        public AuthenticationInfo authInfo { get; set; }

        private EngineeringServices engServices = null;

        private ManufacturingItemService mfnServices = null;

        private BindingSource bindingSource = new BindingSource();

        List<Tuple<string, string>> m_columnPropName = new List<Tuple<string, string>>();
        public EngineeringItemForm(IPassportAuthentication Passport, AuthenticationInfo authInfo)
        {
            InitializeComponent();
            Logger.Info($"INSIDE ENG ITEMS : {authInfo}");
            if (!authInfo.IsValidAuthentication) return;
            this.Passport = Passport;
            this.authInfo = authInfo;

            engServices = new EngineeringServices(authInfo.EnoviaURL, Passport)
            {
                SecurityContext = authInfo.SecurityContext,
                Tenant = authInfo.Tenant
            };
            mfnServices = new ManufacturingItemService(authInfo.EnoviaURL, Passport)
            {
                SecurityContext = authInfo.SecurityContext,
                Tenant = authInfo.Tenant
            };
        }

        private void EngineeringItemForm_Load(object sender, EventArgs e)
        {
            m_searchResultGridView.AutoGenerateColumns = false;
            m_searchResultGridView.DataSource = bindingSource;
            InitializeColumnAndPropertyNames(ref m_columnPropName);
            bindingSource.AllowNew = false;
            InitializeGridColumns(m_searchResultGridView, m_columnPropName);

            m_dateAttributeComboBox.DisplayMember = "Description";
            m_dateAttributeComboBox.Items.Add(new SearchByNameUI());
            m_dateAttributeComboBox.Items.Add(new SearchByCreatedDateUI());
            m_dateAttributeComboBox.Items.Add(new SearchByModifiedDateUI());
            m_dateAttributeComboBox.SelectedIndex = 0;

            m_typeComboBox.DisplayMember = "Description";
            m_typeComboBox.Items.Add(new EngineeringItemUI());
            m_typeComboBox.Items.Add(new ManufacturingItemUI());
            m_typeComboBox.SelectedIndex = 0;
            UpdateUI();
        }

        #region add column and rows
        private void InitializeColumnAndPropertyNames(ref List<Tuple<string, string>> _columnPropName)
        {
            _columnPropName.Add(new Tuple<string, string>("title", "Title"));
            _columnPropName.Add(new Tuple<string, string>("revision", "Revision"));
            _columnPropName.Add(new Tuple<string, string>("state", "State"));
            _columnPropName.Add(new Tuple<string, string>("owner", "Owner"));
            _columnPropName.Add(new Tuple<string, string>("collabspace", "Collab Space"));
            _columnPropName.Add(new Tuple<string, string>("name", "Name"));
            _columnPropName.Add(new Tuple<string, string>("id", "Physical Id"));
            _columnPropName.Add(new Tuple<string, string>("created", "Created"));
            _columnPropName.Add(new Tuple<string, string>("modified", "Modified"));
        }

        private void InitializeGridColumns(DataGridView _datagridView, List<Tuple<string, string>> _columnPropNameList)
        {
            foreach (Tuple<string, string> columnPropName in _columnPropNameList)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = columnPropName.Item1,
                    Name = columnPropName.Item2,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                _datagridView.Columns.Add(column);
            }
        }
        #endregion

        private async void m_searchButton_Click(object sender, EventArgs e)
        {
            if (engServices == null) return;
            if (Passport == null) return;
            if (!Passport.IsValid()) { return; }
            Cursor = Cursors.WaitCursor;

            try
            {
                bindingSource.Clear();
                SearchQuery searchQuery = GetSearchQuery();
                object selectedType = m_typeComboBox.SelectedItem;
                m_searchStrValue.Text = searchQuery.GetSearchString();
                long count = 0;

                if (selectedType is EngineeringItemUI)
                {
                    List<NlsLabeledItemSet<EngineeringItem>> pages = await engServices.SearchAll(searchQuery);
                    #region add ENG data
                    foreach (NlsLabeledItemSet<EngineeringItem> page in pages)
                    {
                        if (page.totalItems > 0)
                        {
                            foreach (Item item in page.member)
                                bindingSource.Add(item);
                            count += page.totalItems;
                        }
                    }
                    #endregion
                }
                else if (selectedType is ManufacturingItemUI)
                {
                    List<NlsLabeledItemSet<ManufacturingItem>> pages = await mfnServices.SearchAll(searchQuery);
                    #region add MFN data
                    foreach (NlsLabeledItemSet<ManufacturingItem> page in pages)
                    {
                        if (page.totalItems > 0)
                        {
                            foreach (Item item in page.member)
                                bindingSource.Add(item);
                            count += page.totalItems;
                        }
                    }
                    #endregion
                }
                m_countLabel.Text = count.ToString();
            }
            catch (Exception _ex)
            {
                Logger.Error(_ex.Message);
                MessageBox.Show(_ex.Message);
            }
            Cursor = Cursors.Default;
        }

        #region GetSearchQuery
        private SearchQuery GetSearchQuery()
        {
            DateTime selectedDate = m_dateTimePicker.Value;
            DateTime selectedDateUTC = selectedDate.ToUniversalTime();
            string searchText = m_searchTextBox.Text.Trim();
            object selectedItem = m_dateAttributeComboBox.SelectedItem;

            if (selectedItem is SearchByNameUI) return new SearchByTitle(searchText);

            SearchByDate searchByDate = null;
            if (selectedItem is SearchByCreatedDateUI) searchByDate = new SearchByCreatedDate(selectedDateUTC);
            else if (selectedItem is SearchByModifiedDateUI) searchByDate = new SearchByModifiedDate(selectedDateUTC);

            if (m_stateReleasedCheckBox.Checked)
            {
                // [ds6w:status]:(VPLM_SMB_Definition.IN_WORK)
                // [ds6w:status]:(VPLM_SMB_Definition.RELEASED)
                searchByDate.AddCriteria("[ds6w:status]:(VPLM_SMB_Definition.RELEASED)");
            }

            List<string> contentStructureOptionsSelected = new List<string>();

            if (m_structureRootCheckBox.Checked) contentStructureOptionsSelected.Add("[ds6w:contentStructure]:\"Root\"");
            if (m_structureLeafCheckBox.Checked) contentStructureOptionsSelected.Add("[ds6w:contentStructure]:\"Leaf\"");
            if (m_structureIntermediateCheckBox.Checked) contentStructureOptionsSelected.Add("[ds6w:contentStructure]:\"Intermediate\"");
            if (m_structureStandaloneCheckBox.Checked) contentStructureOptionsSelected.Add("[ds6w:contentStructure]:\"Standalone\"");

            if (contentStructureOptionsSelected.Count > 0)
            {
                string contentStructureCriteria = contentStructureOptionsSelected[0];

                for (int i = 1; i < contentStructureOptionsSelected.Count; i++)
                    contentStructureCriteria += $" OR {contentStructureOptionsSelected[i]}";

                if (contentStructureOptionsSelected.Count > 1) contentStructureCriteria = $"({contentStructureCriteria})";
                searchByDate.AddCriteria(contentStructureCriteria);
            }
            return searchByDate;
        }

        #endregion

        private void UpdateUI()
        {
            m_dateTimePicker.Visible = m_dateAttributeComboBox.SelectedIndex > 0;
            m_searchTextBox.Visible = m_dateAttributeComboBox.SelectedIndex == 0;
        }

        private void m_dateAttributeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
