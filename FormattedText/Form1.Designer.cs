namespace FormattedText
{
    partial class Form1
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
            this.btn_send = new System.Windows.Forms.Button();
            this.chIsSilent = new System.Windows.Forms.CheckBox();
            this.rdoMarkdown = new System.Windows.Forms.RadioButton();
            this.rdoHtml = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHtmlSample = new System.Windows.Forms.TextBox();
            this.txtMarkdownSample = new System.Windows.Forms.TextBox();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSelctedFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.rhContent = new System.Windows.Forms.RichTextBox();
            this.btnBoldm = new System.Windows.Forms.Button();
            this.grpMarkdownEditor = new System.Windows.Forms.GroupBox();
            this.btnURLm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURLm = new System.Windows.Forms.TextBox();
            this.btnPrem = new System.Windows.Forms.Button();
            this.btnCodem = new System.Windows.Forms.Button();
            this.btnItalicm = new System.Windows.Forms.Button();
            this.grpHtmlEditor = new System.Windows.Forms.GroupBox();
            this.btnQuot = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnGreaterThan = new System.Windows.Forms.Button();
            this.btnLessThan = new System.Windows.Forms.Button();
            this.btnURLh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtURLh = new System.Windows.Forms.TextBox();
            this.btnPreh = new System.Windows.Forms.Button();
            this.btnCodeh = new System.Windows.Forms.Button();
            this.btnItalich = new System.Windows.Forms.Button();
            this.btnBoldh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.LinkLabel();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBotToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChannelId = new System.Windows.Forms.TextBox();
            this.btnBrows = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCaption = new System.Windows.Forms.RichTextBox();
            this.chSendFileIsSilent = new System.Windows.Forms.CheckBox();
            this.rdoSendFile = new System.Windows.Forms.RadioButton();
            this.rdoSendAudio = new System.Windows.Forms.RadioButton();
            this.rdoSendPhoto = new System.Windows.Forms.RadioButton();
            this.rdoSendVideo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAudioTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAudioPerformer = new System.Windows.Forms.TextBox();
            this.pbSendFile = new System.Windows.Forms.PictureBox();
            this.LblFileName = new System.Windows.Forms.Label();
            this.GetMessages = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInlineKeyboardButtonUrl = new System.Windows.Forms.TextBox();
            this.txtInlineKeyboardButtonName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNewButton = new System.Windows.Forms.Button();
            this.chURLButtons = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpMarkdownEditor.SuspendLayout();
            this.grpHtmlEditor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSendFile)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(852, 12);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // chIsSilent
            // 
            this.chIsSilent.AutoSize = true;
            this.chIsSilent.Location = new System.Drawing.Point(5, 18);
            this.chIsSilent.Name = "chIsSilent";
            this.chIsSilent.Size = new System.Drawing.Size(60, 17);
            this.chIsSilent.TabIndex = 6;
            this.chIsSilent.Text = "IsSilent";
            this.chIsSilent.UseVisualStyleBackColor = true;
            // 
            // rdoMarkdown
            // 
            this.rdoMarkdown.AutoSize = true;
            this.rdoMarkdown.Checked = true;
            this.rdoMarkdown.Location = new System.Drawing.Point(6, 14);
            this.rdoMarkdown.Name = "rdoMarkdown";
            this.rdoMarkdown.Size = new System.Drawing.Size(75, 17);
            this.rdoMarkdown.TabIndex = 7;
            this.rdoMarkdown.TabStop = true;
            this.rdoMarkdown.Text = "Markdown";
            this.rdoMarkdown.UseVisualStyleBackColor = true;
            this.rdoMarkdown.CheckedChanged += new System.EventHandler(this.rdoMarkdown_CheckedChanged);
            // 
            // rdoHtml
            // 
            this.rdoHtml.AutoSize = true;
            this.rdoHtml.Location = new System.Drawing.Point(202, 14);
            this.rdoHtml.Name = "rdoHtml";
            this.rdoHtml.Size = new System.Drawing.Size(46, 17);
            this.rdoHtml.TabIndex = 8;
            this.rdoHtml.Text = "Html";
            this.rdoHtml.UseVisualStyleBackColor = true;
            this.rdoHtml.CheckedChanged += new System.EventHandler(this.rdoHtml_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHtmlSample);
            this.groupBox1.Controls.Add(this.txtMarkdownSample);
            this.groupBox1.Controls.Add(this.rdoDefault);
            this.groupBox1.Controls.Add(this.rdoHtml);
            this.groupBox1.Controls.Add(this.rdoMarkdown);
            this.groupBox1.Location = new System.Drawing.Point(6, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 137);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parse Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Samples:";
            // 
            // txtHtmlSample
            // 
            this.txtHtmlSample.Enabled = false;
            this.txtHtmlSample.Location = new System.Drawing.Point(129, 56);
            this.txtHtmlSample.Multiline = true;
            this.txtHtmlSample.Name = "txtHtmlSample";
            this.txtHtmlSample.Size = new System.Drawing.Size(119, 76);
            this.txtHtmlSample.TabIndex = 11;
            // 
            // txtMarkdownSample
            // 
            this.txtMarkdownSample.Location = new System.Drawing.Point(6, 56);
            this.txtMarkdownSample.Multiline = true;
            this.txtMarkdownSample.Name = "txtMarkdownSample";
            this.txtMarkdownSample.Size = new System.Drawing.Size(119, 76);
            this.txtMarkdownSample.TabIndex = 10;
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Location = new System.Drawing.Point(107, 14);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(59, 17);
            this.rdoDefault.TabIndex = 9;
            this.rdoDefault.Text = "Default";
            this.rdoDefault.UseVisualStyleBackColor = true;
            this.rdoDefault.CheckedChanged += new System.EventHandler(this.rdoDefault_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.tsslSelctedFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel1.Text = "Kiaksarg";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel2.Text = "www.Introducing.ir";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel3.Text = "SelectedFile:";
            // 
            // tsslSelctedFile
            // 
            this.tsslSelctedFile.IsLink = true;
            this.tsslSelctedFile.Name = "tsslSelctedFile";
            this.tsslSelctedFile.Size = new System.Drawing.Size(12, 17);
            this.tsslSelctedFile.Text = "-";
            this.tsslSelctedFile.Click += new System.EventHandler(this.tsslSelctedFile_Click);
            // 
            // rhContent
            // 
            this.rhContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.rhContent.Location = new System.Drawing.Point(0, 24);
            this.rhContent.Name = "rhContent";
            this.rhContent.Size = new System.Drawing.Size(971, 197);
            this.rhContent.TabIndex = 11;
            this.rhContent.Text = "";
            // 
            // btnBoldm
            // 
            this.btnBoldm.Location = new System.Drawing.Point(6, 19);
            this.btnBoldm.Name = "btnBoldm";
            this.btnBoldm.Size = new System.Drawing.Size(27, 23);
            this.btnBoldm.TabIndex = 14;
            this.btnBoldm.Text = "b";
            this.btnBoldm.UseVisualStyleBackColor = true;
            this.btnBoldm.Click += new System.EventHandler(this.btnBoldm_Click);
            // 
            // grpMarkdownEditor
            // 
            this.grpMarkdownEditor.Controls.Add(this.btnURLm);
            this.grpMarkdownEditor.Controls.Add(this.label4);
            this.grpMarkdownEditor.Controls.Add(this.txtURLm);
            this.grpMarkdownEditor.Controls.Add(this.btnPrem);
            this.grpMarkdownEditor.Controls.Add(this.btnCodem);
            this.grpMarkdownEditor.Controls.Add(this.btnItalicm);
            this.grpMarkdownEditor.Controls.Add(this.btnBoldm);
            this.grpMarkdownEditor.Location = new System.Drawing.Point(272, 228);
            this.grpMarkdownEditor.Name = "grpMarkdownEditor";
            this.grpMarkdownEditor.Size = new System.Drawing.Size(160, 109);
            this.grpMarkdownEditor.TabIndex = 15;
            this.grpMarkdownEditor.TabStop = false;
            this.grpMarkdownEditor.Text = "Markdown Editor";
            // 
            // btnURLm
            // 
            this.btnURLm.Location = new System.Drawing.Point(9, 79);
            this.btnURLm.Name = "btnURLm";
            this.btnURLm.Size = new System.Drawing.Size(39, 23);
            this.btnURLm.TabIndex = 20;
            this.btnURLm.Text = "URL";
            this.btnURLm.UseVisualStyleBackColor = true;
            this.btnURLm.Click += new System.EventHandler(this.btnURLm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "URL:";
            // 
            // txtURLm
            // 
            this.txtURLm.Location = new System.Drawing.Point(44, 53);
            this.txtURLm.Name = "txtURLm";
            this.txtURLm.Size = new System.Drawing.Size(110, 20);
            this.txtURLm.TabIndex = 18;
            // 
            // btnPrem
            // 
            this.btnPrem.Location = new System.Drawing.Point(115, 19);
            this.btnPrem.Name = "btnPrem";
            this.btnPrem.Size = new System.Drawing.Size(39, 23);
            this.btnPrem.TabIndex = 17;
            this.btnPrem.Text = "pre";
            this.btnPrem.UseVisualStyleBackColor = true;
            this.btnPrem.Click += new System.EventHandler(this.btnPrem_Click);
            // 
            // btnCodem
            // 
            this.btnCodem.Location = new System.Drawing.Point(72, 19);
            this.btnCodem.Name = "btnCodem";
            this.btnCodem.Size = new System.Drawing.Size(39, 23);
            this.btnCodem.TabIndex = 16;
            this.btnCodem.Text = "code";
            this.btnCodem.UseVisualStyleBackColor = true;
            this.btnCodem.Click += new System.EventHandler(this.btnCodem_Click);
            // 
            // btnItalicm
            // 
            this.btnItalicm.Location = new System.Drawing.Point(39, 19);
            this.btnItalicm.Name = "btnItalicm";
            this.btnItalicm.Size = new System.Drawing.Size(27, 23);
            this.btnItalicm.TabIndex = 15;
            this.btnItalicm.Text = "i";
            this.btnItalicm.UseVisualStyleBackColor = true;
            this.btnItalicm.Click += new System.EventHandler(this.btnItalicm_Click);
            // 
            // grpHtmlEditor
            // 
            this.grpHtmlEditor.Controls.Add(this.btnQuot);
            this.grpHtmlEditor.Controls.Add(this.btnAnd);
            this.grpHtmlEditor.Controls.Add(this.btnGreaterThan);
            this.grpHtmlEditor.Controls.Add(this.btnLessThan);
            this.grpHtmlEditor.Controls.Add(this.btnURLh);
            this.grpHtmlEditor.Controls.Add(this.label5);
            this.grpHtmlEditor.Controls.Add(this.txtURLh);
            this.grpHtmlEditor.Controls.Add(this.btnPreh);
            this.grpHtmlEditor.Controls.Add(this.btnCodeh);
            this.grpHtmlEditor.Controls.Add(this.btnItalich);
            this.grpHtmlEditor.Controls.Add(this.btnBoldh);
            this.grpHtmlEditor.Enabled = false;
            this.grpHtmlEditor.Location = new System.Drawing.Point(272, 343);
            this.grpHtmlEditor.Name = "grpHtmlEditor";
            this.grpHtmlEditor.Size = new System.Drawing.Size(160, 137);
            this.grpHtmlEditor.TabIndex = 21;
            this.grpHtmlEditor.TabStop = false;
            this.grpHtmlEditor.Text = "Html Editor";
            // 
            // btnQuot
            // 
            this.btnQuot.Location = new System.Drawing.Point(110, 108);
            this.btnQuot.Name = "btnQuot";
            this.btnQuot.Size = new System.Drawing.Size(27, 23);
            this.btnQuot.TabIndex = 24;
            this.btnQuot.Text = "\"";
            this.btnQuot.UseVisualStyleBackColor = true;
            this.btnQuot.Click += new System.EventHandler(this.btnQuot_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(77, 108);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(27, 23);
            this.btnAnd.TabIndex = 23;
            this.btnAnd.Text = "&&";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnGreaterThan
            // 
            this.btnGreaterThan.Location = new System.Drawing.Point(44, 108);
            this.btnGreaterThan.Name = "btnGreaterThan";
            this.btnGreaterThan.Size = new System.Drawing.Size(27, 23);
            this.btnGreaterThan.TabIndex = 22;
            this.btnGreaterThan.Text = ">";
            this.btnGreaterThan.UseVisualStyleBackColor = true;
            this.btnGreaterThan.Click += new System.EventHandler(this.btnGreaterThan_Click);
            // 
            // btnLessThan
            // 
            this.btnLessThan.Location = new System.Drawing.Point(11, 108);
            this.btnLessThan.Name = "btnLessThan";
            this.btnLessThan.Size = new System.Drawing.Size(27, 23);
            this.btnLessThan.TabIndex = 21;
            this.btnLessThan.Text = "<";
            this.btnLessThan.UseVisualStyleBackColor = true;
            this.btnLessThan.Click += new System.EventHandler(this.btnLessThan_Click);
            // 
            // btnURLh
            // 
            this.btnURLh.Location = new System.Drawing.Point(9, 79);
            this.btnURLh.Name = "btnURLh";
            this.btnURLh.Size = new System.Drawing.Size(46, 23);
            this.btnURLh.TabIndex = 20;
            this.btnURLh.Text = "URL";
            this.btnURLh.UseVisualStyleBackColor = true;
            this.btnURLh.Click += new System.EventHandler(this.btnURLh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "URL:";
            // 
            // txtURLh
            // 
            this.txtURLh.Location = new System.Drawing.Point(44, 53);
            this.txtURLh.Name = "txtURLh";
            this.txtURLh.Size = new System.Drawing.Size(110, 20);
            this.txtURLh.TabIndex = 18;
            // 
            // btnPreh
            // 
            this.btnPreh.Location = new System.Drawing.Point(115, 19);
            this.btnPreh.Name = "btnPreh";
            this.btnPreh.Size = new System.Drawing.Size(39, 23);
            this.btnPreh.TabIndex = 17;
            this.btnPreh.Text = "pre";
            this.btnPreh.UseVisualStyleBackColor = true;
            this.btnPreh.Click += new System.EventHandler(this.btnPreh_Click);
            // 
            // btnCodeh
            // 
            this.btnCodeh.Location = new System.Drawing.Point(72, 19);
            this.btnCodeh.Name = "btnCodeh";
            this.btnCodeh.Size = new System.Drawing.Size(39, 23);
            this.btnCodeh.TabIndex = 16;
            this.btnCodeh.Text = "code";
            this.btnCodeh.UseVisualStyleBackColor = true;
            this.btnCodeh.Click += new System.EventHandler(this.btnCodeh_Click);
            // 
            // btnItalich
            // 
            this.btnItalich.Location = new System.Drawing.Point(39, 19);
            this.btnItalich.Name = "btnItalich";
            this.btnItalich.Size = new System.Drawing.Size(27, 23);
            this.btnItalich.TabIndex = 15;
            this.btnItalich.Text = "i";
            this.btnItalich.UseVisualStyleBackColor = true;
            this.btnItalich.Click += new System.EventHandler(this.btnItalich_Click);
            // 
            // btnBoldh
            // 
            this.btnBoldh.Location = new System.Drawing.Point(6, 19);
            this.btnBoldh.Name = "btnBoldh";
            this.btnBoldh.Size = new System.Drawing.Size(27, 23);
            this.btnBoldh.TabIndex = 14;
            this.btnBoldh.Text = "b";
            this.btnBoldh.UseVisualStyleBackColor = true;
            this.btnBoldh.Click += new System.EventHandler(this.btnBoldh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chURLButtons);
            this.groupBox2.Controls.Add(this.lblMessage);
            this.groupBox2.Controls.Add(this.pbSend);
            this.groupBox2.Controls.Add(this.chIsSilent);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Location = new System.Drawing.Point(7, 481);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(949, 43);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.LinkColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(71, 19);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 45;
            this.lblMessage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMessage_LinkClicked);
            // 
            // pbSend
            // 
            this.pbSend.Image = global::FormattedText.Properties.Resources.ajax_loader;
            this.pbSend.Location = new System.Drawing.Point(930, 13);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(17, 17);
            this.pbSend.TabIndex = 43;
            this.pbSend.TabStop = false;
            this.pbSend.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBotToken);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtChannelId);
            this.groupBox3.Location = new System.Drawing.Point(6, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 109);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Identities";
            // 
            // txtBotToken
            // 
            this.txtBotToken.Location = new System.Drawing.Point(6, 37);
            this.txtBotToken.Name = "txtBotToken";
            this.txtBotToken.Size = new System.Drawing.Size(248, 20);
            this.txtBotToken.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = " Bot Token:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Channel Username (@channelusername): ";
            // 
            // txtChannelId
            // 
            this.txtChannelId.Location = new System.Drawing.Point(6, 76);
            this.txtChannelId.Name = "txtChannelId";
            this.txtChannelId.Size = new System.Drawing.Size(248, 20);
            this.txtChannelId.TabIndex = 5;
            // 
            // btnBrows
            // 
            this.btnBrows.Location = new System.Drawing.Point(6, 149);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(70, 23);
            this.btnBrows.TabIndex = 26;
            this.btnBrows.Text = "Select File";
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Caption:";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(71, 223);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 29;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCaption);
            this.groupBox4.Controls.Add(this.chSendFileIsSilent);
            this.groupBox4.Controls.Add(this.rdoSendFile);
            this.groupBox4.Controls.Add(this.rdoSendAudio);
            this.groupBox4.Controls.Add(this.rdoSendPhoto);
            this.groupBox4.Controls.Add(this.rdoSendVideo);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtAudioTitle);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtAudioPerformer);
            this.groupBox4.Controls.Add(this.pbSendFile);
            this.groupBox4.Controls.Add(this.LblFileName);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnSendFile);
            this.groupBox4.Controls.Add(this.btnBrows);
            this.groupBox4.Location = new System.Drawing.Point(442, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 252);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Send File";
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(6, 27);
            this.txtCaption.MaxLength = 200;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(160, 67);
            this.txtCaption.TabIndex = 45;
            this.txtCaption.Text = "";
            // 
            // chSendFileIsSilent
            // 
            this.chSendFileIsSilent.AutoSize = true;
            this.chSendFileIsSilent.Location = new System.Drawing.Point(6, 227);
            this.chSendFileIsSilent.Name = "chSendFileIsSilent";
            this.chSendFileIsSilent.Size = new System.Drawing.Size(60, 17);
            this.chSendFileIsSilent.TabIndex = 44;
            this.chSendFileIsSilent.Text = "IsSilent";
            this.chSendFileIsSilent.UseVisualStyleBackColor = true;
            // 
            // rdoSendFile
            // 
            this.rdoSendFile.AutoSize = true;
            this.rdoSendFile.Checked = true;
            this.rdoSendFile.Location = new System.Drawing.Point(6, 178);
            this.rdoSendFile.Name = "rdoSendFile";
            this.rdoSendFile.Size = new System.Drawing.Size(69, 17);
            this.rdoSendFile.TabIndex = 42;
            this.rdoSendFile.TabStop = true;
            this.rdoSendFile.Text = "Send File";
            this.rdoSendFile.UseVisualStyleBackColor = true;
            this.rdoSendFile.CheckedChanged += new System.EventHandler(this.rdoSendFile_CheckedChanged);
            // 
            // rdoSendAudio
            // 
            this.rdoSendAudio.AutoSize = true;
            this.rdoSendAudio.Location = new System.Drawing.Point(86, 200);
            this.rdoSendAudio.Name = "rdoSendAudio";
            this.rdoSendAudio.Size = new System.Drawing.Size(80, 17);
            this.rdoSendAudio.TabIndex = 41;
            this.rdoSendAudio.Text = "Send Audio";
            this.rdoSendAudio.UseVisualStyleBackColor = true;
            this.rdoSendAudio.CheckedChanged += new System.EventHandler(this.rdoSendAudio_CheckedChanged);
            // 
            // rdoSendPhoto
            // 
            this.rdoSendPhoto.AutoSize = true;
            this.rdoSendPhoto.Location = new System.Drawing.Point(86, 177);
            this.rdoSendPhoto.Name = "rdoSendPhoto";
            this.rdoSendPhoto.Size = new System.Drawing.Size(81, 17);
            this.rdoSendPhoto.TabIndex = 40;
            this.rdoSendPhoto.Text = "Send Photo";
            this.rdoSendPhoto.UseVisualStyleBackColor = true;
            this.rdoSendPhoto.CheckedChanged += new System.EventHandler(this.rdoSendPhoto_CheckedChanged);
            // 
            // rdoSendVideo
            // 
            this.rdoSendVideo.AutoSize = true;
            this.rdoSendVideo.Location = new System.Drawing.Point(6, 200);
            this.rdoSendVideo.Name = "rdoSendVideo";
            this.rdoSendVideo.Size = new System.Drawing.Size(80, 17);
            this.rdoSendVideo.TabIndex = 39;
            this.rdoSendVideo.Text = "Send Video";
            this.rdoSendVideo.UseVisualStyleBackColor = true;
            this.rdoSendVideo.CheckedChanged += new System.EventHandler(this.rdoSendVideo_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Audio Title:";
            // 
            // txtAudioTitle
            // 
            this.txtAudioTitle.Enabled = false;
            this.txtAudioTitle.Location = new System.Drawing.Point(86, 126);
            this.txtAudioTitle.Name = "txtAudioTitle";
            this.txtAudioTitle.Size = new System.Drawing.Size(80, 20);
            this.txtAudioTitle.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Audio Performer:";
            // 
            // txtAudioPerformer
            // 
            this.txtAudioPerformer.Enabled = false;
            this.txtAudioPerformer.Location = new System.Drawing.Point(86, 100);
            this.txtAudioPerformer.Name = "txtAudioPerformer";
            this.txtAudioPerformer.Size = new System.Drawing.Size(80, 20);
            this.txtAudioPerformer.TabIndex = 35;
            // 
            // pbSendFile
            // 
            this.pbSendFile.Image = global::FormattedText.Properties.Resources.ajax_loader;
            this.pbSendFile.Location = new System.Drawing.Point(149, 223);
            this.pbSendFile.Name = "pbSendFile";
            this.pbSendFile.Size = new System.Drawing.Size(17, 17);
            this.pbSendFile.TabIndex = 34;
            this.pbSendFile.TabStop = false;
            this.pbSendFile.Visible = false;
            // 
            // LblFileName
            // 
            this.LblFileName.AutoSize = true;
            this.LblFileName.Location = new System.Drawing.Point(78, 154);
            this.LblFileName.Name = "LblFileName";
            this.LblFileName.Size = new System.Drawing.Size(16, 13);
            this.LblFileName.TabIndex = 33;
            this.LblFileName.Text = "...";
            // 
            // GetMessages
            // 
            this.GetMessages.Enabled = true;
            this.GetMessages.Interval = 100000;
            this.GetMessages.Tick += new System.EventHandler(this.GetMessages_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.txtCol);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtInlineKeyboardButtonUrl);
            this.groupBox5.Controls.Add(this.txtInlineKeyboardButtonName);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.btnNewButton);
            this.groupBox5.Location = new System.Drawing.Point(620, 228);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(339, 252);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "URL buttons";
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(239, 16);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(21, 20);
            this.txtCol.TabIndex = 13;
            this.txtCol.Text = "1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 180);
            this.panel1.TabIndex = 32;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete All";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Column:";
            // 
            // txtInlineKeyboardButtonUrl
            // 
            this.txtInlineKeyboardButtonUrl.Location = new System.Drawing.Point(59, 42);
            this.txtInlineKeyboardButtonUrl.Name = "txtInlineKeyboardButtonUrl";
            this.txtInlineKeyboardButtonUrl.Size = new System.Drawing.Size(122, 20);
            this.txtInlineKeyboardButtonUrl.TabIndex = 5;
            this.txtInlineKeyboardButtonUrl.Text = "http://introducing.ir/";
            // 
            // txtInlineKeyboardButtonName
            // 
            this.txtInlineKeyboardButtonName.Location = new System.Drawing.Point(59, 16);
            this.txtInlineKeyboardButtonName.Name = "txtInlineKeyboardButtonName";
            this.txtInlineKeyboardButtonName.Size = new System.Drawing.Size(122, 20);
            this.txtInlineKeyboardButtonName.TabIndex = 6;
            this.txtInlineKeyboardButtonName.Text = "وب سایت معرفی";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "URL:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Name:";
            // 
            // btnNewButton
            // 
            this.btnNewButton.Location = new System.Drawing.Point(263, 40);
            this.btnNewButton.Name = "btnNewButton";
            this.btnNewButton.Size = new System.Drawing.Size(73, 23);
            this.btnNewButton.TabIndex = 8;
            this.btnNewButton.Text = "New Button";
            this.btnNewButton.UseVisualStyleBackColor = true;
            this.btnNewButton.Click += new System.EventHandler(this.btnNewButton_Click);
            // 
            // chURLButtons
            // 
            this.chURLButtons.AutoSize = true;
            this.chURLButtons.BackColor = System.Drawing.Color.Red;
            this.chURLButtons.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chURLButtons.Location = new System.Drawing.Point(597, 15);
            this.chURLButtons.Name = "chURLButtons";
            this.chURLButtons.Size = new System.Drawing.Size(248, 17);
            this.chURLButtons.TabIndex = 48;
            this.chURLButtons.Text = "Send URL buttons with files and text messages";
            this.chURLButtons.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 546);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpHtmlEditor);
            this.Controls.Add(this.grpMarkdownEditor);
            this.Controls.Add(this.rhContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(631, 585);
            this.Name = "Form1";
            this.Text = "Telegram Channel Manager Desktop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpMarkdownEditor.ResumeLayout(false);
            this.grpMarkdownEditor.PerformLayout();
            this.grpHtmlEditor.ResumeLayout(false);
            this.grpHtmlEditor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSendFile)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.CheckBox chIsSilent;
        private System.Windows.Forms.RadioButton rdoMarkdown;
        private System.Windows.Forms.RadioButton rdoHtml;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoDefault;
        private System.Windows.Forms.TextBox txtHtmlSample;
        private System.Windows.Forms.TextBox txtMarkdownSample;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.RichTextBox rhContent;
        private System.Windows.Forms.Button btnBoldm;
        private System.Windows.Forms.GroupBox grpMarkdownEditor;
        private System.Windows.Forms.Button btnURLm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURLm;
        private System.Windows.Forms.Button btnPrem;
        private System.Windows.Forms.Button btnCodem;
        private System.Windows.Forms.Button btnItalicm;
        private System.Windows.Forms.GroupBox grpHtmlEditor;
        private System.Windows.Forms.Button btnURLh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtURLh;
        private System.Windows.Forms.Button btnPreh;
        private System.Windows.Forms.Button btnCodeh;
        private System.Windows.Forms.Button btnItalich;
        private System.Windows.Forms.Button btnBoldh;
        private System.Windows.Forms.Button btnQuot;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnGreaterThan;
        private System.Windows.Forms.Button btnLessThan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBotToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChannelId;
        private System.Windows.Forms.Button btnBrows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblFileName;
        private System.Windows.Forms.PictureBox pbSendFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAudioTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAudioPerformer;
        private System.Windows.Forms.ToolStripStatusLabel tsslSelctedFile;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.RadioButton rdoSendFile;
        private System.Windows.Forms.RadioButton rdoSendAudio;
        private System.Windows.Forms.RadioButton rdoSendPhoto;
        private System.Windows.Forms.RadioButton rdoSendVideo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.CheckBox chSendFileIsSilent;
        private System.Windows.Forms.RichTextBox txtCaption;
        private System.Windows.Forms.Timer GetMessages;
        private System.Windows.Forms.LinkLabel lblMessage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNewButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInlineKeyboardButtonName;
        private System.Windows.Forms.TextBox txtInlineKeyboardButtonUrl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chURLButtons;
    }
}

