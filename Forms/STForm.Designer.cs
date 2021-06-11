﻿
namespace MupenUtils.Forms
{
    partial class STForm
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
            this.gp_st = new System.Windows.Forms.GroupBox();
            this.gp_RDRAM = new System.Windows.Forms.GroupBox();
            this.btn_SaveST = new System.Windows.Forms.Button();
            this.btn_Disallow = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Edit = new System.Windows.Forms.TextBox();
            this.txt_RDRAM = new System.Windows.Forms.TextBox();
            this.lbl_Saved = new System.Windows.Forms.Label();
            this.lbl_Interact = new System.Windows.Forms.Label();
            this.lbl_live = new System.Windows.Forms.Label();
            this.btn_RDRAMOffsetHelp = new System.Windows.Forms.Button();
            this.lbl_RDRAMOff = new System.Windows.Forms.Label();
            this.txt_rdramoffset = new System.Windows.Forms.TextBox();
            this.ls_SAVED = new System.Windows.Forms.ListBox();
            this.gp_st.SuspendLayout();
            this.gp_RDRAM.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_st
            // 
            this.gp_st.Controls.Add(this.gp_RDRAM);
            this.gp_st.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_st.Location = new System.Drawing.Point(0, 0);
            this.gp_st.Name = "gp_st";
            this.gp_st.Size = new System.Drawing.Size(762, 453);
            this.gp_st.TabIndex = 1;
            this.gp_st.TabStop = false;
            this.gp_st.Text = "Savestate";
            // 
            // gp_RDRAM
            // 
            this.gp_RDRAM.Controls.Add(this.btn_SaveST);
            this.gp_RDRAM.Controls.Add(this.btn_Disallow);
            this.gp_RDRAM.Controls.Add(this.btn_Remove);
            this.gp_RDRAM.Controls.Add(this.btn_Save);
            this.gp_RDRAM.Controls.Add(this.txt_Edit);
            this.gp_RDRAM.Controls.Add(this.txt_RDRAM);
            this.gp_RDRAM.Controls.Add(this.lbl_Saved);
            this.gp_RDRAM.Controls.Add(this.lbl_Interact);
            this.gp_RDRAM.Controls.Add(this.lbl_live);
            this.gp_RDRAM.Controls.Add(this.btn_RDRAMOffsetHelp);
            this.gp_RDRAM.Controls.Add(this.lbl_RDRAMOff);
            this.gp_RDRAM.Controls.Add(this.txt_rdramoffset);
            this.gp_RDRAM.Controls.Add(this.ls_SAVED);
            this.gp_RDRAM.Dock = System.Windows.Forms.DockStyle.Left;
            this.gp_RDRAM.Location = new System.Drawing.Point(3, 18);
            this.gp_RDRAM.Name = "gp_RDRAM";
            this.gp_RDRAM.Size = new System.Drawing.Size(437, 432);
            this.gp_RDRAM.TabIndex = 1;
            this.gp_RDRAM.TabStop = false;
            this.gp_RDRAM.Text = "RDRAM";
            // 
            // btn_SaveST
            // 
            this.btn_SaveST.Location = new System.Drawing.Point(352, 400);
            this.btn_SaveST.Name = "btn_SaveST";
            this.btn_SaveST.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveST.TabIndex = 0;
            this.btn_SaveST.TabStop = false;
            this.btn_SaveST.Text = "Save ST";
            this.btn_SaveST.UseVisualStyleBackColor = true;
            this.btn_SaveST.Click += new System.EventHandler(this.btn_SaveST_Click);
            // 
            // btn_Disallow
            // 
            this.btn_Disallow.Location = new System.Drawing.Point(128, 40);
            this.btn_Disallow.Name = "btn_Disallow";
            this.btn_Disallow.Size = new System.Drawing.Size(75, 24);
            this.btn_Disallow.TabIndex = 0;
            this.btn_Disallow.TabStop = false;
            this.btn_Disallow.Text = "Block";
            this.btn_Disallow.UseVisualStyleBackColor = true;
            this.btn_Disallow.Click += new System.EventHandler(this.btn_Disallow_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(352, 200);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 24);
            this.btn_Remove.TabIndex = 0;
            this.btn_Remove.TabStop = false;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(208, 40);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 24);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.TabStop = false;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Edit
            // 
            this.txt_Edit.Location = new System.Drawing.Point(288, 16);
            this.txt_Edit.MaxLength = 4;
            this.txt_Edit.Name = "txt_Edit";
            this.txt_Edit.Size = new System.Drawing.Size(136, 22);
            this.txt_Edit.TabIndex = 0;
            this.txt_Edit.TabStop = false;
            this.txt_Edit.TextChanged += new System.EventHandler(this.txt_Edit_TextChanged);
            // 
            // txt_RDRAM
            // 
            this.txt_RDRAM.Location = new System.Drawing.Point(128, 16);
            this.txt_RDRAM.Name = "txt_RDRAM";
            this.txt_RDRAM.ReadOnly = true;
            this.txt_RDRAM.Size = new System.Drawing.Size(154, 22);
            this.txt_RDRAM.TabIndex = 0;
            this.txt_RDRAM.TabStop = false;
            // 
            // lbl_Saved
            // 
            this.lbl_Saved.AutoSize = true;
            this.lbl_Saved.Location = new System.Drawing.Point(8, 80);
            this.lbl_Saved.Name = "lbl_Saved";
            this.lbl_Saved.Size = new System.Drawing.Size(95, 17);
            this.lbl_Saved.TabIndex = 0;
            this.lbl_Saved.Text = "Saved Values";
            this.lbl_Saved.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Interact
            // 
            this.lbl_Interact.AutoSize = true;
            this.lbl_Interact.Location = new System.Drawing.Point(8, 40);
            this.lbl_Interact.Name = "lbl_Interact";
            this.lbl_Interact.Size = new System.Drawing.Size(57, 17);
            this.lbl_Interact.TabIndex = 0;
            this.lbl_Interact.Text = "Change";
            // 
            // lbl_live
            // 
            this.lbl_live.AutoSize = true;
            this.lbl_live.Location = new System.Drawing.Point(8, 16);
            this.lbl_live.Name = "lbl_live";
            this.lbl_live.Size = new System.Drawing.Size(67, 17);
            this.lbl_live.TabIndex = 2;
            this.lbl_live.Text = "Live View";
            // 
            // btn_RDRAMOffsetHelp
            // 
            this.btn_RDRAMOffsetHelp.Location = new System.Drawing.Point(8, 336);
            this.btn_RDRAMOffsetHelp.Name = "btn_RDRAMOffsetHelp";
            this.btn_RDRAMOffsetHelp.Size = new System.Drawing.Size(24, 24);
            this.btn_RDRAMOffsetHelp.TabIndex = 0;
            this.btn_RDRAMOffsetHelp.TabStop = false;
            this.btn_RDRAMOffsetHelp.Text = "?";
            this.btn_RDRAMOffsetHelp.UseVisualStyleBackColor = true;
            this.btn_RDRAMOffsetHelp.Click += new System.EventHandler(this.btn_RDRAMOffsetHelp_Click);
            // 
            // lbl_RDRAMOff
            // 
            this.lbl_RDRAMOff.AutoSize = true;
            this.lbl_RDRAMOff.Location = new System.Drawing.Point(40, 339);
            this.lbl_RDRAMOff.Name = "lbl_RDRAMOff";
            this.lbl_RDRAMOff.Size = new System.Drawing.Size(97, 17);
            this.lbl_RDRAMOff.TabIndex = 0;
            this.lbl_RDRAMOff.Text = "RDRAM offset";
            // 
            // txt_rdramoffset
            // 
            this.txt_rdramoffset.Location = new System.Drawing.Point(144, 339);
            this.txt_rdramoffset.Name = "txt_rdramoffset";
            this.txt_rdramoffset.Size = new System.Drawing.Size(100, 22);
            this.txt_rdramoffset.TabIndex = 0;
            this.txt_rdramoffset.TabStop = false;
            this.txt_rdramoffset.TextChanged += new System.EventHandler(this.txt_rdramoffset_TextChanged);
            // 
            // ls_SAVED
            // 
            this.ls_SAVED.FormattingEnabled = true;
            this.ls_SAVED.ItemHeight = 16;
            this.ls_SAVED.Location = new System.Drawing.Point(128, 80);
            this.ls_SAVED.Name = "ls_SAVED";
            this.ls_SAVED.Size = new System.Drawing.Size(303, 116);
            this.ls_SAVED.TabIndex = 0;
            // 
            // STForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 453);
            this.Controls.Add(this.gp_st);
            this.MaximizeBox = false;
            this.Name = "STForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "STForm";
            this.Shown += new System.EventHandler(this.STForm_Shown);
            this.gp_st.ResumeLayout(false);
            this.gp_RDRAM.ResumeLayout(false);
            this.gp_RDRAM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gp_st;
        private System.Windows.Forms.GroupBox gp_RDRAM;
        private System.Windows.Forms.Button btn_RDRAMOffsetHelp;
        private System.Windows.Forms.Label lbl_RDRAMOff;
        private System.Windows.Forms.TextBox txt_rdramoffset;
        private System.Windows.Forms.TextBox txt_RDRAM;
        private System.Windows.Forms.Label lbl_Saved;
        private System.Windows.Forms.Label lbl_live;
        private System.Windows.Forms.ListBox ls_SAVED;
        private System.Windows.Forms.Button btn_Disallow;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_Interact;
        private System.Windows.Forms.TextBox txt_Edit;
        private System.Windows.Forms.Button btn_SaveST;
    }
}