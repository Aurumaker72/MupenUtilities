
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
            this.gp_Debug_Input = new System.Windows.Forms.GroupBox();
            this.gp_Debug_Hex = new System.Windows.Forms.GroupBox();
            this.chk_RangeMode = new System.Windows.Forms.CheckBox();
            this.gp_Range = new System.Windows.Forms.GroupBox();
            this.rb_ASCII = new System.Windows.Forms.RadioButton();
            this.rb_UTF8 = new System.Windows.Forms.RadioButton();
            this.rb_Integer = new System.Windows.Forms.RadioButton();
            this.rb_HexStr = new System.Windows.Forms.RadioButton();
            this.txt_Encoded = new System.Windows.Forms.TextBox();
            this.lbl_Debug_Value = new System.Windows.Forms.Label();
            this.lbl_Debug_Byten = new System.Windows.Forms.Label();
            this.txt_Debug_HexByte = new System.Windows.Forms.TextBox();
            this.txt_Debug_Value = new System.Windows.Forms.TextBox();
            this.txt_Debug_Byteto = new System.Windows.Forms.TextBox();
            this.txt_Debug_Bytefrom = new System.Windows.Forms.TextBox();
            this.chk_Ignorenulterm = new System.Windows.Forms.CheckBox();
            this.gp_Debug_Input.SuspendLayout();
            this.gp_Debug_Hex.SuspendLayout();
            this.gp_Range.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Debug_Uvalue
            // 
            this.txt_Debug_Uvalue.Location = new System.Drawing.Point(104, 40);
            this.txt_Debug_Uvalue.Name = "txt_Debug_Uvalue";
            this.txt_Debug_Uvalue.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Uvalue.TabIndex = 0;
            this.txt_Debug_Uvalue.TextChanged += new System.EventHandler(this.txt_Debug_Uvalue_TextChanged);
            // 
            // lbl_Debug_InputValue
            // 
            this.lbl_Debug_InputValue.AutoSize = true;
            this.lbl_Debug_InputValue.Location = new System.Drawing.Point(16, 40);
            this.lbl_Debug_InputValue.Name = "lbl_Debug_InputValue";
            this.lbl_Debug_InputValue.Size = new System.Drawing.Size(79, 17);
            this.lbl_Debug_InputValue.TabIndex = 1;
            this.lbl_Debug_InputValue.Text = "Input Value";
            // 
            // txt_Debug_Frame
            // 
            this.txt_Debug_Frame.Location = new System.Drawing.Point(104, 72);
            this.txt_Debug_Frame.Name = "txt_Debug_Frame";
            this.txt_Debug_Frame.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Frame.TabIndex = 2;
            this.txt_Debug_Frame.TextChanged += new System.EventHandler(this.txt_Debug_Frame_TextChanged);
            // 
            // lbl_Debug_Frame
            // 
            this.lbl_Debug_Frame.AutoSize = true;
            this.lbl_Debug_Frame.Location = new System.Drawing.Point(16, 72);
            this.lbl_Debug_Frame.Name = "lbl_Debug_Frame";
            this.lbl_Debug_Frame.Size = new System.Drawing.Size(48, 17);
            this.lbl_Debug_Frame.TabIndex = 1;
            this.lbl_Debug_Frame.Text = "Frame";
            // 
            // btn_Debug_Random
            // 
            this.btn_Debug_Random.Location = new System.Drawing.Point(208, 40);
            this.btn_Debug_Random.Name = "btn_Debug_Random";
            this.btn_Debug_Random.Size = new System.Drawing.Size(75, 23);
            this.btn_Debug_Random.TabIndex = 0;
            this.btn_Debug_Random.TabStop = false;
            this.btn_Debug_Random.Text = "Random";
            this.btn_Debug_Random.UseVisualStyleBackColor = true;
            this.btn_Debug_Random.Click += new System.EventHandler(this.btn_Debug_Random_Click);
            // 
            // gp_Debug_Input
            // 
            this.gp_Debug_Input.Controls.Add(this.txt_Debug_Frame);
            this.gp_Debug_Input.Controls.Add(this.btn_Debug_Random);
            this.gp_Debug_Input.Controls.Add(this.lbl_Debug_Frame);
            this.gp_Debug_Input.Controls.Add(this.lbl_Debug_InputValue);
            this.gp_Debug_Input.Controls.Add(this.txt_Debug_Uvalue);
            this.gp_Debug_Input.Dock = System.Windows.Forms.DockStyle.Left;
            this.gp_Debug_Input.Location = new System.Drawing.Point(0, 0);
            this.gp_Debug_Input.Name = "gp_Debug_Input";
            this.gp_Debug_Input.Size = new System.Drawing.Size(312, 334);
            this.gp_Debug_Input.TabIndex = 3;
            this.gp_Debug_Input.TabStop = false;
            this.gp_Debug_Input.Text = "Input";
            // 
            // gp_Debug_Hex
            // 
            this.gp_Debug_Hex.Controls.Add(this.chk_RangeMode);
            this.gp_Debug_Hex.Controls.Add(this.gp_Range);
            this.gp_Debug_Hex.Controls.Add(this.lbl_Debug_Value);
            this.gp_Debug_Hex.Controls.Add(this.lbl_Debug_Byten);
            this.gp_Debug_Hex.Controls.Add(this.txt_Debug_HexByte);
            this.gp_Debug_Hex.Controls.Add(this.txt_Debug_Value);
            this.gp_Debug_Hex.Controls.Add(this.txt_Debug_Byteto);
            this.gp_Debug_Hex.Controls.Add(this.txt_Debug_Bytefrom);
            this.gp_Debug_Hex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Debug_Hex.Location = new System.Drawing.Point(312, 0);
            this.gp_Debug_Hex.Name = "gp_Debug_Hex";
            this.gp_Debug_Hex.Size = new System.Drawing.Size(352, 334);
            this.gp_Debug_Hex.TabIndex = 0;
            this.gp_Debug_Hex.TabStop = false;
            this.gp_Debug_Hex.Text = "Raw";
            // 
            // chk_RangeMode
            // 
            this.chk_RangeMode.AutoSize = true;
            this.chk_RangeMode.Location = new System.Drawing.Point(16, 104);
            this.chk_RangeMode.Name = "chk_RangeMode";
            this.chk_RangeMode.Size = new System.Drawing.Size(111, 21);
            this.chk_RangeMode.TabIndex = 0;
            this.chk_RangeMode.TabStop = false;
            this.chk_RangeMode.Text = "Range Mode";
            this.chk_RangeMode.UseVisualStyleBackColor = true;
            this.chk_RangeMode.CheckedChanged += new System.EventHandler(this.chk_RangeMode_CheckedChanged);
            // 
            // gp_Range
            // 
            this.gp_Range.Controls.Add(this.chk_Ignorenulterm);
            this.gp_Range.Controls.Add(this.rb_ASCII);
            this.gp_Range.Controls.Add(this.rb_UTF8);
            this.gp_Range.Controls.Add(this.rb_Integer);
            this.gp_Range.Controls.Add(this.rb_HexStr);
            this.gp_Range.Controls.Add(this.txt_Encoded);
            this.gp_Range.Location = new System.Drawing.Point(16, 136);
            this.gp_Range.Name = "gp_Range";
            this.gp_Range.Size = new System.Drawing.Size(328, 152);
            this.gp_Range.TabIndex = 0;
            this.gp_Range.TabStop = false;
            this.gp_Range.Text = "Encoder";
            this.gp_Range.Visible = false;
            // 
            // rb_ASCII
            // 
            this.rb_ASCII.AutoSize = true;
            this.rb_ASCII.Location = new System.Drawing.Point(8, 96);
            this.rb_ASCII.Name = "rb_ASCII";
            this.rb_ASCII.Size = new System.Drawing.Size(62, 21);
            this.rb_ASCII.TabIndex = 0;
            this.rb_ASCII.TabStop = true;
            this.rb_ASCII.Text = "ASCII";
            this.rb_ASCII.UseVisualStyleBackColor = true;
            this.rb_ASCII.MouseUp += new System.Windows.Forms.MouseEventHandler(this.changedEncodeType);
            // 
            // rb_UTF8
            // 
            this.rb_UTF8.AutoSize = true;
            this.rb_UTF8.Location = new System.Drawing.Point(8, 72);
            this.rb_UTF8.Name = "rb_UTF8";
            this.rb_UTF8.Size = new System.Drawing.Size(64, 21);
            this.rb_UTF8.TabIndex = 1;
            this.rb_UTF8.TabStop = true;
            this.rb_UTF8.Text = "UTF8";
            this.rb_UTF8.UseVisualStyleBackColor = true;
            this.rb_UTF8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.changedEncodeType);
            // 
            // rb_Integer
            // 
            this.rb_Integer.AutoSize = true;
            this.rb_Integer.Location = new System.Drawing.Point(8, 48);
            this.rb_Integer.Name = "rb_Integer";
            this.rb_Integer.Size = new System.Drawing.Size(73, 21);
            this.rb_Integer.TabIndex = 0;
            this.rb_Integer.Text = "Integer";
            this.rb_Integer.UseVisualStyleBackColor = true;
            this.rb_Integer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.changedEncodeType);
            // 
            // rb_HexStr
            // 
            this.rb_HexStr.AutoSize = true;
            this.rb_HexStr.Location = new System.Drawing.Point(8, 24);
            this.rb_HexStr.Name = "rb_HexStr";
            this.rb_HexStr.Size = new System.Drawing.Size(94, 21);
            this.rb_HexStr.TabIndex = 1;
            this.rb_HexStr.TabStop = true;
            this.rb_HexStr.Text = "Hex String";
            this.rb_HexStr.UseVisualStyleBackColor = true;
            this.rb_HexStr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.changedEncodeType);
            // 
            // txt_Encoded
            // 
            this.txt_Encoded.Location = new System.Drawing.Point(176, 24);
            this.txt_Encoded.Multiline = true;
            this.txt_Encoded.Name = "txt_Encoded";
            this.txt_Encoded.ReadOnly = true;
            this.txt_Encoded.Size = new System.Drawing.Size(144, 88);
            this.txt_Encoded.TabIndex = 0;
            // 
            // lbl_Debug_Value
            // 
            this.lbl_Debug_Value.AutoSize = true;
            this.lbl_Debug_Value.Location = new System.Drawing.Point(16, 72);
            this.lbl_Debug_Value.Name = "lbl_Debug_Value";
            this.lbl_Debug_Value.Size = new System.Drawing.Size(44, 17);
            this.lbl_Debug_Value.TabIndex = 0;
            this.lbl_Debug_Value.Text = "Value";
            // 
            // lbl_Debug_Byten
            // 
            this.lbl_Debug_Byten.AutoSize = true;
            this.lbl_Debug_Byten.Location = new System.Drawing.Point(16, 40);
            this.lbl_Debug_Byten.Name = "lbl_Debug_Byten";
            this.lbl_Debug_Byten.Size = new System.Drawing.Size(36, 17);
            this.lbl_Debug_Byten.TabIndex = 0;
            this.lbl_Debug_Byten.Text = "Byte";
            // 
            // txt_Debug_HexByte
            // 
            this.txt_Debug_HexByte.Location = new System.Drawing.Point(176, 72);
            this.txt_Debug_HexByte.Name = "txt_Debug_HexByte";
            this.txt_Debug_HexByte.ReadOnly = true;
            this.txt_Debug_HexByte.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_HexByte.TabIndex = 0;
            // 
            // txt_Debug_Value
            // 
            this.txt_Debug_Value.Location = new System.Drawing.Point(64, 72);
            this.txt_Debug_Value.Name = "txt_Debug_Value";
            this.txt_Debug_Value.ReadOnly = true;
            this.txt_Debug_Value.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Value.TabIndex = 0;
            // 
            // txt_Debug_Byteto
            // 
            this.txt_Debug_Byteto.Location = new System.Drawing.Point(176, 40);
            this.txt_Debug_Byteto.Name = "txt_Debug_Byteto";
            this.txt_Debug_Byteto.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Byteto.TabIndex = 0;
            this.txt_Debug_Byteto.Visible = false;
            this.txt_Debug_Byteto.TextChanged += new System.EventHandler(this.txt_Debug_Byteto_TextChanged);
            // 
            // txt_Debug_Bytefrom
            // 
            this.txt_Debug_Bytefrom.Location = new System.Drawing.Point(64, 40);
            this.txt_Debug_Bytefrom.Name = "txt_Debug_Bytefrom";
            this.txt_Debug_Bytefrom.Size = new System.Drawing.Size(100, 22);
            this.txt_Debug_Bytefrom.TabIndex = 0;
            this.txt_Debug_Bytefrom.TextChanged += new System.EventHandler(this.txt_Debug_Nthbyte_TextChanged);
            // 
            // chk_Ignorenulterm
            // 
            this.chk_Ignorenulterm.AutoSize = true;
            this.chk_Ignorenulterm.Location = new System.Drawing.Point(176, 120);
            this.chk_Ignorenulterm.Name = "chk_Ignorenulterm";
            this.chk_Ignorenulterm.Size = new System.Drawing.Size(102, 21);
            this.chk_Ignorenulterm.TabIndex = 0;
            this.chk_Ignorenulterm.TabStop = false;
            this.chk_Ignorenulterm.Text = "Ignore NUL";
            this.chk_Ignorenulterm.UseVisualStyleBackColor = true;
            this.chk_Ignorenulterm.CheckedChanged += new System.EventHandler(this.chk_Ignorenulterm_CheckedChanged);
            // 
            // AdvancedDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(664, 334);
            this.Controls.Add(this.gp_Debug_Hex);
            this.Controls.Add(this.gp_Debug_Input);
            this.Name = "AdvancedDebugForm";
            this.Text = "Debug";
            this.Shown += new System.EventHandler(this.AdvancedDebugForm_Shown_1);
            this.gp_Debug_Input.ResumeLayout(false);
            this.gp_Debug_Input.PerformLayout();
            this.gp_Debug_Hex.ResumeLayout(false);
            this.gp_Debug_Hex.PerformLayout();
            this.gp_Range.ResumeLayout(false);
            this.gp_Range.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Debug_Uvalue;
        private System.Windows.Forms.Label lbl_Debug_InputValue;
        private System.Windows.Forms.TextBox txt_Debug_Frame;
        private System.Windows.Forms.Label lbl_Debug_Frame;
        private System.Windows.Forms.Button btn_Debug_Random;
        private System.Windows.Forms.GroupBox gp_Debug_Input;
        private System.Windows.Forms.GroupBox gp_Debug_Hex;
        private System.Windows.Forms.Label lbl_Debug_Byten;
        private System.Windows.Forms.TextBox txt_Debug_Bytefrom;
        private System.Windows.Forms.Label lbl_Debug_Value;
        private System.Windows.Forms.TextBox txt_Debug_Value;
        private System.Windows.Forms.TextBox txt_Debug_HexByte;
        private System.Windows.Forms.GroupBox gp_Range;
        private System.Windows.Forms.CheckBox chk_RangeMode;
        private System.Windows.Forms.TextBox txt_Debug_Byteto;
        private System.Windows.Forms.TextBox txt_Encoded;
        private System.Windows.Forms.RadioButton rb_ASCII;
        private System.Windows.Forms.RadioButton rb_UTF8;
        private System.Windows.Forms.RadioButton rb_HexStr;
        private System.Windows.Forms.RadioButton rb_Integer;
        private System.Windows.Forms.CheckBox chk_Ignorenulterm;
    }
}