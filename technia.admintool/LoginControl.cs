using ds.authentication;
using ds.authentication.ui.win;
using technia.admintool.settings;

namespace technia.admintool
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void loginDialogButton_Click(object sender, EventArgs e)
        {
            object btn = (sender as Button).Parent;
            object homeForm = (btn as LoginControl).ParentForm;
            AuthenticationSelectionForm authSelectionForm = new AuthenticationSelectionForm();
            var isAuthenticated = PerformAuthentication(authSelectionForm, (homeForm as HomeForm));
            Logger.Info($"Authenticated to 3DExpeirence {(isAuthenticated ? "successfully done" : "failed")}");
            if (!isAuthenticated) return;
            (homeForm as HomeForm)?.EnableMenuButtons();
        }

        #region login authentication

        private bool PerformAuthentication(AuthenticationSelectionForm authSelectionForm, HomeForm homeForm)
        {
            homeForm.Passport = null;
            homeForm.authInfo = null;

            if (authSelectionForm.ShowDialog(this) != DialogResult.OK) return false;
            IAuthenticationType authenticationType = authSelectionForm.SelectedAuthenticationType;

            if (authenticationType.ShowForm(this) != DialogResult.OK) return false;
            homeForm.authInfo = authenticationType.GetAuthenticationInfo();

            if (!homeForm.authInfo.IsValidAuthentication) return false;
            homeForm.Passport = homeForm.authInfo.Passport;
            Logger.Info($"Auth Info is : {homeForm.authInfo.ToString()}");
            return true;
        }

        #endregion
    }
}
