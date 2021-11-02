
namespace MupenUtils.Forms
{
    partial class RNGConverterForm
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
            this.gp_Rngconverter = new System.Windows.Forms.GroupBox();
            this.txt_RngIndicies = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Go = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_RngValues = new System.Windows.Forms.TextBox();
            this.chk_Ascending = new System.Windows.Forms.CheckBox();
            this.gp_Rngconverter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_Rngconverter
            // 
            this.gp_Rngconverter.Controls.Add(this.txt_RngIndicies);
            this.gp_Rngconverter.Controls.Add(this.panel1);
            this.gp_Rngconverter.Controls.Add(this.txt_RngValues);
            this.gp_Rngconverter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Rngconverter.Location = new System.Drawing.Point(0, 0);
            this.gp_Rngconverter.Name = "gp_Rngconverter";
            this.gp_Rngconverter.Size = new System.Drawing.Size(802, 451);
            this.gp_Rngconverter.TabIndex = 0;
            this.gp_Rngconverter.TabStop = false;
            this.gp_Rngconverter.Text = "RNG Converter";
            this.gp_Rngconverter.Enter += new System.EventHandler(this.gp_Rngconverter_Enter);
            // 
            // txt_RngIndicies
            // 
            this.txt_RngIndicies.AcceptsReturn = true;
            this.txt_RngIndicies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RngIndicies.Location = new System.Drawing.Point(398, 18);
            this.txt_RngIndicies.Multiline = true;
            this.txt_RngIndicies.Name = "txt_RngIndicies";
            this.txt_RngIndicies.ReadOnly = true;
            this.txt_RngIndicies.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_RngIndicies.Size = new System.Drawing.Size(401, 430);
            this.txt_RngIndicies.TabIndex = 6;
            this.txt_RngIndicies.TabStop = false;
            this.txt_RngIndicies.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_Ascending);
            this.panel1.Controls.Add(this.btn_Go);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(274, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 430);
            this.panel1.TabIndex = 5;
            // 
            // btn_Go
            // 
            this.btn_Go.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Go.Location = new System.Drawing.Point(0, 387);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(124, 43);
            this.btn_Go.TabIndex = 5;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = global::MupenUtilities.Properties.Resources.RightArrow;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "To Rng Indicies";
            // 
            // txt_RngValues
            // 
            this.txt_RngValues.AcceptsReturn = true;
            this.txt_RngValues.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_RngValues.Location = new System.Drawing.Point(3, 18);
            this.txt_RngValues.Multiline = true;
            this.txt_RngValues.Name = "txt_RngValues";
            this.txt_RngValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_RngValues.Size = new System.Drawing.Size(271, 430);
            this.txt_RngValues.TabIndex = 2;
            this.txt_RngValues.TabStop = false;
            this.txt_RngValues.WordWrap = false;
            // 
            // chk_Ascending
            // 
            this.chk_Ascending.AutoSize = true;
            this.chk_Ascending.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk_Ascending.Location = new System.Drawing.Point(0, 367);
            this.chk_Ascending.Name = "chk_Ascending";
            this.chk_Ascending.Size = new System.Drawing.Size(124, 20);
            this.chk_Ascending.TabIndex = 6;
            this.chk_Ascending.Text = "Ascending";
            this.chk_Ascending.UseVisualStyleBackColor = true;
            // 
            // RNGConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(802, 451);
            this.Controls.Add(this.gp_Rngconverter);
            this.MaximizeBox = false;
            this.Name = "RNGConverterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RNG Converter";
            this.gp_Rngconverter.ResumeLayout(false);
            this.gp_Rngconverter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Rngconverter;
        private System.Windows.Forms.TextBox txt_RngValues;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_RngIndicies;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.CheckBox chk_Ascending;
    }
}