
namespace MupenUtils.Forms
{
    partial class ReplacementForm
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
            this.gpBox_Repl_Replacement = new System.Windows.Forms.GroupBox();
            this.gp_Repl_Commands = new System.Windows.Forms.GroupBox();
            this.chk_Repl_All = new System.Windows.Forms.CheckBox();
            this.btn_Repl_Go = new System.Windows.Forms.Button();
            this.lbl_Repl_Fto = new System.Windows.Forms.Label();
            this.txt_Repl_Fto = new System.Windows.Forms.TextBox();
            this.lbl_Repl_FFrom = new System.Windows.Forms.Label();
            this.txt_Repl_FFrom = new System.Windows.Forms.TextBox();
            this.gp_Repl_File = new System.Windows.Forms.GroupBox();
            this.chk_Repl_Trg = new System.Windows.Forms.CheckBox();
            this.lbl_Repl_Status = new System.Windows.Forms.Label();
            this.btn_Repl_BrowseTrg = new System.Windows.Forms.Button();
            this.btn_Repl_BrowseSrc = new System.Windows.Forms.Button();
            this.txt_Repl_Trg = new System.Windows.Forms.TextBox();
            this.txt_Repl_Src = new System.Windows.Forms.TextBox();
            this.gp_Repl_Trg = new System.Windows.Forms.Label();
            this.gp_Repl_Src = new System.Windows.Forms.Label();
            this.gpBox_Repl_Replacement.SuspendLayout();
            this.gp_Repl_Commands.SuspendLayout();
            this.gp_Repl_File.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBox_Repl_Replacement
            // 
            this.gpBox_Repl_Replacement.Controls.Add(this.gp_Repl_Commands);
            this.gpBox_Repl_Replacement.Controls.Add(this.gp_Repl_File);
            this.gpBox_Repl_Replacement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpBox_Repl_Replacement.Location = new System.Drawing.Point(0, 0);
            this.gpBox_Repl_Replacement.Name = "gpBox_Repl_Replacement";
            this.gpBox_Repl_Replacement.Size = new System.Drawing.Size(544, 237);
            this.gpBox_Repl_Replacement.TabIndex = 0;
            this.gpBox_Repl_Replacement.TabStop = false;
            this.gpBox_Repl_Replacement.Text = "Replacement";
            // 
            // gp_Repl_Commands
            // 
            this.gp_Repl_Commands.Controls.Add(this.chk_Repl_All);
            this.gp_Repl_Commands.Controls.Add(this.btn_Repl_Go);
            this.gp_Repl_Commands.Controls.Add(this.lbl_Repl_Fto);
            this.gp_Repl_Commands.Controls.Add(this.txt_Repl_Fto);
            this.gp_Repl_Commands.Controls.Add(this.lbl_Repl_FFrom);
            this.gp_Repl_Commands.Controls.Add(this.txt_Repl_FFrom);
            this.gp_Repl_Commands.Dock = System.Windows.Forms.DockStyle.Right;
            this.gp_Repl_Commands.Location = new System.Drawing.Point(332, 18);
            this.gp_Repl_Commands.Name = "gp_Repl_Commands";
            this.gp_Repl_Commands.Size = new System.Drawing.Size(209, 216);
            this.gp_Repl_Commands.TabIndex = 0;
            this.gp_Repl_Commands.TabStop = false;
            this.gp_Repl_Commands.Text = "Commands";
            // 
            // chk_Repl_All
            // 
            this.chk_Repl_All.AutoSize = true;
            this.chk_Repl_All.Location = new System.Drawing.Point(16, 112);
            this.chk_Repl_All.Name = "chk_Repl_All";
            this.chk_Repl_All.Size = new System.Drawing.Size(45, 21);
            this.chk_Repl_All.TabIndex = 0;
            this.chk_Repl_All.TabStop = false;
            this.chk_Repl_All.Text = "All";
            this.chk_Repl_All.UseVisualStyleBackColor = true;
            this.chk_Repl_All.CheckedChanged += new System.EventHandler(this.chk_Repl_All_CheckedChanged);
            // 
            // btn_Repl_Go
            // 
            this.btn_Repl_Go.Location = new System.Drawing.Point(96, 176);
            this.btn_Repl_Go.Name = "btn_Repl_Go";
            this.btn_Repl_Go.Size = new System.Drawing.Size(91, 31);
            this.btn_Repl_Go.TabIndex = 0;
            this.btn_Repl_Go.TabStop = false;
            this.btn_Repl_Go.Text = "Go";
            this.btn_Repl_Go.UseVisualStyleBackColor = true;
            this.btn_Repl_Go.Click += new System.EventHandler(this.btn_Repl_Go_Click);
            // 
            // lbl_Repl_Fto
            // 
            this.lbl_Repl_Fto.AutoSize = true;
            this.lbl_Repl_Fto.Location = new System.Drawing.Point(16, 80);
            this.lbl_Repl_Fto.Name = "lbl_Repl_Fto";
            this.lbl_Repl_Fto.Size = new System.Drawing.Size(25, 17);
            this.lbl_Repl_Fto.TabIndex = 0;
            this.lbl_Repl_Fto.Text = "To";
            // 
            // txt_Repl_Fto
            // 
            this.txt_Repl_Fto.Location = new System.Drawing.Point(67, 80);
            this.txt_Repl_Fto.Name = "txt_Repl_Fto";
            this.txt_Repl_Fto.Size = new System.Drawing.Size(112, 22);
            this.txt_Repl_Fto.TabIndex = 0;
            this.txt_Repl_Fto.TabStop = false;
            // 
            // lbl_Repl_FFrom
            // 
            this.lbl_Repl_FFrom.AutoSize = true;
            this.lbl_Repl_FFrom.Location = new System.Drawing.Point(16, 40);
            this.lbl_Repl_FFrom.Name = "lbl_Repl_FFrom";
            this.lbl_Repl_FFrom.Size = new System.Drawing.Size(40, 17);
            this.lbl_Repl_FFrom.TabIndex = 0;
            this.lbl_Repl_FFrom.Text = "From";
            // 
            // txt_Repl_FFrom
            // 
            this.txt_Repl_FFrom.Location = new System.Drawing.Point(67, 40);
            this.txt_Repl_FFrom.Name = "txt_Repl_FFrom";
            this.txt_Repl_FFrom.Size = new System.Drawing.Size(112, 22);
            this.txt_Repl_FFrom.TabIndex = 0;
            this.txt_Repl_FFrom.TabStop = false;
            // 
            // gp_Repl_File
            // 
            this.gp_Repl_File.Controls.Add(this.chk_Repl_Trg);
            this.gp_Repl_File.Controls.Add(this.lbl_Repl_Status);
            this.gp_Repl_File.Controls.Add(this.btn_Repl_BrowseTrg);
            this.gp_Repl_File.Controls.Add(this.btn_Repl_BrowseSrc);
            this.gp_Repl_File.Controls.Add(this.txt_Repl_Trg);
            this.gp_Repl_File.Controls.Add(this.txt_Repl_Src);
            this.gp_Repl_File.Controls.Add(this.gp_Repl_Trg);
            this.gp_Repl_File.Controls.Add(this.gp_Repl_Src);
            this.gp_Repl_File.Dock = System.Windows.Forms.DockStyle.Left;
            this.gp_Repl_File.Location = new System.Drawing.Point(3, 18);
            this.gp_Repl_File.Name = "gp_Repl_File";
            this.gp_Repl_File.Size = new System.Drawing.Size(317, 216);
            this.gp_Repl_File.TabIndex = 0;
            this.gp_Repl_File.TabStop = false;
            this.gp_Repl_File.Text = "File";
            // 
            // chk_Repl_Trg
            // 
            this.chk_Repl_Trg.AutoSize = true;
            this.chk_Repl_Trg.Checked = true;
            this.chk_Repl_Trg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Repl_Trg.Location = new System.Drawing.Point(280, 84);
            this.chk_Repl_Trg.Name = "chk_Repl_Trg";
            this.chk_Repl_Trg.Size = new System.Drawing.Size(18, 17);
            this.chk_Repl_Trg.TabIndex = 0;
            this.chk_Repl_Trg.TabStop = false;
            this.chk_Repl_Trg.UseVisualStyleBackColor = true;
            this.chk_Repl_Trg.Visible = false;
            this.chk_Repl_Trg.CheckedChanged += new System.EventHandler(this.chk_Repl_Trg_CheckedChanged);
            // 
            // lbl_Repl_Status
            // 
            this.lbl_Repl_Status.AutoSize = true;
            this.lbl_Repl_Status.Location = new System.Drawing.Point(16, 184);
            this.lbl_Repl_Status.Name = "lbl_Repl_Status";
            this.lbl_Repl_Status.Size = new System.Drawing.Size(30, 17);
            this.lbl_Repl_Status.TabIndex = 0;
            this.lbl_Repl_Status.Text = "Idle";
            // 
            // btn_Repl_BrowseTrg
            // 
            this.btn_Repl_BrowseTrg.Location = new System.Drawing.Point(200, 80);
            this.btn_Repl_BrowseTrg.Name = "btn_Repl_BrowseTrg";
            this.btn_Repl_BrowseTrg.Size = new System.Drawing.Size(75, 23);
            this.btn_Repl_BrowseTrg.TabIndex = 0;
            this.btn_Repl_BrowseTrg.TabStop = false;
            this.btn_Repl_BrowseTrg.Text = "Browse";
            this.btn_Repl_BrowseTrg.UseVisualStyleBackColor = true;
            this.btn_Repl_BrowseTrg.Click += new System.EventHandler(this.btn_Repl_BrowseTrg_Click);
            // 
            // btn_Repl_BrowseSrc
            // 
            this.btn_Repl_BrowseSrc.Location = new System.Drawing.Point(200, 40);
            this.btn_Repl_BrowseSrc.Name = "btn_Repl_BrowseSrc";
            this.btn_Repl_BrowseSrc.Size = new System.Drawing.Size(75, 23);
            this.btn_Repl_BrowseSrc.TabIndex = 0;
            this.btn_Repl_BrowseSrc.TabStop = false;
            this.btn_Repl_BrowseSrc.Text = "Browse";
            this.btn_Repl_BrowseSrc.UseVisualStyleBackColor = true;
            this.btn_Repl_BrowseSrc.Click += new System.EventHandler(this.btn_Repl_BrowseSrc_Click);
            // 
            // txt_Repl_Trg
            // 
            this.txt_Repl_Trg.Location = new System.Drawing.Point(80, 80);
            this.txt_Repl_Trg.Name = "txt_Repl_Trg";
            this.txt_Repl_Trg.Size = new System.Drawing.Size(112, 22);
            this.txt_Repl_Trg.TabIndex = 0;
            this.txt_Repl_Trg.TabStop = false;
            // 
            // txt_Repl_Src
            // 
            this.txt_Repl_Src.Location = new System.Drawing.Point(80, 40);
            this.txt_Repl_Src.Name = "txt_Repl_Src";
            this.txt_Repl_Src.Size = new System.Drawing.Size(112, 22);
            this.txt_Repl_Src.TabIndex = 0;
            this.txt_Repl_Src.TabStop = false;
            // 
            // gp_Repl_Trg
            // 
            this.gp_Repl_Trg.AutoSize = true;
            this.gp_Repl_Trg.Location = new System.Drawing.Point(16, 80);
            this.gp_Repl_Trg.Name = "gp_Repl_Trg";
            this.gp_Repl_Trg.Size = new System.Drawing.Size(50, 17);
            this.gp_Repl_Trg.TabIndex = 0;
            this.gp_Repl_Trg.Text = "Target";
            // 
            // gp_Repl_Src
            // 
            this.gp_Repl_Src.AutoSize = true;
            this.gp_Repl_Src.Location = new System.Drawing.Point(16, 40);
            this.gp_Repl_Src.Name = "gp_Repl_Src";
            this.gp_Repl_Src.Size = new System.Drawing.Size(53, 17);
            this.gp_Repl_Src.TabIndex = 0;
            this.gp_Repl_Src.Text = "Source";
            // 
            // ReplacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(544, 237);
            this.Controls.Add(this.gpBox_Repl_Replacement);
            this.MaximizeBox = false;
            this.Name = "ReplacementForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ReplacementForm";
            this.Shown += new System.EventHandler(this.ReplacementForm_Shown);
            this.gpBox_Repl_Replacement.ResumeLayout(false);
            this.gp_Repl_Commands.ResumeLayout(false);
            this.gp_Repl_Commands.PerformLayout();
            this.gp_Repl_File.ResumeLayout(false);
            this.gp_Repl_File.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBox_Repl_Replacement;
        private System.Windows.Forms.GroupBox gp_Repl_File;
        private System.Windows.Forms.Label gp_Repl_Trg;
        private System.Windows.Forms.Label gp_Repl_Src;
        private System.Windows.Forms.Button btn_Repl_BrowseTrg;
        private System.Windows.Forms.Button btn_Repl_BrowseSrc;
        private System.Windows.Forms.TextBox txt_Repl_Trg;
        private System.Windows.Forms.TextBox txt_Repl_Src;
        private System.Windows.Forms.GroupBox gp_Repl_Commands;
        private System.Windows.Forms.Label lbl_Repl_Fto;
        private System.Windows.Forms.Label lbl_Repl_FFrom;
        private System.Windows.Forms.TextBox txt_Repl_Fto;
        private System.Windows.Forms.TextBox txt_Repl_FFrom;
        private System.Windows.Forms.Button btn_Repl_Go;
        private System.Windows.Forms.Label lbl_Repl_Status;
        private System.Windows.Forms.CheckBox chk_Repl_All;
        private System.Windows.Forms.CheckBox chk_Repl_Trg;
    }
}