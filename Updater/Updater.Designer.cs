namespace Updater
{
    partial class Updater
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
            this.lblUpdate = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblSUMessage = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.lblUpdateFailed = new System.Windows.Forms.Label();
            this.PBUpdateFailed = new System.Windows.Forms.PictureBox();
            this.pbSU = new System.Windows.Forms.PictureBox();
            this.pbUpdate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBUpdateFailed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUpdate.Location = new System.Drawing.Point(160, 18);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(89, 18);
            this.lblUpdate.TabIndex = 44;
            this.lblUpdate.Text = "Updating...";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1, 101);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(454, 379);
            this.webBrowser1.TabIndex = 42;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(295, 85);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(158, 13);
            this.linkLabel2.TabIndex = 41;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://telegram.me/Introducing";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 85);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 40;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.Introducing.ir";
            // 
            // lblSUMessage
            // 
            this.lblSUMessage.AutoSize = true;
            this.lblSUMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSUMessage.Location = new System.Drawing.Point(12, 21);
            this.lblSUMessage.Name = "lblSUMessage";
            this.lblSUMessage.Size = new System.Drawing.Size(237, 15);
            this.lblSUMessage.TabIndex = 45;
            this.lblSUMessage.Text = "Application has been successfully updated";
            this.lblSUMessage.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(305, 20);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(126, 23);
            this.btnRun.TabIndex = 47;
            this.btnRun.Text = "Click to run the app";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(237, 20);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(75, 23);
            this.btnRetry.TabIndex = 48;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // lblUpdateFailed
            // 
            this.lblUpdateFailed.AutoSize = true;
            this.lblUpdateFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUpdateFailed.Location = new System.Drawing.Point(113, 23);
            this.lblUpdateFailed.Name = "lblUpdateFailed";
            this.lblUpdateFailed.Size = new System.Drawing.Size(84, 15);
            this.lblUpdateFailed.TabIndex = 49;
            this.lblUpdateFailed.Text = "Update Failed";
            this.lblUpdateFailed.Visible = false;
            // 
            // PBUpdateFailed
            // 
            this.PBUpdateFailed.Image = global::Updater.Properties.Resources.messageboxerror;
            this.PBUpdateFailed.Location = new System.Drawing.Point(203, 20);
            this.PBUpdateFailed.Name = "PBUpdateFailed";
            this.PBUpdateFailed.Size = new System.Drawing.Size(28, 25);
            this.PBUpdateFailed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBUpdateFailed.TabIndex = 50;
            this.PBUpdateFailed.TabStop = false;
            this.PBUpdateFailed.Visible = false;
            // 
            // pbSU
            // 
            this.pbSU.Image = global::Updater.Properties.Resources.ProgressSuccess;
            this.pbSU.Location = new System.Drawing.Point(255, 18);
            this.pbSU.Name = "pbSU";
            this.pbSU.Size = new System.Drawing.Size(28, 25);
            this.pbSU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSU.TabIndex = 46;
            this.pbSU.TabStop = false;
            this.pbSU.Visible = false;
            // 
            // pbUpdate
            // 
            this.pbUpdate.Image = global::Updater.Properties.Resources.ajax_loader;
            this.pbUpdate.Location = new System.Drawing.Point(255, 18);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(28, 25);
            this.pbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpdate.TabIndex = 43;
            this.pbUpdate.TabStop = false;
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(457, 480);
            this.Controls.Add(this.PBUpdateFailed);
            this.Controls.Add(this.lblUpdateFailed);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.pbSU);
            this.Controls.Add(this.lblSUMessage);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.pbUpdate);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Name = "Updater";
            this.Text = "Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBUpdateFailed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.PictureBox pbUpdate;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblSUMessage;
        private System.Windows.Forms.PictureBox pbSU;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Label lblUpdateFailed;
        private System.Windows.Forms.PictureBox PBUpdateFailed;
    }
}