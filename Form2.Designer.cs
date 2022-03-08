namespace chinamovementdb
{
    partial class frmIdSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.txtEqualDay = new System.Windows.Forms.TextBox();
            this.lblDay3 = new System.Windows.Forms.Label();
            this.lblMonth3 = new System.Windows.Forms.Label();
            this.lblYear3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOr = new System.Windows.Forms.RadioButton();
            this.radioAnd = new System.Windows.Forms.RadioButton();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblsearchItem = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSelectDatabase = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(133)))), ((int)(((byte)(222)))));
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblsearchItem);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblSelectDatabase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 168);
            this.panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.Location = new System.Drawing.Point(3, 131);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(24, 24);
            this.btnHome.TabIndex = 34;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboYear);
            this.panel2.Controls.Add(this.comboMonth);
            this.panel2.Controls.Add(this.txtEqualDay);
            this.panel2.Controls.Add(this.lblDay3);
            this.panel2.Controls.Add(this.lblMonth3);
            this.panel2.Controls.Add(this.lblYear3);
            this.panel2.Location = new System.Drawing.Point(170, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 50);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // comboYear
            // 
            this.comboYear.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(84, 9);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(85, 29);
            this.comboYear.TabIndex = 23;
            // 
            // comboMonth
            // 
            this.comboMonth.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Items.AddRange(new object[] {
            " ",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboMonth.Location = new System.Drawing.Point(238, 10);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(42, 29);
            this.comboMonth.TabIndex = 22;
            this.comboMonth.Text = "1";
            // 
            // txtEqualDay
            // 
            this.txtEqualDay.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEqualDay.Location = new System.Drawing.Point(342, 11);
            this.txtEqualDay.Name = "txtEqualDay";
            this.txtEqualDay.Size = new System.Drawing.Size(43, 29);
            this.txtEqualDay.TabIndex = 21;
            // 
            // lblDay3
            // 
            this.lblDay3.AutoSize = true;
            this.lblDay3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDay3.ForeColor = System.Drawing.Color.White;
            this.lblDay3.Location = new System.Drawing.Point(391, 14);
            this.lblDay3.Name = "lblDay3";
            this.lblDay3.Size = new System.Drawing.Size(26, 21);
            this.lblDay3.TabIndex = 18;
            this.lblDay3.Text = "日";
            // 
            // lblMonth3
            // 
            this.lblMonth3.AutoSize = true;
            this.lblMonth3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonth3.ForeColor = System.Drawing.Color.White;
            this.lblMonth3.Location = new System.Drawing.Point(286, 14);
            this.lblMonth3.Name = "lblMonth3";
            this.lblMonth3.Size = new System.Drawing.Size(26, 21);
            this.lblMonth3.TabIndex = 17;
            this.lblMonth3.Text = "月";
            // 
            // lblYear3
            // 
            this.lblYear3.AutoSize = true;
            this.lblYear3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYear3.ForeColor = System.Drawing.Color.White;
            this.lblYear3.Location = new System.Drawing.Point(175, 14);
            this.lblYear3.Name = "lblYear3";
            this.lblYear3.Size = new System.Drawing.Size(26, 21);
            this.lblYear3.TabIndex = 16;
            this.lblYear3.Text = "年";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(506, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 29);
            this.textBox2.TabIndex = 33;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(170, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 29);
            this.textBox1.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioOr);
            this.groupBox1.Controls.Add(this.radioAnd);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(370, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 40);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // radioOr
            // 
            this.radioOr.AutoSize = true;
            this.radioOr.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOr.Location = new System.Drawing.Point(63, 12);
            this.radioOr.Name = "radioOr";
            this.radioOr.Size = new System.Drawing.Size(60, 25);
            this.radioOr.TabIndex = 1;
            this.radioOr.Text = "或者";
            this.radioOr.UseVisualStyleBackColor = true;
            // 
            // radioAnd
            // 
            this.radioAnd.AutoSize = true;
            this.radioAnd.Checked = true;
            this.radioAnd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAnd.Location = new System.Drawing.Point(3, 12);
            this.radioAnd.Name = "radioAnd";
            this.radioAnd.Size = new System.Drawing.Size(60, 25);
            this.radioAnd.TabIndex = 0;
            this.radioAnd.TabStop = true;
            this.radioAnd.Text = "并且";
            this.radioAnd.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownload.BackgroundImage")));
            this.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownload.Location = new System.Drawing.Point(47, 131);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(24, 24);
            this.btnDownload.TabIndex = 24;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Location = new System.Drawing.Point(69, 131);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(720, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 165);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Teal;
            this.btnClear.Font = new System.Drawing.Font("STZhongsong", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.btnClear.Location = new System.Drawing.Point(170, 115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("STZhongsong", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(596, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // lblsearchItem
            // 
            this.lblsearchItem.AutoSize = true;
            this.lblsearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearchItem.ForeColor = System.Drawing.Color.White;
            this.lblsearchItem.Location = new System.Drawing.Point(12, 69);
            this.lblsearchItem.Name = "lblsearchItem";
            this.lblsearchItem.Size = new System.Drawing.Size(60, 20);
            this.lblsearchItem.TabIndex = 2;
            this.lblsearchItem.Text = "主题词";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(170, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(526, 26);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSelectDatabase
            // 
            this.lblSelectDatabase.AutoSize = true;
            this.lblSelectDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDatabase.ForeColor = System.Drawing.Color.White;
            this.lblSelectDatabase.Location = new System.Drawing.Point(9, 20);
            this.lblSelectDatabase.Name = "lblSelectDatabase";
            this.lblSelectDatabase.Size = new System.Drawing.Size(111, 20);
            this.lblSelectDatabase.TabIndex = 0;
            this.lblSelectDatabase.Text = "请选择数据库";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(133)))), ((int)(((byte)(222)))));
            this.splitContainer1.Location = new System.Drawing.Point(0, 174);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(710, 270);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(234, 270);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(471, 270);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnList.BackgroundImage")));
            this.btnList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnList.Location = new System.Drawing.Point(25, 131);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(24, 24);
            this.btnList.TabIndex = 36;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // frmIdSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(724, 300);
            this.Name = "frmIdSearch";
            this.Text = "ID检索";
            this.Activated += new System.EventHandler(this.frmIdSearch_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIdSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmIdSearch_Load);
            this.Resize += new System.EventHandler(this.frmSubject_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblsearchItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSelectDatabase;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEqualDay;
        private System.Windows.Forms.Label lblDay3;
        private System.Windows.Forms.Label lblMonth3;
        private System.Windows.Forms.Label lblYear3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioOr;
        private System.Windows.Forms.RadioButton radioAnd;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox comboMonth;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnList;
    }
}