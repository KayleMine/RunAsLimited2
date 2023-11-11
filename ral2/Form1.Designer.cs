namespace ral2
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Login = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.Password = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.Create = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.Remove = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.Run = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.PathBox = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.Command_Line = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.Select_App = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.siticoneRoundedButton1 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.rd_Party = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.third_check = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Login.DefaultText = "";
            this.Login.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Login.DisabledState.Parent = this.Login;
            this.Login.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Login.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Login.FocusedState.Parent = this.Login;
            this.Login.ForeColor = System.Drawing.Color.DimGray;
            this.Login.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Login.HoveredState.Parent = this.Login;
            this.Login.Location = new System.Drawing.Point(17, 103);
            this.Login.Name = "Login";
            this.Login.PasswordChar = '\0';
            this.Login.PlaceholderText = "Login";
            this.Login.SelectedText = "";
            this.Login.ShadowDecoration.Parent = this.Login;
            this.Login.Size = new System.Drawing.Size(342, 36);
            this.Login.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.DefaultText = "";
            this.Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.DisabledState.Parent = this.Password;
            this.Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.FocusedState.Parent = this.Password;
            this.Password.ForeColor = System.Drawing.Color.DimGray;
            this.Password.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.HoveredState.Parent = this.Password;
            this.Password.Location = new System.Drawing.Point(17, 145);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '\0';
            this.Password.PlaceholderText = "Password";
            this.Password.SelectedText = "";
            this.Password.ShadowDecoration.Parent = this.Password;
            this.Password.Size = new System.Drawing.Size(342, 36);
            this.Password.TabIndex = 2;
            // 
            // Create
            // 
            this.Create.CheckedState.Parent = this.Create;
            this.Create.CustomImages.Parent = this.Create;
            this.Create.FillColor = System.Drawing.Color.Green;
            this.Create.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Create.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Create.HoveredState.Parent = this.Create;
            this.Create.Location = new System.Drawing.Point(365, 103);
            this.Create.Name = "Create";
            this.Create.ShadowDecoration.Parent = this.Create;
            this.Create.Size = new System.Drawing.Size(99, 36);
            this.Create.TabIndex = 3;
            this.Create.Text = "Create";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.SystemColors.Control;
            this.Remove.CheckedState.Parent = this.Remove;
            this.Remove.CustomImages.Parent = this.Remove;
            this.Remove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Remove.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Remove.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Remove.HoveredState.Parent = this.Remove;
            this.Remove.Location = new System.Drawing.Point(365, 145);
            this.Remove.Name = "Remove";
            this.Remove.ShadowDecoration.Parent = this.Remove;
            this.Remove.Size = new System.Drawing.Size(99, 36);
            this.Remove.TabIndex = 4;
            this.Remove.Text = "Remove";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Run
            // 
            this.Run.CheckedState.Parent = this.Run;
            this.Run.CustomImages.Parent = this.Run;
            this.Run.FillColor = System.Drawing.Color.Green;
            this.Run.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Run.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Run.HoveredState.Parent = this.Run;
            this.Run.Location = new System.Drawing.Point(17, 194);
            this.Run.Name = "Run";
            this.Run.ShadowDecoration.Parent = this.Run;
            this.Run.Size = new System.Drawing.Size(247, 47);
            this.Run.TabIndex = 5;
            this.Run.Text = "Run";
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // PathBox
            // 
            this.PathBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PathBox.DefaultText = "";
            this.PathBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PathBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PathBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PathBox.DisabledState.Parent = this.PathBox;
            this.PathBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PathBox.Enabled = false;
            this.PathBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PathBox.FocusedState.Parent = this.PathBox;
            this.PathBox.ForeColor = System.Drawing.Color.DimGray;
            this.PathBox.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PathBox.HoveredState.Parent = this.PathBox;
            this.PathBox.Location = new System.Drawing.Point(17, 12);
            this.PathBox.Name = "PathBox";
            this.PathBox.PasswordChar = '\0';
            this.PathBox.PlaceholderText = "Path to application appear here.";
            this.PathBox.SelectedText = "";
            this.PathBox.ShadowDecoration.Parent = this.PathBox;
            this.PathBox.Size = new System.Drawing.Size(342, 36);
            this.PathBox.TabIndex = 6;
            // 
            // Command_Line
            // 
            this.Command_Line.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Command_Line.DefaultText = "";
            this.Command_Line.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Command_Line.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Command_Line.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Command_Line.DisabledState.Parent = this.Command_Line;
            this.Command_Line.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Command_Line.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Command_Line.FocusedState.Parent = this.Command_Line;
            this.Command_Line.ForeColor = System.Drawing.Color.DimGray;
            this.Command_Line.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Command_Line.HoveredState.Parent = this.Command_Line;
            this.Command_Line.Location = new System.Drawing.Point(17, 54);
            this.Command_Line.Name = "Command_Line";
            this.Command_Line.PasswordChar = '\0';
            this.Command_Line.PlaceholderText = "Command Line";
            this.Command_Line.SelectedText = "";
            this.Command_Line.ShadowDecoration.Parent = this.Command_Line;
            this.Command_Line.Size = new System.Drawing.Size(342, 36);
            this.Command_Line.TabIndex = 7;
            // 
            // Select_App
            // 
            this.Select_App.CheckedState.Parent = this.Select_App;
            this.Select_App.CustomImages.Parent = this.Select_App;
            this.Select_App.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Select_App.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Select_App.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Select_App.HoveredState.Parent = this.Select_App;
            this.Select_App.Location = new System.Drawing.Point(365, 12);
            this.Select_App.Name = "Select_App";
            this.Select_App.ShadowDecoration.Parent = this.Select_App;
            this.Select_App.Size = new System.Drawing.Size(99, 36);
            this.Select_App.TabIndex = 8;
            this.Select_App.Text = "Select App";
            this.Select_App.Click += new System.EventHandler(this.Select_App_Click);
            // 
            // siticoneRoundedButton1
            // 
            this.siticoneRoundedButton1.CheckedState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.CustomImages.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.siticoneRoundedButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.siticoneRoundedButton1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.siticoneRoundedButton1.HoveredState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Location = new System.Drawing.Point(365, 54);
            this.siticoneRoundedButton1.Name = "siticoneRoundedButton1";
            this.siticoneRoundedButton1.ShadowDecoration.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Size = new System.Drawing.Size(99, 36);
            this.siticoneRoundedButton1.TabIndex = 9;
            this.siticoneRoundedButton1.Text = "User folder";
            this.siticoneRoundedButton1.Click += new System.EventHandler(this.siticoneRoundedButton1_Click);
            // 
            // rd_Party
            // 
            this.rd_Party.CheckedState.Parent = this.rd_Party;
            this.rd_Party.CustomImages.Parent = this.rd_Party;
            this.rd_Party.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rd_Party.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.rd_Party.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rd_Party.HoveredState.Parent = this.rd_Party;
            this.rd_Party.Location = new System.Drawing.Point(270, 194);
            this.rd_Party.Name = "rd_Party";
            this.rd_Party.ShadowDecoration.Parent = this.rd_Party;
            this.rd_Party.Size = new System.Drawing.Size(89, 47);
            this.rd_Party.TabIndex = 10;
            this.rd_Party.Text = "3rd Party";
            this.rd_Party.Click += new System.EventHandler(this.rd_Party_Click);
            // 
            // third_check
            // 
            this.third_check.AutoSize = true;
            this.third_check.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.third_check.CheckedState.BorderRadius = 2;
            this.third_check.CheckedState.BorderThickness = 0;
            this.third_check.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.third_check.Location = new System.Drawing.Point(10, 19);
            this.third_check.Name = "third_check";
            this.third_check.Size = new System.Drawing.Size(65, 17);
            this.third_check.TabIndex = 11;
            this.third_check.Text = "On \\ Off";
            this.third_check.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.third_check.UncheckedState.BorderRadius = 2;
            this.third_check.UncheckedState.BorderThickness = 0;
            this.third_check.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.third_check.UseVisualStyleBackColor = true;
            this.third_check.CheckedChanged += new System.EventHandler(this.third_check_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.third_check);
            this.groupBox1.Location = new System.Drawing.Point(365, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 47);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toggle 3rd party";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 253);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rd_Party);
            this.Controls.Add(this.siticoneRoundedButton1);
            this.Controls.Add(this.Select_App);
            this.Controls.Add(this.Command_Line);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run As Limited";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.UI.WinForms.SiticoneRoundedTextBox Login;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox Password;
        private Siticone.UI.WinForms.SiticoneRoundedButton Create;
        private Siticone.UI.WinForms.SiticoneRoundedButton Remove;
        private Siticone.UI.WinForms.SiticoneRoundedButton Run;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox PathBox;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox Command_Line;
        private Siticone.UI.WinForms.SiticoneRoundedButton Select_App;
        private Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton1;
        private Siticone.UI.WinForms.SiticoneRoundedButton rd_Party;
        private Siticone.UI.WinForms.SiticoneCheckBox third_check;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

