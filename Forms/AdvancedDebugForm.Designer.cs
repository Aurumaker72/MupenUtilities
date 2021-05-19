
namespace MupenUtils.Forms
{
    partial class AdvancedDebugForm
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
            this.txt_Debug_Uvalue = new System.Windows.Forms.TextBox();
            this.lbl_Debug_InputValue = new System.Windows.Forms.Label();
            this.txt_Debug_Frame = new System.Windows.Forms.TextBox();
            this.lbl_Debug_Frame = new System.Windows.Forms.Label();
            this.btn_Debug_Random = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Debug_Uvalue
            // 
            this.txt_Debug_Uvalue.Location = new System.Drawing.Point(104, 24);
            this.txt_Debug_Uvalue.Name = "txt_Debug_Uvalue";
            this.txt_Debug_Uvalue.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Uvalue.TabIndex = 0;
            this.txt_Debug_Uvalue.TextChanged += new System.EventHandler(this.txt_Debug_Uvalue_TextChanged);
            // 
            // lbl_Debug_InputValue
            // 
            this.lbl_Debug_InputValue.AutoSize = true;
            this.lbl_Debug_InputValue.Location = new System.Drawing.Point(16, 24);
            this.lbl_Debug_InputValue.Name = "lbl_Debug_InputValue";
            this.lbl_Debug_InputValue.Size = new System.Drawing.Size(79, 17);
            this.lbl_Debug_InputValue.TabIndex = 1;
            this.lbl_Debug_InputValue.Text = "Input Value";
            // 
            // txt_Debug_Frame
            // 
            this.txt_Debug_Frame.Location = new System.Drawing.Point(72, 120);
            this.txt_Debug_Frame.Name = "txt_Debug_Frame";
            this.txt_Debug_Frame.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Frame.TabIndex = 2;
            this.txt_Debug_Frame.TextChanged += new System.EventHandler(this.txt_Debug_Frame_TextChanged);
            // 
            // lbl_Debug_Frame
            // 
            this.lbl_Debug_Frame.AutoSize = true;
            this.lbl_Debug_Frame.Location = new System.Drawing.Point(16, 120);
            this.lbl_Debug_Frame.Name = "lbl_Debug_Frame";
            this.lbl_Debug_Frame.Size = new System.Drawing.Size(48, 17);
            this.lbl_Debug_Frame.TabIndex = 1;
            this.lbl_Debug_Frame.Text = "Frame";
            // 
            // btn_Debug_Random
            // 
            this.btn_Debug_Random.Location = new System.Drawing.Point(208, 24);
            this.btn_Debug_Random.Name = "btn_Debug_Random";
            this.btn_Debug_Random.Size = new System.Drawing.Size(75, 23);
            this.btn_Debug_Random.TabIndex = 0;
            this.btn_Debug_Random.TabStop = false;
            this.btn_Debug_Random.Text = "Random";
            this.btn_Debug_Random.UseVisualStyleBackColor = true;
            this.btn_Debug_Random.Click += new System.EventHandler(this.btn_Debug_Random_Click);
            // 
            // AdvancedDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 154);
            this.Controls.Add(this.btn_Debug_Random);
            this.Controls.Add(this.txt_Debug_Frame);
            this.Controls.Add(this.lbl_Debug_Frame);
            this.Controls.Add(this.lbl_Debug_InputValue);
            this.Controls.Add(this.txt_Debug_Uvalue);
            this.Name = "AdvancedDebugForm";
            this.Text = "Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Debug_Uvalue;
        private System.Windows.Forms.Label lbl_Debug_InputValue;
        private System.Windows.Forms.TextBox txt_Debug_Frame;
        private System.Windows.Forms.Label lbl_Debug_Frame;
        private System.Windows.Forms.Button btn_Debug_Random;
    }
}