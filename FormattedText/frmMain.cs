using FormattedText.Resources;
using Helpers.Security;
using Ionic.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormattedText
{
    public partial class frmMain : Form
    {
        string BaseAddress = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

        public frmMain()
        {
            InitializeComponent();

            this.MinimumSize = new Size(905, 650);
            this.MaximumSize = new Size(905, 650);
            // tabControl1.RightToLeft = RightToLeft.Yes;
            //if (!Directory.Exists(BaseAddress + ))
            //{
            //    Directory.CreateDirectory(BaseAddress + "\\Satraps");
            //}
            var sargs = Directory.GetDirectories(BaseAddress, "Bot_*").Where(x => Regex.IsMatch(Path.GetFileName(x), @"^Bot_[0123456789]{1,2}$")).OrderBy(x => int.Parse(Path.GetFileName(x).Replace("Bot_", ""))).ToList();
            if (sargs.Count() <= 0)
            {
                //Creating MDI child form and initialize its fields
                //if (!File.Exists(BaseAddress + "\\Satrapi.exe") && !File.Exists(BaseAddress + "\\Satrapi"))
                //{
                //    MessageBox.Show(".در مسیر برنامه پیدا نشد" + "\"Satrapi.*\"" + "فایل ");
                //    return;
                //}

                var Dirs = Directory.GetDirectories(BaseAddress, "Bot_*").Where(x => Regex.IsMatch(Path.GetFileName(x), @"^Bot_[0123456789]{1,2}$")).Select(x => Convert.ToInt32(Path.GetFileName(x).Replace("Bot_", "")));

                //childCount = Dirs.OrderBy(x => x).Last() + 1;

                int id = int.Parse(Helpers.Security.SecurityMethodes.GenerateRandomCode(8));
                string DataPath = BaseAddress + "Bot_" + childCount.ToString() + "\\";

                frmTelegramBot childForm = new frmTelegramBot(id, DataPath);
                //DAL.TabCount++;
                childForm.Text = "tab " + childCount.ToString();

                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                /// childForm.Siz
                //child Form will now hold a reference value to the tab control
                childForm.tabCtrl = tabControl1;

                //Add a Tabpage and enables it
                TabPage tp = new TabPage();
                tp.Parent = tabControl1;
                tp.Text = childForm.Text;
                tp.Show();

                //child Form will now hold a reference value to a tabpage
                childForm.tabPag = tp;

                //Activate the MDI child form
                childForm.Show();
                childCount++;

                //Activate the newly created Tabpage
                tabControl1.SelectedTab = tp;
                //  Directory.CreateDirectory(Application.ExecutablePath + "//Satraps//Mangoodarz" + childCount.ToString());
            }
            foreach (var item in sargs)
            {
                // DAL.TabCount++;
                int id = int.Parse(Helpers.Security.SecurityMethodes.GenerateRandomCode(8));
                // string DataPath = BaseAddress + "\\Satraps\\Mangoodarz" + childCount.ToString() + "\\";

                frmTelegramBot childForm = new frmTelegramBot(id, item);
                childForm.Text = "tab " + Path.GetFileName(item).Replace("Bot_", "");
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                /// childForm.Siz
                //child Form will now hold a reference value to the tab control
                childForm.tabCtrl = tabControl1;

                //Add a Tabpage and enables it
                TabPage tp = new TabPage();
                tp.Parent = tabControl1;
                tp.Text = childForm.Text;
                tp.Show();

                //child Form will now hold a reference value to a tabpage
                childForm.tabPag = tp;

                //Activate the MDI child form
                childForm.Show();
                childCount++;

                //Activate the newly created Tabpage
                tabControl1.SelectedTab = tp;
                //  Directory.CreateDirectory(Application.ExecutablePath + "//Satraps//Mangoodarz" + childCount.ToString());
            }




            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1020, 30);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
        }
        //  private IContainer components;
        //private TabControl tabControl1;

        int childCount = 1;


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (frmTelegramBot childForm in this.MdiChildren)
            {
                //Check for its corresponding MDI child form
                if (childForm.tabPag.Equals(tabControl1.SelectedTab))
                {
                    //Activate the MDI child form
                    childForm.Select();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DAL.IsMainClose = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void دربارهToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ایجادتبجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating MDI child form and initialize its fields


            var Dirs = Directory.GetDirectories(BaseAddress, "Bot_*").Where(x => Regex.IsMatch(Path.GetFileName(x), @"^Bot_[0123456789]{1,2}$")).Select(x => Convert.ToInt32(Path.GetFileName(x).Replace("Bot_", "")));
            if (Dirs.Any())
                childCount = Dirs.OrderBy(x => x).Last() + 1;
            else
                childCount = 1;
            int id = int.Parse(Helpers.Security.SecurityMethodes.GenerateRandomCode(8));
            string DataPath = BaseAddress + "\\Bot_" + childCount.ToString() + "\\";

            frmTelegramBot childForm = new frmTelegramBot(id, DataPath);
            //DAL.TabCount++;
            childForm.Text = "tab " + childCount.ToString();

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            /// childForm.Siz
            //child Form will now hold a reference value to the tab control
            childForm.tabCtrl = tabControl1;

            //Add a Tabpage and enables it
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = childForm.Text;
            tp.Show();

            //child Form will now hold a reference value to a tabpage
            childForm.tabPag = tp;

            //Activate the MDI child form
            childForm.Show();
            childCount++;

            //Activate the newly created Tabpage
            tabControl1.SelectedTab = tp;
            //  Directory.CreateDirectory(Application.ExecutablePath + "//Satraps//Mangoodarz" + childCount.ToString());
        }

        private void خروجازحسابکاربریToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void دربارهToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void neToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Dirs = Directory.GetDirectories(BaseAddress, "Bot_*").Where(x => Regex.IsMatch(Path.GetFileName(x), @"^Bot_[0123456789]{1,2}$")).Select(x => Convert.ToInt32(Path.GetFileName(x).Replace("Bot_", "")));
            if (Dirs.Any())
                childCount = Dirs.OrderBy(x => x).Last() + 1;
            else
                childCount = 1;
            int id = int.Parse(Helpers.Security.SecurityMethodes.GenerateRandomCode(8));
            string DataPath = BaseAddress + "\\Bot_" + childCount.ToString() + "\\";

            frmTelegramBot childForm = new frmTelegramBot(id, DataPath);
            //DAL.TabCount++;
            childForm.Text = "tab " + childCount.ToString();

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            /// childForm.Siz
            //child Form will now hold a reference value to the tab control
            childForm.tabCtrl = tabControl1;

            //Add a Tabpage and enables it
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = childForm.Text;
            tp.Show();

            //child Form will now hold a reference value to a tabpage
            childForm.tabPag = tp;

            //Activate the MDI child form
            childForm.Show();
            childCount++;

            //Activate the newly created Tabpage
            tabControl1.SelectedTab = tp;
            //  Directory.CreateDirectory(Application.ExecutablePath + "//Satraps//Mangoodarz" + childCount.ToString());
        }


        async Task<IRestResponse> PostClick()
        {
            try
            {
                RestRequest req = new RestRequest(Method.POST);
                RestClient client = new RestClient
                ($"{Statics.Uri}/api/PostClickEvent");
                var resp = await Task.Run(() =>
                {
                    return client.Execute(req);
                });

                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }
        async Task<IRestResponse> PostUser(string identifier, string ComputeName, string v)
        {
            try
            {
                // userIdentifier, string userName, string v
                RestRequest req = new RestRequest(Method.POST);
                req.AddParameter("userIdentifier", identifier);
                req.AddParameter("userName", ComputeName);
                req.AddParameter("v", v);


                RestClient client = new RestClient
                                ($"{Statics.Uri}/api/PostUser");

                var resp = await Task.Run(() =>
                {
                    return client.Execute(req);
                });

                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }
        async Task<IRestResponse> CheckForUpdate()
        {
            try
            {
                // userIdentifier, string userName, string v
                RestRequest req = new RestRequest(Method.GET);

                RestClient client = new RestClient
                                ($"{Statics.Uri}/api/CheckForUpdate?ver={Statics.CurrentVersion}");

                var resp = await Task.Run(() =>
                {
                    return client.Execute(req);
                });

                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ExtractFileToDirectory(Stream file, string outputDirectory)
        {
            try
            {
                ZipFile zip = ZipFile.Read(file);
                Directory.CreateDirectory(outputDirectory);
                foreach (ZipEntry e in zip)
                {
                    // check if you want to extract e or not
                    //if (e.FileName == "TheFileToExtract")

                    try
                    {
                        if (File.Exists(outputDirectory + "\\" + e.FileName))
                        {
                            File.Delete(outputDirectory + "\\" + e.FileName);
                        }
                    }
                    catch (Exception ex)
                    {

                        if (e.FileName != "FormattedText.vshost.exe")
                        {
                            return;
                        }
                    }
                    e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception e)
            {

            }
        }
        async private void frmMain_Load(object sender, EventArgs e)
        {
            string UpdaterPath = BaseAddress + "Updater";
            string CvPath = UpdaterPath + "\\cv.statics";
            string UriPath = UpdaterPath + "\\uri.statics";
            try
            {
                #region AddClient
                var identifier = "";
                if (File.Exists(BaseAddress + "\\identifier.kiaksarg"))
                {
                    identifier = File.ReadAllText(BaseAddress + "\\identifier.kiaksarg");
                }
                else
                {
                    identifier = Convert.ToBase64String(SecurityMethodes.GenerateSalt()) + SecurityMethodes.GenerateRandomCode(10, true);
                }


                var resp = await PostUser(identifier, System.Windows.Forms.SystemInformation.ComputerName, "v" + Statics.CurrentVersion);
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (!File.Exists(BaseAddress + "\\identifier.kiaksarg"))
                        File.WriteAllText(BaseAddress + "\\identifier.kiaksarg", identifier);
                }
                #endregion

                #region CheckForUpdate

                try
                {
                    if (File.Exists(CvPath))
                    {
                        if (File.ReadAllText(CvPath) != Statics.CurrentVersion + "")
                        {
                            File.WriteAllText(CvPath, Statics.CurrentVersion + "");
                        }
                    }
                    else
                    {
                        File.WriteAllText(CvPath, Statics.CurrentVersion + "");
                    }
                    //
                    if (File.Exists(UriPath))
                    {
                        if (File.ReadAllText(UriPath) != Statics.Uri + "")
                        {
                            File.WriteAllText(UriPath, Statics.Uri + "");
                        }
                    }
                    else
                    {
                        File.WriteAllText(UriPath, Statics.Uri + "");
                    }
                }
                catch (Exception)
                {
                }

                var Uresp = await CheckForUpdate();
                if (Uresp.StatusCode == System.Net.HttpStatusCode.OK && bool.Parse(Uresp.Content))
                {
                    try
                    {
                        Stream stream = new MemoryStream(Up_Res.Updater);
                        if (!Directory.Exists(UpdaterPath))
                        {
                            Directory.CreateDirectory(UpdaterPath);
                        }
                        ExtractFileToDirectory(stream, UpdaterPath);
                        try
                        {
                            if (File.Exists(CvPath))
                            {
                                if (File.ReadAllText(CvPath) != Statics.CurrentVersion + "")
                                {
                                    File.WriteAllText(CvPath, Statics.CurrentVersion + "");
                                }
                            }
                            else
                            {
                                File.WriteAllText(CvPath, Statics.CurrentVersion + "");
                            }
                            //
                            if (File.Exists(UriPath))
                            {
                                if (File.ReadAllText(UriPath) != Statics.Uri + "")
                                {
                                    File.WriteAllText(UriPath, Statics.Uri + "");
                                }
                            }
                            else
                            {
                                File.WriteAllText(UriPath, Statics.Uri + "");
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    catch (Exception)
                    {

                    }

                    if (Directory.Exists(UpdaterPath))
                    {
                        if (MessageBox.Show("There's a new update available. Do want close the application to update?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {


                            System.Diagnostics.Process.Start(UpdaterPath + "\\Updater.exe");
                            Application.Exit();
                        }



                    }
                    else
                    {
                        MessageBox.Show("Updater not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //var frmAbout = new frmAbout(true);
                    //frmAbout.ShowDialog();
                }
                else
                {

                }
                #endregion
            }
            catch (Exception)
            {

            }
        }
    }
}
