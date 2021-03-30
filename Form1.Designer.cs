
namespace MupenUtils
{
    partial class MainForm
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
            this.btn_PathSel = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.gb_Path = new System.Windows.Forms.GroupBox();
            this.rb_STsel = new System.Windows.Forms.RadioButton();
            this.rb_M64sel = new System.Windows.Forms.RadioButton();
            this.st_Status = new System.Windows.Forms.StatusStrip();
            this.st_Status1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gp_M64 = new System.Windows.Forms.GroupBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.gp_Plugins = new System.Windows.Forms.GroupBox();
            this.lbl_Video = new System.Windows.Forms.Label();
            this.txt_videoplugin = new System.Windows.Forms.TextBox();
            this.lbl_RSP = new System.Windows.Forms.Label();
            this.txt_inputplugin = new System.Windows.Forms.TextBox();
            this.lbl_Audio = new System.Windows.Forms.Label();
            this.txtbox_Audioplugin = new System.Windows.Forms.TextBox();
            this.lbl_Input = new System.Windows.Forms.Label();
            this.txt_Rsp = new System.Windows.Forms.TextBox();
            this.txt_Author = new System.Windows.Forms.TextBox();
            this.txt_PathName = new System.Windows.Forms.TextBox();
            this.gp_M64_misc = new System.Windows.Forms.GroupBox();
            this.txt_misc_UID = new System.Windows.Forms.TextBox();
            this.txt_misc_Version = new System.Windows.Forms.TextBox();
            this.txt_misc_Magic = new System.Windows.Forms.TextBox();
            this.lbl_misc_uid = new System.Windows.Forms.Label();
            this.lbl_misc_version = new System.Windows.Forms.Label();
            this.lbl_misc_Magic = new System.Windows.Forms.Label();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.lbl_RomCountry = new System.Windows.Forms.Label();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.lbl_ROMCRC = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_ROMNAME = new System.Windows.Forms.Label();
            this.lb_starttype = new System.Windows.Forms.Label();
            this.txt_RomCountry = new System.Windows.Forms.TextBox();
            this.txt_Crc = new System.Windows.Forms.TextBox();
            this.lbl_Ctrls = new System.Windows.Forms.Label();
            this.txt_Rom = new System.Windows.Forms.TextBox();
            this.txt_StartType = new System.Windows.Forms.TextBox();
            this.txt_CTRLS = new System.Windows.Forms.TextBox();
            this.txt_RR = new System.Windows.Forms.TextBox();
            this.txt_VIs = new System.Windows.Forms.TextBox();
            this.lb_RR = new System.Windows.Forms.Label();
            this.lb_VIs = new System.Windows.Forms.Label();
            this.gpRom = new System.Windows.Forms.GroupBox();
            this.gp_User = new System.Windows.Forms.GroupBox();
            this.gb_Path.SuspendLayout();
            this.st_Status.SuspendLayout();
            this.gp_M64.SuspendLayout();
            this.gp_Plugins.SuspendLayout();
            this.gp_M64_misc.SuspendLayout();
            this.gpRom.SuspendLayout();
            this.gp_User.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_PathSel
            // 
            this.btn_PathSel.Location = new System.Drawing.Point(160, 16);
            this.btn_PathSel.Name = "btn_PathSel";
            this.btn_PathSel.Size = new System.Drawing.Size(75, 23);
            this.btn_PathSel.TabIndex = 0;
            this.btn_PathSel.TabStop = false;
            this.btn_PathSel.Text = "Browse";
            this.btn_PathSel.UseVisualStyleBackColor = true;
            this.btn_PathSel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_PathSel_MouseClick);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(8, 16);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(144, 20);
            this.txt_Path.TabIndex = 0;
            this.txt_Path.TabStop = false;
            // 
            // gb_Path
            // 
            this.gb_Path.Controls.Add(this.rb_STsel);
            this.gb_Path.Controls.Add(this.rb_M64sel);
            this.gb_Path.Controls.Add(this.txt_Path);
            this.gb_Path.Controls.Add(this.btn_PathSel);
            this.gb_Path.Location = new System.Drawing.Point(8, 8);
            this.gb_Path.Name = "gb_Path";
            this.gb_Path.Size = new System.Drawing.Size(240, 72);
            this.gb_Path.TabIndex = 2;
            this.gb_Path.TabStop = false;
            this.gb_Path.Text = "Selection";
            // 
            // rb_STsel
            // 
            this.rb_STsel.AutoSize = true;
            this.rb_STsel.Location = new System.Drawing.Point(56, 48);
            this.rb_STsel.Name = "rb_STsel";
            this.rb_STsel.Size = new System.Drawing.Size(39, 17);
            this.rb_STsel.TabIndex = 0;
            this.rb_STsel.Text = "ST";
            this.rb_STsel.UseVisualStyleBackColor = true;
            this.rb_STsel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rb_STsel_MouseDown);
            // 
            // rb_M64sel
            // 
            this.rb_M64sel.AutoSize = true;
            this.rb_M64sel.Location = new System.Drawing.Point(8, 48);
            this.rb_M64sel.Name = "rb_M64sel";
            this.rb_M64sel.Size = new System.Drawing.Size(46, 17);
            this.rb_M64sel.TabIndex = 0;
            this.rb_M64sel.Text = "M64";
            this.rb_M64sel.UseVisualStyleBackColor = true;
            this.rb_M64sel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rb_M64sel_MouseDown);
            // 
            // st_Status
            // 
            this.st_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.st_Status1});
            this.st_Status.Location = new System.Drawing.Point(0, 422);
            this.st_Status.Name = "st_Status";
            this.st_Status.Size = new System.Drawing.Size(442, 22);
            this.st_Status.TabIndex = 0;
            this.st_Status.Text = "STATUSBAR";
            // 
            // st_Status1
            // 
            this.st_Status1.Name = "st_Status1";
            this.st_Status1.Size = new System.Drawing.Size(67, 17);
            this.st_Status1.Text = "1234567890";
            // 
            // gp_M64
            // 
            this.gp_M64.Controls.Add(this.gp_User);
            this.gp_M64.Controls.Add(this.gpRom);
            this.gp_M64.Controls.Add(this.gp_Plugins);
            this.gp_M64.Controls.Add(this.gp_M64_misc);
            this.gp_M64.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gp_M64.Location = new System.Drawing.Point(0, 88);
            this.gp_M64.Name = "gp_M64";
            this.gp_M64.Size = new System.Drawing.Size(442, 334);
            this.gp_M64.TabIndex = 0;
            this.gp_M64.TabStop = false;
            this.gp_M64.Text = "M64";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(96, 72);
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.ReadOnly = true;
            this.txt_Desc.Size = new System.Drawing.Size(100, 20);
            this.txt_Desc.TabIndex = 0;
            this.txt_Desc.TabStop = false;
            // 
            // gp_Plugins
            // 
            this.gp_Plugins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_Plugins.Controls.Add(this.lbl_Video);
            this.gp_Plugins.Controls.Add(this.txt_videoplugin);
            this.gp_Plugins.Controls.Add(this.lbl_RSP);
            this.gp_Plugins.Controls.Add(this.txt_inputplugin);
            this.gp_Plugins.Controls.Add(this.lbl_Audio);
            this.gp_Plugins.Controls.Add(this.txtbox_Audioplugin);
            this.gp_Plugins.Controls.Add(this.lbl_Input);
            this.gp_Plugins.Controls.Add(this.txt_Rsp);
            this.gp_Plugins.Location = new System.Drawing.Point(216, 192);
            this.gp_Plugins.Name = "gp_Plugins";
            this.gp_Plugins.Size = new System.Drawing.Size(200, 128);
            this.gp_Plugins.TabIndex = 0;
            this.gp_Plugins.TabStop = false;
            this.gp_Plugins.Text = "Plugins";
            // 
            // lbl_Video
            // 
            this.lbl_Video.AutoSize = true;
            this.lbl_Video.Location = new System.Drawing.Point(8, 16);
            this.lbl_Video.Name = "lbl_Video";
            this.lbl_Video.Size = new System.Drawing.Size(37, 13);
            this.lbl_Video.TabIndex = 0;
            this.lbl_Video.Text = "Video ";
            // 
            // txt_videoplugin
            // 
            this.txt_videoplugin.Location = new System.Drawing.Point(96, 8);
            this.txt_videoplugin.Name = "txt_videoplugin";
            this.txt_videoplugin.ReadOnly = true;
            this.txt_videoplugin.Size = new System.Drawing.Size(100, 20);
            this.txt_videoplugin.TabIndex = 0;
            this.txt_videoplugin.TabStop = false;
            // 
            // lbl_RSP
            // 
            this.lbl_RSP.AutoSize = true;
            this.lbl_RSP.Location = new System.Drawing.Point(8, 88);
            this.lbl_RSP.Name = "lbl_RSP";
            this.lbl_RSP.Size = new System.Drawing.Size(29, 13);
            this.lbl_RSP.TabIndex = 0;
            this.lbl_RSP.Text = "RSP";
            // 
            // txt_inputplugin
            // 
            this.txt_inputplugin.Location = new System.Drawing.Point(96, 32);
            this.txt_inputplugin.Name = "txt_inputplugin";
            this.txt_inputplugin.ReadOnly = true;
            this.txt_inputplugin.Size = new System.Drawing.Size(100, 20);
            this.txt_inputplugin.TabIndex = 0;
            this.txt_inputplugin.TabStop = false;
            // 
            // lbl_Audio
            // 
            this.lbl_Audio.AutoSize = true;
            this.lbl_Audio.Location = new System.Drawing.Point(8, 64);
            this.lbl_Audio.Name = "lbl_Audio";
            this.lbl_Audio.Size = new System.Drawing.Size(34, 13);
            this.lbl_Audio.TabIndex = 0;
            this.lbl_Audio.Text = "Audio";
            // 
            // txtbox_Audioplugin
            // 
            this.txtbox_Audioplugin.Location = new System.Drawing.Point(96, 56);
            this.txtbox_Audioplugin.Name = "txtbox_Audioplugin";
            this.txtbox_Audioplugin.ReadOnly = true;
            this.txtbox_Audioplugin.Size = new System.Drawing.Size(100, 20);
            this.txtbox_Audioplugin.TabIndex = 0;
            this.txtbox_Audioplugin.TabStop = false;
            // 
            // lbl_Input
            // 
            this.lbl_Input.AutoSize = true;
            this.lbl_Input.Location = new System.Drawing.Point(8, 40);
            this.lbl_Input.Name = "lbl_Input";
            this.lbl_Input.Size = new System.Drawing.Size(31, 13);
            this.lbl_Input.TabIndex = 0;
            this.lbl_Input.Text = "Input";
            // 
            // txt_Rsp
            // 
            this.txt_Rsp.Location = new System.Drawing.Point(96, 80);
            this.txt_Rsp.Name = "txt_Rsp";
            this.txt_Rsp.ReadOnly = true;
            this.txt_Rsp.Size = new System.Drawing.Size(100, 20);
            this.txt_Rsp.TabIndex = 0;
            this.txt_Rsp.TabStop = false;
            // 
            // txt_Author
            // 
            this.txt_Author.Location = new System.Drawing.Point(96, 48);
            this.txt_Author.Name = "txt_Author";
            this.txt_Author.ReadOnly = true;
            this.txt_Author.Size = new System.Drawing.Size(100, 20);
            this.txt_Author.TabIndex = 0;
            this.txt_Author.TabStop = false;
            // 
            // txt_PathName
            // 
            this.txt_PathName.Location = new System.Drawing.Point(96, 24);
            this.txt_PathName.Name = "txt_PathName";
            this.txt_PathName.ReadOnly = true;
            this.txt_PathName.Size = new System.Drawing.Size(100, 20);
            this.txt_PathName.TabIndex = 0;
            this.txt_PathName.TabStop = false;
            // 
            // gp_M64_misc
            // 
            this.gp_M64_misc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_M64_misc.Controls.Add(this.txt_misc_UID);
            this.gp_M64_misc.Controls.Add(this.txt_misc_Version);
            this.gp_M64_misc.Controls.Add(this.txt_misc_Magic);
            this.gp_M64_misc.Controls.Add(this.lbl_misc_uid);
            this.gp_M64_misc.Controls.Add(this.lbl_misc_version);
            this.gp_M64_misc.Controls.Add(this.lbl_misc_Magic);
            this.gp_M64_misc.Controls.Add(this.txt_StartType);
            this.gp_M64_misc.Controls.Add(this.txt_CTRLS);
            this.gp_M64_misc.Controls.Add(this.lbl_Ctrls);
            this.gp_M64_misc.Controls.Add(this.lb_starttype);
            this.gp_M64_misc.Location = new System.Drawing.Point(216, 24);
            this.gp_M64_misc.Name = "gp_M64_misc";
            this.gp_M64_misc.Size = new System.Drawing.Size(200, 160);
            this.gp_M64_misc.TabIndex = 0;
            this.gp_M64_misc.TabStop = false;
            this.gp_M64_misc.Text = "Miscellaneous";
            // 
            // txt_misc_UID
            // 
            this.txt_misc_UID.Location = new System.Drawing.Point(88, 72);
            this.txt_misc_UID.Name = "txt_misc_UID";
            this.txt_misc_UID.ReadOnly = true;
            this.txt_misc_UID.Size = new System.Drawing.Size(100, 20);
            this.txt_misc_UID.TabIndex = 0;
            this.txt_misc_UID.TabStop = false;
            // 
            // txt_misc_Version
            // 
            this.txt_misc_Version.Location = new System.Drawing.Point(88, 48);
            this.txt_misc_Version.Name = "txt_misc_Version";
            this.txt_misc_Version.ReadOnly = true;
            this.txt_misc_Version.Size = new System.Drawing.Size(100, 20);
            this.txt_misc_Version.TabIndex = 0;
            this.txt_misc_Version.TabStop = false;
            // 
            // txt_misc_Magic
            // 
            this.txt_misc_Magic.Location = new System.Drawing.Point(88, 24);
            this.txt_misc_Magic.Name = "txt_misc_Magic";
            this.txt_misc_Magic.ReadOnly = true;
            this.txt_misc_Magic.Size = new System.Drawing.Size(100, 20);
            this.txt_misc_Magic.TabIndex = 0;
            this.txt_misc_Magic.TabStop = false;
            // 
            // lbl_misc_uid
            // 
            this.lbl_misc_uid.AutoSize = true;
            this.lbl_misc_uid.Location = new System.Drawing.Point(16, 72);
            this.lbl_misc_uid.Name = "lbl_misc_uid";
            this.lbl_misc_uid.Size = new System.Drawing.Size(26, 13);
            this.lbl_misc_uid.TabIndex = 0;
            this.lbl_misc_uid.Text = "UID";
            // 
            // lbl_misc_version
            // 
            this.lbl_misc_version.AutoSize = true;
            this.lbl_misc_version.Location = new System.Drawing.Point(16, 48);
            this.lbl_misc_version.Name = "lbl_misc_version";
            this.lbl_misc_version.Size = new System.Drawing.Size(42, 13);
            this.lbl_misc_version.TabIndex = 0;
            this.lbl_misc_version.Text = "Version";
            // 
            // lbl_misc_Magic
            // 
            this.lbl_misc_Magic.AutoSize = true;
            this.lbl_misc_Magic.Location = new System.Drawing.Point(16, 24);
            this.lbl_misc_Magic.Name = "lbl_misc_Magic";
            this.lbl_misc_Magic.Size = new System.Drawing.Size(36, 13);
            this.lbl_misc_Magic.TabIndex = 0;
            this.lbl_misc_Magic.Text = "Magic";
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Location = new System.Drawing.Point(8, 72);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(60, 13);
            this.lbl_Desc.TabIndex = 0;
            this.lbl_Desc.Text = "Description";
            // 
            // lbl_RomCountry
            // 
            this.lbl_RomCountry.AutoSize = true;
            this.lbl_RomCountry.Location = new System.Drawing.Point(8, 72);
            this.lbl_RomCountry.Name = "lbl_RomCountry";
            this.lbl_RomCountry.Size = new System.Drawing.Size(71, 13);
            this.lbl_RomCountry.TabIndex = 0;
            this.lbl_RomCountry.Text = "ROM Country";
            // 
            // lbl_Author
            // 
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.Location = new System.Drawing.Point(8, 48);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(38, 13);
            this.lbl_Author.TabIndex = 0;
            this.lbl_Author.Text = "Author";
            // 
            // lbl_ROMCRC
            // 
            this.lbl_ROMCRC.AutoSize = true;
            this.lbl_ROMCRC.Location = new System.Drawing.Point(8, 48);
            this.lbl_ROMCRC.Name = "lbl_ROMCRC";
            this.lbl_ROMCRC.Size = new System.Drawing.Size(57, 13);
            this.lbl_ROMCRC.TabIndex = 0;
            this.lbl_ROMCRC.Text = "ROM CRC";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(8, 24);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_ROMNAME
            // 
            this.lbl_ROMNAME.AutoSize = true;
            this.lbl_ROMNAME.Location = new System.Drawing.Point(8, 24);
            this.lbl_ROMNAME.Name = "lbl_ROMNAME";
            this.lbl_ROMNAME.Size = new System.Drawing.Size(63, 13);
            this.lbl_ROMNAME.TabIndex = 0;
            this.lbl_ROMNAME.Text = "ROM Name";
            // 
            // lb_starttype
            // 
            this.lb_starttype.AutoSize = true;
            this.lb_starttype.Location = new System.Drawing.Point(16, 120);
            this.lb_starttype.Name = "lb_starttype";
            this.lb_starttype.Size = new System.Drawing.Size(56, 13);
            this.lb_starttype.TabIndex = 0;
            this.lb_starttype.Text = "Start Type";
            // 
            // txt_RomCountry
            // 
            this.txt_RomCountry.Location = new System.Drawing.Point(96, 64);
            this.txt_RomCountry.Name = "txt_RomCountry";
            this.txt_RomCountry.ReadOnly = true;
            this.txt_RomCountry.Size = new System.Drawing.Size(100, 20);
            this.txt_RomCountry.TabIndex = 0;
            this.txt_RomCountry.TabStop = false;
            // 
            // txt_Crc
            // 
            this.txt_Crc.Location = new System.Drawing.Point(96, 40);
            this.txt_Crc.Name = "txt_Crc";
            this.txt_Crc.ReadOnly = true;
            this.txt_Crc.Size = new System.Drawing.Size(100, 20);
            this.txt_Crc.TabIndex = 0;
            this.txt_Crc.TabStop = false;
            // 
            // lbl_Ctrls
            // 
            this.lbl_Ctrls.AutoSize = true;
            this.lbl_Ctrls.Location = new System.Drawing.Point(16, 96);
            this.lbl_Ctrls.Name = "lbl_Ctrls";
            this.lbl_Ctrls.Size = new System.Drawing.Size(56, 13);
            this.lbl_Ctrls.TabIndex = 0;
            this.lbl_Ctrls.Text = "Controllers";
            // 
            // txt_Rom
            // 
            this.txt_Rom.Location = new System.Drawing.Point(96, 16);
            this.txt_Rom.Name = "txt_Rom";
            this.txt_Rom.ReadOnly = true;
            this.txt_Rom.Size = new System.Drawing.Size(100, 20);
            this.txt_Rom.TabIndex = 0;
            this.txt_Rom.TabStop = false;
            // 
            // txt_StartType
            // 
            this.txt_StartType.Location = new System.Drawing.Point(88, 120);
            this.txt_StartType.Name = "txt_StartType";
            this.txt_StartType.ReadOnly = true;
            this.txt_StartType.Size = new System.Drawing.Size(100, 20);
            this.txt_StartType.TabIndex = 0;
            this.txt_StartType.TabStop = false;
            // 
            // txt_CTRLS
            // 
            this.txt_CTRLS.Location = new System.Drawing.Point(88, 96);
            this.txt_CTRLS.Name = "txt_CTRLS";
            this.txt_CTRLS.ReadOnly = true;
            this.txt_CTRLS.Size = new System.Drawing.Size(100, 20);
            this.txt_CTRLS.TabIndex = 0;
            this.txt_CTRLS.TabStop = false;
            // 
            // txt_RR
            // 
            this.txt_RR.Location = new System.Drawing.Point(96, 96);
            this.txt_RR.Name = "txt_RR";
            this.txt_RR.ReadOnly = true;
            this.txt_RR.Size = new System.Drawing.Size(100, 20);
            this.txt_RR.TabIndex = 0;
            this.txt_RR.TabStop = false;
            // 
            // txt_VIs
            // 
            this.txt_VIs.Location = new System.Drawing.Point(96, 120);
            this.txt_VIs.Name = "txt_VIs";
            this.txt_VIs.ReadOnly = true;
            this.txt_VIs.Size = new System.Drawing.Size(100, 20);
            this.txt_VIs.TabIndex = 0;
            this.txt_VIs.TabStop = false;
            // 
            // lb_RR
            // 
            this.lb_RR.AutoSize = true;
            this.lb_RR.Location = new System.Drawing.Point(8, 104);
            this.lb_RR.Name = "lb_RR";
            this.lb_RR.Size = new System.Drawing.Size(56, 13);
            this.lb_RR.TabIndex = 0;
            this.lb_RR.Text = "Rerecords";
            // 
            // lb_VIs
            // 
            this.lb_VIs.AutoSize = true;
            this.lb_VIs.Location = new System.Drawing.Point(8, 128);
            this.lb_VIs.Name = "lb_VIs";
            this.lb_VIs.Size = new System.Drawing.Size(22, 13);
            this.lb_VIs.TabIndex = 0;
            this.lb_VIs.Text = "VIs";
            // 
            // gpRom
            // 
            this.gpRom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpRom.Controls.Add(this.txt_Rom);
            this.gpRom.Controls.Add(this.txt_Crc);
            this.gpRom.Controls.Add(this.txt_RomCountry);
            this.gpRom.Controls.Add(this.lbl_ROMNAME);
            this.gpRom.Controls.Add(this.lbl_ROMCRC);
            this.gpRom.Controls.Add(this.lbl_RomCountry);
            this.gpRom.Location = new System.Drawing.Point(8, 192);
            this.gpRom.Name = "gpRom";
            this.gpRom.Size = new System.Drawing.Size(200, 128);
            this.gpRom.TabIndex = 0;
            this.gpRom.TabStop = false;
            this.gpRom.Text = "ROM";
            // 
            // gp_User
            // 
            this.gp_User.Controls.Add(this.txt_PathName);
            this.gp_User.Controls.Add(this.lbl_Name);
            this.gp_User.Controls.Add(this.txt_Desc);
            this.gp_User.Controls.Add(this.lbl_Author);
            this.gp_User.Controls.Add(this.txt_VIs);
            this.gp_User.Controls.Add(this.lb_VIs);
            this.gp_User.Controls.Add(this.txt_RR);
            this.gp_User.Controls.Add(this.lbl_Desc);
            this.gp_User.Controls.Add(this.lb_RR);
            this.gp_User.Controls.Add(this.txt_Author);
            this.gp_User.Location = new System.Drawing.Point(8, 24);
            this.gp_User.Name = "gp_User";
            this.gp_User.Size = new System.Drawing.Size(200, 160);
            this.gp_User.TabIndex = 0;
            this.gp_User.TabStop = false;
            this.gp_User.Text = "Specific";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 444);
            this.Controls.Add(this.gp_M64);
            this.Controls.Add(this.st_Status);
            this.Controls.Add(this.gb_Path);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mupen Utilities";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.gb_Path.ResumeLayout(false);
            this.gb_Path.PerformLayout();
            this.st_Status.ResumeLayout(false);
            this.st_Status.PerformLayout();
            this.gp_M64.ResumeLayout(false);
            this.gp_Plugins.ResumeLayout(false);
            this.gp_Plugins.PerformLayout();
            this.gp_M64_misc.ResumeLayout(false);
            this.gp_M64_misc.PerformLayout();
            this.gpRom.ResumeLayout(false);
            this.gpRom.PerformLayout();
            this.gp_User.ResumeLayout(false);
            this.gp_User.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PathSel;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.GroupBox gb_Path;
        private System.Windows.Forms.StatusStrip st_Status;
        private System.Windows.Forms.ToolStripStatusLabel st_Status1;
        private System.Windows.Forms.RadioButton rb_STsel;
        private System.Windows.Forms.RadioButton rb_M64sel;
        private System.Windows.Forms.GroupBox gp_M64;
        private System.Windows.Forms.Label lbl_Ctrls;
        private System.Windows.Forms.Label lb_RR;
        private System.Windows.Forms.GroupBox gp_M64_misc;
        private System.Windows.Forms.Label lbl_misc_Magic;
        private System.Windows.Forms.Label lbl_misc_uid;
        private System.Windows.Forms.Label lbl_misc_version;
        private System.Windows.Forms.TextBox txt_misc_UID;
        private System.Windows.Forms.TextBox txt_misc_Version;
        private System.Windows.Forms.TextBox txt_misc_Magic;
        private System.Windows.Forms.TextBox txt_CTRLS;
        private System.Windows.Forms.TextBox txt_RR;
        private System.Windows.Forms.Label lbl_Input;
        private System.Windows.Forms.Label lbl_Video;
        private System.Windows.Forms.Label lb_starttype;
        private System.Windows.Forms.TextBox txt_inputplugin;
        private System.Windows.Forms.TextBox txt_videoplugin;
        private System.Windows.Forms.TextBox txt_StartType;
        private System.Windows.Forms.Label lbl_RSP;
        private System.Windows.Forms.Label lbl_Audio;
        private System.Windows.Forms.TextBox txt_Rsp;
        private System.Windows.Forms.TextBox txtbox_Audioplugin;
        private System.Windows.Forms.GroupBox gp_Plugins;
        private System.Windows.Forms.Label lbl_ROMCRC;
        private System.Windows.Forms.Label lbl_ROMNAME;
        private System.Windows.Forms.TextBox txt_Crc;
        private System.Windows.Forms.TextBox txt_Rom;
        private System.Windows.Forms.Label lbl_RomCountry;
        private System.Windows.Forms.TextBox txt_RomCountry;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.TextBox txt_Author;
        private System.Windows.Forms.TextBox txt_PathName;
        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_VIs;
        private System.Windows.Forms.Label lb_VIs;
        private System.Windows.Forms.GroupBox gp_User;
        private System.Windows.Forms.GroupBox gpRom;
    }
}

