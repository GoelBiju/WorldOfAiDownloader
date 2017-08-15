namespace Metacraft.FlightSimulation.WoaiDownloader
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
			if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treePackages = new System.Windows.Forms.TreeView();
            this.registerAvsim = new System.Windows.Forms.LinkLabel();
            this.ddlSim = new System.Windows.Forms.ComboBox();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.progOverall = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progCurrentFile = new System.Windows.Forms.ProgressBar();
            this.rtfMessages = new Metacraft.FlightSimulation.WoaiDownloader.EnhancedRichTextBox();
            this.availablePackagesLabel = new MaterialSkin.Controls.MaterialLabel();
            this.selectedPackagesLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.selectedPackagesCount = new MaterialSkin.Controls.MaterialLabel();
            this.chkSavePassword = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtAvsimUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtAvsimPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBrowseDownloadFolder = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.firstStep = new System.Windows.Forms.PictureBox();
            this.secondStep = new System.Windows.Forms.PictureBox();
            this.thirdStep = new System.Windows.Forms.PictureBox();
            this.btnRefreshPackageList = new MaterialSkin.Controls.MaterialFlatButton();
            this.progFetchPackageList = new System.Windows.Forms.ProgressBar();
            this.chkSkipPreviousSaved = new MaterialSkin.Controls.MaterialCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.fourthStep = new System.Windows.Forms.PictureBox();
            this.btnDownloadPackages = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.firstStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthStep)).BeginInit();
            this.SuspendLayout();
            // 
            // treePackages
            // 
            this.treePackages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treePackages.BackColor = System.Drawing.Color.White;
            this.treePackages.CheckBoxes = true;
            this.treePackages.Location = new System.Drawing.Point(12, 141);
            this.treePackages.Name = "treePackages";
            this.treePackages.Size = new System.Drawing.Size(250, 426);
            this.treePackages.TabIndex = 2;
            this.treePackages.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treePackages_AfterCheck);
            this.treePackages.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treePackages_AfterExpand);
            this.treePackages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePackages_AfterSelect);
            // 
            // registerAvsim
            // 
            this.registerAvsim.AutoSize = true;
            this.registerAvsim.BackColor = System.Drawing.Color.White;
            this.registerAvsim.Location = new System.Drawing.Point(284, 113);
            this.registerAvsim.Name = "registerAvsim";
            this.registerAvsim.Size = new System.Drawing.Size(173, 13);
            this.registerAvsim.TabIndex = 10;
            this.registerAvsim.TabStop = true;
            this.registerAvsim.Tag = "";
            this.registerAvsim.Text = "Register account on AVSIM Library";
            this.registerAvsim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registerAvsim.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ddlSim
            // 
            this.ddlSim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSim.FormattingEnabled = true;
            this.ddlSim.Location = new System.Drawing.Point(337, 181);
            this.ddlSim.Name = "ddlSim";
            this.ddlSim.Size = new System.Drawing.Size(70, 21);
            this.ddlSim.TabIndex = 6;
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadFolder.BackColor = System.Drawing.Color.White;
            this.txtDownloadFolder.Location = new System.Drawing.Point(527, 185);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.ReadOnly = true;
            this.txtDownloadFolder.Size = new System.Drawing.Size(269, 20);
            this.txtDownloadFolder.TabIndex = 8;
            // 
            // progOverall
            // 
            this.progOverall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progOverall.Location = new System.Drawing.Point(351, 544);
            this.progOverall.Name = "progOverall";
            this.progOverall.Size = new System.Drawing.Size(519, 23);
            this.progOverall.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progOverall.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(279, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Overall:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(276, 515);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Current File:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progCurrentFile
            // 
            this.progCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progCurrentFile.Location = new System.Drawing.Point(351, 515);
            this.progCurrentFile.MarqueeAnimationSpeed = 10;
            this.progCurrentFile.Name = "progCurrentFile";
            this.progCurrentFile.Size = new System.Drawing.Size(519, 23);
            this.progCurrentFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progCurrentFile.TabIndex = 7;
            // 
            // rtfMessages
            // 
            this.rtfMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfMessages.Location = new System.Drawing.Point(279, 246);
            this.rtfMessages.Name = "rtfMessages";
            this.rtfMessages.Size = new System.Drawing.Size(591, 263);
            this.rtfMessages.TabIndex = 5;
            this.rtfMessages.Text = "";
            // 
            // availablePackagesLabel
            // 
            this.availablePackagesLabel.AutoSize = true;
            this.availablePackagesLabel.BackColor = System.Drawing.Color.White;
            this.availablePackagesLabel.Depth = 0;
            this.availablePackagesLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.availablePackagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.availablePackagesLabel.Location = new System.Drawing.Point(53, 75);
            this.availablePackagesLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.availablePackagesLabel.Name = "availablePackagesLabel";
            this.availablePackagesLabel.Size = new System.Drawing.Size(139, 19);
            this.availablePackagesLabel.TabIndex = 14;
            this.availablePackagesLabel.Text = "Available Packages";
            this.availablePackagesLabel.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // selectedPackagesLabel
            // 
            this.selectedPackagesLabel.AutoSize = true;
            this.selectedPackagesLabel.BackColor = System.Drawing.Color.White;
            this.selectedPackagesLabel.Depth = 0;
            this.selectedPackagesLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.selectedPackagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.selectedPackagesLabel.Location = new System.Drawing.Point(12, 109);
            this.selectedPackagesLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.selectedPackagesLabel.Name = "selectedPackagesLabel";
            this.selectedPackagesLabel.Size = new System.Drawing.Size(140, 19);
            this.selectedPackagesLabel.TabIndex = 15;
            this.selectedPackagesLabel.Text = "Selected Packages:";
            this.selectedPackagesLabel.Click += new System.EventHandler(this.materialLabel2_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(545, 224);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(78, 19);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "Messages";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click_1);
            // 
            // selectedPackagesCount
            // 
            this.selectedPackagesCount.AutoSize = true;
            this.selectedPackagesCount.BackColor = System.Drawing.Color.White;
            this.selectedPackagesCount.Depth = 0;
            this.selectedPackagesCount.Font = new System.Drawing.Font("Roboto", 11F);
            this.selectedPackagesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.selectedPackagesCount.Location = new System.Drawing.Point(171, 109);
            this.selectedPackagesCount.MouseState = MaterialSkin.MouseState.HOVER;
            this.selectedPackagesCount.Name = "selectedPackagesCount";
            this.selectedPackagesCount.Size = new System.Drawing.Size(17, 19);
            this.selectedPackagesCount.TabIndex = 17;
            this.selectedPackagesCount.Text = "0";
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.BackColor = System.Drawing.Color.White;
            this.chkSavePassword.Depth = 0;
            this.chkSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSavePassword.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkSavePassword.Location = new System.Drawing.Point(592, 109);
            this.chkSavePassword.Margin = new System.Windows.Forms.Padding(0);
            this.chkSavePassword.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSavePassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Ripple = true;
            this.chkSavePassword.Size = new System.Drawing.Size(123, 19);
            this.chkSavePassword.TabIndex = 18;
            this.chkSavePassword.Text = "Save password";
            this.chkSavePassword.UseVisualStyleBackColor = false;
            // 
            // txtAvsimUsername
            // 
            this.txtAvsimUsername.BackColor = System.Drawing.Color.White;
            this.txtAvsimUsername.Depth = 0;
            this.txtAvsimUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAvsimUsername.Hint = "";
            this.txtAvsimUsername.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAvsimUsername.Location = new System.Drawing.Point(469, 75);
            this.txtAvsimUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAvsimUsername.Name = "txtAvsimUsername";
            this.txtAvsimUsername.PasswordChar = '\0';
            this.txtAvsimUsername.SelectedText = "";
            this.txtAvsimUsername.SelectionLength = 0;
            this.txtAvsimUsername.SelectionStart = 0;
            this.txtAvsimUsername.Size = new System.Drawing.Size(103, 23);
            this.txtAvsimUsername.TabIndex = 19;
            this.txtAvsimUsername.UseSystemPasswordChar = false;
            // 
            // txtAvsimPassword
            // 
            this.txtAvsimPassword.BackColor = System.Drawing.Color.White;
            this.txtAvsimPassword.Depth = 0;
            this.txtAvsimPassword.Hint = "";
            this.txtAvsimPassword.Location = new System.Drawing.Point(774, 75);
            this.txtAvsimPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAvsimPassword.Name = "txtAvsimPassword";
            this.txtAvsimPassword.PasswordChar = '*';
            this.txtAvsimPassword.SelectedText = "";
            this.txtAvsimPassword.SelectionLength = 0;
            this.txtAvsimPassword.SelectionStart = 0;
            this.txtAvsimPassword.Size = new System.Drawing.Size(113, 23);
            this.txtAvsimPassword.TabIndex = 20;
            this.txtAvsimPassword.UseSystemPasswordChar = false;
            this.txtAvsimPassword.Click += new System.EventHandler(this.txtAvsimPassword_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(283, 79);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(180, 19);
            this.materialLabel3.TabIndex = 22;
            this.materialLabel3.Text = "AVSIM Library Username:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(588, 79);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(178, 19);
            this.materialLabel4.TabIndex = 23;
            this.materialLabel4.Text = "AVSIM Library Password:";
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(523, 157);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(182, 19);
            this.materialLabel2.TabIndex = 24;
            this.materialLabel2.Text = "Choose Download Folder:";
            // 
            // btnBrowseDownloadFolder
            // 
            this.btnBrowseDownloadFolder.AutoSize = true;
            this.btnBrowseDownloadFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseDownloadFolder.BackColor = System.Drawing.Color.White;
            this.btnBrowseDownloadFolder.Depth = 0;
            this.btnBrowseDownloadFolder.Location = new System.Drawing.Point(803, 176);
            this.btnBrowseDownloadFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseDownloadFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseDownloadFolder.Name = "btnBrowseDownloadFolder";
            this.btnBrowseDownloadFolder.Primary = false;
            this.btnBrowseDownloadFolder.Size = new System.Drawing.Size(67, 36);
            this.btnBrowseDownloadFolder.TabIndex = 4;
            this.btnBrowseDownloadFolder.Text = "Browse";
            this.btnBrowseDownloadFolder.UseVisualStyleBackColor = false;
            this.btnBrowseDownloadFolder.Click += new System.EventHandler(this.btnBrowseDownloadFolder_Click_1);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.White;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(333, 157);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(124, 19);
            this.materialLabel5.TabIndex = 25;
            this.materialLabel5.Text = "Select Simulator:";
            // 
            // firstStep
            // 
            this.firstStep.BackColor = System.Drawing.Color.White;
            this.firstStep.Image = ((System.Drawing.Image)(resources.GetObject("firstStep.Image")));
            this.firstStep.Location = new System.Drawing.Point(230, 75);
            this.firstStep.Name = "firstStep";
            this.firstStep.Size = new System.Drawing.Size(48, 48);
            this.firstStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.firstStep.TabIndex = 26;
            this.firstStep.TabStop = false;
            // 
            // secondStep
            // 
            this.secondStep.BackColor = System.Drawing.Color.White;
            this.secondStep.Image = ((System.Drawing.Image)(resources.GetObject("secondStep.Image")));
            this.secondStep.Location = new System.Drawing.Point(279, 157);
            this.secondStep.Name = "secondStep";
            this.secondStep.Size = new System.Drawing.Size(48, 48);
            this.secondStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.secondStep.TabIndex = 27;
            this.secondStep.TabStop = false;
            // 
            // thirdStep
            // 
            this.thirdStep.BackColor = System.Drawing.Color.White;
            this.thirdStep.Image = ((System.Drawing.Image)(resources.GetObject("thirdStep.Image")));
            this.thirdStep.Location = new System.Drawing.Point(469, 157);
            this.thirdStep.Name = "thirdStep";
            this.thirdStep.Size = new System.Drawing.Size(48, 48);
            this.thirdStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.thirdStep.TabIndex = 28;
            this.thirdStep.TabStop = false;
            this.thirdStep.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnRefreshPackageList
            // 
            this.btnRefreshPackageList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshPackageList.AutoSize = true;
            this.btnRefreshPackageList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshPackageList.BackColor = System.Drawing.Color.White;
            this.btnRefreshPackageList.Depth = 0;
            this.btnRefreshPackageList.Location = new System.Drawing.Point(56, 575);
            this.btnRefreshPackageList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshPackageList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshPackageList.Name = "btnRefreshPackageList";
            this.btnRefreshPackageList.Primary = false;
            this.btnRefreshPackageList.Size = new System.Drawing.Size(167, 36);
            this.btnRefreshPackageList.TabIndex = 29;
            this.btnRefreshPackageList.Text = "Refresh Package List";
            this.btnRefreshPackageList.UseVisualStyleBackColor = false;
            this.btnRefreshPackageList.Click += new System.EventHandler(this.btnRefreshPackageList_Click_1);
            // 
            // progFetchPackageList
            // 
            this.progFetchPackageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progFetchPackageList.BackColor = System.Drawing.Color.White;
            this.progFetchPackageList.Location = new System.Drawing.Point(12, 575);
            this.progFetchPackageList.MarqueeAnimationSpeed = 10;
            this.progFetchPackageList.Name = "progFetchPackageList";
            this.progFetchPackageList.Size = new System.Drawing.Size(250, 21);
            this.progFetchPackageList.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progFetchPackageList.TabIndex = 4;
            // 
            // chkSkipPreviousSaved
            // 
            this.chkSkipPreviousSaved.BackColor = System.Drawing.Color.White;
            this.chkSkipPreviousSaved.Depth = 0;
            this.chkSkipPreviousSaved.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkSkipPreviousSaved.Location = new System.Drawing.Point(287, 592);
            this.chkSkipPreviousSaved.Margin = new System.Windows.Forms.Padding(0);
            this.chkSkipPreviousSaved.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSkipPreviousSaved.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSkipPreviousSaved.Name = "chkSkipPreviousSaved";
            this.chkSkipPreviousSaved.Ripple = true;
            this.chkSkipPreviousSaved.Size = new System.Drawing.Size(293, 19);
            this.chkSkipPreviousSaved.TabIndex = 30;
            this.chkSkipPreviousSaved.Text = "Skip previously downloaded files by name";
            this.chkSkipPreviousSaved.UseVisualStyleBackColor = false;
            this.chkSkipPreviousSaved.CheckedChanged += new System.EventHandler(this.chkSkipPreviousSaved_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(282, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(697, 41);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(192, 19);
            this.materialLabel6.TabIndex = 32;
            this.materialLabel6.Text = "Developed by Ross Carlson";
            this.materialLabel6.Click += new System.EventHandler(this.materialLabel6_Click);
            // 
            // fourthStep
            // 
            this.fourthStep.BackColor = System.Drawing.Color.White;
            this.fourthStep.Image = ((System.Drawing.Image)(resources.GetObject("fourthStep.Image")));
            this.fourthStep.Location = new System.Drawing.Point(592, 575);
            this.fourthStep.Name = "fourthStep";
            this.fourthStep.Size = new System.Drawing.Size(48, 48);
            this.fourthStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fourthStep.TabIndex = 33;
            this.fourthStep.TabStop = false;
            // 
            // btnDownloadPackages
            // 
            this.btnDownloadPackages.AutoSize = true;
            this.btnDownloadPackages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDownloadPackages.Depth = 0;
            this.btnDownloadPackages.Location = new System.Drawing.Point(647, 581);
            this.btnDownloadPackages.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDownloadPackages.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDownloadPackages.Name = "btnDownloadPackages";
            this.btnDownloadPackages.Primary = false;
            this.btnDownloadPackages.Size = new System.Drawing.Size(229, 36);
            this.btnDownloadPackages.TabIndex = 34;
            this.btnDownloadPackages.Text = "Download Selected Packages";
            this.btnDownloadPackages.UseVisualStyleBackColor = true;
            this.btnDownloadPackages.Click += new System.EventHandler(this.btnDownloadPackages_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(900, 630);
            this.Controls.Add(this.btnDownloadPackages);
            this.Controls.Add(this.fourthStep);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkSkipPreviousSaved);
            this.Controls.Add(this.btnRefreshPackageList);
            this.Controls.Add(this.thirdStep);
            this.Controls.Add(this.secondStep);
            this.Controls.Add(this.firstStep);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.btnBrowseDownloadFolder);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtDownloadFolder);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.ddlSim);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.registerAvsim);
            this.Controls.Add(this.txtAvsimPassword);
            this.Controls.Add(this.txtAvsimUsername);
            this.Controls.Add(this.chkSavePassword);
            this.Controls.Add(this.selectedPackagesCount);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.selectedPackagesLabel);
            this.Controls.Add(this.availablePackagesLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progCurrentFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progOverall);
            this.Controls.Add(this.treePackages);
            this.Controls.Add(this.progFetchPackageList);
            this.Controls.Add(this.rtfMessages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 630);
            this.Name = "MainForm";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World of AI Package Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.firstStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TreeView treePackages;
		private System.Windows.Forms.TextBox txtDownloadFolder;
		private System.Windows.Forms.ProgressBar progOverall;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ProgressBar progCurrentFile;
		private EnhancedRichTextBox rtfMessages;
		private System.Windows.Forms.ComboBox ddlSim;
        private System.Windows.Forms.LinkLabel registerAvsim;
        private MaterialSkin.Controls.MaterialLabel availablePackagesLabel;
        private MaterialSkin.Controls.MaterialLabel selectedPackagesLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel selectedPackagesCount;
        private MaterialSkin.Controls.MaterialCheckBox chkSavePassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAvsimUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAvsimPassword;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton btnBrowseDownloadFolder;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.PictureBox firstStep;
        private System.Windows.Forms.PictureBox secondStep;
        private System.Windows.Forms.PictureBox thirdStep;
        private MaterialSkin.Controls.MaterialFlatButton btnRefreshPackageList;
        private System.Windows.Forms.ProgressBar progFetchPackageList;
        private MaterialSkin.Controls.MaterialCheckBox chkSkipPreviousSaved;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.PictureBox fourthStep;
        private MaterialSkin.Controls.MaterialFlatButton btnDownloadPackages;
    }
}

