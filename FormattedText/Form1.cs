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
        public Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup GetInlineKeyboardMarkup()
        {
            Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup mk = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup();
            int col = int.Parse(txtCol.Text);

            int row = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Convert.ToDouble(UrlBttons.Count) / col)));
            Telegram.Bot.Types.InlineKeyboardButton[][] keyboard =
               new Telegram.Bot.Types.InlineKeyboardButton[row][];


            int ocupied = 0;
            int counter = 0;
            int Maincounter = 0;

            for (int i = 0; i < row; i++)
            {
                int tmp = (UrlBttons.Count - ocupied >= col) ? col : UrlBttons.Count - ocupied;
                ocupied += tmp;
                var TmpStringArry = new Telegram.Bot.Types.InlineKeyboardButton[tmp];

                for (int j = 0; j < tmp; j++)
                {
                    TmpStringArry[counter] = new Telegram.Bot.Types.InlineKeyboardButton();
                    TmpStringArry[counter].Text = UrlBttons[i].Text;
                    TmpStringArry[counter++].Url = UrlBttons[i].Url;

                    if (counter == col || j == tmp - 1)
                    {
                        keyboard[Maincounter++] = TmpStringArry;
                        counter = 0;
                    }
                }


            }

            mk.InlineKeyboard = keyboard;

            return mk;
        }
        async private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {



                TelegramBotClient Bot = new TelegramBotClient(txtBotToken.Text);

                pbSend.Visible = true;
                await Bot.SendTextMessageAsync(txtChannelId.Text, rhContent.Text, false, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null, (rdoDefault.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Default : (rdoHtml.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Html : Telegram.Bot.Types.Enums.ParseMode.Markdown);
                pbSend.Visible = false;
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
                        (rdoSendAudio.Checked) ? (byte)3 : (byte)0,
                        Column = txtCol.Text,
                        SendUrlButton = chURLButtons.Checked,
                        UrlButtons = UrlBttons,
                        UrlButtonText = txtInlineKeyboardButtonName.Text,
                        UrlButtonURL = txtInlineKeyboardButtonUrl.Text
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

   async     private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
                    UrlBttons = (Saved.UrlButtons == null) ? new List<UrlButton>() : Saved.UrlButtons;
                    txtInlineKeyboardButtonName.Text = (String.IsNullOrEmpty(Saved.UrlButtonText))? "وب سایت معرفی" : Saved.UrlButtonText;
                    txtInlineKeyboardButtonUrl.Text =(String.IsNullOrEmpty(Saved.UrlButtonURL)) ? "http://introducing.ir/" : Saved.UrlButtonURL;
                    txtCol.Text= (Saved.Column == null) ? "1" : Saved.Column;
                    chURLButtons.Checked = Saved.SendUrlButton;

                   await PanelBuildr();

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
                TelegramBotClient Bot = new TelegramBotClient(txtBotToken.Text);
                if (rdoSendFile.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await
                        Bot.SendDocumentAsync(txtChannelId.Text, _FileToSend,
                        txtCaption.Text, chSendFileIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                }
                else if (rdoSendPhoto.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await Bot.SendPhotoAsync(txtChannelId.Text, _FileToSend,
                        txtCaption.Text, chSendFileIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                }
                else if (rdoSendVideo.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await Bot.SendVideoAsync(txtChannelId.Text, _FileToSend, 0, txtCaption.Text, chSendFileIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);

                }
                else if (rdoSendAudio.Checked)
                {
                    Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();
                    _FileToSend.Content = new FileStream(path, FileMode.Open);
                    _FileToSend.Filename = Path.GetFileName(path);
                    pbSendFile.Visible = true;
                    var r = await
                        Bot.SendAudioAsync(txtChannelId.Text, _FileToSend, 0,
                        txtAudioPerformer.Text, txtAudioTitle.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
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





        List<UrlButton> UrlBttons = new List<UrlButton>();
        async public Task PanelBuildr()
        {
            panel1.Controls.Clear();
            int pointX = 35;
            int pointY = 30;
            int count = 1;
            await Task.Run(() =>
            {
                foreach (var item in UrlBttons)
                {

                    try
                    {
                        //  panel1.AutoScroll = true;
                        //panel1.BorderStyle = BorderStyle.FixedSingle;

                        //  panel1.Controls.Clear();


                        Button btnInlineKeyboardButton = new Button();
                        // textBox1.SelectionStart = textBox1.Text.Length;
                        // a.ScrollBars = ScrollBars.Both;
                        //  a.ScrollToCaret();

                        Label lbl = new Label();
                        lbl.Name = count.ToString();
                        lbl.Text = count + "";
                        lbl.Location = new Point(pointX + 0, pointY);
                        lbl.Size = new System.Drawing.Size(20, 15);


                        //////////////////
                        Button btn1 = new Button();
                        btn1.Text = "✖";
                        btn1.Name = item.Id;
                        btn1.Location = new Point(pointX + 155, pointY);
                        btn1.Size = new System.Drawing.Size(30, 30);
                        btn1.Click += new EventHandler(button_Click);



                        ////////////
                        btnInlineKeyboardButton.Size = new System.Drawing.Size(131, 30);
                        btnInlineKeyboardButton.Text = item.Text;
                        btnInlineKeyboardButton.Name = $"{item.Id}_btnInlineKeyboardButton";
                        btnInlineKeyboardButton.Click += btnInlineKeyboardButton_Click;
                        btnInlineKeyboardButton.Tag = item.Url;
                        btnInlineKeyboardButton.Location = new Point(pointX + 25, pointY);



                        ////
                        LinkLabel lblUrl = new LinkLabel();
                        lblUrl.Text = item.Url;
                        lblUrl.Name = count.ToString() + "_lblUrl";
                        lblUrl.Location = new Point(pointX + 30, pointY + 30);
                        // lblUrl.Size = new System.Drawing.Size(30, 30);
                        lblUrl.Click += btnInlineKeyboardButton_Click;

                        ////
                        Invoke(new MethodInvoker(delegate ()
                        {
                            panel1.Controls.Add(btn1);
                            panel1.Controls.Add(lbl);
                            panel1.Controls.Add(btnInlineKeyboardButton);
                            panel1.Controls.Add(lblUrl);

                            panel1.Show();
                        }));

                        count++;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    pointY += 55;
                }
            });

        }
        async private void btnNewButton_Click(object sender, EventArgs e)
        {
            btnNewButton.Enabled = false;
            UrlBttons.Add(new UrlButton()
            {
                Id = Guid.NewGuid().ToString(),
                Text = txtInlineKeyboardButtonName.Text,
                Url = txtInlineKeyboardButtonUrl.Text
            });
            await PanelBuildr();
            btnNewButton.Enabled = true;
        }
        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            UrlBttons.Remove(UrlBttons.SingleOrDefault(x => x.Id == button.Name));
            PanelBuildr();
            //Button button = sender as Button;
            ////to remove control by Name
            //foreach (Control item in panel1.Controls.OfType<Control>())
            //{
            //    if (item.Name.Split('_')[0] == button.Name)
            //    {
            //        panel1.Controls.Remove(item);
            //    }

            //}
            //foreach (Control item in panel1.Controls.OfType<Control>())
            //{
            //    if ( item.Name == button.Name + "_lblUrl")
            //    {
            //        panel1.Controls.Remove(item);
            //    }

            //}
            //panel1.Controls.Remove(button);

            //// identify which button was clicked and perform necessary actions
        }
        protected void btnInlineKeyboardButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (sender.GetType().Name)
                {
                    case "Button":
                        {
                            Button button = sender as Button;

                            System.Diagnostics.Process.Start((string)button.Tag);
                            break;
                        }
                    case "LinkLabel":
                        {
                            LinkLabel LinkLabel = sender as LinkLabel;

                            System.Diagnostics.Process.Start((string)LinkLabel.Text);
                            break;
                        }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        async private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to delete all buttons?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                UrlBttons.Clear();
                await PanelBuildr();
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.AutoScrollMinSize = new System.Drawing.Size(panel1.Width, panel1.Height);

        }
    }
    class Messages
    {
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
