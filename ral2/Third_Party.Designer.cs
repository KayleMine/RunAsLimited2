namespace ral2
{
    partial class Third_Party
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Third_Party));
            this.path3_box = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.cmd3_box = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.select_path = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.delay = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.save_cfg = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.SuspendLayout();
            // 
            // path3_box
            // 
            this.path3_box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.path3_box.DefaultText = "";
            this.path3_box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.path3_box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.path3_box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.path3_box.DisabledState.Parent = this.path3_box;
            this.path3_box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.path3_box.Enabled = false;
            this.path3_box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.path3_box.FocusedState.Parent = this.path3_box;
            this.path3_box.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.path3_box.HoveredState.Parent = this.path3_box;
            this.path3_box.Location = new System.Drawing.Point(12, 12);
            this.path3_box.Name = "path3_box";
            this.path3_box.PasswordChar = '\0';
            this.path3_box.PlaceholderText = "Path to third party appear here";
            this.path3_box.SelectedText = "";
            this.path3_box.ShadowDecoration.Parent = this.path3_box;
            this.path3_box.Size = new System.Drawing.Size(338, 36);
            this.path3_box.TabIndex = 0;
            // 
            // cmd3_box
            // 
            this.cmd3_box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmd3_box.DefaultText = "";
            this.cmd3_box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cmd3_box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cmd3_box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmd3_box.DisabledState.Parent = this.cmd3_box;
            this.cmd3_box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmd3_box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmd3_box.FocusedState.Parent = this.cmd3_box;
            this.cmd3_box.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmd3_box.HoveredState.Parent = this.cmd3_box;
            this.cmd3_box.Location = new System.Drawing.Point(12, 54);
            this.cmd3_box.Name = "cmd3_box";
            this.cmd3_box.PasswordChar = '\0';
            this.cmd3_box.PlaceholderText = "Command line";
            this.cmd3_box.SelectedText = "";
            this.cmd3_box.ShadowDecoration.Parent = this.cmd3_box;
            this.cmd3_box.Size = new System.Drawing.Size(338, 36);
            this.cmd3_box.TabIndex = 1;
            // 
            // select_path
            // 
            this.select_path.CheckedState.Parent = this.select_path;
            this.select_path.CustomImages.Parent = this.select_path;
            this.select_path.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.select_path.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.select_path.ForeColor = System.Drawing.Color.White;
            this.select_path.HoveredState.Parent = this.select_path;
            this.select_path.Location = new System.Drawing.Point(12, 144);
            this.select_path.Name = "select_path";
            this.select_path.ShadowDecoration.Parent = this.select_path;
            this.select_path.Size = new System.Drawing.Size(169, 45);
            this.select_path.TabIndex = 2;
            this.select_path.Text = "Select App";
            this.select_path.Click += new System.EventHandler(this.select_path_Click);
            // 
            // delay
            // 
            this.delay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.delay.DefaultText = "";
            this.delay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.delay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.delay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.delay.DisabledState.Parent = this.delay;
            this.delay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.delay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.delay.FocusedState.Parent = this.delay;
            this.delay.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.delay.HoveredState.Parent = this.delay;
            this.delay.Location = new System.Drawing.Point(12, 96);
            this.delay.Name = "delay";
            this.delay.PasswordChar = '\0';
            this.delay.PlaceholderText = "Delay in ms";
            this.delay.SelectedText = "";
            this.delay.ShadowDecoration.Parent = this.delay;
            this.delay.Size = new System.Drawing.Size(338, 36);
            this.delay.TabIndex = 3;
            // 
            // save_cfg
            // 
            this.save_cfg.CheckedState.Parent = this.save_cfg;
            this.save_cfg.CustomImages.Parent = this.save_cfg;
            this.save_cfg.FillColor = System.Drawing.Color.Green;
            this.save_cfg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.save_cfg.ForeColor = System.Drawing.Color.White;
            this.save_cfg.HoveredState.Parent = this.save_cfg;
            this.save_cfg.Location = new System.Drawing.Point(181, 144);
            this.save_cfg.Name = "save_cfg";
            this.save_cfg.ShadowDecoration.Parent = this.save_cfg;
            this.save_cfg.Size = new System.Drawing.Size(169, 45);
            this.save_cfg.TabIndex = 4;
            this.save_cfg.Text = "Save";
            this.save_cfg.Click += new System.EventHandler(this.save_cfg_Click);
            // 
            // Third_Party
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 199);
            this.Controls.Add(this.save_cfg);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.select_path);
            this.Controls.Add(this.cmd3_box);
            this.Controls.Add(this.path3_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Third_Party";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Third party app!";
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticoneRoundedTextBox path3_box;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox cmd3_box;
        private Siticone.UI.WinForms.SiticoneRoundedButton select_path;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox delay;
        private Siticone.UI.WinForms.SiticoneRoundedButton save_cfg;
    }
}