﻿
namespace MupenUtils.Forms
{
    partial class InputStatsForm
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
            this.gp_Stats = new System.Windows.Forms.GroupBox();
            this.gp_Buttons = new System.Windows.Forms.GroupBox();
            this.lbl_Res2 = new System.Windows.Forms.Label();
            this.lbl_Res1 = new System.Windows.Forms.Label();
            this.lbl_Start = new System.Windows.Forms.Label();
            this.lbl_DDown = new System.Windows.Forms.Label();
            this.lbl_DRight = new System.Windows.Forms.Label();
            this.lbl_DLeft = new System.Windows.Forms.Label();
            this.lbl_DUp = new System.Windows.Forms.Label();
            this.lbl_CDown = new System.Windows.Forms.Label();
            this.lbl_CRight = new System.Windows.Forms.Label();
            this.lbl_CLeft = new System.Windows.Forms.Label();
            this.lbl_CUp = new System.Windows.Forms.Label();
            this.lbl_L = new System.Windows.Forms.Label();
            this.lbl_R = new System.Windows.Forms.Label();
            this.lbl_Z = new System.Windows.Forms.Label();
            this.lbl_B = new System.Windows.Forms.Label();
            this.lbl_A = new System.Windows.Forms.Label();
            this.cbox_Ctl = new System.Windows.Forms.ComboBox();
            this.lbl_Ctl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gp_joystick = new System.Windows.Forms.GroupBox();
            this.lbl_SumX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_X = new System.Windows.Forms.TextBox();
            this.txt_Y = new System.Windows.Forms.TextBox();
            this.lbl_ABC = new System.Windows.Forms.Label();
            this.lbl_IsTAS = new System.Windows.Forms.Label();
            this.gp_Stats.SuspendLayout();
            this.gp_Buttons.SuspendLayout();
            this.gp_joystick.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_Stats
            // 
            this.gp_Stats.Controls.Add(this.lbl_IsTAS);
            this.gp_Stats.Controls.Add(this.lbl_ABC);
            this.gp_Stats.Controls.Add(this.gp_joystick);
            this.gp_Stats.Controls.Add(this.gp_Buttons);
            this.gp_Stats.Controls.Add(this.cbox_Ctl);
            this.gp_Stats.Controls.Add(this.lbl_Ctl);
            this.gp_Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Stats.Location = new System.Drawing.Point(0, 0);
            this.gp_Stats.Name = "gp_Stats";
            this.gp_Stats.Size = new System.Drawing.Size(582, 353);
            this.gp_Stats.TabIndex = 0;
            this.gp_Stats.TabStop = false;
            this.gp_Stats.Text = "Input Statistics";
            // 
            // gp_Buttons
            // 
            this.gp_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_Buttons.Controls.Add(this.lbl_Res2);
            this.gp_Buttons.Controls.Add(this.lbl_Res1);
            this.gp_Buttons.Controls.Add(this.label1);
            this.gp_Buttons.Controls.Add(this.lbl_Start);
            this.gp_Buttons.Controls.Add(this.lbl_DDown);
            this.gp_Buttons.Controls.Add(this.lbl_DRight);
            this.gp_Buttons.Controls.Add(this.lbl_DLeft);
            this.gp_Buttons.Controls.Add(this.lbl_DUp);
            this.gp_Buttons.Controls.Add(this.lbl_CDown);
            this.gp_Buttons.Controls.Add(this.lbl_CRight);
            this.gp_Buttons.Controls.Add(this.lbl_CLeft);
            this.gp_Buttons.Controls.Add(this.lbl_CUp);
            this.gp_Buttons.Controls.Add(this.lbl_L);
            this.gp_Buttons.Controls.Add(this.lbl_R);
            this.gp_Buttons.Controls.Add(this.lbl_Z);
            this.gp_Buttons.Controls.Add(this.lbl_B);
            this.gp_Buttons.Controls.Add(this.lbl_A);
            this.gp_Buttons.Location = new System.Drawing.Point(224, 64);
            this.gp_Buttons.Name = "gp_Buttons";
            this.gp_Buttons.Size = new System.Drawing.Size(355, 286);
            this.gp_Buttons.TabIndex = 0;
            this.gp_Buttons.TabStop = false;
            this.gp_Buttons.Text = "Buttons";
            // 
            // lbl_Res2
            // 
            this.lbl_Res2.AutoSize = true;
            this.lbl_Res2.Location = new System.Drawing.Point(136, 80);
            this.lbl_Res2.Name = "lbl_Res2";
            this.lbl_Res2.Size = new System.Drawing.Size(49, 17);
            this.lbl_Res2.TabIndex = 5;
            this.lbl_Res2.Text = "Res. 2";
            // 
            // lbl_Res1
            // 
            this.lbl_Res1.AutoSize = true;
            this.lbl_Res1.Location = new System.Drawing.Point(136, 56);
            this.lbl_Res1.Name = "lbl_Res1";
            this.lbl_Res1.Size = new System.Drawing.Size(49, 17);
            this.lbl_Res1.TabIndex = 6;
            this.lbl_Res1.Text = "Res. 1";
            // 
            // lbl_Start
            // 
            this.lbl_Start.AutoSize = true;
            this.lbl_Start.Location = new System.Drawing.Point(136, 32);
            this.lbl_Start.Name = "lbl_Start";
            this.lbl_Start.Size = new System.Drawing.Size(38, 17);
            this.lbl_Start.TabIndex = 7;
            this.lbl_Start.Text = "Start";
            // 
            // lbl_DDown
            // 
            this.lbl_DDown.AutoSize = true;
            this.lbl_DDown.Location = new System.Drawing.Point(136, 224);
            this.lbl_DDown.Name = "lbl_DDown";
            this.lbl_DDown.Size = new System.Drawing.Size(25, 17);
            this.lbl_DDown.TabIndex = 1;
            this.lbl_DDown.Text = "Dv";
            // 
            // lbl_DRight
            // 
            this.lbl_DRight.AutoSize = true;
            this.lbl_DRight.Location = new System.Drawing.Point(136, 200);
            this.lbl_DRight.Name = "lbl_DRight";
            this.lbl_DRight.Size = new System.Drawing.Size(26, 17);
            this.lbl_DRight.TabIndex = 2;
            this.lbl_DRight.Text = "D>";
            // 
            // lbl_DLeft
            // 
            this.lbl_DLeft.AutoSize = true;
            this.lbl_DLeft.Location = new System.Drawing.Point(136, 176);
            this.lbl_DLeft.Name = "lbl_DLeft";
            this.lbl_DLeft.Size = new System.Drawing.Size(26, 17);
            this.lbl_DLeft.TabIndex = 3;
            this.lbl_DLeft.Text = "D<";
            // 
            // lbl_DUp
            // 
            this.lbl_DUp.AutoSize = true;
            this.lbl_DUp.Location = new System.Drawing.Point(136, 152);
            this.lbl_DUp.Name = "lbl_DUp";
            this.lbl_DUp.Size = new System.Drawing.Size(25, 17);
            this.lbl_DUp.TabIndex = 4;
            this.lbl_DUp.Text = "D^";
            // 
            // lbl_CDown
            // 
            this.lbl_CDown.AutoSize = true;
            this.lbl_CDown.Location = new System.Drawing.Point(16, 224);
            this.lbl_CDown.Name = "lbl_CDown";
            this.lbl_CDown.Size = new System.Drawing.Size(24, 17);
            this.lbl_CDown.TabIndex = 0;
            this.lbl_CDown.Text = "Cv";
            // 
            // lbl_CRight
            // 
            this.lbl_CRight.AutoSize = true;
            this.lbl_CRight.Location = new System.Drawing.Point(16, 200);
            this.lbl_CRight.Name = "lbl_CRight";
            this.lbl_CRight.Size = new System.Drawing.Size(25, 17);
            this.lbl_CRight.TabIndex = 0;
            this.lbl_CRight.Text = "C>";
            // 
            // lbl_CLeft
            // 
            this.lbl_CLeft.AutoSize = true;
            this.lbl_CLeft.Location = new System.Drawing.Point(16, 176);
            this.lbl_CLeft.Name = "lbl_CLeft";
            this.lbl_CLeft.Size = new System.Drawing.Size(25, 17);
            this.lbl_CLeft.TabIndex = 0;
            this.lbl_CLeft.Text = "C<";
            // 
            // lbl_CUp
            // 
            this.lbl_CUp.AutoSize = true;
            this.lbl_CUp.Location = new System.Drawing.Point(16, 152);
            this.lbl_CUp.Name = "lbl_CUp";
            this.lbl_CUp.Size = new System.Drawing.Size(24, 17);
            this.lbl_CUp.TabIndex = 0;
            this.lbl_CUp.Text = "C^";
            // 
            // lbl_L
            // 
            this.lbl_L.AutoSize = true;
            this.lbl_L.Location = new System.Drawing.Point(16, 128);
            this.lbl_L.Name = "lbl_L";
            this.lbl_L.Size = new System.Drawing.Size(16, 17);
            this.lbl_L.TabIndex = 0;
            this.lbl_L.Text = "L";
            // 
            // lbl_R
            // 
            this.lbl_R.AutoSize = true;
            this.lbl_R.Location = new System.Drawing.Point(16, 104);
            this.lbl_R.Name = "lbl_R";
            this.lbl_R.Size = new System.Drawing.Size(18, 17);
            this.lbl_R.TabIndex = 0;
            this.lbl_R.Text = "R";
            // 
            // lbl_Z
            // 
            this.lbl_Z.AutoSize = true;
            this.lbl_Z.Location = new System.Drawing.Point(16, 80);
            this.lbl_Z.Name = "lbl_Z";
            this.lbl_Z.Size = new System.Drawing.Size(17, 17);
            this.lbl_Z.TabIndex = 0;
            this.lbl_Z.Text = "Z";
            // 
            // lbl_B
            // 
            this.lbl_B.AutoSize = true;
            this.lbl_B.Location = new System.Drawing.Point(16, 56);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(17, 17);
            this.lbl_B.TabIndex = 0;
            this.lbl_B.Text = "B";
            // 
            // lbl_A
            // 
            this.lbl_A.AutoSize = true;
            this.lbl_A.Location = new System.Drawing.Point(16, 32);
            this.lbl_A.Name = "lbl_A";
            this.lbl_A.Size = new System.Drawing.Size(17, 17);
            this.lbl_A.TabIndex = 0;
            this.lbl_A.Text = "A";
            // 
            // cbox_Ctl
            // 
            this.cbox_Ctl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Ctl.FormattingEnabled = true;
            this.cbox_Ctl.Location = new System.Drawing.Point(96, 32);
            this.cbox_Ctl.Name = "cbox_Ctl";
            this.cbox_Ctl.Size = new System.Drawing.Size(121, 24);
            this.cbox_Ctl.TabIndex = 1;
            this.cbox_Ctl.SelectedIndexChanged += new System.EventHandler(this.cbox_Ctl_SelectedIndexChanged);
            // 
            // lbl_Ctl
            // 
            this.lbl_Ctl.AutoSize = true;
            this.lbl_Ctl.Location = new System.Drawing.Point(16, 36);
            this.lbl_Ctl.Name = "lbl_Ctl";
            this.lbl_Ctl.Size = new System.Drawing.Size(69, 17);
            this.lbl_Ctl.TabIndex = 0;
            this.lbl_Ctl.Text = "Controller";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 7;
            // 
            // gp_joystick
            // 
            this.gp_joystick.Controls.Add(this.txt_Y);
            this.gp_joystick.Controls.Add(this.txt_X);
            this.gp_joystick.Controls.Add(this.label2);
            this.gp_joystick.Controls.Add(this.lbl_SumX);
            this.gp_joystick.Location = new System.Drawing.Point(8, 64);
            this.gp_joystick.Name = "gp_joystick";
            this.gp_joystick.Size = new System.Drawing.Size(208, 288);
            this.gp_joystick.TabIndex = 0;
            this.gp_joystick.TabStop = false;
            this.gp_joystick.Text = "Joystick";
            // 
            // lbl_SumX
            // 
            this.lbl_SumX.AutoSize = true;
            this.lbl_SumX.Location = new System.Drawing.Point(16, 40);
            this.lbl_SumX.Name = "lbl_SumX";
            this.lbl_SumX.Size = new System.Drawing.Size(94, 17);
            this.lbl_SumX.TabIndex = 0;
            this.lbl_SumX.Text = "Sum of X Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sum of Y Axis";
            // 
            // txt_X
            // 
            this.txt_X.Location = new System.Drawing.Point(16, 64);
            this.txt_X.Multiline = true;
            this.txt_X.Name = "txt_X";
            this.txt_X.ReadOnly = true;
            this.txt_X.Size = new System.Drawing.Size(176, 80);
            this.txt_X.TabIndex = 1;
            // 
            // txt_Y
            // 
            this.txt_Y.Location = new System.Drawing.Point(16, 192);
            this.txt_Y.Multiline = true;
            this.txt_Y.Name = "txt_Y";
            this.txt_Y.ReadOnly = true;
            this.txt_Y.Size = new System.Drawing.Size(176, 80);
            this.txt_Y.TabIndex = 1;
            // 
            // lbl_ABC
            // 
            this.lbl_ABC.AutoSize = true;
            this.lbl_ABC.Location = new System.Drawing.Point(248, 32);
            this.lbl_ABC.Name = "lbl_ABC";
            this.lbl_ABC.Size = new System.Drawing.Size(53, 17);
            this.lbl_ABC.TabIndex = 0;
            this.lbl_ABC.Text = "Is ABC:";
            // 
            // lbl_IsTAS
            // 
            this.lbl_IsTAS.AutoSize = true;
            this.lbl_IsTAS.Location = new System.Drawing.Point(376, 32);
            this.lbl_IsTAS.Name = "lbl_IsTAS";
            this.lbl_IsTAS.Size = new System.Drawing.Size(53, 17);
            this.lbl_IsTAS.TabIndex = 0;
            this.lbl_IsTAS.Text = "Is TAS:";
            // 
            // InputStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.gp_Stats);
            this.MaximizeBox = false;
            this.Name = "InputStatsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputStatsForm";
            this.Shown += new System.EventHandler(this.InputStatsForm_Shown);
            this.gp_Stats.ResumeLayout(false);
            this.gp_Stats.PerformLayout();
            this.gp_Buttons.ResumeLayout(false);
            this.gp_Buttons.PerformLayout();
            this.gp_joystick.ResumeLayout(false);
            this.gp_joystick.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_Stats;
        private System.Windows.Forms.ComboBox cbox_Ctl;
        private System.Windows.Forms.Label lbl_Ctl;
        private System.Windows.Forms.GroupBox gp_Buttons;
        private System.Windows.Forms.Label lbl_DDown;
        private System.Windows.Forms.Label lbl_DRight;
        private System.Windows.Forms.Label lbl_DLeft;
        private System.Windows.Forms.Label lbl_DUp;
        private System.Windows.Forms.Label lbl_CDown;
        private System.Windows.Forms.Label lbl_CRight;
        private System.Windows.Forms.Label lbl_CLeft;
        private System.Windows.Forms.Label lbl_CUp;
        private System.Windows.Forms.Label lbl_L;
        private System.Windows.Forms.Label lbl_R;
        private System.Windows.Forms.Label lbl_Z;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.Label lbl_A;
        private System.Windows.Forms.Label lbl_Res2;
        private System.Windows.Forms.Label lbl_Res1;
        private System.Windows.Forms.Label lbl_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gp_joystick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_SumX;
        private System.Windows.Forms.TextBox txt_Y;
        private System.Windows.Forms.TextBox txt_X;
        private System.Windows.Forms.Label lbl_IsTAS;
        private System.Windows.Forms.Label lbl_ABC;
    }
}