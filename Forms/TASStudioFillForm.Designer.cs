
namespace MupenUtilities.Forms
{
    partial class TASStudioFillForm
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
            this.cmb_Buttons = new System.Windows.Forms.ComboBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_Go = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_Buttons
            // 
            this.cmb_Buttons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Buttons.FormattingEnabled = true;
            this.cmb_Buttons.Location = new System.Drawing.Point(144, 10);
            this.cmb_Buttons.Name = "cmb_Buttons";
            this.cmb_Buttons.Size = new System.Drawing.Size(121, 24);
            this.cmb_Buttons.TabIndex = 0;
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(13, 13);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(114, 16);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "Fill the region with:";
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(252, 59);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(161, 36);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Apply and Close";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // TASStudioFillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(425, 107);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.cmb_Buttons);
            this.MaximizeBox = false;
            this.Name = "TASStudioFillForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TASStudioFillForm";
            this.Shown += new System.EventHandler(this.TASStudioFillForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Buttons;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_Go;
    }
}