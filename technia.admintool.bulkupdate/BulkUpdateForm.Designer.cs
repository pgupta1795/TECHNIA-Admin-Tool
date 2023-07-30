namespace technia.admintool.bulkupdate
{
    partial class BulkUpdateForm
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
            topPanel = new Panel();
            UpdateButton = new Button();
            Path = new Label();
            filePathTextbox = new TextBox();
            BrowseButton = new Button();
            m_searchResultGridView = new DataGridView();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_searchResultGridView).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(UpdateButton);
            topPanel.Controls.Add(Path);
            topPanel.Controls.Add(filePathTextbox);
            topPanel.Controls.Add(BrowseButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1215, 56);
            topPanel.TabIndex = 1;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateButton.BackColor = Color.FromArgb(96, 175, 197);
            UpdateButton.Cursor = Cursors.No;
            UpdateButton.Enabled = false;
            UpdateButton.FlatAppearance.BorderSize = 0;
            UpdateButton.FlatStyle = FlatStyle.Flat;
            UpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateButton.Location = new Point(1132, 12);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(71, 27);
            UpdateButton.TabIndex = 4;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = false;
            UpdateButton.Click += UpdateButton_ClickAsync;
            // 
            // Path
            // 
            Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Path.AutoSize = true;
            Path.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Path.Location = new Point(595, 15);
            Path.Name = "Path";
            Path.Size = new Size(48, 20);
            Path.TabIndex = 3;
            Path.Text = "Path : ";
            // 
            // filePathTextbox
            // 
            filePathTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filePathTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            filePathTextbox.Location = new Point(649, 12);
            filePathTextbox.Name = "filePathTextbox";
            filePathTextbox.Size = new Size(372, 27);
            filePathTextbox.TabIndex = 2;
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseButton.BackColor = Color.FromArgb(96, 175, 197);
            BrowseButton.FlatAppearance.BorderSize = 0;
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BrowseButton.Location = new Point(1041, 12);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(71, 27);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = false;
            BrowseButton.Click += BrowseButton_Click;
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
            m_searchResultGridView.Location = new Point(3, 62);
            m_searchResultGridView.MultiSelect = false;
            m_searchResultGridView.Name = "m_searchResultGridView";
            m_searchResultGridView.ReadOnly = true;
            m_searchResultGridView.RowHeadersWidth = 51;
            m_searchResultGridView.RowTemplate.Height = 24;
            m_searchResultGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_searchResultGridView.Size = new Size(1200, 566);
            m_searchResultGridView.TabIndex = 9;
            // 
            // BulkUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 640);
            Controls.Add(topPanel);
            Controls.Add(m_searchResultGridView);
            Name = "BulkUpdateForm";
            Text = "BulkUpdateForm";
            Load += BulkUpdateForm_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)m_searchResultGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel topPanel;
        private Button BrowseButton;
        private TextBox filePathTextbox;
        private Label Path;
        private DataGridView m_searchResultGridView;
        private Button UpdateButton;
    }
}