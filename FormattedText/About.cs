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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormattedText
{
    public partial class frmAbout : Form
    {
        string BaseAddress = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public bool Updating { get; set; }
        public frmAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.Introducing.ir");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://telegram.me/Introducing");


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
        async private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Statics.CurrentVersion + ".0";

            var resp = await CheckForUpdate();



            if (resp.StatusCode == System.Net.HttpStatusCode.OK && bool.Parse(resp.Content))
            {
                lblUpdate.Visible = true;

            }
            else
            {
                lblLastVer.Visible = true;
                pbUS.Visible = true;
            }
            //    if (Updating)
            //    {
            //        pbUpdate.Visible = true;
            //        lblUpdate.Visible = true;
            //        var resp = await GetUpdate();
            //        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            Stream stream = new MemoryStream(resp.RawBytes);
            //            ExtractFileToDirectory(stream, BaseAddress);
            //            pbUpdate.Visible = false;
            //            lblUpdate.Visible = false;
            //            if (MessageBox.Show("Update completed successfully. Do you want to restart the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //            {
            //                Application.Restart();
            //            }



            //            //File.WriteAllBytes($"{BaseAddress}//new.zip", resp.RawBytes);
            //        }
            //    }
            webBrowser1.Navigate("http://introducing.ir/");
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            //}
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pbUpdate.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void lblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region CheckForUpdate
            string UpdaterPath = BaseAddress + "\\Updater";
            string CvPath = UpdaterPath + "\\cv.statics";
            string UriPath = UpdaterPath + "\\uri.statics";
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


            if (Directory.Exists(UpdaterPath))
            {
                System.Diagnostics.Process.Start(UpdaterPath + "\\Updater.exe");
                Process.GetCurrentProcess().Kill();

            }
            else
            {
                MessageBox.Show("Updater not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            #endregion
        }
    }
}
