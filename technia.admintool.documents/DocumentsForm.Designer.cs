namespace technia.admintool.documents
{
    partial class DocumentsForm
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
            button1 = new Button();
            domainUpDown1 = new DomainUpDown();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(383, 158);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(484, 286);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(150, 27);
            domainUpDown1.TabIndex = 0;
            domainUpDown1.Text = "domainUpDown1";
            // 
            // DocumentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(domainUpDown1);
            Controls.Add(button1);
            Name = "DocumentsForm";
            Text = "DocumentsForm";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DomainUpDown domainUpDown1;
    }
}