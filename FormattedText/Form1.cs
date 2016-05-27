using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
namespace FormattedText
{
    public partial class Form1 : Form
    {
        string MessageURL = "www.introducing.ir";
        public static readonly List<string>
            ImageExtensions = new List<string>
            { ".JPG", ".JPEG", ".BMP", ".GIF", ".PNG", "TIF" };
        public static readonly List<string>
            AudioExtensions = new List<string>
            { ".MP3", ".WAV", ".M4A",".WMA" };
        public static readonly List<string>
            VideoExtensions = new List<string>
            { ".MP4", ".AVI", ".MOV", ".MPG", ".WMV ", ".DIVX"};

        public Form1()
        {
            InitializeComponent();

            txtMarkdownSample.Text = @"*bold text*
_italic text_
[introducing](http://introducing.ir/)
`inline fixed-width code`
```pre-formatted fixed-width code block```";

            txtHtmlSample.Text = @"<b>bold</b>, <strong>bold</strong>
<i>italic</i>, <em>italic</em>
<a href='http://introducing.ir/'>introducing</a>
<code>inline fixed-width code</code>
<pre>pre-formatted fixed-width code block</pre>";
        }

        async private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                Telegram.Bot.Api Bot = new Api(txtBotToken.Text);
                pbSend.Visible = true;
                await Bot.SendTextMessage(txtChannelId.Text, rhContent.Text, false, chIsSilent.Checked, 0, null, (rdoDefault.Checked == true) ? Telegram.Bot.Types.ParseMode.Default : (rdoHtml.Checked == true) ? Telegram.Bot.Types.ParseMode.Html : Telegram.Bot.Types.ParseMode.Markdown);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void rdoDefault_CheckedChanged(object sender, EventArgs e)
        {
            txtMarkdownSample.Enabled = false;
            txtHtmlSample.Enabled = false;
            grpHtmlEditor.Enabled = false;
            grpMarkdownEditor.Enabled = false;
        }

        private void rdoMarkdown_CheckedChanged(object sender, EventArgs e)
        {
            txtMarkdownSample.Enabled = true;
            grpMarkdownEditor.Enabled = true;
            grpHtmlEditor.Enabled = false;

            txtHtmlSample.Enabled = false;


        }

        private void rdoHtml_CheckedChanged(object sender, EventArgs e)
        {
            txtHtmlSample.Enabled = true;
            txtMarkdownSample.Enabled = false;
            grpMarkdownEditor.Enabled = false;
            grpHtmlEditor.Enabled = true;

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.Introducing.ir");
        }


        private void btnBoldm_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "*" + rhContent.SelectedText + "*";
        }

        private void btnBoldh_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<b>" + rhContent.SelectedText + "</b>";

        }

        private void btnItalicm_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "_" + rhContent.SelectedText + "_";

        }

        private void btnItalich_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<i>" + rhContent.SelectedText + "</i>";

        }

        private void btnCodem_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "`" + rhContent.SelectedText + "`";
        }

        private void btnCodeh_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<code>" + rhContent.SelectedText + "</code>";
        }

        private void btnPrem_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "```" + rhContent.SelectedText + "```";
        }

        private void btnPreh_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<pre>" + rhContent.SelectedText + "</pre>";

        }

        private void btnURLm_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "[" + rhContent.SelectedText + "]" + "(" + txtURLm.Text + ")";
        }

        private void btnURLh_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<a href='" + txtURLh.Text + "'>" + rhContent.SelectedText + "</a>";
            //<a href="URL">inline URL</a>
        }

        private void btnLessThan_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "&lt";
        }

        private void btnGreaterThan_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "&gt";

        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "&amp";

        }

        private void btnQuot_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "&quot";

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sdi = new SaveFileDialog();
                //sdi.DefaultExt = "Json File (*.json)|All files (*.*)";
                //sdi.Filter = "Json File (*.json)|All files (*.*)";
                if (sdi.ShowDialog() == DialogResult.OK)
                {
                    Save sv = new Save()
                    {
                        ChannelId = txtChannelId.Text,
                        Content = rhContent.Text,
                        Token = txtBotToken.Text,
                        AudioPerformer = txtAudioPerformer.Text,
                        AudioTitle = txtAudioTitle.Text,
                        Caption = txtCaption.Text,
                        SelectedFile = path,
                        IsSilent = chIsSilent.Checked,
                        SendFileIsSilent = chSendFileIsSilent.Checked,
                        ParseMode =
                        (rdoHtml.Checked) ? (byte)0 :
                        (rdoMarkdown.Checked) ? (byte)1 : (byte)2,
                        SendFileMethod =
                        (rdoSendPhoto.Checked) ? (byte)1 :
                        (rdoSendVideo.Checked) ? (byte)2 :
                        (rdoSendAudio.Checked) ? (byte)3 : (byte)0
                    };
                    if (sdi.CheckPathExists)
                        using (StreamWriter rw = new StreamWriter(sdi.FileName))
                        {
                            rw.Write(JsonConvert.SerializeObject(sv));
                        }
                    else
                    {
                        MessageBox.Show("Path does not exist");
                    }
                    MessageBox.Show("Your bot and message has been saved sucessfully");
                }
                else
                {

                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog di = new OpenFileDialog();
                if (di.ShowDialog() == DialogResult.OK)
                {
                    var Saved = JsonConvert.DeserializeObject<Save>(File.ReadAllText(di.FileName));
                    txtChannelId.Text = Saved.ChannelId;
                    rhContent.Text = Saved.Content;
                    txtBotToken.Text = Saved.Token;
                    path = Saved.SelectedFile;

                    LblFileName.Text = (Path.GetFileName(Saved.SelectedFile).Length > 58) ?
       Path.GetFileName(Saved.SelectedFile).Substring(0, 58) : Path.GetFileName(Saved.SelectedFile);
                    tsslSelctedFile.Text =
                        (Saved.SelectedFile.Length < 58) ? Saved.SelectedFile : (Path.GetFileName(Saved.SelectedFile).Length > 58) ?
                        Path.GetFileName(Saved.SelectedFile).Substring(0, 58) : Path.GetFileName(Saved.SelectedFile);

                    //LblFileName.Text = Path.GetFileName(Saved.SelectedFile);
                    //tsslSelctedFile.Text = Saved.SelectedFile;
                    txtAudioTitle.Text = Saved.AudioTitle;
                    txtAudioPerformer.Text = Saved.AudioPerformer;
                    txtCaption.Text = Saved.Caption;
                    chIsSilent.Checked = Saved.IsSilent;
                    chSendFileIsSilent.Checked = Saved.SendFileIsSilent;
                    switch (Saved.ParseMode)
                    {
                        case 0:
                            rdoHtml.Checked = true;
                            break;
                        case 1:
                            rdoMarkdown.Checked = true;
                            break;
                        default:
                            rdoDefault.Checked = true;
                            break;
                    }
                    switch (Saved.SendFileMethod)
                    {
                        case 1:
                            rdoSendPhoto.Checked = true;
                            break;
                        case 2:
                            rdoSendVideo.Checked = true;
                            break;
                        case 3:
                            rdoSendAudio.Checked = true;
                            break;
                        default:
                            rdoSendFile.Checked = true;
                            break;
                    }

                }
            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            frm.ShowDialog();
        }
        string path;
        private void btnBrows_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ODilg = new OpenFileDialog();
                if (ODilg.ShowDialog() == DialogResult.OK)
                {
                    path = ODilg.FileName;
                    LblFileName.Text = (Path.GetFileName(ODilg.FileName).Length > 58) ?
                        Path.GetFileName(ODilg.FileName).Substring(0, 58) : Path.GetFileName(ODilg.FileName);
                    tsslSelctedFile.Text =
                        (ODilg.FileName.Length < 58) ? ODilg.FileName : (Path.GetFileName(ODilg.FileName).Length > 58) ?
                        Path.GetFileName(ODilg.FileName).Substring(0, 58) : Path.GetFileName(ODilg.FileName);
                    if (ImageExtensions.Contains(Path.GetExtension(ODilg.FileName).ToUpperInvariant()))
                        rdoSendPhoto.Checked = true;
                    else if (AudioExtensions.Contains(Path.GetExtension(ODilg.FileName).ToUpperInvariant()))
                        rdoSendAudio.Checked = true;
                    else if (VideoExtensions.Contains(Path.GetExtension(ODilg.FileName).ToUpperInvariant()))
                        rdoSendVideo.Checked = true;
                    else
                        rdoSendFile.Checked = true;

                }
            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }
        }




        async private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                Api Bot = new Api(txtBotToken.Text);
                if (rdoSendFile.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await
                        Bot.SendDocument(txtChannelId.Text, _FileToSend,
                        txtCaption.Text, chSendFileIsSilent.Checked);
                }
                else if (rdoSendPhoto.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await Bot.SendPhoto(txtChannelId.Text, _FileToSend,
                        txtCaption.Text, chSendFileIsSilent.Checked);
                }
                else if (rdoSendVideo.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await Bot.SendVideo(txtChannelId.Text, _FileToSend, 0, txtCaption.Text);

                }
                else if (rdoSendAudio.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await
                        Bot.SendAudio(txtChannelId.Text, _FileToSend, 0,
                        txtAudioPerformer.Text, txtAudioTitle.Text, chIsSilent.Checked);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            pbSendFile.Visible = false;
        }

        private void rdoSendFile_CheckedChanged(object sender, EventArgs e)
        {
            txtAudioPerformer.Enabled = false;
            txtAudioTitle.Enabled = false;
            txtCaption.Enabled = true;
        }

        private void rdoSendPhoto_CheckedChanged(object sender, EventArgs e)
        {
            txtAudioPerformer.Enabled = false;
            txtAudioTitle.Enabled = false;
            txtCaption.Enabled = true;
        }

        private void rdoSendVideo_CheckedChanged(object sender, EventArgs e)
        {
            txtCaption.Enabled = true;
            txtAudioPerformer.Enabled = false;
            txtAudioTitle.Enabled = false;
        }

        private void rdoSendAudio_CheckedChanged(object sender, EventArgs e)
        {
            txtAudioPerformer.Enabled = true;
            txtAudioTitle.Enabled = true;
            txtCaption.Enabled = false;
        }

        private void tsslSelctedFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
                System.Diagnostics.Process.Start(path);
        }
        async Task<IRestResponse> SeResponse()
        {
            try
            {
                RestRequest req = new RestRequest(Method.GET);
                RestClient client = new RestClient
                ("http://teletablighi.ir/api/GetTelegramChannelManagerDesktopMessages");
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

        async private void GetMessages_Tick(object sender, EventArgs e)
        {
            try
            {
                var resp = await SeResponse();
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Random rnd = new Random();
                    var msgs = JsonConvert.DeserializeObject<List<Messages>>(resp.Content);
                    var message = msgs[rnd.Next(0, msgs.Count)];
                    lblMessage.Text = (message.Message.Length < 90) ? message.Message : message.Message.Substring(0, 90);
                    MessageURL = message.Url;
                }
            }
            catch (Exception)
            {

            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MessageURL);

        }

       async private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var resp = await SeResponse();
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Random rnd = new Random();
                    var msgs = JsonConvert.DeserializeObject<List<Messages>>(resp.Content);
                    var message = msgs[rnd.Next(0, msgs.Count)];
                    lblMessage.Text = (message.Message.Length < 90) ? message.Message : message.Message.Substring(0, 90);
                    MessageURL = message.Url;
                }
            }
            catch (Exception)
            {

            }
        }
    }
    class Messages
    {
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
