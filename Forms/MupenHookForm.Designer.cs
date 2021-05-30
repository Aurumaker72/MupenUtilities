﻿
namespace MupenUtils.Forms
{
    partial class MupenHookForm
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
            this.panel_LoadingMupen = new System.Windows.Forms.Panel();
            this.lc_Loading = new MRG.Controls.UI.LoadingCircle();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.panel_MupenHook = new System.Windows.Forms.Panel();
            this.lbl_ProcName = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.panel_LoadingMupen.SuspendLayout();
            this.panel_MupenHook.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_LoadingMupen
            // 
            this.panel_LoadingMupen.BackColor = System.Drawing.SystemColors.Control;
            this.panel_LoadingMupen.Controls.Add(this.lc_Loading);
            this.panel_LoadingMupen.Controls.Add(this.lbl_Loading);
            this.panel_LoadingMupen.Location = new System.Drawing.Point(240, 16);
            this.panel_LoadingMupen.Name = "panel_LoadingMupen";
            this.panel_LoadingMupen.Size = new System.Drawing.Size(248, 152);
            this.panel_LoadingMupen.TabIndex = 0;
            // 
            // lc_Loading
            // 
            this.lc_Loading.Active = true;
            this.lc_Loading.BackColor = System.Drawing.Color.Transparent;
            this.lc_Loading.Color = System.Drawing.Color.Black;
            this.lc_Loading.InnerCircleRadius = 5;
            this.lc_Loading.Location = new System.Drawing.Point(104, 56);
            this.lc_Loading.Name = "lc_Loading";
            this.lc_Loading.NumberSpoke = 12;
            this.lc_Loading.OuterCircleRadius = 11;
            this.lc_Loading.RotationSpeed = 100;
            this.lc_Loading.Size = new System.Drawing.Size(200, 128);
            this.lc_Loading.SpokeThickness = 2;
            this.lc_Loading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.lc_Loading.TabIndex = 0;
            this.lc_Loading.TabStop = false;
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Loading.ForeColor = System.Drawing.Color.Black;
            this.lbl_Loading.Location = new System.Drawing.Point(144, 16);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(118, 32);
            this.lbl_Loading.TabIndex = 0;
            this.lbl_Loading.Text = "Loading";
            // 
            // panel_MupenHook
            // 
            this.panel_MupenHook.Controls.Add(this.lbl_Name);
            this.panel_MupenHook.Controls.Add(this.lbl_ProcName);
            this.panel_MupenHook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_MupenHook.Location = new System.Drawing.Point(24, 16);
            this.panel_MupenHook.Name = "panel_MupenHook";
            this.panel_MupenHook.Size = new System.Drawing.Size(200, 100);
            this.panel_MupenHook.TabIndex = 0;
            this.panel_MupenHook.Visible = false;
            // 
            // lbl_ProcName
            // 
            this.lbl_ProcName.AutoSize = true;
            this.lbl_ProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProcName.Location = new System.Drawing.Point(8, 16);
            this.lbl_ProcName.Name = "lbl_ProcName";
            this.lbl_ProcName.Size = new System.Drawing.Size(139, 24);
            this.lbl_ProcName.TabIndex = 0;
            this.lbl_ProcName.Text = "Process Name ";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(8, 48);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(66, 24);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name ";
            // 
            // MupenHookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 199);
            this.Controls.Add(this.panel_LoadingMupen);
            this.Controls.Add(this.panel_MupenHook);
            this.MaximizeBox = false;
            this.Name = "MupenHookForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MupenHookForm";
            this.Load += new System.EventHandler(this.MupenHookForm_Load);
            this.Shown += new System.EventHandler(this.MupenHookForm_Shown);
            this.panel_LoadingMupen.ResumeLayout(false);
            this.panel_LoadingMupen.PerformLayout();
            this.panel_MupenHook.ResumeLayout(false);
            this.panel_MupenHook.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_LoadingMupen;
        private System.Windows.Forms.Label lbl_Loading;
        private MRG.Controls.UI.LoadingCircle lc_Loading;
        private System.Windows.Forms.Panel panel_MupenHook;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_ProcName;
    }
}