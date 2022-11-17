namespace WForRestGet
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBLogin = new System.Windows.Forms.TextBox();
            this.txtBPass = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtBDomen = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblTestRIMS = new System.Windows.Forms.Label();
            this.btnTestRims = new System.Windows.Forms.Button();
            this.btnTestDB = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbl_Cap = new System.Windows.Forms.Label();
            this.picBoxXclose = new System.Windows.Forms.PictureBox();
            this.picBoxTitle = new System.Windows.Forms.PictureBox();
            this.picBoxEye = new System.Windows.Forms.PictureBox();
            this.picBoxTestDB = new System.Windows.Forms.PictureBox();
            this.picBoxTestRIMS = new System.Windows.Forms.PictureBox();
            this.txtBoxConsole = new System.Windows.Forms.TextBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.btnZRims = new System.Windows.Forms.Button();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.btnExToRims = new System.Windows.Forms.Button();
            this.txtBoxOP1 = new System.Windows.Forms.TextBox();
            this.txtBoxOP2 = new System.Windows.Forms.TextBox();
            this.txtBoxOP3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEWS = new System.Windows.Forms.Button();
            this.txtBoxOP4 = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTestDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTestRIMS)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(399, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Форма работы с данными RIMS, MS SQL, Exchange";
            // 
            // txtBLogin
            // 
            this.txtBLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBLogin.Location = new System.Drawing.Point(657, 32);
            this.txtBLogin.Name = "txtBLogin";
            this.txtBLogin.Size = new System.Drawing.Size(219, 22);
            this.txtBLogin.TabIndex = 1;
            // 
            // txtBPass
            // 
            this.txtBPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBPass.Location = new System.Drawing.Point(657, 59);
            this.txtBPass.Name = "txtBPass";
            this.txtBPass.Size = new System.Drawing.Size(219, 22);
            this.txtBPass.TabIndex = 1;
            this.txtBPass.UseSystemPasswordChar = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(572, 37);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(43, 16);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login:";
            // 
            // txtBDomen
            // 
            this.txtBDomen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDomen.Location = new System.Drawing.Point(657, 86);
            this.txtBDomen.Name = "txtBDomen";
            this.txtBDomen.Size = new System.Drawing.Size(219, 22);
            this.txtBDomen.TabIndex = 1;
            this.txtBDomen.Text = "ie.corp";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(572, 64);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(70, 16);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Password:";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomain.Location = new System.Drawing.Point(572, 91);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(57, 16);
            this.lblDomain.TabIndex = 2;
            this.lblDomain.Text = "Domain:";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 131);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(644, 282);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // lblTestRIMS
            // 
            this.lblTestRIMS.AutoSize = true;
            this.lblTestRIMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestRIMS.Location = new System.Drawing.Point(12, 69);
            this.lblTestRIMS.Name = "lblTestRIMS";
            this.lblTestRIMS.Size = new System.Drawing.Size(165, 16);
            this.lblTestRIMS.TabIndex = 4;
            this.lblTestRIMS.Text = "Тест соеденения с RIMS";
            // 
            // btnTestRims
            // 
            this.btnTestRims.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestRims.Location = new System.Drawing.Point(183, 65);
            this.btnTestRims.Name = "btnTestRims";
            this.btnTestRims.Size = new System.Drawing.Size(90, 23);
            this.btnTestRims.TabIndex = 5;
            this.btnTestRims.Text = "Test RIMS";
            this.btnTestRims.UseVisualStyleBackColor = true;
            this.btnTestRims.Click += new System.EventHandler(this.btnTestRims_Click);
            // 
            // btnTestDB
            // 
            this.btnTestDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDB.Location = new System.Drawing.Point(270, 100);
            this.btnTestDB.Name = "btnTestDB";
            this.btnTestDB.Size = new System.Drawing.Size(90, 23);
            this.btnTestDB.TabIndex = 5;
            this.btnTestDB.Text = "Test DB";
            this.btnTestDB.UseVisualStyleBackColor = true;
            this.btnTestDB.Click += new System.EventHandler(this.btnTestDB_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTop.Controls.Add(this.lbl_Cap);
            this.panelTop.Controls.Add(this.picBoxXclose);
            this.panelTop.Controls.Add(this.picBoxTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(906, 26);
            this.panelTop.TabIndex = 7;
            // 
            // lbl_Cap
            // 
            this.lbl_Cap.AutoSize = true;
            this.lbl_Cap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cap.Location = new System.Drawing.Point(32, 5);
            this.lbl_Cap.Name = "lbl_Cap";
            this.lbl_Cap.Size = new System.Drawing.Size(177, 16);
            this.lbl_Cap.TabIndex = 8;
            this.lbl_Cap.Text = "Demo Algoritms in works";
            // 
            // picBoxXclose
            // 
            this.picBoxXclose.BackgroundImage = global::WForRestGet.Properties.Resources.square_x_icon_215388;
            this.picBoxXclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxXclose.Location = new System.Drawing.Point(877, 0);
            this.picBoxXclose.Name = "picBoxXclose";
            this.picBoxXclose.Size = new System.Drawing.Size(28, 26);
            this.picBoxXclose.TabIndex = 8;
            this.picBoxXclose.TabStop = false;
            // 
            // picBoxTitle
            // 
            this.picBoxTitle.BackgroundImage = global::WForRestGet.Properties.Resources.target_icon_154532;
            this.picBoxTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.picBoxTitle.Name = "picBoxTitle";
            this.picBoxTitle.Size = new System.Drawing.Size(28, 26);
            this.picBoxTitle.TabIndex = 8;
            this.picBoxTitle.TabStop = false;
            // 
            // picBoxEye
            // 
            this.picBoxEye.BackgroundImage = global::WForRestGet.Properties.Resources.slash_eye_icon_224538;
            this.picBoxEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxEye.Location = new System.Drawing.Point(877, 60);
            this.picBoxEye.Name = "picBoxEye";
            this.picBoxEye.Size = new System.Drawing.Size(25, 21);
            this.picBoxEye.TabIndex = 6;
            this.picBoxEye.TabStop = false;
            this.picBoxEye.Click += new System.EventHandler(this.picBoxEye_Click);
            // 
            // picBoxTestDB
            // 
            this.picBoxTestDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxTestDB.Location = new System.Drawing.Point(364, 99);
            this.picBoxTestDB.Name = "picBoxTestDB";
            this.picBoxTestDB.Size = new System.Drawing.Size(24, 26);
            this.picBoxTestDB.TabIndex = 6;
            this.picBoxTestDB.TabStop = false;
            // 
            // picBoxTestRIMS
            // 
            this.picBoxTestRIMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxTestRIMS.Location = new System.Drawing.Point(277, 64);
            this.picBoxTestRIMS.Name = "picBoxTestRIMS";
            this.picBoxTestRIMS.Size = new System.Drawing.Size(24, 26);
            this.picBoxTestRIMS.TabIndex = 6;
            this.picBoxTestRIMS.TabStop = false;
            // 
            // txtBoxConsole
            // 
            this.txtBoxConsole.Location = new System.Drawing.Point(12, 435);
            this.txtBoxConsole.Multiline = true;
            this.txtBoxConsole.Name = "txtBoxConsole";
            this.txtBoxConsole.ReadOnly = true;
            this.txtBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxConsole.Size = new System.Drawing.Size(644, 94);
            this.txtBoxConsole.TabIndex = 8;
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsole.Location = new System.Drawing.Point(15, 416);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(96, 16);
            this.lblConsole.TabIndex = 9;
            this.lblConsole.Text = "Output console";
            // 
            // btnZRims
            // 
            this.btnZRims.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZRims.Location = new System.Drawing.Point(687, 182);
            this.btnZRims.Name = "btnZRims";
            this.btnZRims.Size = new System.Drawing.Size(188, 33);
            this.btnZRims.TabIndex = 10;
            this.btnZRims.Text = "Zapros k RIMS";
            this.btnZRims.UseVisualStyleBackColor = true;
            this.btnZRims.Click += new System.EventHandler(this.btnZRims_Click);
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDB.Location = new System.Drawing.Point(687, 280);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(188, 33);
            this.btnSaveDB.TabIndex = 10;
            this.btnSaveDB.Text = "Save in DBase";
            this.btnSaveDB.UseVisualStyleBackColor = true;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // btnExToRims
            // 
            this.btnExToRims.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExToRims.Location = new System.Drawing.Point(687, 487);
            this.btnExToRims.Name = "btnExToRims";
            this.btnExToRims.Size = new System.Drawing.Size(188, 33);
            this.btnExToRims.TabIndex = 10;
            this.btnExToRims.Text = "OutToRims->EX";
            this.btnExToRims.UseVisualStyleBackColor = true;
            this.btnExToRims.Click += new System.EventHandler(this.btnExToRims_Click);
            // 
            // txtBoxOP1
            // 
            this.txtBoxOP1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxOP1.Location = new System.Drawing.Point(662, 131);
            this.txtBoxOP1.Multiline = true;
            this.txtBoxOP1.Name = "txtBoxOP1";
            this.txtBoxOP1.ReadOnly = true;
            this.txtBoxOP1.Size = new System.Drawing.Size(230, 45);
            this.txtBoxOP1.TabIndex = 12;
            this.txtBoxOP1.Text = "Запрос к API RIMS для получения пользователей со статусом временно нетрудоспособе" +
    "н. Активен только после теста\r\n";
            // 
            // txtBoxOP2
            // 
            this.txtBoxOP2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxOP2.Location = new System.Drawing.Point(662, 221);
            this.txtBoxOP2.Multiline = true;
            this.txtBoxOP2.Name = "txtBoxOP2";
            this.txtBoxOP2.ReadOnly = true;
            this.txtBoxOP2.Size = new System.Drawing.Size(230, 58);
            this.txtBoxOP2.TabIndex = 12;
            this.txtBoxOP2.Text = "Запись полученных данных пользователей со статусом временно нетрудоспособен в баз" +
    "у MS SQL. Активен только после теста и при наличии данных\r\n\r\n";
            // 
            // txtBoxOP3
            // 
            this.txtBoxOP3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxOP3.Location = new System.Drawing.Point(662, 425);
            this.txtBoxOP3.Multiline = true;
            this.txtBoxOP3.Name = "txtBoxOP3";
            this.txtBoxOP3.ReadOnly = true;
            this.txtBoxOP3.Size = new System.Drawing.Size(230, 58);
            this.txtBoxOP3.TabIndex = 12;
            this.txtBoxOP3.Text = "Формирование запросов и отправка их в API RIMS. Чтобы они были обработаны RIMS и " +
    "отправлены в почтовый сервер для установления статусов пользователям.";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(251, 34);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Тест соеденения DB и её актуализация \r\n(удаление устаревших записей -1 день)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1.Text = "Select All";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem2.Text = "Copy to Clipboard";
            // 
            // btnEWS
            // 
            this.btnEWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEWS.Location = new System.Drawing.Point(687, 380);
            this.btnEWS.Name = "btnEWS";
            this.btnEWS.Size = new System.Drawing.Size(188, 33);
            this.btnEWS.TabIndex = 10;
            this.btnEWS.Text = "Check Status";
            this.btnEWS.UseVisualStyleBackColor = true;
            this.btnEWS.Click += new System.EventHandler(this.btnEWS_Click);
            // 
            // txtBoxOP4
            // 
            this.txtBoxOP4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxOP4.Location = new System.Drawing.Point(662, 319);
            this.txtBoxOP4.Multiline = true;
            this.txtBoxOP4.Name = "txtBoxOP4";
            this.txtBoxOP4.ReadOnly = true;
            this.txtBoxOP4.Size = new System.Drawing.Size(230, 56);
            this.txtBoxOP4.TabIndex = 12;
            this.txtBoxOP4.Text = "Получение статуса автоответа пользователей в Microsoft Exchange через RIMS, если " +
    "пользователь сам установил его. Мы его сохраним. Используем многопоточность";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(906, 541);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtBoxOP4);
            this.Controls.Add(this.txtBoxOP3);
            this.Controls.Add(this.txtBoxOP2);
            this.Controls.Add(this.txtBoxOP1);
            this.Controls.Add(this.btnEWS);
            this.Controls.Add(this.btnExToRims);
            this.Controls.Add(this.btnSaveDB);
            this.Controls.Add(this.btnZRims);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.txtBoxConsole);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.picBoxEye);
            this.Controls.Add(this.picBoxTestDB);
            this.Controls.Add(this.picBoxTestRIMS);
            this.Controls.Add(this.btnTestDB);
            this.Controls.Add(this.btnTestRims);
            this.Controls.Add(this.lblTestRIMS);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtBDomen);
            this.Controls.Add(this.txtBPass);
            this.Controls.Add(this.txtBLogin);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTestDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTestRIMS)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtBLogin;
        private System.Windows.Forms.TextBox txtBPass;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtBDomen;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblTestRIMS;
        private System.Windows.Forms.Button btnTestRims;
        private System.Windows.Forms.PictureBox picBoxTestRIMS;
        private System.Windows.Forms.PictureBox picBoxEye;
        private System.Windows.Forms.Button btnTestDB;
        private System.Windows.Forms.PictureBox picBoxTestDB;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox picBoxTitle;
        private System.Windows.Forms.PictureBox picBoxXclose;
        private System.Windows.Forms.Label lbl_Cap;
        private System.Windows.Forms.TextBox txtBoxConsole;
        private System.Windows.Forms.Label lblConsole;
        private System.Windows.Forms.Button btnZRims;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.Button btnExToRims;
        private System.Windows.Forms.TextBox txtBoxOP1;
        private System.Windows.Forms.TextBox txtBoxOP2;
        private System.Windows.Forms.TextBox txtBoxOP3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnEWS;
        private System.Windows.Forms.TextBox txtBoxOP4;
    }
}

