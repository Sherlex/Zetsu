namespace Zetsu
{
    partial class AuthorizationForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.CancelBbutton = new System.Windows.Forms.Button();
            this.entryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hidePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(106, 69);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(163, 20);
            this.passwordTextBox.TabIndex = 25;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(106, 30);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(163, 20);
            this.loginTextBox.TabIndex = 24;
            // 
            // CancelBbutton
            // 
            this.CancelBbutton.Location = new System.Drawing.Point(192, 141);
            this.CancelBbutton.Name = "CancelBbutton";
            this.CancelBbutton.Size = new System.Drawing.Size(75, 23);
            this.CancelBbutton.TabIndex = 23;
            this.CancelBbutton.Text = "Cancel";
            this.CancelBbutton.UseVisualStyleBackColor = true;
            this.CancelBbutton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(51, 141);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(75, 23);
            this.entryButton.TabIndex = 22;
            this.entryButton.Text = "Entry";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.Entry_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Login";
            // 
            // hidePasswordCheckBox
            // 
            this.hidePasswordCheckBox.AutoSize = true;
            this.hidePasswordCheckBox.Checked = true;
            this.hidePasswordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidePasswordCheckBox.Location = new System.Drawing.Point(106, 107);
            this.hidePasswordCheckBox.Name = "hidePasswordCheckBox";
            this.hidePasswordCheckBox.Size = new System.Drawing.Size(96, 17);
            this.hidePasswordCheckBox.TabIndex = 26;
            this.hidePasswordCheckBox.Text = "Hide password";
            this.hidePasswordCheckBox.UseVisualStyleBackColor = true;
            this.hidePasswordCheckBox.CheckedChanged += new System.EventHandler(this.HidePasswordCheckBox_CheckedChanged);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 189);
            this.Controls.Add(this.hidePasswordCheckBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.CancelBbutton);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Button CancelBbutton;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox hidePasswordCheckBox;
    }
}