
namespace MupenUtilities.Forms
{
    partial class MovieDiagnosticForm
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
            this.gp_Moviediag = new System.Windows.Forms.GroupBox();
            this.lb_Checks = new System.Windows.Forms.ListBox();
            this.btn_Recalc = new System.Windows.Forms.Button();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.gp_Moviediag.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_Moviediag
            // 
            this.gp_Moviediag.Controls.Add(this.lbl_info);
            this.gp_Moviediag.Controls.Add(this.lbl_Result);
            this.gp_Moviediag.Controls.Add(this.btn_Recalc);
            this.gp_Moviediag.Controls.Add(this.lb_Checks);
            this.gp_Moviediag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Moviediag.Location = new System.Drawing.Point(0, 0);
            this.gp_Moviediag.Name = "gp_Moviediag";
            this.gp_Moviediag.Size = new System.Drawing.Size(517, 227);
            this.gp_Moviediag.TabIndex = 0;
            this.gp_Moviediag.TabStop = false;
            this.gp_Moviediag.Text = "Movie Diagnostic";
            // 
            // lb_Checks
            // 
            this.lb_Checks.FormattingEnabled = true;
            this.lb_Checks.ItemHeight = 16;
            this.lb_Checks.Location = new System.Drawing.Point(12, 21);
            this.lb_Checks.Name = "lb_Checks";
            this.lb_Checks.Size = new System.Drawing.Size(493, 132);
            this.lb_Checks.TabIndex = 0;
            this.lb_Checks.TabStop = false;
            // 
            // btn_Recalc
            // 
            this.btn_Recalc.Location = new System.Drawing.Point(12, 184);
            this.btn_Recalc.Name = "btn_Recalc";
            this.btn_Recalc.Size = new System.Drawing.Size(104, 34);
            this.btn_Recalc.TabIndex = 0;
            this.btn_Recalc.TabStop = false;
            this.btn_Recalc.Text = "Recalculate";
            this.btn_Recalc.UseVisualStyleBackColor = true;
            this.btn_Recalc.Click += new System.EventHandler(this.btn_Recalc_Click);
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Result.Location = new System.Drawing.Point(12, 156);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(23, 25);
            this.lbl_Result.TabIndex = 0;
            this.lbl_Result.Text = "?";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(122, 184);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(313, 32);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "An automatic movie diagnostic was performed\r\nbecause your movie contains suspicio" +
    "us properties";
            this.lbl_info.Visible = false;
            // 
            // MovieDiagnosticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(517, 227);
            this.Controls.Add(this.gp_Moviediag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MovieDiagnosticForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovieDiagnosticForm";
            this.Shown += new System.EventHandler(this.MovieDiagnosticForm_Shown);
            this.gp_Moviediag.ResumeLayout(false);
            this.gp_Moviediag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Moviediag;
        private System.Windows.Forms.ListBox lb_Checks;
        private System.Windows.Forms.Button btn_Recalc;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Label lbl_info;
    }
}