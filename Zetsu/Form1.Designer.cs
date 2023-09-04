namespace Zetsu
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lengthTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.lowercaseCheckBox = new System.Windows.Forms.CheckBox();
            this.specialsCheckBox = new System.Windows.Forms.CheckBox();
            this.numbersCheckBox = new System.Windows.Forms.CheckBox();
            this.uppercaseCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.strength2Label = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hidePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.spyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(298, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // spyToolStripMenuItem
            // 
            this.spyToolStripMenuItem.Name = "spyToolStripMenuItem";
            this.spyToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.spyToolStripMenuItem.Text = "Spy";
            this.spyToolStripMenuItem.Click += new System.EventHandler(this.SpyToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Use in password:";
            // 
            // lengthTrackBar
            // 
            this.lengthTrackBar.Location = new System.Drawing.Point(12, 162);
            this.lengthTrackBar.Maximum = 20;
            this.lengthTrackBar.Minimum = 8;
            this.lengthTrackBar.Name = "lengthTrackBar";
            this.lengthTrackBar.Size = new System.Drawing.Size(272, 45);
            this.lengthTrackBar.TabIndex = 4;
            this.lengthTrackBar.Value = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password length:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(14, 281);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(267, 20);
            this.passwordTextBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.passwordTextBox, "Entry password for checking");
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(97, 222);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(102, 38);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generate!";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.Location = new System.Drawing.Point(28, 374);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(0, 13);
            this.strengthLabel.TabIndex = 7;
            // 
            // lowercaseCheckBox
            // 
            this.lowercaseCheckBox.AutoSize = true;
            this.lowercaseCheckBox.Location = new System.Drawing.Point(172, 73);
            this.lowercaseCheckBox.Name = "lowercaseCheckBox";
            this.lowercaseCheckBox.Size = new System.Drawing.Size(109, 17);
            this.lowercaseCheckBox.TabIndex = 8;
            this.lowercaseCheckBox.Text = "Lowercase letters";
            this.lowercaseCheckBox.UseVisualStyleBackColor = true;
            this.lowercaseCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // specialsCheckBox
            // 
            this.specialsCheckBox.AutoSize = true;
            this.specialsCheckBox.Location = new System.Drawing.Point(31, 96);
            this.specialsCheckBox.Name = "specialsCheckBox";
            this.specialsCheckBox.Size = new System.Drawing.Size(66, 17);
            this.specialsCheckBox.TabIndex = 8;
            this.specialsCheckBox.Text = "Specials";
            this.specialsCheckBox.UseVisualStyleBackColor = true;
            this.specialsCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // numbersCheckBox
            // 
            this.numbersCheckBox.AutoSize = true;
            this.numbersCheckBox.Checked = true;
            this.numbersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numbersCheckBox.Location = new System.Drawing.Point(31, 73);
            this.numbersCheckBox.Name = "numbersCheckBox";
            this.numbersCheckBox.Size = new System.Drawing.Size(68, 17);
            this.numbersCheckBox.TabIndex = 8;
            this.numbersCheckBox.Text = "Numbers";
            this.numbersCheckBox.UseVisualStyleBackColor = true;
            this.numbersCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // uppercaseCheckBox
            // 
            this.uppercaseCheckBox.AutoSize = true;
            this.uppercaseCheckBox.Location = new System.Drawing.Point(172, 96);
            this.uppercaseCheckBox.Name = "uppercaseCheckBox";
            this.uppercaseCheckBox.Size = new System.Drawing.Size(109, 17);
            this.uppercaseCheckBox.TabIndex = 8;
            this.uppercaseCheckBox.Text = "Uppercase letters";
            this.uppercaseCheckBox.UseVisualStyleBackColor = true;
            this.uppercaseCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "8    9    10   11   12   13   14   15   16   17   18   19   20";
            // 
            // strength2Label
            // 
            this.strength2Label.AutoSize = true;
            this.strength2Label.Location = new System.Drawing.Point(28, 401);
            this.strength2Label.Name = "strength2Label";
            this.strength2Label.Size = new System.Drawing.Size(0, 13);
            this.strength2Label.TabIndex = 7;
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(97, 320);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(102, 38);
            this.checkButton.TabIndex = 10;
            this.checkButton.Text = "Check!";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // hidePasswordCheckBox
            // 
            this.hidePasswordCheckBox.AutoSize = true;
            this.hidePasswordCheckBox.Checked = true;
            this.hidePasswordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidePasswordCheckBox.Location = new System.Drawing.Point(12, 433);
            this.hidePasswordCheckBox.Name = "hidePasswordCheckBox";
            this.hidePasswordCheckBox.Size = new System.Drawing.Size(96, 17);
            this.hidePasswordCheckBox.TabIndex = 8;
            this.hidePasswordCheckBox.Text = "Hide password";
            this.hidePasswordCheckBox.UseVisualStyleBackColor = true;
            this.hidePasswordCheckBox.CheckedChanged += new System.EventHandler(this.HidePasswordCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 462);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uppercaseCheckBox);
            this.Controls.Add(this.hidePasswordCheckBox);
            this.Controls.Add(this.numbersCheckBox);
            this.Controls.Add(this.specialsCheckBox);
            this.Controls.Add(this.lowercaseCheckBox);
            this.Controls.Add(this.strength2Label);
            this.Controls.Add(this.strengthLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.lengthTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Zetsu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spyToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar lengthTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.CheckBox lowercaseCheckBox;
        private System.Windows.Forms.CheckBox specialsCheckBox;
        private System.Windows.Forms.CheckBox numbersCheckBox;
        private System.Windows.Forms.CheckBox uppercaseCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label strength2Label;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox hidePasswordCheckBox;
    }
}

