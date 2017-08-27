using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// Import HTML handling packages.
using HtmlAgilityPack;

// Import Material Skins.
using MaterialSkin;
using MaterialSkin.Controls;

namespace Metacraft.FlightSimulation.WoaiDownloader
{
    public partial class MainForm : MaterialForm
	{
        private const string FORM_TITLE = "World Of AI Package Downloader";

		private const string WORLD_OF_AI_PACKAGE_LIST_URL = "http://www.world-of-ai.com/allpackages.php";
        private const string WORLD_OF_AI_PACKAGE_INSTALLER_URL = "http://www.world-of-ai.com/installer.php";

        private const string AVSIM_LOGIN_URL = "https://library.avsim.net/dologin.php";
        private const string AVSIM_REGISTER_URL = "https://library.avsim.net/register.php";
        private const string AVSIM_DOWNLOAD_URL_FORMAT = "https://library.avsim.net/sendfile.php?Location=AVSIM&Proto=ftp&DLID={0}";
        
        private const string LOCAL_PACKAGE_LIST_FILE = "packages.html";
        private List<PackageGroup> mPackageGroups = new List<PackageGroup>() {
			new PackageGroup("airlines", "Passenger Airlines"),
			new PackageGroup("cargo", "Cargo Airlines"),
			new PackageGroup("ga", "General Aviation"),
			new PackageGroup("military", "Military"),
			new PackageGroup("ceased", "Airlines No Longer Operating")
		};
		private Dictionary<string, Dictionary<string, List<PackageInfo>>> mPackages;
		private WebClient mPackageListClient = new WebClient();
		private CookieAwareWebClient mPackageDownloadClient = new CookieAwareWebClient();
        private List<PackageInfo> mSelectedPackages;
        private int mCurrentPackageIndex;

		private bool mDownloadInProgress;
        private bool skipPreviouslySavedFiles = false;

        public MainForm()
		{
			InitializeComponent();

            // Create a material theme manager and add the form  to manage (this).
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure colour schema.
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			mPackageListClient.DownloadProgressChanged += mPackageListClient_DownloadProgressChanged;
			mPackageListClient.DownloadStringCompleted += mPackageListClient_DownloadStringCompleted;
			mPackageDownloadClient.UploadValuesCompleted += mPackageDownloadClient_UploadValuesCompleted;
			mPackageDownloadClient.DownloadStringCompleted += mPackageDownloadClient_DownloadStringCompleted;
			mPackageDownloadClient.DownloadDataCompleted += mPackageDownloadClient_DownloadDataCompleted;

            // Add the download selection and set to FSX.
            ddlSim.Items.Add("FS9");
			ddlSim.Items.Add("FSX");
            ddlSim.SelectedIndex = 1;

			LoadConfig();
			SetControlStates();
		}

		private void LoadConfig()
		{
			Config cfg = Config.Load();
			txtAvsimUsername.Text = cfg.AvsimUsername;
			txtAvsimPassword.Text = cfg.AvsimPassword;
			chkSavePassword.Checked = cfg.SavePassword;
			ddlSim.SelectedItem = cfg.Simulator;
			txtDownloadFolder.Text = cfg.DownloadFolder;
		}

		private void SetControlStates()
		{
			if (mDownloadInProgress) {
				progCurrentFile.Style = ProgressBarStyle.Marquee;
				btnDownloadPackages.Text = "Cancel Download";
				btnDownloadPackages.Enabled = true;

                // Step invisible.
                firstStep.Visible = false;
                secondStep.Visible = false;
                thirdStep.Visible = false;
                fourthStep.Visible = false;

                // Configuration group
                txtAvsimUsername.Enabled = false;
                txtAvsimPassword.Enabled = false;
                chkSavePassword.Enabled = false;
                registerAvsim.Enabled = false;
                chkSkipPreviousSaved.Enabled = false;
                ddlSim.Enabled = false;
                txtDownloadFolder.Enabled = false;
                btnBrowseDownloadFolder.Enabled = false;

                treePackages.Enabled = false;
				btnRefreshPackageList.Enabled = false;

            } else {
				progCurrentFile.Style = ProgressBarStyle.Continuous;
				btnDownloadPackages.Text = "Download Selected Packages";
				btnDownloadPackages.Enabled =
					!string.IsNullOrEmpty(txtAvsimUsername.Text)
					&& !string.IsNullOrEmpty(txtAvsimPassword.Text)
					&& (GetCheckedNodes(treePackages.Nodes).Count > 0);

                // Step visible.
                firstStep.Visible = true;
                secondStep.Visible = true;
                thirdStep.Visible = true;
                fourthStep.Visible = true;

                // Configuration group
                txtAvsimUsername.Enabled = true;
                txtAvsimPassword.Enabled = true;
                chkSavePassword.Enabled = true;
                registerAvsim.Enabled = true;
                chkSkipPreviousSaved.Enabled = true;
                ddlSim.Enabled = true;
                txtDownloadFolder.Enabled = true;
                btnBrowseDownloadFolder.Enabled = true;

                treePackages.Enabled = true;
				btnRefreshPackageList.Enabled = true;
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			Application.DoEvents();
			FetchPackageList();
		}

		private void btnRefreshPackageList_Click_1(object sender, EventArgs e)
		{
			FetchPackageList();
            selectedPackagesCount.Text = "0";
        }

		private void FetchPackageList()
		{
            // Clear any previous messages before fetching the latest package list.
            ClearMessages();

			AddMessage("Fetching package list ...");
			if (File.Exists(LOCAL_PACKAGE_LIST_FILE)) {
				try {
					string html = File.ReadAllText(LOCAL_PACKAGE_LIST_FILE);
					AddMessage(" done." + Environment.NewLine);
					ParsePackageList(html);
					if (mPackages != null) {
						PopulateTree();
					}
				}
				catch (Exception ex) {
					MessageBox.Show(string.Format("Error loading local package file: {0}", ex.Message), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			} else {
				try {
					btnRefreshPackageList.Hide();
					progFetchPackageList.Value = 0;
					progFetchPackageList.Show();
					mPackageListClient.DownloadStringAsync(new Uri(WORLD_OF_AI_PACKAGE_LIST_URL));
				}
				catch (Exception ex) {
					MessageBox.Show(string.Format("Error loading package list from WoAI web site: {0}", ex.Message), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		void mPackageListClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progFetchPackageList.Value = e.ProgressPercentage;
		}

		void mPackageListClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Cancelled) {
				return;
			}
			if (e.Error != null) {
				MessageBox.Show(string.Format("Error loading package list from WoAI web site: {0}{1}{2}{3}", e.Error.Message, Environment.NewLine, Environment.NewLine, e.Error.InnerException != null ? e.Error.InnerException.Message : ""), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				AddErrorMessage(" error." + Environment.NewLine);
				return;
			}
			AddMessage(" done." + Environment.NewLine);
			progFetchPackageList.Hide();
			btnRefreshPackageList.Show();
			ParsePackageList(e.Result);
			if (mPackages != null) {
				PopulateTree();
			}
		}

        private void ParsePackageList(string html)
        {
            AddMessage("Parsing package links ...");
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            mPackages = new Dictionary<string, Dictionary<string, List<PackageInfo>>>();
            doc.LoadHtml(html);
            foreach (PackageGroup packageGroup in mPackageGroups)
            {
                mPackages.Add(packageGroup.Name, new Dictionary<string, List<PackageInfo>>());
                string query = string.Format("//a[@name='{0}']/following::table[1]", packageGroup.Anchor);
                HtmlNode table = doc.DocumentNode.SelectSingleNode(query);
                if (table == null) continue;
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    HtmlNodeCollection cells = row.SelectNodes("td");
                    if (cells.Count != 6) continue;
                    PackageInfo pi = new PackageInfo()
                    {
                        Name = cells[1].InnerText.Trim(),
                        Country = cells[2].InnerText.Trim()
                    };
                    if (string.IsNullOrEmpty(pi.Country)) pi.Country = "N/A";
                    HtmlNodeCollection links = cells[5].SelectNodes("a");
                    List<HtmlAgilityPack.HtmlNode> avsimLinks = new List<HtmlAgilityPack.HtmlNode>();
                    foreach (HtmlAgilityPack.HtmlNode link in links)
                    {
                        if (link.InnerText.ToLower().Trim() == "avsim")
                        {
                            avsimLinks.Add(link);
                        }
                    }
                    if (avsimLinks.Count == 1)
                    {
                        pi.AvsimUrlFs9 = avsimLinks[0].Attributes["href"].Value;
                        pi.AvsimUrlFsx = pi.AvsimUrlFs9;
                    }
                    else if (avsimLinks.Count == 2)
                    {
                        pi.AvsimUrlFs9 = avsimLinks[0].Attributes["href"].Value;
                        pi.AvsimUrlFsx = avsimLinks[1].Attributes["href"].Value;
                    }
                    else
                    {
                        MessageBox.Show(this, "Error finding AVSIM links for package: \"" + pi.Name + "\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!mPackages[packageGroup.Name].ContainsKey(pi.Country)) mPackages[packageGroup.Name].Add(pi.Country, new List<PackageInfo>());
                    mPackages[packageGroup.Name][pi.Country].Add(pi);
                }
            }
            AddMessage(" done." + Environment.NewLine);
            AddMessage(new string('_', 97) + Environment.NewLine, Color.Green);
        }

		private void PopulateTree()
		{
			treePackages.Nodes.Clear();
			foreach (PackageGroup packageGroup in mPackageGroups) {
				TreeNode groupNode = treePackages.Nodes.Add(packageGroup.Name);
				foreach (string country in mPackages[packageGroup.Name].Keys.OrderBy(x => x)) {
					TreeNode countryNode = groupNode.Nodes.Add(country);
					foreach (PackageInfo pi in mPackages[packageGroup.Name][country].OrderBy(x => x.Name)) {
						TreeNode packageNode = countryNode.Nodes.Add(pi.Name);
						packageNode.Tag = pi;
					}
				}
			}
		}

		private void treePackages_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent != null) {
				e.Node.Parent.Expand();
			}
		}

		private void treePackages_AfterCheck(object sender, TreeViewEventArgs e)
		{
			treePackages.AfterCheck -= new TreeViewEventHandler(treePackages_AfterCheck);
			CheckAllNodes(e.Node, e.Node.Checked);
			CheckParentsWhereAllChildrenChecked(treePackages.Nodes);
			treePackages.AfterCheck += new TreeViewEventHandler(treePackages_AfterCheck);
			SetControlStates();


            selectedPackagesCount.Text = GetCheckedNodes(treePackages.Nodes).Count.ToString();
        }

		private List<TreeNode> GetCheckedNodes(TreeNodeCollection nodes)
		{
			List<TreeNode> checkedNodes = new List<TreeNode>();
			foreach (TreeNode node in nodes) {
				if (node.Checked) {
					checkedNodes.Add(node);
				}
				checkedNodes.AddRange(GetCheckedNodes(node.Nodes));
			}

			return checkedNodes;
		}

		private void CheckAllNodes(TreeNode node, bool isChecked)
		{
			foreach (TreeNode childNode in node.Nodes) {
				childNode.Checked = isChecked;
				CheckAllNodes(childNode, isChecked);
			}
		}

		private void CheckParentsWhereAllChildrenChecked(TreeNodeCollection nodes)
		{
			bool allChecked = true;
			foreach (TreeNode node in nodes) {
				CheckParentsWhereAllChildrenChecked(node.Nodes);
				if (!node.Checked) allChecked = false;
			}
			if ((nodes.Count > 0) && (nodes[0].Parent != null)) {
				nodes[0].Parent.Checked = allChecked;
			}
		}

		private void btnBrowseDownloadFolder_Click_1(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Specify the folder where the package files will be saved:";
			dlg.ShowNewFolderButton = true;
			dlg.SelectedPath = txtDownloadFolder.Text;
			DialogResult result = dlg.ShowDialog(this);
			if (result == DialogResult.OK) {
				txtDownloadFolder.Text = dlg.SelectedPath;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveConfig();
			if (mPackageListClient != null) {
				mPackageListClient.Dispose();
			}
			if (mPackageDownloadClient != null) {
				mPackageDownloadClient.Dispose();
			}
		}

		private void Credentials_TextChanged(object sender, EventArgs e)
		{
			SetControlStates();
		}

		private void btnDownloadPackages_Click_1(object sender, EventArgs e)
		{
			if (mDownloadInProgress) {
				StopDownload();
			} else {
				StartDownload();
			}
		}

		private bool hasWriteAccessToFolder(string folderPath)
		{
			try {
				// Attempt to get a list of security permissions from the folder. 
				// This will raise an exception if the path is read only or do not have access to view the permissions. 
				System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
				return true;
			}
			catch (UnauthorizedAccessException) {
				return false;
			}
		}

		private void StartDownload()
		{
            // Make sure the folder we are going to download to exists.
            if (!Directory.Exists(txtDownloadFolder.Text))
            {
                DialogResult dialogResult = MessageBox.Show("The download folder you have selected does not exist, would you like to create it now?", FORM_TITLE, MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(txtDownloadFolder.Text);
                    AddMessage("Created new download folder: " + txtDownloadFolder.Text + Environment.NewLine);
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Please select another download folder before starting to download the selected packages.", FORM_TITLE);
                    return;
                }
            }

            // Check if the folder we are going to save the downloaded packages to has write access.
            if (!hasWriteAccessToFolder(txtDownloadFolder.Text))
            {
                MessageBox.Show("You do not appear to have write access to the specified download folder.", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mDownloadInProgress = true;
            SetControlStates();
            mSelectedPackages = GetCheckedNodes(treePackages.Nodes).Where(x => x.Tag != null).Select(x => x.Tag as PackageInfo).ToList();
            mCurrentPackageIndex = -1;
            progOverall.Value = 0;
            progOverall.Maximum = mSelectedPackages.Count;
            DoLogin();
		}

		private void StopDownload()
		{
			if (mPackageDownloadClient.IsBusy) {
				mPackageDownloadClient.CancelAsync();
			}

			mDownloadInProgress = false;
			SetControlStates();
			progOverall.Value = 0;
			AddErrorMessage("Download aborted." + Environment.NewLine);
		}

		private void DoLogin()
		{
			AddMessage("Logging into AVSIM ...");
			NameValueCollection form = new NameValueCollection();
			form.Add("UserLogin", txtAvsimUsername.Text);
			form.Add("Password", txtAvsimPassword.Text);
			mPackageDownloadClient.UploadValuesAsync(new Uri(AVSIM_LOGIN_URL), "POST", form);
		}

		void mPackageDownloadClient_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
		{
			if (e.Cancelled) {
				return;
			}
			if (e.Error != null) {
				AddErrorMessage(" error." + Environment.NewLine);
				StopDownload();
				MessageBox.Show(string.Format("Error logging into AVSIM: {0}{1}{2}{3}", e.Error.Message, Environment.NewLine, Environment.NewLine, e.Error.InnerException != null ? e.Error.InnerException.Message : ""), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			CookieCollection cookies = mPackageDownloadClient.CookieContainer.GetCookies(new Uri(AVSIM_LOGIN_URL));
			bool gotAuthCookie = false;
			foreach (Cookie cookie in cookies) {
				cookie.Path = "/";
				if (cookie.Name == "LibraryLogin") {
					gotAuthCookie = true;
				}
			}

			mPackageDownloadClient.CookieContainer.Add(cookies);
			if (!gotAuthCookie) {
				AddErrorMessage(" error." + Environment.NewLine);
				StopDownload();
				MessageBox.Show("AVSIM login failed. Please check your username and password.", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			AddMessage(" done." + Environment.NewLine);

			DownloadNextPackage();
		}

		private void DownloadNextPackage()
		{
			mCurrentPackageIndex++;
			if (mCurrentPackageIndex >= mSelectedPackages.Count) {
				mDownloadInProgress = false;
				SetControlStates();

				MessageBox.Show("Package download complete!", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			AddMessage(string.Format("\nFetching download link for {0} ...", mSelectedPackages[mCurrentPackageIndex].Name) + Environment.NewLine); 
			string downloadUri = (ddlSim.SelectedItem.ToString() == "FSX") ? mSelectedPackages[mCurrentPackageIndex].AvsimUrlFsx : mSelectedPackages[mCurrentPackageIndex].AvsimUrlFs9;

            // Get the filename of the file we are to download for use if the skip by name option is checked.
            Match fileNameMatch = Regex.Match(downloadUri, "SearchTerm=(.*?)&", RegexOptions.IgnoreCase);
            string currentFileName = fileNameMatch.Groups[1].Value.ToLower();
            AddMessage("Current file: " + currentFileName + Environment.NewLine);

            // If the skip by name is checked, check if the current file we are about to download exists or 
            // not in the download folder.
            if (skipPreviouslySavedFiles)
            {
                string checkFilePath = txtDownloadFolder.Text + "\\" + currentFileName;
                AddMessage("Checking if file exists at: " + checkFilePath);
                if (File.Exists(checkFilePath))
                {
                    AddMessage("File " + currentFileName + " already exists, skipping to next file.", Color.Orange);
                    DownloadNextPackage();
                }
                else
                {
                    mPackageDownloadClient.DownloadStringAsync(new Uri(downloadUri));
                }
            }
            else
            {
                mPackageDownloadClient.DownloadStringAsync(new Uri(downloadUri));
            }
		}

		void mPackageDownloadClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Cancelled) {
				return;
			}

			if (e.Error != null) {
				AddErrorMessage(" error." + Environment.NewLine);
				StopDownload();
				MessageBox.Show(string.Format("Error fetching download link or FTP URL: {0}{1}{2}{3}", e.Error.Message, Environment.NewLine, Environment.NewLine, e.Error.InnerException != null ? e.Error.InnerException.Message : ""), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string redirectUrl = mPackageDownloadClient.ResponseHeaders[HttpResponseHeader.Location];
			AddMessage(" done." + Environment.NewLine);

			if (!string.IsNullOrEmpty(redirectUrl)) {
				AddMessage("Following redirect ...");
				mPackageDownloadClient.DownloadStringAsync(new Uri(redirectUrl));
				return;
			}

			HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(e.Result);
			HtmlNode link = doc.DocumentNode.SelectSingleNode("//a[contains(@href,'download.php')]");
			if (link == null) {
				AddErrorMessage("Could not find download link in HTML returned from AVSIM." + Environment.NewLine);
				DownloadNextPackage();
				return;
			}

			Match fileIdMatch = Regex.Match(link.Attributes["href"].Value, @"DLID=(\d+)", RegexOptions.IgnoreCase);
			if (!fileIdMatch.Success) {
				AddErrorMessage("Could not find download link in HTML returned from AVSIM." + Environment.NewLine);
				DownloadNextPackage();
				return;
			}

			string downloadUrl = string.Format(AVSIM_DOWNLOAD_URL_FORMAT, fileIdMatch.Groups[1].Value);
			AddMessage("Downloading file ...");
			mPackageDownloadClient.DownloadDataAsync(new Uri(downloadUrl));
		}

		void mPackageDownloadClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {

            if (e.Cancelled) {
				return;
			}

			if (e.Error != null) {
				AddErrorMessage(" error." + Environment.NewLine);
				StopDownload();
				MessageBox.Show(string.Format("Error downloading package: {0}{1}{2}{3}", e.Error.Message, Environment.NewLine, Environment.NewLine, e.Error.InnerException != null ? e.Error.InnerException.Message : ""), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string filenameHeader = mPackageDownloadClient.ResponseHeaders["Content-Disposition"] ?? string.Empty;
			Match fileNameMatch = Regex.Match(filenameHeader, "filename=\"(.+?)\"", RegexOptions.IgnoreCase);
			if (!fileNameMatch.Success) {
				AddErrorMessage(" filename not found in response headers." + Environment.NewLine);
				DownloadNextPackage();
				return;
			}

			string filename = Path.Combine(txtDownloadFolder.Text, fileNameMatch.Groups[1].Value);
			try {
				File.WriteAllBytes(filename, e.Result);
			}
			catch (Exception ex) {
				AddErrorMessage(" error." + Environment.NewLine);
				StopDownload();
				MessageBox.Show(string.Format("Error saving downloaded package: {0}{1}{2}{3}", ex.Message, Environment.NewLine, Environment.NewLine, ex.InnerException != null ? ex.InnerException.Message : ""), FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            AddMessage(" done." + Environment.NewLine);
			progOverall.Value = mCurrentPackageIndex + 1;

            DownloadNextPackage();
		}

		private void AddMessage(string message)
		{
			AddMessage(message, Color.Black);
		}

		private void AddErrorMessage(string error)
		{
			AddMessage(error, Color.Red);
		}

		private void AddMessage(string message, Color color)
		{
			if (rtfMessages.IsDisposed || rtfMessages.Disposing) {
				return;
			}
			if (string.IsNullOrEmpty(message)) {
				return;
			}
			bool scrolledToBottom = rtfMessages.IsAtMaxScroll();
			rtfMessages.SelectionStart = rtfMessages.TextLength;
			rtfMessages.SelectionColor = color;
			rtfMessages.SelectedText = message;
			rtfMessages.SelectionStart = rtfMessages.TextLength;
			if (scrolledToBottom) {
				rtfMessages.ScrollToCaret();
			}
		}

        private void ClearMessages()
        {
            rtfMessages.Clear();
        }

        // TODO: Password does not automatically load.
		private void SaveConfig()
		{
			Config cfg = new Config() {
				AvsimUsername = txtAvsimUsername.Text,
				AvsimPassword = chkSavePassword.Checked ? txtAvsimPassword.Text : string.Empty,
				SavePassword = chkSavePassword.Checked,
				Simulator = ddlSim.SelectedItem.ToString(),
				DownloadFolder = txtDownloadFolder.Text
			};
			cfg.Save();
		}

        private void chkSkipPreviousSaved_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkipPreviousSaved.Checked)
            {
                MessageBox.Show("Beware that this will skip previous files that have been downloaded (under the same name) which may be corrupt or incomplete." +
                    "\n\n It is best to untick and download the latest files.\n\n" +
                    "HOWEVER, you can still use this to check if you have all the files from World Of AI.", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                skipPreviouslySavedFiles = true;
                AddMessage("\n* Skipping previously downloaded World Of AI files by name.*\n", Color.Blue);
            }
            else
            {
                skipPreviouslySavedFiles = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(AVSIM_REGISTER_URL);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(WORLD_OF_AI_PACKAGE_INSTALLER_URL);
        }

        private void GitHubImage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/RossMetacraft");
        }

        // Click/select or check changed events we no longer which were extras.
        private void label6_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label9_Click_1(object sender, EventArgs e) { }
        private void treePackages_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void materialLabel1_Click(object sender, EventArgs e) { } 
        private void materialLabel2_Click(object sender, EventArgs e) { }
        private void materialLabel1_Click_1(object sender, EventArgs e) { }
        private void materialLabel2_Click_1(object sender, EventArgs e) { }
        private void txtAvsimPassword_Click(object sender, EventArgs e) { }
        private void materialLabel4_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void progCurrentFile_Click(object sender, EventArgs e) { }
        private void materialLabel6_Click(object sender, EventArgs e) { }
    }
}
