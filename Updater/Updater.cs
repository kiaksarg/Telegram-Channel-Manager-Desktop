using Ionic.Zip;
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

namespace Updater
{
    public partial class Updater : Form
    {
        string BaseAddress = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public Updater()
        {
            InitializeComponent();
        }
        public bool ExtractFileToDirectory(Stream file, string outputDirectory)
        {
            try
            {
                ZipFile zip = ZipFile.Read(file);
                Directory.CreateDirectory(outputDirectory);
                foreach (ZipEntry e in zip)
                {
                    // check if you want to extract e or not
                    //if (e.FileName == "TheFileToExtract")

                    if (File.Exists(outputDirectory + "\\" + e.FileName))
                    {
                        File.Delete(outputDirectory + "\\" + e.FileName);
                    }
                    e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
                return true;
            }
            catch (Exception e)
            {
                pbUpdate.Visible = false;
                lblUpdate.Visible = false;

                PBUpdateFailed.Visible = true;
                lblUpdateFailed.Visible = true;
                btnRetry.Visible = true;
                MessageBox.Show(e.Message);
                return false;
            }
        }
        async Task<IRestResponse> GetUpdate()
        {
            try
            {
                string CurrentVersion = "";
                string CurrentUri = "";

                if (File.Exists(BaseAddress + "\\cv.statics"))
                {
                    CurrentVersion = File.ReadAllText(BaseAddress + "\\cv.statics");
                }
                else
                {
                    Application.Exit(); return null;
                }

                if (File.Exists(BaseAddress + "\\uri.statics"))
                {
                    CurrentUri = File.ReadAllText(BaseAddress + "\\uri.statics");
                }
                else
                {
                    Application.Exit();
                    return null;
                }



                // userIdentifier, string userName, string v
                RestRequest req = new RestRequest(Method.GET);
                req.AddParameter("ver", CurrentVersion);


                RestClient client = new RestClient
                                ($"{CurrentUri}/api/GetLastUpdate");

                var data = await client.ExecuteTaskAsync(req);
                return data;
            }
            catch (Exception e)
            {
                pbUpdate.Visible = false;
                lblUpdate.Visible = false;

                PBUpdateFailed.Visible = true;
                lblUpdateFailed.Visible = true;
                btnRetry.Visible = true;
                MessageBox.Show(e.Message);
                return null;
            }

        }
        async private void Updater_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://introducing.ir/");


            try
            {
                var resp = await GetUpdate();
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream stream = new MemoryStream(resp.RawBytes);

                    while (true)
                    {
                        if (Process.GetProcessesByName("FormattedText").Any())
                        {
                            if (MessageBox.Show("To continue updating, application Must be closed. Pleas close the app first, then click on the retry button.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            {
                                foreach (Process p in System.Diagnostics.Process.GetProcessesByName("FormattedText.vshost"))
                                {
                                    try
                                    {
                                        p.Kill();
                                        p.WaitForExit(); // possibly with a timeout
                                    }
                                    catch (Win32Exception winException)
                                    {
                                        // process was terminating or can't be terminated - deal with it
                                    }
                                    catch (InvalidOperationException invalidException)
                                    {
                                        // process has already exited - might be able to let this one go
                                    }
                                }
                                Application.Exit();
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (ExtractFileToDirectory(stream, Directory.GetParent(BaseAddress).FullName))
                    {
                        pbUpdate.Visible = false;
                        lblUpdate.Visible = false;
                        pbSU.Visible = true;
                        lblSUMessage.Visible = true;
                        btnRun.Visible = true;
                    }
                    else
                    {
                        pbUpdate.Visible = false;
                        lblUpdate.Visible = false;

                        PBUpdateFailed.Visible = true;
                        lblUpdateFailed.Visible = true;
                        btnRetry.Visible = true;
                    }
                   


                    //if (MessageBox.Show("Update completed successfully. Do you want to restart the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    //{
                    //    Application.Restart();
                    //}

                    //File.WriteAllBytes($"{BaseAddress}//new.zip", resp.RawBytes);
                }
                else
                {
                    pbUpdate.Visible = false;
                    lblUpdate.Visible = false;

                    PBUpdateFailed.Visible = true;
                    lblUpdateFailed.Visible = true;
                    btnRetry.Visible = true;
                    MessageBox.Show("Not Found");
                    // Application.Exit();
                    
                }
            }
            catch (Exception ex)
            {
                
                pbUpdate.Visible = false;
                lblUpdate.Visible = false;

                PBUpdateFailed.Visible = true;
                lblUpdateFailed.Visible = true;
                btnRetry.Visible = true;

                MessageBox.Show(ex.Message);
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetParent(BaseAddress).FullName + "\\FormattedText.exe");
            Application.Exit();
        }

      
      async  private void btnRetry_Click(object sender, EventArgs e)
        {
            PBUpdateFailed.Visible = false;
            lblUpdateFailed.Visible = false;
            btnRetry.Visible = false; ;



            pbUpdate.Visible = true;
            lblUpdate.Visible = true;
            try
            {
                var resp = await GetUpdate();
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream stream = new MemoryStream(resp.RawBytes);

                    while (true)
                    {
                        if (Process.GetProcessesByName("FormattedText").Any())
                        {
                            if (MessageBox.Show("To continue updating, application Must be closed. Please close the app first, then click on the retry button.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            {
                                foreach (Process p in System.Diagnostics.Process.GetProcessesByName("FormattedText.vshost"))
                                {
                                    try
                                    {
                                        p.Kill();
                                        p.WaitForExit(); // possibly with a timeout
                                    }
                                    catch (Win32Exception winException)
                                    {
                                        // process was terminating or can't be terminated - deal with it
                                    }
                                    catch (InvalidOperationException invalidException)
                                    {
                                        // process has already exited - might be able to let this one go
                                    }
                                }
                                Application.Exit();
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (ExtractFileToDirectory(stream, Directory.GetParent(BaseAddress).FullName))
                    {
                        pbUpdate.Visible = false;
                        lblUpdate.Visible = false;
                        pbSU.Visible = true;
                        lblSUMessage.Visible = true;
                        btnRun.Visible = true;
                    }
                    else
                    {
                        pbUpdate.Visible = false;
                        lblUpdate.Visible = false;
                        PBUpdateFailed.Visible = true;
                        lblUpdateFailed.Visible = true;
                        btnRetry.Visible = true;
                    }


                    //if (MessageBox.Show("Update completed successfully. Do you want to restart the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    //{
                    //    Application.Restart();
                    //}

                    //File.WriteAllBytes($"{BaseAddress}//new.zip", resp.RawBytes);
                }
                else
                {
                    pbUpdate.Visible = false;
                    lblUpdate.Visible = false;
                    MessageBox.Show("Not Found");
                    // Application.Exit();
                    PBUpdateFailed.Visible = true;
                    lblUpdateFailed.Visible = true;
                    btnRetry.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pbUpdate.Visible = false;
                lblUpdate.Visible = false;

                PBUpdateFailed.Visible = true;
                lblUpdateFailed.Visible = true;
                btnRetry.Visible = true;
            }

        }
    }
}
