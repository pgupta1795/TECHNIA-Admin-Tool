using ds.authentication;
using System.Runtime.InteropServices;
using technia.admintool.bulkupdate;
using technia.admintool.documents;
using technia.admintool.engineeringitems;
using technia.admintool.settings;

namespace technia.admintool
{
    public partial class HomeForm : Form
    {

        //Fields 
        private Button _currentButton;

        public IPassportAuthentication Passport { get; set; }

        public AuthenticationInfo authInfo { get; set; }

        public HomeForm()
        {
            InitializeComponent();
            Logger.Info($"**********************************************************");
            Logger.Info($"************* Technia Admin Tool Started *****************");
            Logger.Info($"**********************************************************");
            DisableMenuButtons();
            /*
            const Primary primaryColor = (Primary)6336453; // #60afc5; 96, 175, 197
            const Primary primaryDarkColor = (Primary)3699340; // #38728c; 56,114,140
            const Primary primLightColor = (Primary)9029853; //#89c8dd; 137,200,221
            */
        }

        #region Open Child Form

        private void ActivateButton(object btnSender)
        {
            if (_currentButton != (Button)btnSender)
            {
                DisableButton();
                Color color = ColorTranslator.FromHtml("#60afc5");
                _currentButton = (Button)btnSender;
                _currentButton.BackColor = SystemColors.Control;
                _currentButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMainMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            ActivateButton(btnSender);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            var formName = ((System.Windows.Forms.ButtonBase)btnSender).Text;
            Logger.Info($"Form {formName} Opened");
        }

        #endregion

        #region Menu Click Events

        private void engineeringButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Engineering Button Clicked");
            OpenChildForm(new EngineeringItemForm(Passport, authInfo), sender);
        }

        private void documentsButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Document Button Clicked");
            OpenChildForm(new DocumentsForm(), sender);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Search Button Clicked");
            OpenChildForm(new BulkUpdateForm(Passport, authInfo), sender);
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            Logger.Info("TECHNIA Admin Tool Loaded");
        }
        #endregion

        #region Other Events
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelLoginTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Enable/Disble Menu Buttons

        public void EnableMenuButtons()
        {
            searchButton.Enabled = true;
            engineeringButton.Enabled = true;
            documentsButton.Enabled = true;
            searchButton.PerformClick();
            homeTitle.Text = authInfo.LoginMessage;
            Logger.Info("Enabled Menu Buttons");
        }

        public void DisableMenuButtons()
        {
            //searchButton.Enabled = false;
            engineeringButton.Enabled = false;
            documentsButton.Enabled = false;
        }

        #endregion
    }
}
