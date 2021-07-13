
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
            this.panel_MupenHook = new System.Windows.Forms.Panel();
            this.gp_General = new System.Windows.Forms.GroupBox();
            this.lbl_ProcName = new System.Windows.Forms.Label();
            this.lbl_Ver = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_NameVer = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_SaveLog = new System.Windows.Forms.Button();
            this.panel_MupenHook.SuspendLayout();
            this.gp_General.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MupenHook
            // 
            this.panel_MupenHook.Controls.Add(this.gp_General);
            this.panel_MupenHook.Controls.Add(this.btn_SaveLog);
            this.panel_MupenHook.Controls.Add(this.btn_Stop);
            this.panel_MupenHook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MupenHook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_MupenHook.Location = new System.Drawing.Point(0, 0);
            this.panel_MupenHook.Name = "panel_MupenHook";
            this.panel_MupenHook.Size = new System.Drawing.Size(453, 199);
            this.panel_MupenHook.TabIndex = 0;
            // 
            // gp_General
            // 
            this.gp_General.Controls.Add(this.lbl_ProcName);
            this.gp_General.Controls.Add(this.lbl_Ver);
            this.gp_General.Controls.Add(this.lbl_Name);
            this.gp_General.Controls.Add(this.lbl_NameVer);
            this.gp_General.Location = new System.Drawing.Point(12, 12);
            this.gp_General.Name = "gp_General";
            this.gp_General.Size = new System.Drawing.Size(347, 175);
            this.gp_General.TabIndex = 0;
            this.gp_General.TabStop = false;
            this.gp_General.Text = "General";
            // 
            // lbl_ProcName
            // 
            this.lbl_ProcName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_ProcName.AutoSize = true;
            this.lbl_ProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProcName.Location = new System.Drawing.Point(6, 30);
            this.lbl_ProcName.Name = "lbl_ProcName";
            this.lbl_ProcName.Size = new System.Drawing.Size(130, 20);
            this.lbl_ProcName.TabIndex = 0;
            this.lbl_ProcName.Text = "Process Name: ";
            // 
            // lbl_Ver
            // 
            this.lbl_Ver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Ver.AutoSize = true;
            this.lbl_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ver.Location = new System.Drawing.Point(6, 90);
            this.lbl_Ver.Name = "lbl_Ver";
            this.lbl_Ver.Size = new System.Drawing.Size(76, 20);
            this.lbl_Ver.TabIndex = 0;
            this.lbl_Ver.Text = "Version: ";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(6, 70);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(63, 20);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name: ";
            // 
            // lbl_NameVer
            // 
            this.lbl_NameVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_NameVer.AutoSize = true;
            this.lbl_NameVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NameVer.Location = new System.Drawing.Point(6, 50);
            this.lbl_NameVer.Name = "lbl_NameVer";
            this.lbl_NameVer.Size = new System.Drawing.Size(157, 20);
            this.lbl_NameVer.TabIndex = 0;
            this.lbl_NameVer.Text = "Name and Version: ";
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Stop.FlatAppearance.BorderSize = 0;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.Location = new System.Drawing.Point(365, 155);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(80, 32);
            this.btn_Stop.TabIndex = 0;
            this.btn_Stop.TabStop = false;
            this.btn_Stop.Text = "Exit";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_SaveLog
            // 
            this.btn_SaveLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_SaveLog.FlatAppearance.BorderSize = 0;
            this.btn_SaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveLog.Location = new System.Drawing.Point(365, 117);
            this.btn_SaveLog.Name = "btn_SaveLog";
            this.btn_SaveLog.Size = new System.Drawing.Size(80, 32);
            this.btn_SaveLog.TabIndex = 0;
            this.btn_SaveLog.TabStop = false;
            this.btn_SaveLog.Text = "Save";
            this.btn_SaveLog.UseVisualStyleBackColor = false;
            this.btn_SaveLog.Click += new System.EventHandler(this.btn_SaveLog_Click);
            // 
            // MupenHookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(453, 199);
            this.ControlBox = false;
            this.Controls.Add(this.panel_MupenHook);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MupenHookForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MupenHookForm";
            this.Load += new System.EventHandler(this.MupenHookForm_Load);
            this.Shown += new System.EventHandler(this.MupenHookForm_Shown);
            this.panel_MupenHook.ResumeLayout(false);
            this.gp_General.ResumeLayout(false);
            this.gp_General.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_MupenHook;
        private System.Windows.Forms.Label lbl_NameVer;
        private System.Windows.Forms.Label lbl_ProcName;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.GroupBox gp_General;
        private System.Windows.Forms.Label lbl_Ver;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btn_SaveLog;
    }
}