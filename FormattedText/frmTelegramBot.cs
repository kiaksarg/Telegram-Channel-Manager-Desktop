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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
namespace FormattedText
{
    public partial class frmTelegramBot : Form
    {
        public TabControl tabCtrl
        {
            get; set;
        }
        public TabPage tabPag { get; set; }

        Messages MessageURL = new Messages() { Message = "www.introducing.ir", Url = "www.introducing.ir" };
        public static readonly List<string>
            ImageExtensions = new List<string>
            { ".JPG", ".JPEG", ".BMP", ".GIF", ".PNG", "TIF" };
        public static readonly List<string>
            AudioExtensions = new List<string>
            { ".MP3", ".WAV", ".M4A",".WMA" };
        public static readonly List<string>
            VideoExtensions = new List<string>
            { ".MP4", ".AVI", ".MOV", ".MPG", ".WMV ", ".DIVX"};

        public string DataDirectoryPath { get; set; }
        public string DataPath { get; set; }
        public string BackupPath { get; set; }
        public frmTelegramBot(int id, string dataPath)
        {
            InitializeComponent();
            Chats = new List<Chat>();
            DataDirectoryPath = dataPath;
            DataPath = $"{DataDirectoryPath}\\Data.json";
            BackupPath = $"{DataDirectoryPath}\\Backup.json";
            if (!Directory.Exists(dataPath))
            {
                if (!CreateFiles())
                {
                    return;
                }
            }

        }
        private bool CreateFiles()
        {
            try
            {
                if (!Directory.Exists(DataDirectoryPath))
                {
                    Directory.CreateDirectory(DataDirectoryPath);
                    File.WriteAllText(DataPath, JsonConvert.SerializeObject(null));
                    File.WriteAllText(BackupPath, JsonConvert.SerializeObject(null));


                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;

        }


        public Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup GetInlineKeyboardMarkup()
        {
            Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup mk = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup();
            if (string.IsNullOrWhiteSpace(txtCol.Text))
            {
                throw new NoNullAllowedException("Enter the URL buttons Column...!");
            }
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
            pbSend.Visible = true;
            try
            {
                TelegramBotClient Bot = new TelegramBotClient(txtBotToken.Text);

                if (lstChats.SelectedIndices == null || lstChats.SelectedIndices.Count < 1)
                {
                    var chatId = txtChannelUserName.Text;

                    if (chatId.Length < 1)
                    {
                        pbSend.Visible = false;

                        MessageBox.Show("Select a chat...");
                        return;

                    }

                    if (MessageBox.Show($"You haven't selected any chat...! Do you want send the message to {txtChannelUserName.Text} ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        pbSend.Visible = false;

                        return;
                    }




                    await Bot.SendTextMessageAsync(chatId, rhContent.Text, false, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null, (rdoDefault.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Default : (rdoHtml.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Html : Telegram.Bot.Types.Enums.ParseMode.Markdown);
                }
                else
                {
                    if (lstChats.SelectedIndices.Count > 1)
                    {
                        if (MessageBox.Show($"Are you sure you want to send this message to {lstChats.SelectedIndices.Count} chat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            pbSend.Visible = false;

                            return;
                        }
                    }
                    foreach (int item in lstChats.SelectedIndices)
                    {
                        var chatId = ((Chats[item].ChatType == Telegram.Bot.Types.Enums.ChatType.Channel) ? Chats[item].UserName : Chats[item].ChatId + "");



                        await Bot.SendTextMessageAsync(chatId, rhContent.Text, false, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null, (rdoDefault.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Default : (rdoHtml.Checked == true) ? Telegram.Bot.Types.Enums.ParseMode.Html : Telegram.Bot.Types.Enums.ParseMode.Markdown);

                    }
                }




            }
            catch (Exception ex)
            {
                pbSend.Visible = false;

                MessageBox.Show(ex.Message);
            }
            pbSend.Visible = false;

        }

        private void rdoDefault_CheckedChanged(object sender, EventArgs e)
        {
            //  txtMarkdownSample.Enabled = false;
            //  txtHtmlSample.Enabled = false;
            gbHtml.Enabled = false;
            grpMarkdownEditor.Enabled = false;
        }

        private void rdoMarkdown_CheckedChanged(object sender, EventArgs e)
        {
            //   txtMarkdownSample.Enabled = true;
            grpMarkdownEditor.Enabled = true;
            gbHtml.Enabled = false;

            // txtHtmlSample.Enabled = false;

        }

        private void rdoHtml_CheckedChanged(object sender, EventArgs e)
        {
            // txtHtmlSample.Enabled = true;
            // txtMarkdownSample.Enabled = false;
            //  grpMarkdownEditor.Enabled = false;
            grpMarkdownEditor.Enabled = true;
            gbHtml.Enabled = true;

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.Introducing.ir");
        }


        private void btnBoldm_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = (rdoMarkdown.Checked) ? "*" + rhContent.SelectedText + "*" : "<b>" + rhContent.SelectedText + "</b>"; ;
        }

        private void btnItalicm_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = (rdoMarkdown.Checked) ? "_" + rhContent.SelectedText + "_" : "<i>" + rhContent.SelectedText + "</i>";

        }



        private void btnCodem_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = (rdoMarkdown.Checked) ? "`" + rhContent.SelectedText + "`" : "<code>" + rhContent.SelectedText + "</code>";
        }



        private void btnPrem_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = (rdoMarkdown.Checked) ? "```" + rhContent.SelectedText + "```" : "<pre>" + rhContent.SelectedText + "</pre>";
        }

        private void btnURLm_Click(object sender, EventArgs e)
        {
            if (rdoMarkdown.Checked)
            {
                rhContent.SelectedText = $"[{ rhContent.SelectedText}]({ txtURL.Text})";
            }
            else if (rdoHtml.Checked)
            {
                rhContent.SelectedText = $"<a href='{ txtURL.Text}'>{ rhContent.SelectedText}</a>";
            }
        }

        private void btnURLh_Click(object sender, EventArgs e)
        {
            rhContent.SelectedText = "<a href='" + txtURL.Text + "'>" + rhContent.SelectedText + "</a>";
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
                    LblFileName.Text = (Path.GetFileName(ODilg.FileName).Length > 30) ?
                        Path.GetFileName(ODilg.FileName).Substring(0, 30) : Path.GetFileName(ODilg.FileName);
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
            Telegram.Bot.Types.FileToSend _FileToSend = new Telegram.Bot.Types.FileToSend();

            try
            {
                pbSend.Visible = true;

                TelegramBotClient Bot = new TelegramBotClient(txtBotToken.Text);
                Bot.UploadTimeout = TimeSpan.FromMinutes(double.Parse(txtUploadTimeout.Text));
                if (lstChats.SelectedIndices == null || lstChats.SelectedIndices.Count < 1)
                {
                    var chatId = txtChannelUserName.Text;

                    if (chatId.Length < 1)
                    {
                        pbSend.Visible = false;

                        MessageBox.Show("Select a chat...");
                        return;

                    }

                    if (MessageBox.Show($"You haven't selected any chat...! Do you want send the message to {txtChannelUserName.Text} ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        pbSend.Visible = false;

                        return;
                    }

                    if (rdoSendFile.Checked)
                    {
                        _FileToSend.Content = new FileStream(path, FileMode.Open);
                        _FileToSend.Filename = Path.GetFileName(path);
                        var r = await
                            Bot.SendDocumentAsync(chatId, _FileToSend,
                            txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                    }
                    else if (rdoSendPhoto.Checked)
                    {
                        _FileToSend.Content = new FileStream(path, FileMode.Open);
                        _FileToSend.Filename = Path.GetFileName(path);
                        var r = await Bot.SendPhotoAsync(chatId, _FileToSend,
                            txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                    }
                    else if (rdoSendVideo.Checked)
                    {
                        _FileToSend.Content = new FileStream(path, FileMode.Open);
                        _FileToSend.Filename = Path.GetFileName(path);
                        var r = await Bot.SendVideoAsync(chatId, _FileToSend, 0, txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);

                    }
                    else if (rdoSendAudio.Checked)
                    {
                        _FileToSend.Content = new FileStream(path, FileMode.Open);
                        _FileToSend.Filename = Path.GetFileName(path);
                        var r = await
                            Bot.SendAudioAsync(chatId, _FileToSend, 0,
                            txtAudioPerformer.Text, txtAudioTitle.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                    }
                }
                else
                {
                    if (lstChats.SelectedIndices.Count > 1)
                    {
                        if (MessageBox.Show($"Are you sure you want to send this message to {lstChats.SelectedIndices.Count} chat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            pbSend.Visible = false;

                            return;
                        }
                    }
                    foreach (int item in lstChats.SelectedIndices)
                    {
                        var chatId = ((Chats[item].ChatType == Telegram.Bot.Types.Enums.ChatType.Channel) ? Chats[item].UserName : Chats[item].ChatId + "");

                        if (rdoSendFile.Checked)
                        {
                            _FileToSend.Content = new FileStream(path, FileMode.Open);
                            _FileToSend.Filename = Path.GetFileName(path);
                            var r = await
                                Bot.SendDocumentAsync(chatId, _FileToSend,
                                txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                        }
                        else if (rdoSendPhoto.Checked)
                        {
                            _FileToSend.Content = new FileStream(path, FileMode.Open);
                            _FileToSend.Filename = Path.GetFileName(path);
                            var r = await Bot.SendPhotoAsync(chatId, _FileToSend,
                                txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                        }
                        else if (rdoSendVideo.Checked)
                        {
                            _FileToSend.Content = new FileStream(path, FileMode.Open);
                            _FileToSend.Filename = Path.GetFileName(path);
                            var r = await Bot.SendVideoAsync(chatId, _FileToSend, 0, txtCaption.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);

                        }
                        else if (rdoSendAudio.Checked)
                        {
                            _FileToSend.Content = new FileStream(path, FileMode.Open);
                            _FileToSend.Filename = Path.GetFileName(path);
                            var r = await
                                Bot.SendAudioAsync(chatId, _FileToSend, 0,
                                txtAudioPerformer.Text, txtAudioTitle.Text, chIsSilent.Checked, 0, (chURLButtons.Checked) ? GetInlineKeyboardMarkup() : null);
                        }
                    }
                }
                pbSend.Visible = false;


                if (_FileToSend.Content != null)
                    _FileToSend.Content.Close();

            }
            catch (Exception ex)
            {
                pbSend.Visible = false;
                if (_FileToSend.Content != null)
                    _FileToSend.Content.Close();

                MessageBox.Show(ex.Message);
            }

            pbSend.Visible = false;
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
                ($"{Statics.Uri}/api/GetTelegramChannelManagerDesktopMessages");
                req.AddParameter("ver", "v" + Statics.CurrentVersion);
                var resp = await client.ExecuteTaskAsync(req);

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
                    MessageURL = message;
                }
            }
            catch (Exception)
            {

            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        async Task<IRestResponse> PostClick(int linkId, string link, string userIdentifier, string text)
        {
            try
            {
                // userIdentifier, string userName, string v
                RestRequest req = new RestRequest(Method.POST);
                req.AddParameter("linkId", linkId);
                req.AddParameter("link", link);
                req.AddParameter("userIdentifier", userIdentifier);
                req.AddParameter("text", text);


                RestClient client = new RestClient
                                ($"{Statics.Uri}/api/PostClickEvent");

                var resp = await client.ExecuteTaskAsync(req);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private async void lblMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MessageURL.Url);
            await PostClick(MessageURL.Id, MessageURL.Url, "-", MessageURL.Message);
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
                    MessageURL = message;
                }
            }
            catch (Exception)
            {

            }

            var Saved = JsonConvert.DeserializeObject<Save>(File.ReadAllText(DataPath));
            AutoSaveTimer.Enabled = true;
            if (Saved != null)
                try
                {


                    txtChannelUserName.Text = Saved.ChannelId;
                    rhContent.Text = Saved.Content;
                    txtBotToken.Text = Saved.Token;
                    path = Saved.SelectedFile;

                    LblFileName.Text = (Saved.SelectedFile == null) ? "..." : (Path.GetFileName(Saved.SelectedFile).Length > 30) ?
       Path.GetFileName(Saved.SelectedFile).Substring(0, 30) : Path.GetFileName(Saved.SelectedFile);


                    tsslSelctedFile.Text = (Saved.SelectedFile == null) ? "..." :
                        (Saved.SelectedFile.Length < 58) ? Saved.SelectedFile : (Path.GetFileName(Saved.SelectedFile).Length > 58) ?
                        Path.GetFileName(Saved.SelectedFile).Substring(0, 58) : Path.GetFileName(Saved.SelectedFile);

                    //LblFileName.Text = Path.GetFileName(Saved.SelectedFile);
                    //tsslSelctedFile.Text = Saved.SelectedFile;
                    txtAudioTitle.Text = Saved.AudioTitle;
                    txtAudioPerformer.Text = Saved.AudioPerformer;
                    txtCaption.Text = Saved.Caption;
                    chIsSilent.Checked = Saved.IsSilent;
                    switch (Saved.ParseMode)
                    {
                        case 0:
                            {
                                rdoHtml.Checked = true;
                                grpMarkdownEditor.Enabled = true;
                                gbHtml.Enabled = true;
                            }

                            break;
                        case 1:
                            {
                                rdoMarkdown.Checked = true;
                                grpMarkdownEditor.Enabled = true;
                                gbHtml.Enabled = false;
                            }

                            break;
                        default:
                            {
                                rdoDefault.Checked = true;
                                grpMarkdownEditor.Enabled = false;
                                gbHtml.Enabled = false;
                            }

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
                    txtInlineKeyboardButtonName.Text = (String.IsNullOrEmpty(Saved.UrlButtonText)) ? "وب سایت معرفی" : Saved.UrlButtonText;
                    txtInlineKeyboardButtonUrl.Text = (String.IsNullOrEmpty(Saved.UrlButtonURL)) ? "http://introducing.ir/" : Saved.UrlButtonURL;
                    txtCol.Text = (Saved.Column == null) ? "1" : Saved.Column;
                    chURLButtons.Checked = Saved.SendUrlButton;
                    offset = Saved.Offset;
                    await PanelBuildr();

                    Chats = Saved.Chats ?? new List<Chat>();
                    buildChatList();



                    if (string.IsNullOrWhiteSpace(txtCol.Text))
                    {
                        txtCol.Text = "1";
                    }
                    if (string.IsNullOrWhiteSpace(txtUploadTimeout.Text))
                    {
                        txtUploadTimeout.Text = "10";
                    }
                }
                catch (Exception er)
                {

                    MessageBox.Show("Error - " + er.Message);
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
            if (string.IsNullOrWhiteSpace(txtInlineKeyboardButtonName.Text))
            {
                MessageBox.Show("Enter the button text");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInlineKeyboardButtonUrl.Text))
            {
                MessageBox.Show("Enter the button Url");
                return;
            }

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


        int offset = 0;
        bool stop = false;
        public List<Chat> Chats { get; set; }
        public async Task GetUpdats()
        {
            try
            {
                TelegramBotClient Bot = new TelegramBotClient(txtBotToken.Text);
                var me = await Bot.GetMeAsync();
                while (!stop)
                {
                    var Updates = await Bot.GetUpdatesAsync(offset + 1);
                    //Invoke(new MethodInvoker(delegate ()
                    //{
                    //    lstUpdates.Items.Add($"Updates Count:{Updates.Count()}");
                    //    lstUpdates.TopIndex = lstUpdates.Items.Count - 1;


                    //}));
                    foreach (var item in Updates)
                    {
                        offset = item.Id;


                        if (item.Message.Type == Telegram.Bot.Types.Enums.MessageType.ServiceMessage && item.Message.NewChatMember != null && (item.Message.Chat.Type == Telegram.Bot.Types.Enums.ChatType.Group || item.Message.Chat.Type == Telegram.Bot.Types.Enums.ChatType.Supergroup && item.Message.NewChatMember.Username == me.Username))
                        {
                            var GruopTitle = item.Message.Chat.Title;
                            var GroupId = item.Message.Chat.Id;
                            if (Chats.Any(x => x.ChatId == GroupId))
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    lstUpdates.Items.Add($"{GruopTitle} is exists in to the chat list");
                                    lstUpdates.Items.Add($"ChatType:Group");
                                    lstUpdates.Items.Add($"ChatId:{GroupId}");
                                    lstUpdates.TopIndex = lstUpdates.Items.Count - 3;
                                    if (chIdenticalChats.Checked)
                                    {
                                        lstUpdates.Items.Add($"{GruopTitle} skipped");
                                        lstUpdates.TopIndex = lstUpdates.Items.Count - 1;
                                    }
                                }));
                                if (chIdenticalChats.Checked)
                                {
                                    continue;
                                }

                            }

                            Chats.Add(new Chat()
                            {
                                ChatType = Telegram.Bot.Types.Enums.ChatType.Group,
                                BotUserName = me.Username,
                                BotToken = txtBotToken.Text,
                                ChatId = GroupId,
                                ChatName = GruopTitle
                            });

                            Invoke(new MethodInvoker(delegate ()
                            {
                                lstUpdates.Items.Add($"{GruopTitle} has been inserted");
                                lstUpdates.Items.Add($"ChatType:Group");
                                lstUpdates.Items.Add($"ChatId:{GroupId}");
                                lstUpdates.TopIndex = lstUpdates.Items.Count - 3;
                            }));
                        }
                        else if (item.Message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage && item.Message.Chat.Type == Telegram.Bot.Types.Enums.ChatType.Private)
                        {
                            var PersonTitle = item.Message.Chat.FirstName + " " + item.Message.Chat.LastName;
                            var PersonId = item.Message.Chat.Id;

                            if (Chats.Any(x => x.ChatId == PersonId))
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    lstUpdates.Items.Add($"{PersonTitle} is exists in to the chat list");
                                    lstUpdates.Items.Add($"ChatType:Person");
                                    lstUpdates.Items.Add($"ChatId:{PersonId}");
                                    lstUpdates.TopIndex = lstUpdates.Items.Count - 3;
                                    if (chIdenticalChats.Checked)
                                    {
                                        lstUpdates.Items.Add($"{PersonTitle} skipped");
                                        lstUpdates.TopIndex = lstUpdates.Items.Count - 1;
                                    }
                                }));
                                if (chIdenticalChats.Checked)
                                {
                                    continue;
                                }

                            }

                            Chats.Add(new Chat()
                            {
                                ChatType = Telegram.Bot.Types.Enums.ChatType.Private,
                                BotUserName = me.Username,
                                BotToken = txtBotToken.Text,
                                ChatId = PersonId,
                                ChatName = PersonTitle,
                                UserName = item.Message.From.Username
                            });

                            Invoke(new MethodInvoker(delegate ()
                            {
                                lstUpdates.Items.Add($"{PersonTitle} has been inserted");
                                lstUpdates.Items.Add($"ChatType:Person");
                                lstUpdates.Items.Add($"ChatId:{PersonId}");
                                lstUpdates.TopIndex = lstUpdates.Items.Count - 3;
                            }));
                        }
                        offset = item.Id;
                        // item.Message.From.Id;
                        Invoke(new MethodInvoker(delegate ()
                        {
                            buildChatList();
                        }));
                    }

                }
            }
            catch (Exception e)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    //pcGPChecking.Visible = false;
                    //stop = true;
                    //btnStartGetUpdates.Enabled = true;
                    //btnStopGetUpdates.Enabled = false;
                    lstUpdates.Items.Add(e.Message);
                    if (e.InnerException != null)
                    {
                        lstUpdates.Items.Add(e.InnerException.Message);
                    }
                 //   MessageBox.Show(e.Message);
                }));

            }


        }
        public void buildChatList()
        {
            lstChats.Items.Clear();
            //for (int i = 0; i < Chats.Count; i++)
            //{
            //    lstChats.Items.Add($"{i}-{Chats[i].ChatType}: {Chats[i].ChatName},{Environment.NewLine}: {Chats[i].UserName}");
            //}
            foreach (var item in Chats)
            {
                lstChats.Items.Add($"{item.ChatType}: {item.ChatName},{Environment.NewLine}: {item.UserName}");
            }

        }
        async private void btnStartGetUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                pcGPChecking.Visible = true;
                btnStopGetUpdates.Enabled = true;
                stop = false;
                btnStartGetUpdates.Enabled = false;
                await Task.Run(GetUpdats);
            }
            catch (Exception)
            {
                pcGPChecking.Visible = false;
                throw;
            }


        }

        private void btnStopGetUpdates_Click(object sender, EventArgs e)
        {
            pcGPChecking.Visible = false;
            stop = true;
            btnStartGetUpdates.Enabled = true;
            btnStopGetUpdates.Enabled = false;
        }

        private void btn_chats_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtChannelUserName.Text))
                {
                    MessageBox.Show("Enter the channel username");
                    return;
                }
                Chats.Add(new Chat()
                {
                    ChatType = Telegram.Bot.Types.Enums.ChatType.Channel,
                    BotToken = txtBotToken.Text,
                    ChatName = txtChannelUserName.Text.TrimStart('@'),
                    UserName = (txtChannelUserName.Text[0] != '@') ? "@" + txtChannelUserName.Text : txtChannelUserName.Text

                });
                txtChannelUserName.Text = "";
                buildChatList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lstUpdates_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void lstUpdates_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpMarkdownEditor_Enter(object sender, EventArgs e)
        {

        }

        private void frmTelegramBot_Activated(object sender, EventArgs e)
        {
            tabCtrl.SelectedTab = tabPag;

            if (!tabCtrl.Visible)
            {
                tabCtrl.Visible = true;
            }
        }

        private async void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {



                OpenFileDialog di = new OpenFileDialog();
                if (di.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show($"Are you sure to overwrite the information?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        var Saved = JsonConvert.DeserializeObject<Save>(File.ReadAllText(di.FileName));
                        txtChannelUserName.Text = Saved.ChannelId;
                        rhContent.Text = Saved.Content;
                        txtBotToken.Text = Saved.Token;
                        path = Saved.SelectedFile;

                        LblFileName.Text = (Path.GetFileName(Saved.SelectedFile).Length > 30) ?
           Path.GetFileName(Saved.SelectedFile).Substring(0, 30) : Path.GetFileName(Saved.SelectedFile);

                        tsslSelctedFile.Text =
                            (Saved.SelectedFile.Length < 58) ? Saved.SelectedFile : (Path.GetFileName(Saved.SelectedFile).Length > 58) ?
                            Path.GetFileName(Saved.SelectedFile).Substring(0, 58) : Path.GetFileName(Saved.SelectedFile);

                        //LblFileName.Text = Path.GetFileName(Saved.SelectedFile);
                        //tsslSelctedFile.Text = Saved.SelectedFile;
                        txtAudioTitle.Text = Saved.AudioTitle;
                        txtAudioPerformer.Text = Saved.AudioPerformer;
                        txtCaption.Text = Saved.Caption;
                        chIsSilent.Checked = Saved.IsSilent;
                        switch (Saved.ParseMode)
                        {
                            case 0:
                                {
                                    rdoHtml.Checked = true;
                                    grpMarkdownEditor.Enabled = true;
                                    gbHtml.Enabled = true;
                                }

                                break;
                            case 1:
                                {
                                    rdoMarkdown.Checked = true;
                                    grpMarkdownEditor.Enabled = true;
                                    gbHtml.Enabled = false;
                                }

                                break;
                            default:
                                {
                                    rdoDefault.Checked = true;
                                    grpMarkdownEditor.Enabled = false;
                                    gbHtml.Enabled = false;
                                }

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
                        txtInlineKeyboardButtonName.Text = (String.IsNullOrEmpty(Saved.UrlButtonText)) ? "وب سایت معرفی" : Saved.UrlButtonText;
                        txtInlineKeyboardButtonUrl.Text = (String.IsNullOrEmpty(Saved.UrlButtonURL)) ? "http://introducing.ir/" : Saved.UrlButtonURL;
                        txtCol.Text = (Saved.Column == null) ? "1" : Saved.Column;
                        chURLButtons.Checked = Saved.SendUrlButton;
                        offset = Saved.Offset;
                        await PanelBuildr();

                        Chats = Saved.Chats ?? new List<Chat>();
                        buildChatList();
                    }
                }

            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {


                Save sv = new Save()
                {
                    ChannelId = txtChannelUserName.Text,
                    Content = rhContent.Text,
                    Token = txtBotToken.Text,
                    AudioPerformer = txtAudioPerformer.Text,
                    AudioTitle = txtAudioTitle.Text,
                    Caption = txtCaption.Text,
                    SelectedFile = path,
                    IsSilent = chIsSilent.Checked,
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
                    UrlButtonURL = txtInlineKeyboardButtonUrl.Text,
                    Offset = offset,
                    Chats = Chats
                };

                if (File.Exists(DataPath))
                    using (var fs = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sv));
                        fs.Write(bytes, 0, bytes.Length);
                    }
                else
                {
                    MessageBox.Show("Data Path does not exist");
                }
                // MessageBox.Show("Your bot and message has been saved sucessfully");


            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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
                        ChannelId = txtChannelUserName.Text,
                        Content = rhContent.Text,
                        Token = txtBotToken.Text,
                        AudioPerformer = txtAudioPerformer.Text,
                        AudioTitle = txtAudioTitle.Text,
                        Caption = txtCaption.Text,
                        SelectedFile = path,
                        IsSilent = chIsSilent.Checked,
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
                        UrlButtonURL = txtInlineKeyboardButtonUrl.Text,
                        Offset = offset,
                        Chats = Chats
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
        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            try
            {

                Save sv = new Save()
                {
                    ChannelId = txtChannelUserName.Text,
                    Content = rhContent.Text,
                    Token = txtBotToken.Text,
                    AudioPerformer = txtAudioPerformer.Text,
                    AudioTitle = txtAudioTitle.Text,
                    Caption = txtCaption.Text,
                    SelectedFile = path,
                    IsSilent = chIsSilent.Checked,
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
                    UrlButtonURL = txtInlineKeyboardButtonUrl.Text,
                    Offset = offset,
                    Chats = Chats
                };

                if (File.Exists(DataPath))
                    using (var fs = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sv));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                    }
                else
                {
                    MessageBox.Show("Data Path does not exist");
                }
                // MessageBox.Show("Your bot and message has been saved sucessfully");



            }
            catch
            {
                // MessageBox.Show("Error - " + er.Message);
            }
        }

        private void btnDeleteChat_Click(object sender, EventArgs e)
        {
            try
            {
                //ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstChats);
                var selectedItems = lstChats.SelectedIndices;

                if (lstChats.SelectedIndex != -1)
                {
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                        Chats.RemoveAt(selectedItems[i]);
                }

                //foreach (var item in lstChats.SelectedItems)
                //{
                //    var chatItem = Chats.FirstOrDefault(x => x == Chats[int.Parse(((string)item).Split('')[0])]);
                //    if (chatItem != null)
                //    {
                //        Chats.Remove(chatItem);
                //    }
                //}
                //  var selectedIndex = lstChats.SelectedIndex;

                buildChatList();
                //lstChats.SelectedIndex = ite - 1;

            }
            catch (Exception ex)
            {
                buildChatList();
                lstChats.SelectedIndex = 0;

            }
        }

        private void frmTelegramBot_FormClosing(object sender, FormClosingEventArgs e)
        {

            AutoSaveTimer.Stop();
            AutoSaveTimer.Enabled = false;
            AutoSaveTimer.Dispose();

            //Thread.Sleep(1000);
            try
            {
                Save sv = new Save()
                {
                    ChannelId = txtChannelUserName.Text,
                    Content = rhContent.Text,
                    Token = txtBotToken.Text,
                    AudioPerformer = txtAudioPerformer.Text,
                    AudioTitle = txtAudioTitle.Text,
                    Caption = txtCaption.Text,
                    SelectedFile = path,
                    IsSilent = chIsSilent.Checked,
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
                    UrlButtonURL = txtInlineKeyboardButtonUrl.Text,
                    Offset = offset,
                    Chats = Chats
                };
                //     Thread.Sleep(1000);
                if (File.Exists(DataPath))
                {
                    using (var fs = new FileStream(BackupPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sv));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                    }
                    using (var fs = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sv));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                    }

                }

                else
                {
                    MessageBox.Show("Data Path does not exist");
                }
                // MessageBox.Show("Your bot and message has been saved sucessfully");


            }
            catch (Exception er)
            {

                MessageBox.Show("Error - " + er.Message);
            }

            if (!tabCtrl.HasChildren)
            {
                tabCtrl.Visible = false;

            }
            if (e.CloseReason == CloseReason.UserClosing)
            {


                if (MessageBox.Show($"Do you want to save the tab?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    try
                    {
                        Directory.Delete(DataDirectoryPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error...! {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }

            this.tabPag.Dispose();
        }

        private void LblFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(tsslSelctedFile.Text))
                System.Diagnostics.Process.Start(tsslSelctedFile.Text);
        }

        private void btnSelectAllChats_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstChats.Items.Count; i++)
            {
                lstChats.SetSelected(i, true);
            }
        }

        private void btnUnselectAllChats_Click(object sender, EventArgs e)
        {
            lstChats.ClearSelected();

        }

        private void openDataAndBackupFoldeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DataDirectoryPath);
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            try
            {

                Save sv = new Save()
                {
                    ChannelId = txtChannelUserName.Text,
                    Content = rhContent.Text,
                    Token = txtBotToken.Text,
                    AudioPerformer = txtAudioPerformer.Text,
                    AudioTitle = txtAudioTitle.Text,
                    Caption = txtCaption.Text,
                    SelectedFile = path,
                    IsSilent = chIsSilent.Checked,
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
                    UrlButtonURL = txtInlineKeyboardButtonUrl.Text,
                    Offset = offset,
                    Chats = Chats
                };

                if (File.Exists(BackupPath))
                    using (var fs = new FileStream(BackupPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sv));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                    }
                else
                {
                    MessageBox.Show("Data Path does not exist");
                }
                // MessageBox.Show("Your bot and message has been saved sucessfully");



            }
            catch
            {
                // MessageBox.Show("Error - " + er.Message);
            }

        }
    }
    class Messages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
