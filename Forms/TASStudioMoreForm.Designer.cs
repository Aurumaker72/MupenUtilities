
namespace MupenUtils.Forms
{
    partial class TASStudioMoreForm
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
            this.gp_TasStudio_Help = new System.Windows.Forms.GroupBox();
            this.btn_TasStudio_EasterEggObunga = new System.Windows.Forms.Button();
            this.txt_TasStudio_Frame = new System.Windows.Forms.TextBox();
            this.gp_TasStudio_Goto = new System.Windows.Forms.GroupBox();
            this.btn_TasStudio_Goto = new System.Windows.Forms.Button();
            this.lbl_TasStudio_Frame = new System.Windows.Forms.Label();
            this.gp_TasStudio_Help.SuspendLayout();
            this.gp_TasStudio_Goto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_TasStudio_Help
            // 
            this.gp_TasStudio_Help.Controls.Add(this.btn_TasStudio_EasterEggObunga);
            this.gp_TasStudio_Help.Controls.Add(this.txt_TasStudio_Frame);
            this.gp_TasStudio_Help.Controls.Add(this.gp_TasStudio_Goto);
            this.gp_TasStudio_Help.Controls.Add(this.lbl_TasStudio_Frame);
            this.gp_TasStudio_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_TasStudio_Help.Location = new System.Drawing.Point(0, 0);
            this.gp_TasStudio_Help.Name = "gp_TasStudio_Help";
            this.gp_TasStudio_Help.Size = new System.Drawing.Size(532, 343);
            this.gp_TasStudio_Help.TabIndex = 0;
            this.gp_TasStudio_Help.TabStop = false;
            this.gp_TasStudio_Help.Text = "TAS Studio Commands";
            // 
            // btn_TasStudio_EasterEggObunga
            // 
            this.btn_TasStudio_EasterEggObunga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TasStudio_EasterEggObunga.FlatAppearance.BorderSize = 0;
            this.btn_TasStudio_EasterEggObunga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TasStudio_EasterEggObunga.Location = new System.Drawing.Point(488, 312);
            this.btn_TasStudio_EasterEggObunga.Name = "btn_TasStudio_EasterEggObunga";
            this.btn_TasStudio_EasterEggObunga.Size = new System.Drawing.Size(35, 23);
            this.btn_TasStudio_EasterEggObunga.TabIndex = 0;
            this.btn_TasStudio_EasterEggObunga.TabStop = false;
            this.btn_TasStudio_EasterEggObunga.UseVisualStyleBackColor = false;
            this.btn_TasStudio_EasterEggObunga.Click += new System.EventHandler(this.btn_TasStudio_EasterEggObunga_Click);
            // 
            // txt_TasStudio_Frame
            // 
            this.txt_TasStudio_Frame.Location = new System.Drawing.Point(112, 32);
            this.txt_TasStudio_Frame.Name = "txt_TasStudio_Frame";
            this.txt_TasStudio_Frame.Size = new System.Drawing.Size(160, 22);
            this.txt_TasStudio_Frame.TabIndex = 3;
            this.txt_TasStudio_Frame.TextChanged += new System.EventHandler(this.txt_TasStudio_Frame_TextChanged);
            // 
            // gp_TasStudio_Goto
            // 
            this.gp_TasStudio_Goto.Controls.Add(this.btn_TasStudio_Goto);
            this.gp_TasStudio_Goto.Location = new System.Drawing.Point(16, 64);
            this.gp_TasStudio_Goto.Name = "gp_TasStudio_Goto";
            this.gp_TasStudio_Goto.Size = new System.Drawing.Size(256, 64);
            this.gp_TasStudio_Goto.TabIndex = 2;
            this.gp_TasStudio_Goto.TabStop = false;
            this.gp_TasStudio_Goto.Text = "GOTO";
            // 
            // btn_TasStudio_Goto
            // 
            this.btn_TasStudio_Goto.Location = new System.Drawing.Point(8, 24);
            this.btn_TasStudio_Goto.Name = "btn_TasStudio_Goto";
            this.btn_TasStudio_Goto.Size = new System.Drawing.Size(91, 31);
            this.btn_TasStudio_Goto.TabIndex = 0;
            this.btn_TasStudio_Goto.Text = "Goto";
            this.btn_TasStudio_Goto.UseVisualStyleBackColor = true;
            this.btn_TasStudio_Goto.Click += new System.EventHandler(this.btn_TasStudio_Goto_Click);
            // 
            // lbl_TasStudio_Frame
            // 
            this.lbl_TasStudio_Frame.AutoSize = true;
            this.lbl_TasStudio_Frame.Location = new System.Drawing.Point(16, 32);
            this.lbl_TasStudio_Frame.Name = "lbl_TasStudio_Frame";
            this.lbl_TasStudio_Frame.Size = new System.Drawing.Size(94, 17);
            this.lbl_TasStudio_Frame.TabIndex = 1;
            this.lbl_TasStudio_Frame.Text = "Target Frame";
            // 
            // TASStudioMoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(532, 343);
            this.Controls.Add(this.gp_TasStudio_Help);
            this.MaximizeBox = false;
            this.Name = "TASStudioMoreForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TAS Studio Commands";
            this.Shown += new System.EventHandler(this.TASStudioMoreForm_Shown);
            this.gp_TasStudio_Help.ResumeLayout(false);
            this.gp_TasStudio_Help.PerformLayout();
            this.gp_TasStudio_Goto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_TasStudio_Help;
        private System.Windows.Forms.GroupBox gp_TasStudio_Goto;
        private System.Windows.Forms.Button btn_TasStudio_Goto;
        private System.Windows.Forms.Label lbl_TasStudio_Frame;
        private System.Windows.Forms.TextBox txt_TasStudio_Frame;
        private System.Windows.Forms.Button btn_TasStudio_EasterEggObunga;
    }
}