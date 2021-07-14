
namespace MupenUtils.Forms
{
    partial class ExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.lbl_Exception = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.llbl_Issues = new System.Windows.Forms.LinkLabel();
            this.btn_Continue = new System.Windows.Forms.Button();
            this.pb_LogoBad = new System.Windows.Forms.PictureBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_CrashLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LogoBad)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Exception
            // 
            this.lbl_Exception.AutoSize = true;
            this.lbl_Exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exception.Location = new System.Drawing.Point(200, 16);
            this.lbl_Exception.Name = "lbl_Exception";
            this.lbl_Exception.Size = new System.Drawing.Size(395, 32);
            this.lbl_Exception.TabIndex = 0;
            this.lbl_Exception.Text = "An exception has been thrown";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(208, 64);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(298, 96);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = resources.GetString("lbl_info.Text");
            // 
            // llbl_Issues
            // 
            this.llbl_Issues.AutoSize = true;
            this.llbl_Issues.Location = new System.Drawing.Point(16, 192);
            this.llbl_Issues.Name = "llbl_Issues";
            this.llbl_Issues.Size = new System.Drawing.Size(110, 16);
            this.llbl_Issues.TabIndex = 0;
            this.llbl_Issues.TabStop = true;
            this.llbl_Issues.Text = "Post Github Issue";
            this.llbl_Issues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_Issues_LinkClicked);
            // 
            // btn_Continue
            // 
            this.btn_Continue.Location = new System.Drawing.Point(208, 296);
            this.btn_Continue.Name = "btn_Continue";
            this.btn_Continue.Size = new System.Drawing.Size(88, 32);
            this.btn_Continue.TabIndex = 0;
            this.btn_Continue.TabStop = false;
            this.btn_Continue.Text = "Continue";
            this.btn_Continue.UseVisualStyleBackColor = true;
            this.btn_Continue.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // pb_LogoBad
            // 
            this.pb_LogoBad.BackgroundImage = global::MupenUtilities.Properties.Resources.mupenbw;
            this.pb_LogoBad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_LogoBad.Location = new System.Drawing.Point(16, 16);
            this.pb_LogoBad.Name = "pb_LogoBad";
            this.pb_LogoBad.Size = new System.Drawing.Size(176, 160);
            this.pb_LogoBad.TabIndex = 0;
            this.pb_LogoBad.TabStop = false;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(504, 296);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(88, 32);
            this.btn_Quit.TabIndex = 0;
            this.btn_Quit.TabStop = false;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_CrashLog
            // 
            this.btn_CrashLog.Location = new System.Drawing.Point(304, 296);
            this.btn_CrashLog.Name = "btn_CrashLog";
            this.btn_CrashLog.Size = new System.Drawing.Size(192, 32);
            this.btn_CrashLog.TabIndex = 0;
            this.btn_CrashLog.TabStop = false;
            this.btn_CrashLog.Text = "Dump Crash Log";
            this.btn_CrashLog.UseVisualStyleBackColor = true;
            this.btn_CrashLog.Click += new System.EventHandler(this.btn_CrashLog_Click);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(599, 338);
            this.Controls.Add(this.btn_CrashLog);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Continue);
            this.Controls.Add(this.llbl_Issues);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_Exception);
            this.Controls.Add(this.pb_LogoBad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ExceptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExceptionForm";
            this.Deactivate += new System.EventHandler(this.FocusLost);
            this.Shown += new System.EventHandler(this.ExceptionForm_Shown);
            this.LostFocus += new System.EventHandler(this.FocusLost);
            ((System.ComponentModel.ISupportInitialize)(this.pb_LogoBad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_LogoBad;
        private System.Windows.Forms.Label lbl_Exception;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.LinkLabel llbl_Issues;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_CrashLog;
    }
}