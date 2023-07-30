namespace technia.admintool.engineeringitems
{
    partial class EngineeringItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            m_searchResultGridView = new DataGridView();
            m_searchTextBox = new TextBox();
            m_stateReleasedCheckBox = new CheckBox();
            m_structureRootCheckBox = new CheckBox();
            m_structureLeafCheckBox = new CheckBox();
            m_structureStandaloneCheckBox = new CheckBox();
            m_structureIntermediateCheckBox = new CheckBox();
            m_typeComboBox = new ComboBox();
            label2 = new Label();
            m_dateAttributeComboBox = new ComboBox();
            label1 = new Label();
            m_searchButton = new Button();
            titleLabel = new Label();
            totalLabel = new Label();
            m_countLabel = new Label();
            m_searchStrValue = new Label();
            searchFilter = new Label();
            m_dateTimePicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)m_searchResultGridView).BeginInit();
            SuspendLayout();
            // 
            // m_searchResultGridView
            // 
            m_searchResultGridView.AllowUserToAddRows = false;
            m_searchResultGridView.AllowUserToDeleteRows = false;
            m_searchResultGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.Azure;
            m_searchResultGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            m_searchResultGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_searchResultGridView.BackgroundColor = Color.FromArgb(224, 224, 224);
            m_searchResultGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            m_searchResultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            m_searchResultGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(96, 175, 197);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            m_searchResultGridView.DefaultCellStyle = dataGridViewCellStyle3;
            m_searchResultGridView.Location = new Point(17, 98);
            m_searchResultGridView.MultiSelect = false;
            m_searchResultGridView.Name = "m_searchResultGridView";
            m_searchResultGridView.ReadOnly = true;
            m_searchResultGridView.RowHeadersWidth = 51;
            m_searchResultGridView.RowTemplate.Height = 24;
            m_searchResultGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_searchResultGridView.Size = new Size(1098, 555);
            m_searchResultGridView.TabIndex = 8;
            // 
            // m_searchTextBox
            // 
            m_searchTextBox.Location = new Point(17, 45);
            m_searchTextBox.Margin = new Padding(4, 5, 4, 5);
            m_searchTextBox.Name = "m_searchTextBox";
            m_searchTextBox.Size = new Size(197, 27);
            m_searchTextBox.TabIndex = 37;
            // 
            // m_stateReleasedCheckBox
            // 
            m_stateReleasedCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_stateReleasedCheckBox.AutoSize = true;
            m_stateReleasedCheckBox.Location = new Point(1121, 142);
            m_stateReleasedCheckBox.Name = "m_stateReleasedCheckBox";
            m_stateReleasedCheckBox.Size = new Size(91, 24);
            m_stateReleasedCheckBox.TabIndex = 36;
            m_stateReleasedCheckBox.Text = "Released";
            m_stateReleasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_structureRootCheckBox
            // 
            m_structureRootCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_structureRootCheckBox.AutoSize = true;
            m_structureRootCheckBox.Location = new Point(1121, 305);
            m_structureRootCheckBox.Name = "m_structureRootCheckBox";
            m_structureRootCheckBox.Size = new Size(63, 24);
            m_structureRootCheckBox.TabIndex = 35;
            m_structureRootCheckBox.Text = "Root";
            m_structureRootCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_structureLeafCheckBox
            // 
            m_structureLeafCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_structureLeafCheckBox.AutoSize = true;
            m_structureLeafCheckBox.Location = new Point(1121, 266);
            m_structureLeafCheckBox.Name = "m_structureLeafCheckBox";
            m_structureLeafCheckBox.Size = new Size(59, 24);
            m_structureLeafCheckBox.TabIndex = 34;
            m_structureLeafCheckBox.Text = "Leaf";
            m_structureLeafCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_structureStandaloneCheckBox
            // 
            m_structureStandaloneCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_structureStandaloneCheckBox.AutoSize = true;
            m_structureStandaloneCheckBox.Location = new Point(1121, 226);
            m_structureStandaloneCheckBox.Name = "m_structureStandaloneCheckBox";
            m_structureStandaloneCheckBox.Size = new Size(106, 24);
            m_structureStandaloneCheckBox.TabIndex = 33;
            m_structureStandaloneCheckBox.Text = "Standalone";
            m_structureStandaloneCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_structureIntermediateCheckBox
            // 
            m_structureIntermediateCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_structureIntermediateCheckBox.AutoSize = true;
            m_structureIntermediateCheckBox.Location = new Point(1121, 184);
            m_structureIntermediateCheckBox.Name = "m_structureIntermediateCheckBox";
            m_structureIntermediateCheckBox.Size = new Size(116, 24);
            m_structureIntermediateCheckBox.TabIndex = 32;
            m_structureIntermediateCheckBox.Text = "Intermediate";
            m_structureIntermediateCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_typeComboBox
            // 
            m_typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            m_typeComboBox.FormattingEnabled = true;
            m_typeComboBox.Location = new Point(284, 45);
            m_typeComboBox.Name = "m_typeComboBox";
            m_typeComboBox.Size = new Size(177, 28);
            m_typeComboBox.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 14);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 30;
            label2.Text = "Type :";
            // 
            // m_dateAttributeComboBox
            // 
            m_dateAttributeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            m_dateAttributeComboBox.FormattingEnabled = true;
            m_dateAttributeComboBox.Location = new Point(520, 44);
            m_dateAttributeComboBox.Name = "m_dateAttributeComboBox";
            m_dateAttributeComboBox.Size = new Size(162, 28);
            m_dateAttributeComboBox.TabIndex = 29;
            m_dateAttributeComboBox.Click += m_dateAttributeComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(520, 14);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 28;
            label1.Text = "Search By :";
            // 
            // m_searchButton
            // 
            m_searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_searchButton.BackColor = Color.FromArgb(96, 175, 197);
            m_searchButton.FlatAppearance.BorderSize = 0;
            m_searchButton.FlatStyle = FlatStyle.Flat;
            m_searchButton.Location = new Point(1121, 31);
            m_searchButton.Name = "m_searchButton";
            m_searchButton.Size = new Size(105, 42);
            m_searchButton.TabIndex = 27;
            m_searchButton.Text = "Search";
            m_searchButton.UseVisualStyleBackColor = false;
            m_searchButton.Click += m_searchButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(17, 14);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(49, 20);
            titleLabel.TabIndex = 38;
            titleLabel.Text = "Title : ";
            // 
            // totalLabel
            // 
            totalLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(1121, 438);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(53, 20);
            totalLabel.TabIndex = 39;
            totalLabel.Text = "Total : ";
            // 
            // m_countLabel
            // 
            m_countLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_countLabel.AutoSize = true;
            m_countLabel.Location = new Point(1180, 438);
            m_countLabel.MaximumSize = new Size(100, 0);
            m_countLabel.Name = "m_countLabel";
            m_countLabel.Size = new Size(15, 20);
            m_countLabel.TabIndex = 40;
            m_countLabel.Text = "-";
            m_countLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // m_searchStrValue
            // 
            m_searchStrValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_searchStrValue.AutoSize = true;
            m_searchStrValue.Location = new Point(1132, 523);
            m_searchStrValue.MaximumSize = new Size(100, 0);
            m_searchStrValue.Name = "m_searchStrValue";
            m_searchStrValue.Size = new Size(15, 20);
            m_searchStrValue.TabIndex = 42;
            m_searchStrValue.Text = "-";
            // 
            // searchFilter
            // 
            searchFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            searchFilter.AutoSize = true;
            searchFilter.Location = new Point(1121, 488);
            searchFilter.Name = "searchFilter";
            searchFilter.Size = new Size(49, 20);
            searchFilter.TabIndex = 41;
            searchFilter.Text = "Filter :";
            // 
            // m_dateTimePicker
            // 
            m_dateTimePicker.Location = new Point(778, 43);
            m_dateTimePicker.Name = "m_dateTimePicker";
            m_dateTimePicker.Size = new Size(198, 27);
            m_dateTimePicker.TabIndex = 43;
            // 
            // EngineeringItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1238, 665);
            Controls.Add(m_searchStrValue);
            Controls.Add(searchFilter);
            Controls.Add(m_dateTimePicker);
            Controls.Add(m_countLabel);
            Controls.Add(totalLabel);
            Controls.Add(titleLabel);
            Controls.Add(m_searchTextBox);
            Controls.Add(m_stateReleasedCheckBox);
            Controls.Add(m_structureRootCheckBox);
            Controls.Add(m_structureLeafCheckBox);
            Controls.Add(m_structureStandaloneCheckBox);
            Controls.Add(m_structureIntermediateCheckBox);
            Controls.Add(m_typeComboBox);
            Controls.Add(label2);
            Controls.Add(m_dateAttributeComboBox);
            Controls.Add(label1);
            Controls.Add(m_searchButton);
            Controls.Add(m_searchResultGridView);
            Name = "EngineeringItemForm";
            Text = "EngineeringItemForm";
            Load += EngineeringItemForm_Load;
            ((System.ComponentModel.ISupportInitialize)m_searchResultGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView m_searchResultGridView;
        private TextBox m_searchTextBox;
        private CheckBox m_stateReleasedCheckBox;
        private CheckBox m_structureRootCheckBox;
        private CheckBox m_structureLeafCheckBox;
        private CheckBox m_structureStandaloneCheckBox;
        private CheckBox m_structureIntermediateCheckBox;
        private ComboBox m_typeComboBox;
        private Label label2;
        private ComboBox m_dateAttributeComboBox;
        private Label label1;
        private Button m_searchButton;
        private Label titleLabel;
        private Label totalLabel;
        private Label m_countLabel;
        private Label m_searchStrValue;
        private Label searchFilter;
        private DateTimePicker m_dateTimePicker;
    }
}