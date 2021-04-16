
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreForm));
            this.gp_More_Tips = new System.Windows.Forms.GroupBox();
            this.lbl_More_TipInfo = new System.Windows.Forms.Label();
            this.lbl_More_Tip = new System.Windows.Forms.Label();
            this.btn_More_NewTip = new System.Windows.Forms.Button();
            this.gp_More_About = new System.Windows.Forms.GroupBox();
            this.btn_More_CheckUpdates = new System.Windows.Forms.Button();
            this.lbl_More_Related2 = new System.Windows.Forms.Label();
            this.lbl_More_Related = new System.Windows.Forms.Label();
            this.Llbl_More_MupenCringe = new System.Windows.Forms.LinkLabel();
            this.Llbl_More_Resources = new System.Windows.Forms.LinkLabel();
            this.Llbl_More_Mupen = new System.Windows.Forms.LinkLabel();
            this.txt_More_Info = new System.Windows.Forms.TextBox();
            this.pb_More_Logo = new System.Windows.Forms.PictureBox();
            this.btn_More_AllTips = new System.Windows.Forms.Button();
            this.gp_More_Tips.SuspendLayout();
            this.gp_More_About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_More_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_More_Tips
            // 
            this.gp_More_Tips.Controls.Add(this.lbl_More_TipInfo);
            this.gp_More_Tips.Controls.Add(this.lbl_More_Tip);
            this.gp_More_Tips.Controls.Add(this.btn_More_AllTips);
            this.gp_More_Tips.Controls.Add(this.btn_More_NewTip);
            this.gp_More_Tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.gp_More_Tips.Location = new System.Drawing.Point(0, 0);
            this.gp_More_Tips.Name = "gp_More_Tips";
            this.gp_More_Tips.Size = new System.Drawing.Size(534, 144);
            this.gp_More_Tips.TabIndex = 0;
            this.gp_More_Tips.TabStop = false;
            this.gp_More_Tips.Text = "Tips";
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
            this.lbl_More_TipInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.event_NewTip);
            // 
            // lbl_More_Tip
            // 
            this.lbl_More_Tip.AutoSize = true;
            this.lbl_More_Tip.Location = new System.Drawing.Point(72, 40);
            this.lbl_More_Tip.Name = "lbl_More_Tip";
            this.lbl_More_Tip.Size = new System.Drawing.Size(337, 17);
            this.lbl_More_Tip.TabIndex = 0;
            this.lbl_More_Tip.Text = "Press the \"New Tip\" button or \"Tip\" text to show a tip";
            this.lbl_More_Tip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_More_Tip_MouseDown);
            // 
            // btn_More_NewTip
            // 
            this.btn_More_NewTip.Location = new System.Drawing.Point(448, 104);
            this.btn_More_NewTip.Name = "btn_More_NewTip";
            this.btn_More_NewTip.Size = new System.Drawing.Size(75, 31);
            this.btn_More_NewTip.TabIndex = 0;
            this.btn_More_NewTip.TabStop = false;
            this.btn_More_NewTip.Text = "New Tip";
            this.btn_More_NewTip.UseVisualStyleBackColor = true;
            this.btn_More_NewTip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.event_NewTip);
            // 
            // gp_More_About
            // 
            this.gp_More_About.Controls.Add(this.btn_More_CheckUpdates);
            this.gp_More_About.Controls.Add(this.lbl_More_Related2);
            this.gp_More_About.Controls.Add(this.lbl_More_Related);
            this.gp_More_About.Controls.Add(this.Llbl_More_MupenCringe);
            this.gp_More_About.Controls.Add(this.Llbl_More_Resources);
            this.gp_More_About.Controls.Add(this.Llbl_More_Mupen);
            this.gp_More_About.Controls.Add(this.txt_More_Info);
            this.gp_More_About.Controls.Add(this.pb_More_Logo);
            this.gp_More_About.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gp_More_About.Location = new System.Drawing.Point(0, 144);
            this.gp_More_About.Name = "gp_More_About";
            this.gp_More_About.Size = new System.Drawing.Size(534, 260);
            this.gp_More_About.TabIndex = 0;
            this.gp_More_About.TabStop = false;
            this.gp_More_About.Text = "About";
            // 
            // btn_More_CheckUpdates
            // 
            this.btn_More_CheckUpdates.Location = new System.Drawing.Point(384, 224);
            this.btn_More_CheckUpdates.Name = "btn_More_CheckUpdates";
            this.btn_More_CheckUpdates.Size = new System.Drawing.Size(139, 31);
            this.btn_More_CheckUpdates.TabIndex = 0;
            this.btn_More_CheckUpdates.TabStop = false;
            this.btn_More_CheckUpdates.Text = "Check for Updates";
            this.btn_More_CheckUpdates.UseVisualStyleBackColor = true;
            this.btn_More_CheckUpdates.Click += new System.EventHandler(this.btn_More_CheckUpdates_Click);
            // 
            // lbl_More_Related2
            // 
            this.lbl_More_Related2.AutoSize = true;
            this.lbl_More_Related2.Location = new System.Drawing.Point(16, 152);
            this.lbl_More_Related2.Name = "lbl_More_Related2";
            this.lbl_More_Related2.Size = new System.Drawing.Size(157, 17);
            this.lbl_More_Related2.TabIndex = 0;
            this.lbl_More_Related2.Text = "Other useful resources:";
            // 
            // lbl_More_Related
            // 
            this.lbl_More_Related.AutoSize = true;
            this.lbl_More_Related.Location = new System.Drawing.Point(16, 128);
            this.lbl_More_Related.Name = "lbl_More_Related";
            this.lbl_More_Related.Size = new System.Drawing.Size(112, 17);
            this.lbl_More_Related.TabIndex = 0;
            this.lbl_More_Related.Text = "To be used with:";
            // 
            // Llbl_More_MupenCringe
            // 
            this.Llbl_More_MupenCringe.ActiveLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_MupenCringe.AutoSize = true;
            this.Llbl_More_MupenCringe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Llbl_More_MupenCringe.Location = new System.Drawing.Point(288, 152);
            this.Llbl_More_MupenCringe.Name = "Llbl_More_MupenCringe";
            this.Llbl_More_MupenCringe.Size = new System.Drawing.Size(125, 17);
            this.Llbl_More_MupenCringe.TabIndex = 0;
            this.Llbl_More_MupenCringe.TabStop = true;
            this.Llbl_More_MupenCringe.Text = "Mupen TASVideos";
            this.Llbl_More_MupenCringe.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_MupenCringe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_More_MupenCringe_LinkClicked);
            // 
            // Llbl_More_Resources
            // 
            this.Llbl_More_Resources.ActiveLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_Resources.AutoSize = true;
            this.Llbl_More_Resources.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Llbl_More_Resources.Location = new System.Drawing.Point(176, 152);
            this.Llbl_More_Resources.Name = "Llbl_More_Resources";
            this.Llbl_More_Resources.Size = new System.Drawing.Size(107, 17);
            this.Llbl_More_Resources.TabIndex = 0;
            this.Llbl_More_Resources.TabStop = true;
            this.Llbl_More_Resources.Text = "TAS Resources";
            this.Llbl_More_Resources.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_Resources.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_More_Resources_LinkClicked);
            // 
            // Llbl_More_Mupen
            // 
            this.Llbl_More_Mupen.ActiveLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_Mupen.AutoSize = true;
            this.Llbl_More_Mupen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Llbl_More_Mupen.Location = new System.Drawing.Point(128, 128);
            this.Llbl_More_Mupen.Name = "Llbl_More_Mupen";
            this.Llbl_More_Mupen.Size = new System.Drawing.Size(104, 17);
            this.Llbl_More_Mupen.TabIndex = 0;
            this.Llbl_More_Mupen.TabStop = true;
            this.Llbl_More_Mupen.Text = "Mupen64 rr lua";
            this.Llbl_More_Mupen.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Llbl_More_Mupen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_More_Mupen_LinkClicked);
            // 
            // txt_More_Info
            // 
            this.txt_More_Info.Location = new System.Drawing.Point(112, 32);
            this.txt_More_Info.Multiline = true;
            this.txt_More_Info.Name = "txt_More_Info";
            this.txt_More_Info.ReadOnly = true;
            this.txt_More_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_More_Info.Size = new System.Drawing.Size(408, 80);
            this.txt_More_Info.TabIndex = 0;
            this.txt_More_Info.TabStop = false;
            this.txt_More_Info.Text = resources.GetString("txt_More_Info.Text");
            // 
            // pb_More_Logo
            // 
            this.pb_More_Logo.BackgroundImage = global::MupenUtils.Properties.Resources.logo;
            this.pb_More_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_More_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_More_Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_More_Logo.Location = new System.Drawing.Point(16, 32);
            this.pb_More_Logo.Name = "pb_More_Logo";
            this.pb_More_Logo.Size = new System.Drawing.Size(88, 80);
            this.pb_More_Logo.TabIndex = 0;
            this.pb_More_Logo.TabStop = false;
            this.pb_More_Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_More_Logo_MouseDown);
            // 
            // btn_More_AllTips
            // 
            this.btn_More_AllTips.Location = new System.Drawing.Point(368, 104);
            this.btn_More_AllTips.Name = "btn_More_AllTips";
            this.btn_More_AllTips.Size = new System.Drawing.Size(75, 31);
            this.btn_More_AllTips.TabIndex = 0;
            this.btn_More_AllTips.TabStop = false;
            this.btn_More_AllTips.Text = "All Tips";
            this.btn_More_AllTips.UseVisualStyleBackColor = true;
            this.btn_More_AllTips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.event_AllTips);
            // 
            // MoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(534, 404);
            this.Controls.Add(this.gp_More_About);
            this.Controls.Add(this.gp_More_Tips);
            this.MaximizeBox = false;
            this.Name = "MoreForm";
            this.ShowIcon = false;
            this.gp_More_Tips.ResumeLayout(false);
            this.gp_More_Tips.PerformLayout();
            this.gp_More_About.ResumeLayout(false);
            this.gp_More_About.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_More_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_More_Tips;
        private System.Windows.Forms.Button btn_More_NewTip;
        private System.Windows.Forms.Label lbl_More_TipInfo;
        private System.Windows.Forms.Label lbl_More_Tip;
        private System.Windows.Forms.GroupBox gp_More_About;
        private System.Windows.Forms.PictureBox pb_More_Logo;
        private System.Windows.Forms.TextBox txt_More_Info;
        private System.Windows.Forms.LinkLabel Llbl_More_Mupen;
        private System.Windows.Forms.Label lbl_More_Related2;
        private System.Windows.Forms.Label lbl_More_Related;
        private System.Windows.Forms.LinkLabel Llbl_More_Resources;
        private System.Windows.Forms.LinkLabel Llbl_More_MupenCringe;
        private System.Windows.Forms.Button btn_More_CheckUpdates;
        private System.Windows.Forms.Button btn_More_AllTips;
    }
}