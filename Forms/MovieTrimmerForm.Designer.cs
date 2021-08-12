
namespace MupenUtilities.Forms
{
    partial class MovieTrimmerForm
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
            this.gp_File = new System.Windows.Forms.GroupBox();
            this.btn_BrowseOut = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.btn_BrowseSrc = new System.Windows.Forms.Button();
            this.txt_Src = new System.Windows.Forms.TextBox();
            this.lbl_Output = new System.Windows.Forms.Label();
            this.lbl_Src = new System.Windows.Forms.Label();
            this.gp_MovieTrim = new System.Windows.Forms.GroupBox();
            this.gp_TrimOptions = new System.Windows.Forms.GroupBox();
            this.chk_TrimAdjustSamplesInHeader = new System.Windows.Forms.CheckBox();
            this.gp_Commands = new System.Windows.Forms.GroupBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.btn_help = new System.Windows.Forms.Button();
            this.gp_File.SuspendLayout();
            this.gp_MovieTrim.SuspendLayout();
            this.gp_TrimOptions.SuspendLayout();
            this.gp_Commands.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_File
            // 
            this.gp_File.Controls.Add(this.btn_BrowseOut);
            this.gp_File.Controls.Add(this.txt_Output);
            this.gp_File.Controls.Add(this.btn_BrowseSrc);
            this.gp_File.Controls.Add(this.txt_Src);
            this.gp_File.Controls.Add(this.lbl_Output);
            this.gp_File.Controls.Add(this.lbl_Src);
            this.gp_File.Location = new System.Drawing.Point(12, 21);
            this.gp_File.Name = "gp_File";
            this.gp_File.Size = new System.Drawing.Size(283, 105);
            this.gp_File.TabIndex = 1;
            this.gp_File.TabStop = false;
            this.gp_File.Text = "File";
            // 
            // btn_BrowseOut
            // 
            this.btn_BrowseOut.Location = new System.Drawing.Point(192, 49);
            this.btn_BrowseOut.Name = "btn_BrowseOut";
            this.btn_BrowseOut.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseOut.TabIndex = 0;
            this.btn_BrowseOut.TabStop = false;
            this.btn_BrowseOut.Text = "Browse";
            this.btn_BrowseOut.UseVisualStyleBackColor = true;
            this.btn_BrowseOut.Click += new System.EventHandler(this.btn_BrowseOut_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(74, 49);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(112, 22);
            this.txt_Output.TabIndex = 0;
            this.txt_Output.TabStop = false;
            this.txt_Output.TextChanged += new System.EventHandler(this.txt_Output_TextChanged);
            // 
            // btn_BrowseSrc
            // 
            this.btn_BrowseSrc.Location = new System.Drawing.Point(192, 21);
            this.btn_BrowseSrc.Name = "btn_BrowseSrc";
            this.btn_BrowseSrc.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseSrc.TabIndex = 0;
            this.btn_BrowseSrc.TabStop = false;
            this.btn_BrowseSrc.Text = "Browse";
            this.btn_BrowseSrc.UseVisualStyleBackColor = true;
            this.btn_BrowseSrc.Click += new System.EventHandler(this.btn_BrowseSrc_Click);
            // 
            // txt_Src
            // 
            this.txt_Src.Location = new System.Drawing.Point(74, 21);
            this.txt_Src.Name = "txt_Src";
            this.txt_Src.ReadOnly = true;
            this.txt_Src.Size = new System.Drawing.Size(112, 22);
            this.txt_Src.TabIndex = 0;
            this.txt_Src.TabStop = false;
            // 
            // lbl_Output
            // 
            this.lbl_Output.AutoSize = true;
            this.lbl_Output.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Output.Location = new System.Drawing.Point(8, 49);
            this.lbl_Output.Name = "lbl_Output";
            this.lbl_Output.Size = new System.Drawing.Size(65, 32);
            this.lbl_Output.TabIndex = 0;
            this.lbl_Output.Text = "Output\r\n(Optional)\r\n";
            // 
            // lbl_Src
            // 
            this.lbl_Src.AutoSize = true;
            this.lbl_Src.Location = new System.Drawing.Point(8, 24);
            this.lbl_Src.Name = "lbl_Src";
            this.lbl_Src.Size = new System.Drawing.Size(50, 16);
            this.lbl_Src.TabIndex = 0;
            this.lbl_Src.Text = "Source";
            // 
            // gp_MovieTrim
            // 
            this.gp_MovieTrim.Controls.Add(this.btn_help);
            this.gp_MovieTrim.Controls.Add(this.gp_Commands);
            this.gp_MovieTrim.Controls.Add(this.gp_TrimOptions);
            this.gp_MovieTrim.Controls.Add(this.gp_File);
            this.gp_MovieTrim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_MovieTrim.Location = new System.Drawing.Point(0, 0);
            this.gp_MovieTrim.Name = "gp_MovieTrim";
            this.gp_MovieTrim.Size = new System.Drawing.Size(436, 196);
            this.gp_MovieTrim.TabIndex = 0;
            this.gp_MovieTrim.TabStop = false;
            this.gp_MovieTrim.Text = "Movie Trimmer";
            // 
            // gp_TrimOptions
            // 
            this.gp_TrimOptions.Controls.Add(this.chk_TrimAdjustSamplesInHeader);
            this.gp_TrimOptions.Location = new System.Drawing.Point(12, 132);
            this.gp_TrimOptions.Name = "gp_TrimOptions";
            this.gp_TrimOptions.Size = new System.Drawing.Size(283, 52);
            this.gp_TrimOptions.TabIndex = 0;
            this.gp_TrimOptions.TabStop = false;
            this.gp_TrimOptions.Text = "Trim Options";
            // 
            // chk_TrimAdjustSamplesInHeader
            // 
            this.chk_TrimAdjustSamplesInHeader.AutoSize = true;
            this.chk_TrimAdjustSamplesInHeader.Location = new System.Drawing.Point(11, 21);
            this.chk_TrimAdjustSamplesInHeader.Name = "chk_TrimAdjustSamplesInHeader";
            this.chk_TrimAdjustSamplesInHeader.Size = new System.Drawing.Size(125, 20);
            this.chk_TrimAdjustSamplesInHeader.TabIndex = 0;
            this.chk_TrimAdjustSamplesInHeader.Text = "Retouch header";
            this.chk_TrimAdjustSamplesInHeader.UseVisualStyleBackColor = true;
            // 
            // gp_Commands
            // 
            this.gp_Commands.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gp_Commands.Controls.Add(this.btn_Go);
            this.gp_Commands.Location = new System.Drawing.Point(301, 21);
            this.gp_Commands.Name = "gp_Commands";
            this.gp_Commands.Size = new System.Drawing.Size(122, 105);
            this.gp_Commands.TabIndex = 2;
            this.gp_Commands.TabStop = false;
            this.gp_Commands.Text = "Commands";
            // 
            // btn_Go
            // 
            this.btn_Go.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Go.Location = new System.Drawing.Point(16, 45);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(91, 31);
            this.btn_Go.TabIndex = 0;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // btn_help
            // 
            this.btn_help.Location = new System.Drawing.Point(393, 157);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(30, 27);
            this.btn_help.TabIndex = 3;
            this.btn_help.Text = "?";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // MovieTrimmerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(436, 196);
            this.Controls.Add(this.gp_MovieTrim);
            this.MaximizeBox = false;
            this.Name = "MovieTrimmerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovieTrimmerForm";
            this.gp_File.ResumeLayout(false);
            this.gp_File.PerformLayout();
            this.gp_MovieTrim.ResumeLayout(false);
            this.gp_TrimOptions.ResumeLayout(false);
            this.gp_TrimOptions.PerformLayout();
            this.gp_Commands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_File;
        private System.Windows.Forms.Button btn_BrowseOut;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Button btn_BrowseSrc;
        private System.Windows.Forms.TextBox txt_Src;
        private System.Windows.Forms.Label lbl_Output;
        private System.Windows.Forms.Label lbl_Src;
        private System.Windows.Forms.GroupBox gp_MovieTrim;
        private System.Windows.Forms.GroupBox gp_TrimOptions;
        private System.Windows.Forms.CheckBox chk_TrimAdjustSamplesInHeader;
        private System.Windows.Forms.GroupBox gp_Commands;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Button btn_help;
    }
}