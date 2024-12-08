namespace KPSyncForDrive
{
    partial class ConfigurationForm
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
            this.components = new System.ComponentModel.Container();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnAbout = new System.Windows.Forms.Button();
            this.m_imgList = new System.Windows.Forms.ImageList(this.components);
            this.m_toolTipper = new System.Windows.Forms.ToolTip(this.components);
            this.m_bannerImage = new System.Windows.Forms.PictureBox();
            this.m_tabOptions = new System.Windows.Forms.TabPage();
            this.m_grpAuthTokenSecurityDefaults = new System.Windows.Forms.GroupBox();
            this.m_lnkAuthTokenDefaultsHelp = new System.Windows.Forms.LinkLabel();
            this.m_chkWarnAuthToken = new System.Windows.Forms.CheckBox();
            this.m_chkDontSaveAuthDefault = new System.Windows.Forms.CheckBox();
            this.m_grpCmdEnabled = new System.Windows.Forms.GroupBox();
            this.m_chkDownloadEnabled = new System.Windows.Forms.CheckBox();
            this.m_chkUploadEnabled = new System.Windows.Forms.CheckBox();
            this.m_chkSyncEnabled = new System.Windows.Forms.CheckBox();
            this.m_grpDriveAuthDefaults = new System.Windows.Forms.GroupBox();
            this.m_lnkGoogle2 = new System.Windows.Forms.LinkLabel();
            this.m_lnkHelp2 = new System.Windows.Forms.LinkLabel();
            this.m_grpFolderDefaults = new System.Windows.Forms.GroupBox();
            this.m_btnGetColors = new System.Windows.Forms.Button();
            this.m_cbColors = new System.Windows.Forms.ComboBox();
            this.m_lblHintDefaultFolder = new System.Windows.Forms.Label();
            this.m_txtFolderDefault = new System.Windows.Forms.TextBox();
            this.m_lblDefaultFolderLabel = new System.Windows.Forms.Label();
            this.m_lblDefFolderColor = new System.Windows.Forms.Label();
            this.m_grpAutoSync = new System.Windows.Forms.GroupBox();
            this.m_chkSyncOnReopen = new System.Windows.Forms.CheckBox();
            this.m_chkSyncOnSave = new System.Windows.Forms.CheckBox();
            this.m_chkSyncOnOpen = new System.Windows.Forms.CheckBox();
            this.m_tabGSignIn = new System.Windows.Forms.TabPage();
            this.m_grpAuthTokenSecurity = new System.Windows.Forms.GroupBox();
            this.m_lnkAuthTokenHelp = new System.Windows.Forms.LinkLabel();
            this.m_chkDontSaveAuthToken = new System.Windows.Forms.CheckBox();
            this.m_grpDriveAuth = new System.Windows.Forms.GroupBox();
            this.AuthorizeFiles_label = new System.Windows.Forms.Label();
            this.AuthorizeFiles_btn = new System.Windows.Forms.Button();
            this.m_lnkGoogle = new System.Windows.Forms.LinkLabel();
            this.m_lnkHelp = new System.Windows.Forms.LinkLabel();
            this.m_grpEntry = new System.Windows.Forms.GroupBox();
            this.m_cbAccount = new System.Windows.Forms.ComboBox();
            this.m_lblAccount = new System.Windows.Forms.Label();
            this.m_grpDriveOptions = new System.Windows.Forms.GroupBox();
            this.m_lblHintFolder = new System.Windows.Forms.Label();
            this.m_txtFolder = new System.Windows.Forms.TextBox();
            this.m_lblFolder = new System.Windows.Forms.Label();
            this.m_tabMain = new System.Windows.Forms.TabControl();
            this.AuthorizeFiles_tooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).BeginInit();
            this.m_tabOptions.SuspendLayout();
            this.m_grpAuthTokenSecurityDefaults.SuspendLayout();
            this.m_grpCmdEnabled.SuspendLayout();
            this.m_grpDriveAuthDefaults.SuspendLayout();
            this.m_grpFolderDefaults.SuspendLayout();
            this.m_grpAutoSync.SuspendLayout();
            this.m_tabGSignIn.SuspendLayout();
            this.m_grpAuthTokenSecurity.SuspendLayout();
            this.m_grpDriveAuth.SuspendLayout();
            this.m_grpEntry.SuspendLayout();
            this.m_grpDriveOptions.SuspendLayout();
            this.m_tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(746, 806);
            this.m_btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(112, 35);
            this.m_btnCancel.TabIndex = 102;
            this.m_btnCancel.Text = "Btn_DlgCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnOK
            // 
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Location = new System.Drawing.Point(624, 806);
            this.m_btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(112, 35);
            this.m_btnOK.TabIndex = 100;
            this.m_btnOK.Text = "Btn_DlgOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            // 
            // m_btnAbout
            // 
            this.m_btnAbout.ImageList = this.m_imgList;
            this.m_btnAbout.Location = new System.Drawing.Point(18, 806);
            this.m_btnAbout.Margin = new System.Windows.Forms.Padding(6);
            this.m_btnAbout.Name = "m_btnAbout";
            this.m_btnAbout.Size = new System.Drawing.Size(217, 35);
            this.m_btnAbout.TabIndex = 103;
            this.m_btnAbout.Text = "Btn_About";
            this.m_btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_btnAbout.UseVisualStyleBackColor = true;
            // 
            // m_imgList
            // 
            this.m_imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.m_imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_bannerImage
            // 
            this.m_bannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bannerImage.Location = new System.Drawing.Point(0, 0);
            this.m_bannerImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_bannerImage.Name = "m_bannerImage";
            this.m_bannerImage.Size = new System.Drawing.Size(870, 92);
            this.m_bannerImage.TabIndex = 1;
            this.m_bannerImage.TabStop = false;
            // 
            // m_tabOptions
            // 
            this.m_tabOptions.Controls.Add(this.m_grpAuthTokenSecurityDefaults);
            this.m_tabOptions.Controls.Add(this.m_grpCmdEnabled);
            this.m_tabOptions.Controls.Add(this.m_grpDriveAuthDefaults);
            this.m_tabOptions.Controls.Add(this.m_grpFolderDefaults);
            this.m_tabOptions.Controls.Add(this.m_grpAutoSync);
            this.m_tabOptions.Location = new System.Drawing.Point(4, 29);
            this.m_tabOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_tabOptions.Name = "m_tabOptions";
            this.m_tabOptions.Size = new System.Drawing.Size(832, 659);
            this.m_tabOptions.TabIndex = 3;
            this.m_tabOptions.Text = "Title_DefaultsTab";
            this.m_tabOptions.UseVisualStyleBackColor = true;
            // 
            // m_grpAuthTokenSecurityDefaults
            // 
            this.m_grpAuthTokenSecurityDefaults.Controls.Add(this.m_lnkAuthTokenDefaultsHelp);
            this.m_grpAuthTokenSecurityDefaults.Controls.Add(this.m_chkWarnAuthToken);
            this.m_grpAuthTokenSecurityDefaults.Controls.Add(this.m_chkDontSaveAuthDefault);
            this.m_grpAuthTokenSecurityDefaults.Location = new System.Drawing.Point(9, 151);
            this.m_grpAuthTokenSecurityDefaults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAuthTokenSecurityDefaults.Name = "m_grpAuthTokenSecurityDefaults";
            this.m_grpAuthTokenSecurityDefaults.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAuthTokenSecurityDefaults.Size = new System.Drawing.Size(807, 122);
            this.m_grpAuthTokenSecurityDefaults.TabIndex = 2;
            this.m_grpAuthTokenSecurityDefaults.TabStop = false;
            this.m_grpAuthTokenSecurityDefaults.Text = "Group_AuthTokenSecurityDefaults";
            // 
            // m_lnkAuthTokenDefaultsHelp
            // 
            this.m_lnkAuthTokenDefaultsHelp.AutoSize = true;
            this.m_lnkAuthTokenDefaultsHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAuthTokenDefaultsHelp.Location = new System.Drawing.Point(199, 94);
            this.m_lnkAuthTokenDefaultsHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkAuthTokenDefaultsHelp.Name = "m_lnkAuthTokenDefaultsHelp";
            this.m_lnkAuthTokenDefaultsHelp.Size = new System.Drawing.Size(188, 20);
            this.m_lnkAuthTokenDefaultsHelp.TabIndex = 2;
            this.m_lnkAuthTokenDefaultsHelp.TabStop = true;
            this.m_lnkAuthTokenDefaultsHelp.Text = "Lnk_AuthTokenAppHelp";
            // 
            // m_chkWarnAuthToken
            // 
            this.m_chkWarnAuthToken.AutoSize = true;
            this.m_chkWarnAuthToken.Location = new System.Drawing.Point(204, 65);
            this.m_chkWarnAuthToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkWarnAuthToken.Name = "m_chkWarnAuthToken";
            this.m_chkWarnAuthToken.Size = new System.Drawing.Size(221, 24);
            this.m_chkWarnAuthToken.TabIndex = 1;
            this.m_chkWarnAuthToken.Text = "Lbl_WarnEntryAuthToken";
            this.m_chkWarnAuthToken.UseVisualStyleBackColor = true;
            // 
            // m_chkDontSaveAuthDefault
            // 
            this.m_chkDontSaveAuthDefault.AutoSize = true;
            this.m_chkDontSaveAuthDefault.Location = new System.Drawing.Point(204, 29);
            this.m_chkDontSaveAuthDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkDontSaveAuthDefault.Name = "m_chkDontSaveAuthDefault";
            this.m_chkDontSaveAuthDefault.Size = new System.Drawing.Size(224, 24);
            this.m_chkDontSaveAuthDefault.TabIndex = 0;
            this.m_chkDontSaveAuthDefault.Text = "Lbl_DontSaveAuthDefault";
            this.m_chkDontSaveAuthDefault.UseVisualStyleBackColor = true;
            // 
            // m_grpCmdEnabled
            // 
            this.m_grpCmdEnabled.Controls.Add(this.m_chkDownloadEnabled);
            this.m_grpCmdEnabled.Controls.Add(this.m_chkUploadEnabled);
            this.m_grpCmdEnabled.Controls.Add(this.m_chkSyncEnabled);
            this.m_grpCmdEnabled.Location = new System.Drawing.Point(9, 9);
            this.m_grpCmdEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpCmdEnabled.Name = "m_grpCmdEnabled";
            this.m_grpCmdEnabled.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpCmdEnabled.Size = new System.Drawing.Size(354, 132);
            this.m_grpCmdEnabled.TabIndex = 0;
            this.m_grpCmdEnabled.TabStop = false;
            this.m_grpCmdEnabled.Text = "Group_CmdEnabled";
            // 
            // m_chkDownloadEnabled
            // 
            this.m_chkDownloadEnabled.AutoSize = true;
            this.m_chkDownloadEnabled.Location = new System.Drawing.Point(27, 95);
            this.m_chkDownloadEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkDownloadEnabled.Name = "m_chkDownloadEnabled";
            this.m_chkDownloadEnabled.Size = new System.Drawing.Size(197, 24);
            this.m_chkDownloadEnabled.TabIndex = 2;
            this.m_chkDownloadEnabled.Text = "Lbl_DownloadEnabled";
            this.m_chkDownloadEnabled.UseVisualStyleBackColor = true;
            // 
            // m_chkUploadEnabled
            // 
            this.m_chkUploadEnabled.AutoSize = true;
            this.m_chkUploadEnabled.Location = new System.Drawing.Point(27, 61);
            this.m_chkUploadEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkUploadEnabled.Name = "m_chkUploadEnabled";
            this.m_chkUploadEnabled.Size = new System.Drawing.Size(175, 24);
            this.m_chkUploadEnabled.TabIndex = 1;
            this.m_chkUploadEnabled.Text = "Lbl_UploadEnabled";
            this.m_chkUploadEnabled.UseVisualStyleBackColor = true;
            // 
            // m_chkSyncEnabled
            // 
            this.m_chkSyncEnabled.AutoSize = true;
            this.m_chkSyncEnabled.Location = new System.Drawing.Point(27, 28);
            this.m_chkSyncEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkSyncEnabled.Name = "m_chkSyncEnabled";
            this.m_chkSyncEnabled.Size = new System.Drawing.Size(160, 24);
            this.m_chkSyncEnabled.TabIndex = 0;
            this.m_chkSyncEnabled.Text = "Lbl_SyncEnabled";
            this.m_chkSyncEnabled.UseVisualStyleBackColor = true;
            // 
            // m_grpDriveAuthDefaults
            // 
            this.m_grpDriveAuthDefaults.Controls.Add(this.m_lnkGoogle2);
            this.m_grpDriveAuthDefaults.Controls.Add(this.m_lnkHelp2);
            this.m_grpDriveAuthDefaults.Location = new System.Drawing.Point(9, 425);
            this.m_grpDriveAuthDefaults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveAuthDefaults.Name = "m_grpDriveAuthDefaults";
            this.m_grpDriveAuthDefaults.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveAuthDefaults.Size = new System.Drawing.Size(807, 221);
            this.m_grpDriveAuthDefaults.TabIndex = 5;
            this.m_grpDriveAuthDefaults.TabStop = false;
            // 
            // m_lnkGoogle2
            // 
            this.m_lnkGoogle2.AutoSize = true;
            this.m_lnkGoogle2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGoogle2.Location = new System.Drawing.Point(288, 191);
            this.m_lnkGoogle2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkGoogle2.Name = "m_lnkGoogle2";
            this.m_lnkGoogle2.Size = new System.Drawing.Size(128, 20);
            this.m_lnkGoogle2.TabIndex = 6;
            this.m_lnkGoogle2.TabStop = true;
            this.m_lnkGoogle2.Text = "Lnk_GoogleDev";
            // 
            // m_lnkHelp2
            // 
            this.m_lnkHelp2.AutoSize = true;
            this.m_lnkHelp2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkHelp2.Location = new System.Drawing.Point(199, 191);
            this.m_lnkHelp2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkHelp2.Name = "m_lnkHelp2";
            this.m_lnkHelp2.Size = new System.Drawing.Size(80, 20);
            this.m_lnkHelp2.TabIndex = 5;
            this.m_lnkHelp2.TabStop = true;
            this.m_lnkHelp2.Text = "Lnk_Help";
            // 
            // m_grpFolderDefaults
            // 
            this.m_grpFolderDefaults.Controls.Add(this.m_btnGetColors);
            this.m_grpFolderDefaults.Controls.Add(this.m_cbColors);
            this.m_grpFolderDefaults.Controls.Add(this.m_lblHintDefaultFolder);
            this.m_grpFolderDefaults.Controls.Add(this.m_txtFolderDefault);
            this.m_grpFolderDefaults.Controls.Add(this.m_lblDefaultFolderLabel);
            this.m_grpFolderDefaults.Controls.Add(this.m_lblDefFolderColor);
            this.m_grpFolderDefaults.Location = new System.Drawing.Point(9, 282);
            this.m_grpFolderDefaults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpFolderDefaults.Name = "m_grpFolderDefaults";
            this.m_grpFolderDefaults.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpFolderDefaults.Size = new System.Drawing.Size(807, 132);
            this.m_grpFolderDefaults.TabIndex = 3;
            this.m_grpFolderDefaults.TabStop = false;
            this.m_grpFolderDefaults.Text = "Group_FolderDefaults";
            // 
            // m_btnGetColors
            // 
            this.m_btnGetColors.Location = new System.Drawing.Point(467, 75);
            this.m_btnGetColors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_btnGetColors.Name = "m_btnGetColors";
            this.m_btnGetColors.Size = new System.Drawing.Size(251, 35);
            this.m_btnGetColors.TabIndex = 2;
            this.m_btnGetColors.Text = "Btn_GetColors";
            this.m_btnGetColors.UseVisualStyleBackColor = true;
            // 
            // m_cbColors
            // 
            this.m_cbColors.FormattingEnabled = true;
            this.m_cbColors.Location = new System.Drawing.Point(274, 78);
            this.m_cbColors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_cbColors.Name = "m_cbColors";
            this.m_cbColors.Size = new System.Drawing.Size(181, 28);
            this.m_cbColors.TabIndex = 1;
            // 
            // m_lblHintDefaultFolder
            // 
            this.m_lblHintDefaultFolder.AutoSize = true;
            this.m_lblHintDefaultFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblHintDefaultFolder.Location = new System.Drawing.Point(280, 15);
            this.m_lblHintDefaultFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblHintDefaultFolder.Name = "m_lblHintDefaultFolder";
            this.m_lblHintDefaultFolder.Size = new System.Drawing.Size(187, 17);
            this.m_lblHintDefaultFolder.TabIndex = 29;
            this.m_lblHintDefaultFolder.Text = "Lbl_DefaultTargetFolderHint";
            // 
            // m_txtFolderDefault
            // 
            this.m_txtFolderDefault.Location = new System.Drawing.Point(276, 38);
            this.m_txtFolderDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_txtFolderDefault.Name = "m_txtFolderDefault";
            this.m_txtFolderDefault.Size = new System.Drawing.Size(439, 26);
            this.m_txtFolderDefault.TabIndex = 0;
            // 
            // m_lblDefaultFolderLabel
            // 
            this.m_lblDefaultFolderLabel.Location = new System.Drawing.Point(18, 41);
            this.m_lblDefaultFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblDefaultFolderLabel.Name = "m_lblDefaultFolderLabel";
            this.m_lblDefaultFolderLabel.Size = new System.Drawing.Size(248, 20);
            this.m_lblDefaultFolderLabel.TabIndex = 24;
            this.m_lblDefaultFolderLabel.Text = "Lbl_DefaultTargetFolder";
            this.m_lblDefaultFolderLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblDefFolderColor
            // 
            this.m_lblDefFolderColor.Location = new System.Drawing.Point(22, 81);
            this.m_lblDefFolderColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblDefFolderColor.Name = "m_lblDefFolderColor";
            this.m_lblDefFolderColor.Size = new System.Drawing.Size(243, 20);
            this.m_lblDefFolderColor.TabIndex = 26;
            this.m_lblDefFolderColor.Text = "Lbl_DefaultTgtFolderColor";
            this.m_lblDefFolderColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_grpAutoSync
            // 
            this.m_grpAutoSync.Controls.Add(this.m_chkSyncOnReopen);
            this.m_grpAutoSync.Controls.Add(this.m_chkSyncOnSave);
            this.m_grpAutoSync.Controls.Add(this.m_chkSyncOnOpen);
            this.m_grpAutoSync.Location = new System.Drawing.Point(372, 9);
            this.m_grpAutoSync.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAutoSync.Name = "m_grpAutoSync";
            this.m_grpAutoSync.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAutoSync.Size = new System.Drawing.Size(444, 132);
            this.m_grpAutoSync.TabIndex = 1;
            this.m_grpAutoSync.TabStop = false;
            this.m_grpAutoSync.Text = "Group_AutoSync";
            // 
            // m_chkSyncOnReopen
            // 
            this.m_chkSyncOnReopen.AutoSize = true;
            this.m_chkSyncOnReopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkSyncOnReopen.Location = new System.Drawing.Point(58, 95);
            this.m_chkSyncOnReopen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkSyncOnReopen.Name = "m_chkSyncOnReopen";
            this.m_chkSyncOnReopen.Size = new System.Drawing.Size(186, 21);
            this.m_chkSyncOnReopen.TabIndex = 2;
            this.m_chkSyncOnReopen.Text = "Lbl_AutoSyncOnReopen";
            this.m_chkSyncOnReopen.UseVisualStyleBackColor = true;
            // 
            // m_chkSyncOnSave
            // 
            this.m_chkSyncOnSave.AutoSize = true;
            this.m_chkSyncOnSave.Location = new System.Drawing.Point(27, 62);
            this.m_chkSyncOnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkSyncOnSave.Name = "m_chkSyncOnSave";
            this.m_chkSyncOnSave.Size = new System.Drawing.Size(193, 24);
            this.m_chkSyncOnSave.TabIndex = 1;
            this.m_chkSyncOnSave.Text = "Lbl_AutoSyncOnSave";
            this.m_chkSyncOnSave.UseVisualStyleBackColor = true;
            // 
            // m_chkSyncOnOpen
            // 
            this.m_chkSyncOnOpen.AutoSize = true;
            this.m_chkSyncOnOpen.Location = new System.Drawing.Point(27, 28);
            this.m_chkSyncOnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkSyncOnOpen.Name = "m_chkSyncOnOpen";
            this.m_chkSyncOnOpen.Size = new System.Drawing.Size(196, 24);
            this.m_chkSyncOnOpen.TabIndex = 0;
            this.m_chkSyncOnOpen.Text = "Lbl_AutoSyncOnOpen";
            this.m_chkSyncOnOpen.UseVisualStyleBackColor = true;
            // 
            // m_tabGSignIn
            // 
            this.m_tabGSignIn.Controls.Add(this.m_grpAuthTokenSecurity);
            this.m_tabGSignIn.Controls.Add(this.m_grpDriveAuth);
            this.m_tabGSignIn.Controls.Add(this.m_grpEntry);
            this.m_tabGSignIn.Controls.Add(this.m_grpDriveOptions);
            this.m_tabGSignIn.Location = new System.Drawing.Point(4, 29);
            this.m_tabGSignIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_tabGSignIn.Name = "m_tabGSignIn";
            this.m_tabGSignIn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_tabGSignIn.Size = new System.Drawing.Size(832, 659);
            this.m_tabGSignIn.TabIndex = 0;
            this.m_tabGSignIn.Text = "Title_SyncAuthTab";
            this.m_tabGSignIn.UseVisualStyleBackColor = true;
            // 
            // m_grpAuthTokenSecurity
            // 
            this.m_grpAuthTokenSecurity.Controls.Add(this.m_lnkAuthTokenHelp);
            this.m_grpAuthTokenSecurity.Controls.Add(this.m_chkDontSaveAuthToken);
            this.m_grpAuthTokenSecurity.Location = new System.Drawing.Point(9, 280);
            this.m_grpAuthTokenSecurity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAuthTokenSecurity.Name = "m_grpAuthTokenSecurity";
            this.m_grpAuthTokenSecurity.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpAuthTokenSecurity.Size = new System.Drawing.Size(810, 122);
            this.m_grpAuthTokenSecurity.TabIndex = 2;
            this.m_grpAuthTokenSecurity.TabStop = false;
            this.m_grpAuthTokenSecurity.Text = "Group_AuthTokenSecurity";
            // 
            // m_lnkAuthTokenHelp
            // 
            this.m_lnkAuthTokenHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkAuthTokenHelp.AutoSize = true;
            this.m_lnkAuthTokenHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAuthTokenHelp.Location = new System.Drawing.Point(192, 78);
            this.m_lnkAuthTokenHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkAuthTokenHelp.Name = "m_lnkAuthTokenHelp";
            this.m_lnkAuthTokenHelp.Size = new System.Drawing.Size(159, 20);
            this.m_lnkAuthTokenHelp.TabIndex = 1;
            this.m_lnkAuthTokenHelp.TabStop = true;
            this.m_lnkAuthTokenHelp.Text = "Lnk_AuthTokenHelp";
            // 
            // m_chkDontSaveAuthToken
            // 
            this.m_chkDontSaveAuthToken.AutoSize = true;
            this.m_chkDontSaveAuthToken.Location = new System.Drawing.Point(197, 42);
            this.m_chkDontSaveAuthToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_chkDontSaveAuthToken.Name = "m_chkDontSaveAuthToken";
            this.m_chkDontSaveAuthToken.Size = new System.Drawing.Size(215, 24);
            this.m_chkDontSaveAuthToken.TabIndex = 0;
            this.m_chkDontSaveAuthToken.Text = "Lbl_DontSaveAuthToken";
            this.m_chkDontSaveAuthToken.UseVisualStyleBackColor = true;
            // 
            // m_grpDriveAuth
            // 
            this.m_grpDriveAuth.Controls.Add(this.AuthorizeFiles_label);
            this.m_grpDriveAuth.Controls.Add(this.AuthorizeFiles_btn);
            this.m_grpDriveAuth.Controls.Add(this.m_lnkGoogle);
            this.m_grpDriveAuth.Controls.Add(this.m_lnkHelp);
            this.m_grpDriveAuth.Location = new System.Drawing.Point(9, 412);
            this.m_grpDriveAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveAuth.Name = "m_grpDriveAuth";
            this.m_grpDriveAuth.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveAuth.Size = new System.Drawing.Size(810, 162);
            this.m_grpDriveAuth.TabIndex = 4;
            this.m_grpDriveAuth.TabStop = false;
            this.m_grpDriveAuth.Text = "Group_gDriveAuth";
            // 
            // AuthorizeFiles_label
            // 
            this.AuthorizeFiles_label.Location = new System.Drawing.Point(27, 46);
            this.AuthorizeFiles_label.Name = "AuthorizeFiles_label";
            this.AuthorizeFiles_label.Size = new System.Drawing.Size(156, 39);
            this.AuthorizeFiles_label.TabIndex = 8;
            this.AuthorizeFiles_label.Text = "AuthorizeFiles_label";
            this.AuthorizeFiles_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AuthorizeFiles_label.UseCompatibleTextRendering = true;
            // 
            // AuthorizeFiles_btn
            // 
            this.AuthorizeFiles_btn.Location = new System.Drawing.Point(197, 46);
            this.AuthorizeFiles_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AuthorizeFiles_btn.Name = "AuthorizeFiles_btn";
            this.AuthorizeFiles_btn.Size = new System.Drawing.Size(153, 39);
            this.AuthorizeFiles_btn.TabIndex = 7;
            this.AuthorizeFiles_btn.Text = "AuthorizeFiles_btn";
            this.AuthorizeFiles_btn.UseCompatibleTextRendering = true;
            this.AuthorizeFiles_btn.UseVisualStyleBackColor = true;
            this.AuthorizeFiles_btn.Click += new System.EventHandler(this.HandleAuthorizeFilesAction);
            // 
            // m_lnkGoogle
            // 
            this.m_lnkGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkGoogle.AutoSize = true;
            this.m_lnkGoogle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGoogle.Location = new System.Drawing.Point(280, 132);
            this.m_lnkGoogle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkGoogle.Name = "m_lnkGoogle";
            this.m_lnkGoogle.Size = new System.Drawing.Size(128, 20);
            this.m_lnkGoogle.TabIndex = 6;
            this.m_lnkGoogle.TabStop = true;
            this.m_lnkGoogle.Text = "Lnk_GoogleDev";
            // 
            // m_lnkHelp
            // 
            this.m_lnkHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_lnkHelp.AutoSize = true;
            this.m_lnkHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkHelp.Location = new System.Drawing.Point(192, 132);
            this.m_lnkHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lnkHelp.Name = "m_lnkHelp";
            this.m_lnkHelp.Size = new System.Drawing.Size(80, 20);
            this.m_lnkHelp.TabIndex = 5;
            this.m_lnkHelp.TabStop = true;
            this.m_lnkHelp.Text = "Lnk_Help";
            // 
            // m_grpEntry
            // 
            this.m_grpEntry.Controls.Add(this.m_cbAccount);
            this.m_grpEntry.Controls.Add(this.m_lblAccount);
            this.m_grpEntry.Location = new System.Drawing.Point(9, 9);
            this.m_grpEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpEntry.Name = "m_grpEntry";
            this.m_grpEntry.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpEntry.Size = new System.Drawing.Size(810, 125);
            this.m_grpEntry.TabIndex = 0;
            this.m_grpEntry.TabStop = false;
            this.m_grpEntry.Text = "Group_Entry";
            // 
            // m_cbAccount
            // 
            this.m_cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbAccount.FormattingEnabled = true;
            this.m_cbAccount.Location = new System.Drawing.Point(197, 51);
            this.m_cbAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_cbAccount.Name = "m_cbAccount";
            this.m_cbAccount.Size = new System.Drawing.Size(584, 28);
            this.m_cbAccount.TabIndex = 0;
            // 
            // m_lblAccount
            // 
            this.m_lblAccount.Location = new System.Drawing.Point(27, 55);
            this.m_lblAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblAccount.Name = "m_lblAccount";
            this.m_lblAccount.Size = new System.Drawing.Size(156, 20);
            this.m_lblAccount.TabIndex = 5;
            this.m_lblAccount.Text = "Lbl_AuthPwEntry";
            this.m_lblAccount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_grpDriveOptions
            // 
            this.m_grpDriveOptions.Controls.Add(this.m_lblHintFolder);
            this.m_grpDriveOptions.Controls.Add(this.m_txtFolder);
            this.m_grpDriveOptions.Controls.Add(this.m_lblFolder);
            this.m_grpDriveOptions.Location = new System.Drawing.Point(9, 142);
            this.m_grpDriveOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveOptions.Name = "m_grpDriveOptions";
            this.m_grpDriveOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_grpDriveOptions.Size = new System.Drawing.Size(810, 128);
            this.m_grpDriveOptions.TabIndex = 1;
            this.m_grpDriveOptions.TabStop = false;
            this.m_grpDriveOptions.Text = "Group_DriveOptions";
            // 
            // m_lblHintFolder
            // 
            this.m_lblHintFolder.AutoSize = true;
            this.m_lblHintFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblHintFolder.Location = new System.Drawing.Point(192, 29);
            this.m_lblHintFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblHintFolder.Name = "m_lblHintFolder";
            this.m_lblHintFolder.Size = new System.Drawing.Size(187, 17);
            this.m_lblHintFolder.TabIndex = 30;
            this.m_lblHintFolder.Text = "Lbl_DefaultTargetFolderHint";
            // 
            // m_txtFolder
            // 
            this.m_txtFolder.Location = new System.Drawing.Point(197, 54);
            this.m_txtFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_txtFolder.Name = "m_txtFolder";
            this.m_txtFolder.Size = new System.Drawing.Size(432, 26);
            this.m_txtFolder.TabIndex = 0;
            // 
            // m_lblFolder
            // 
            this.m_lblFolder.Location = new System.Drawing.Point(27, 59);
            this.m_lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblFolder.Name = "m_lblFolder";
            this.m_lblFolder.Size = new System.Drawing.Size(156, 20);
            this.m_lblFolder.TabIndex = 22;
            this.m_lblFolder.Text = "Lbl_TargetFolder";
            this.m_lblFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_tabMain
            // 
            this.m_tabMain.Controls.Add(this.m_tabGSignIn);
            this.m_tabMain.Controls.Add(this.m_tabOptions);
            this.m_tabMain.ImageList = this.m_imgList;
            this.m_tabMain.Location = new System.Drawing.Point(18, 101);
            this.m_tabMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_tabMain.Name = "m_tabMain";
            this.m_tabMain.SelectedIndex = 0;
            this.m_tabMain.Size = new System.Drawing.Size(840, 692);
            this.m_tabMain.TabIndex = 0;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 854);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOK);
            this.Controls.Add(this.m_btnAbout);
            this.Controls.Add(this.m_tabMain);
            this.Controls.Add(this.m_bannerImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Text";
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).EndInit();
            this.m_tabOptions.ResumeLayout(false);
            this.m_grpAuthTokenSecurityDefaults.ResumeLayout(false);
            this.m_grpAuthTokenSecurityDefaults.PerformLayout();
            this.m_grpCmdEnabled.ResumeLayout(false);
            this.m_grpCmdEnabled.PerformLayout();
            this.m_grpDriveAuthDefaults.ResumeLayout(false);
            this.m_grpDriveAuthDefaults.PerformLayout();
            this.m_grpFolderDefaults.ResumeLayout(false);
            this.m_grpFolderDefaults.PerformLayout();
            this.m_grpAutoSync.ResumeLayout(false);
            this.m_grpAutoSync.PerformLayout();
            this.m_tabGSignIn.ResumeLayout(false);
            this.m_grpAuthTokenSecurity.ResumeLayout(false);
            this.m_grpAuthTokenSecurity.PerformLayout();
            this.m_grpDriveAuth.ResumeLayout(false);
            this.m_grpDriveAuth.PerformLayout();
            this.m_grpEntry.ResumeLayout(false);
            this.m_grpDriveOptions.ResumeLayout(false);
            this.m_grpDriveOptions.PerformLayout();
            this.m_tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label AuthorizeFiles_label;

        private System.Windows.Forms.Button AuthorizeFiles_btn;

        #endregion

        private System.Windows.Forms.PictureBox m_bannerImage;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnAbout;
        private System.Windows.Forms.ImageList m_imgList;
        private System.Windows.Forms.ToolTip m_toolTipper;
        private System.Windows.Forms.TabPage m_tabOptions;
        private System.Windows.Forms.GroupBox m_grpAuthTokenSecurityDefaults;
        private System.Windows.Forms.LinkLabel m_lnkAuthTokenDefaultsHelp;
        private System.Windows.Forms.CheckBox m_chkWarnAuthToken;
        private System.Windows.Forms.CheckBox m_chkDontSaveAuthDefault;
        private System.Windows.Forms.GroupBox m_grpCmdEnabled;
        private System.Windows.Forms.CheckBox m_chkDownloadEnabled;
        private System.Windows.Forms.CheckBox m_chkUploadEnabled;
        private System.Windows.Forms.CheckBox m_chkSyncEnabled;
        private System.Windows.Forms.GroupBox m_grpDriveAuthDefaults;
        private System.Windows.Forms.LinkLabel m_lnkGoogle2;
        private System.Windows.Forms.LinkLabel m_lnkHelp2;
        private System.Windows.Forms.GroupBox m_grpFolderDefaults;
        private System.Windows.Forms.Button m_btnGetColors;
        private System.Windows.Forms.ComboBox m_cbColors;
        private System.Windows.Forms.Label m_lblHintDefaultFolder;
        private System.Windows.Forms.TextBox m_txtFolderDefault;
        private System.Windows.Forms.Label m_lblDefaultFolderLabel;
        private System.Windows.Forms.Label m_lblDefFolderColor;
        private System.Windows.Forms.GroupBox m_grpAutoSync;
        private System.Windows.Forms.CheckBox m_chkSyncOnReopen;
        private System.Windows.Forms.CheckBox m_chkSyncOnSave;
        private System.Windows.Forms.CheckBox m_chkSyncOnOpen;
        private System.Windows.Forms.TabPage m_tabGSignIn;
        private System.Windows.Forms.GroupBox m_grpAuthTokenSecurity;
        private System.Windows.Forms.LinkLabel m_lnkAuthTokenHelp;
        private System.Windows.Forms.CheckBox m_chkDontSaveAuthToken;
        private System.Windows.Forms.GroupBox m_grpDriveAuth;
        private System.Windows.Forms.LinkLabel m_lnkGoogle;
        private System.Windows.Forms.LinkLabel m_lnkHelp;
        private System.Windows.Forms.GroupBox m_grpEntry;
        private System.Windows.Forms.ComboBox m_cbAccount;
        private System.Windows.Forms.Label m_lblAccount;
        private System.Windows.Forms.GroupBox m_grpDriveOptions;
        private System.Windows.Forms.Label m_lblHintFolder;
        private System.Windows.Forms.TextBox m_txtFolder;
        private System.Windows.Forms.Label m_lblFolder;
        private System.Windows.Forms.TabControl m_tabMain;
        private System.Windows.Forms.ToolTip AuthorizeFiles_tooltip;
    }
}
