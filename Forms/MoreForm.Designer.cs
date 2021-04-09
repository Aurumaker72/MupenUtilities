
namespace MupenUtils
{
    partial class MoreForm
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
            this.gp_More_Tips = new System.Windows.Forms.GroupBox();
            this.btn_More_NewTip = new System.Windows.Forms.Button();
            this.lbl_More_Tip = new System.Windows.Forms.Label();
            this.lbl_More_TipInfo = new System.Windows.Forms.Label();
            this.gp_More_Tips.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_More_Tips
            // 
            this.gp_More_Tips.Controls.Add(this.lbl_More_TipInfo);
            this.gp_More_Tips.Controls.Add(this.lbl_More_Tip);
            this.gp_More_Tips.Controls.Add(this.btn_More_NewTip);
            this.gp_More_Tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.gp_More_Tips.Location = new System.Drawing.Point(0, 0);
            this.gp_More_Tips.Name = "gp_More_Tips";
            this.gp_More_Tips.Size = new System.Drawing.Size(534, 144);
            this.gp_More_Tips.TabIndex = 0;
            this.gp_More_Tips.TabStop = false;
            this.gp_More_Tips.Text = "Tips";
            // 
            // btn_More_NewTip
            // 
            this.btn_More_NewTip.Location = new System.Drawing.Point(448, 112);
            this.btn_More_NewTip.Name = "btn_More_NewTip";
            this.btn_More_NewTip.Size = new System.Drawing.Size(75, 23);
            this.btn_More_NewTip.TabIndex = 0;
            this.btn_More_NewTip.TabStop = false;
            this.btn_More_NewTip.Text = "New Tip";
            this.btn_More_NewTip.UseVisualStyleBackColor = true;
            this.btn_More_NewTip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_More_NewTip_MouseDown);
            // 
            // lbl_More_Tip
            // 
            this.lbl_More_Tip.AutoSize = true;
            this.lbl_More_Tip.Location = new System.Drawing.Point(72, 40);
            this.lbl_More_Tip.Name = "lbl_More_Tip";
            this.lbl_More_Tip.Size = new System.Drawing.Size(260, 17);
            this.lbl_More_Tip.TabIndex = 0;
            this.lbl_More_Tip.Text = "Press the \"New Tip\" button to show a tip";
            // 
            // lbl_More_TipInfo
            // 
            this.lbl_More_TipInfo.AutoSize = true;
            this.lbl_More_TipInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_More_TipInfo.Location = new System.Drawing.Point(16, 32);
            this.lbl_More_TipInfo.Name = "lbl_More_TipInfo";
            this.lbl_More_TipInfo.Size = new System.Drawing.Size(55, 32);
            this.lbl_More_TipInfo.TabIndex = 0;
            this.lbl_More_TipInfo.Text = "Tip";
            // 
            // MoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(534, 404);
            this.Controls.Add(this.gp_More_Tips);
            this.MaximizeBox = false;
            this.Name = "MoreForm";
            this.ShowIcon = false;
            this.Text = "MoreForm";
            this.gp_More_Tips.ResumeLayout(false);
            this.gp_More_Tips.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_More_Tips;
        private System.Windows.Forms.Button btn_More_NewTip;
        private System.Windows.Forms.Label lbl_More_TipInfo;
        private System.Windows.Forms.Label lbl_More_Tip;
    }
}