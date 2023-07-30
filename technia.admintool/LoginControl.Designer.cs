namespace technia.admintool
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginDialogButton = new Button();
            SuspendLayout();
            // 
            // loginDialogButton
            // 
            loginDialogButton.BackColor = Color.FromArgb(96, 175, 197);
            loginDialogButton.Dock = DockStyle.Fill;
            loginDialogButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            loginDialogButton.Location = new Point(0, 0);
            loginDialogButton.Name = "loginDialogButton";
            loginDialogButton.Size = new Size(200, 60);
            loginDialogButton.TabIndex = 0;
            loginDialogButton.Text = "Login";
            loginDialogButton.UseVisualStyleBackColor = false;
            loginDialogButton.Click += loginDialogButton_Click;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(loginDialogButton);
            Name = "LoginControl";
            Size = new Size(200, 60);
            ResumeLayout(false);
        }

        #endregion

        private Button loginDialogButton;
    }
}
