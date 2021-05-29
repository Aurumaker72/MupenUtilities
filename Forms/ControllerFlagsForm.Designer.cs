
namespace MupenUtils.Forms
{
    partial class ControllerFlagsForm
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
            this.gp_Cflg_Flags = new System.Windows.Forms.GroupBox();
            this.chk_Cflg_Rumblepak = new System.Windows.Forms.CheckBox();
            this.chk_Cflg_Mempak = new System.Windows.Forms.CheckBox();
            this.chk_Cflg_Present = new System.Windows.Forms.CheckBox();
            this.cbox_Cflg_ControllerSelect = new System.Windows.Forms.ComboBox();
            this.gp_Cflg_Flags.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_Cflg_Flags
            // 
            this.gp_Cflg_Flags.Controls.Add(this.chk_Cflg_Rumblepak);
            this.gp_Cflg_Flags.Controls.Add(this.chk_Cflg_Mempak);
            this.gp_Cflg_Flags.Controls.Add(this.chk_Cflg_Present);
            this.gp_Cflg_Flags.Controls.Add(this.cbox_Cflg_ControllerSelect);
            this.gp_Cflg_Flags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Cflg_Flags.Location = new System.Drawing.Point(0, 0);
            this.gp_Cflg_Flags.Name = "gp_Cflg_Flags";
            this.gp_Cflg_Flags.Size = new System.Drawing.Size(261, 145);
            this.gp_Cflg_Flags.TabIndex = 0;
            this.gp_Cflg_Flags.TabStop = false;
            this.gp_Cflg_Flags.Text = "Controller Flags";
            // 
            // chk_Cflg_Rumblepak
            // 
            this.chk_Cflg_Rumblepak.AutoSize = true;
            this.chk_Cflg_Rumblepak.Location = new System.Drawing.Point(16, 104);
            this.chk_Cflg_Rumblepak.Name = "chk_Cflg_Rumblepak";
            this.chk_Cflg_Rumblepak.Size = new System.Drawing.Size(101, 21);
            this.chk_Cflg_Rumblepak.TabIndex = 2;
            this.chk_Cflg_Rumblepak.Text = "Rumblepak";
            this.chk_Cflg_Rumblepak.UseVisualStyleBackColor = true;
            this.chk_Cflg_Rumblepak.CheckedChanged += new System.EventHandler(this.chk_Cflg_Rumblepak_CheckedChanged);
            // 
            // chk_Cflg_Mempak
            // 
            this.chk_Cflg_Mempak.AutoSize = true;
            this.chk_Cflg_Mempak.Location = new System.Drawing.Point(16, 80);
            this.chk_Cflg_Mempak.Name = "chk_Cflg_Mempak";
            this.chk_Cflg_Mempak.Size = new System.Drawing.Size(83, 21);
            this.chk_Cflg_Mempak.TabIndex = 2;
            this.chk_Cflg_Mempak.Text = "Mempak";
            this.chk_Cflg_Mempak.UseVisualStyleBackColor = true;
            this.chk_Cflg_Mempak.CheckedChanged += new System.EventHandler(this.chk_Cflg_Mempak_CheckedChanged);
            // 
            // chk_Cflg_Present
            // 
            this.chk_Cflg_Present.AutoSize = true;
            this.chk_Cflg_Present.Location = new System.Drawing.Point(16, 56);
            this.chk_Cflg_Present.Name = "chk_Cflg_Present";
            this.chk_Cflg_Present.Size = new System.Drawing.Size(79, 21);
            this.chk_Cflg_Present.TabIndex = 2;
            this.chk_Cflg_Present.Text = "Present";
            this.chk_Cflg_Present.UseVisualStyleBackColor = true;
            this.chk_Cflg_Present.CheckedChanged += new System.EventHandler(this.chk_Cflg_Present_CheckedChanged);
            // 
            // cbox_Cflg_ControllerSelect
            // 
            this.cbox_Cflg_ControllerSelect.BackColor = System.Drawing.SystemColors.Window;
            this.cbox_Cflg_ControllerSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Cflg_ControllerSelect.FormattingEnabled = true;
            this.cbox_Cflg_ControllerSelect.Items.AddRange(new object[] {
            "Controller 1",
            "Controller 2",
            "Controller 3",
            "Controller 4"});
            this.cbox_Cflg_ControllerSelect.Location = new System.Drawing.Point(16, 24);
            this.cbox_Cflg_ControllerSelect.Name = "cbox_Cflg_ControllerSelect";
            this.cbox_Cflg_ControllerSelect.Size = new System.Drawing.Size(121, 24);
            this.cbox_Cflg_ControllerSelect.TabIndex = 0;
            this.cbox_Cflg_ControllerSelect.SelectedIndexChanged += new System.EventHandler(this.cbox_Cflg_ControllerSelect_SelectedIndexChanged);
            // 
            // ControllerFlagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(261, 145);
            this.Controls.Add(this.gp_Cflg_Flags);
            this.MaximizeBox = false;
            this.Name = "ControllerFlagsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControllerFlagsForm";
            this.Shown += new System.EventHandler(this.ControllerFlagsForm_Shown);
            this.gp_Cflg_Flags.ResumeLayout(false);
            this.gp_Cflg_Flags.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Cflg_Flags;
        private System.Windows.Forms.ComboBox cbox_Cflg_ControllerSelect;
        private System.Windows.Forms.CheckBox chk_Cflg_Rumblepak;
        private System.Windows.Forms.CheckBox chk_Cflg_Mempak;
        private System.Windows.Forms.CheckBox chk_Cflg_Present;
    }
}