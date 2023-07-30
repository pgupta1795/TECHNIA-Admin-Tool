namespace technia.admintool
{
    partial class HomeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            panelMainMenu = new Panel();
            panelLoginTitle = new Panel();
            homeTitle = new Label();
            documentsButton = new Button();
            engineeringButton = new Button();
            loginControl1 = new LoginControl();
            searchButton = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            imageList1 = new ImageList(components);
            panelDesktopPane = new Panel();
            panelMainMenu.SuspendLayout();
            panelLoginTitle.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelMainMenu
            // 
            panelMainMenu.BackColor = Color.White;
            panelMainMenu.Controls.Add(panelLoginTitle);
            panelMainMenu.Controls.Add(documentsButton);
            panelMainMenu.Controls.Add(engineeringButton);
            panelMainMenu.Controls.Add(loginControl1);
            panelMainMenu.Controls.Add(searchButton);
            panelMainMenu.Controls.Add(panelLogo);
            panelMainMenu.Dock = DockStyle.Left;
            panelMainMenu.Location = new Point(0, 0);
            panelMainMenu.Name = "panelMainMenu";
            panelMainMenu.Size = new Size(200, 707);
            panelMainMenu.TabIndex = 0;
            // 
            // panelLoginTitle
            // 
            panelLoginTitle.BackColor = Color.White;
            panelLoginTitle.Controls.Add(homeTitle);
            panelLoginTitle.Dock = DockStyle.Fill;
            panelLoginTitle.Location = new Point(0, 250);
            panelLoginTitle.Name = "panelLoginTitle";
            panelLoginTitle.Size = new Size(200, 382);
            panelLoginTitle.TabIndex = 1;
            panelLoginTitle.MouseDown += panelLoginTitle_MouseDown;
            // 
            // homeTitle
            // 
            homeTitle.AutoSize = true;
            homeTitle.BackColor = Color.White;
            homeTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            homeTitle.ForeColor = Color.Black;
            homeTitle.Location = new Point(12, 299);
            homeTitle.MaximumSize = new Size(180, 0);
            homeTitle.Name = "homeTitle";
            homeTitle.Size = new Size(15, 20);
            homeTitle.TabIndex = 0;
            homeTitle.Text = "-";
            // 
            // documentsButton
            // 
            documentsButton.Dock = DockStyle.Top;
            documentsButton.FlatAppearance.BorderSize = 0;
            documentsButton.FlatStyle = FlatStyle.Flat;
            documentsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            documentsButton.ForeColor = Color.FromArgb(56, 114, 140);
            documentsButton.Image = Properties.Resources.Documents;
            documentsButton.ImageAlign = ContentAlignment.MiddleLeft;
            documentsButton.Location = new Point(0, 200);
            documentsButton.Name = "documentsButton";
            documentsButton.Size = new Size(200, 50);
            documentsButton.TabIndex = 7;
            documentsButton.Text = "Documents";
            documentsButton.TextAlign = ContentAlignment.MiddleRight;
            documentsButton.UseVisualStyleBackColor = true;
            documentsButton.Click += documentsButton_Click;
            // 
            // engineeringButton
            // 
            engineeringButton.BackColor = Color.White;
            engineeringButton.Dock = DockStyle.Top;
            engineeringButton.FlatAppearance.BorderSize = 0;
            engineeringButton.FlatStyle = FlatStyle.Flat;
            engineeringButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            engineeringButton.ForeColor = Color.FromArgb(56, 114, 140);
            engineeringButton.Image = Properties.Resources.ProductsSearch;
            engineeringButton.ImageAlign = ContentAlignment.MiddleLeft;
            engineeringButton.Location = new Point(0, 150);
            engineeringButton.Name = "engineeringButton";
            engineeringButton.Size = new Size(200, 50);
            engineeringButton.TabIndex = 6;
            engineeringButton.Text = "Products";
            engineeringButton.TextAlign = ContentAlignment.MiddleRight;
            engineeringButton.UseVisualStyleBackColor = false;
            engineeringButton.Click += engineeringButton_Click;
            // 
            // loginControl1
            // 
            loginControl1.Dock = DockStyle.Bottom;
            loginControl1.ForeColor = Color.White;
            loginControl1.Location = new Point(0, 632);
            loginControl1.Name = "loginControl1";
            loginControl1.Size = new Size(200, 75);
            loginControl1.TabIndex = 5;
            // 
            // searchButton
            // 
            searchButton.Dock = DockStyle.Top;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            searchButton.ForeColor = Color.FromArgb(56, 114, 140);
            searchButton.Image = Properties.Resources.Import;
            searchButton.ImageAlign = ContentAlignment.MiddleLeft;
            searchButton.Location = new Point(0, 100);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(200, 50);
            searchButton.TabIndex = 4;
            searchButton.Text = "Bulk Update";
            searchButton.TextAlign = ContentAlignment.MiddleRight;
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.ForeColor = Color.White;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 100);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.TECHNIA_Addnode;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.BackColor = SystemColors.Control;
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Location = new Point(200, 0);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(970, 707);
            panelDesktopPane.TabIndex = 2;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 707);
            Controls.Add(panelDesktopPane);
            Controls.Add(panelMainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 600);
            Name = "HomeForm";
            Text = "TECHNIA Admin Tool";
            Load += HomeForm_Load;
            panelMainMenu.ResumeLayout(false);
            panelLoginTitle.ResumeLayout(false);
            panelLoginTitle.PerformLayout();
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainMenu;
        private Panel panelLogo;
        private Panel panelLoginTitle;
        private Label homeTitle;
        private ImageList imageList1;
        private Panel panelDesktopPane;
        private Button searchButton;
        private PictureBox pictureBox1;
        private LoginControl loginControl1;
        private Button documentsButton;
        private Button engineeringButton;
    }
}