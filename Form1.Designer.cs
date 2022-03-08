namespace chinamovementdb
{
    partial class frmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Database of the Chinese Political Campaigns in the 1950s: From Land Reform to Sta" +
        "te-Private Joint Ownership，1949-1956");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("The Chinese Anti-Rightist Campaign Database，1957–");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("The Chinese Great Leap Forward ──Great Famine Database，1958–1962");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("The Chinese Cultural Revolution Database， 1966-1976");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Databases for History of Contemporary Chinese Political Movements, 1949-   ", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("中国五十年代初中期的政治运动数据库：从土地改革到公私合营，1949-1956");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("中国反右运动数据库，1957–");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("中国大跃进-大饥荒数据库，1958-1962");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("中国文化大革命文库，1966-1976");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode(" 中国当代政治运动史数据库，1949-    ", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnLang = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnTitle = new System.Windows.Forms.Button();
            this.btnFulltext = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnPlace = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLang
            // 
            this.btnLang.BackColor = System.Drawing.Color.Teal;
            this.btnLang.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLang.ForeColor = System.Drawing.Color.Yellow;
            this.btnLang.Location = new System.Drawing.Point(42, 70);
            this.btnLang.Name = "btnLang";
            this.btnLang.Size = new System.Drawing.Size(78, 44);
            this.btnLang.TabIndex = 6;
            this.btnLang.Text = "English";
            this.btnLang.UseVisualStyleBackColor = false;
            this.btnLang.Click += new System.EventHandler(this.btnLang_Click);
            this.btnLang.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnLang.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnSubject
            // 
            this.btnSubject.BackColor = System.Drawing.Color.Teal;
            this.btnSubject.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubject.ForeColor = System.Drawing.Color.Yellow;
            this.btnSubject.Location = new System.Drawing.Point(118, 70);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(104, 44);
            this.btnSubject.TabIndex = 8;
            this.btnSubject.Text = "主题检索";
            this.btnSubject.UseVisualStyleBackColor = false;
            this.btnSubject.Click += new System.EventHandler(this.button3_Click);
            this.btnSubject.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSubject.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.Teal;
            this.btnDate.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDate.ForeColor = System.Drawing.Color.Yellow;
            this.btnDate.Location = new System.Drawing.Point(220, 70);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(104, 44);
            this.btnDate.TabIndex = 9;
            this.btnDate.Text = "日期检索";
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            this.btnDate.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDate.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnAuthor
            // 
            this.btnAuthor.BackColor = System.Drawing.Color.Teal;
            this.btnAuthor.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuthor.ForeColor = System.Drawing.Color.Yellow;
            this.btnAuthor.Location = new System.Drawing.Point(321, 70);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(104, 44);
            this.btnAuthor.TabIndex = 10;
            this.btnAuthor.Text = "作者检索";
            this.btnAuthor.UseVisualStyleBackColor = false;
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            this.btnAuthor.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAuthor.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnTitle
            // 
            this.btnTitle.BackColor = System.Drawing.Color.Teal;
            this.btnTitle.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTitle.ForeColor = System.Drawing.Color.Yellow;
            this.btnTitle.Location = new System.Drawing.Point(422, 70);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(104, 44);
            this.btnTitle.TabIndex = 11;
            this.btnTitle.Text = "标题检索";
            this.btnTitle.UseVisualStyleBackColor = false;
            this.btnTitle.Click += new System.EventHandler(this.btnTitle_Click);
            this.btnTitle.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTitle.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnFulltext
            // 
            this.btnFulltext.BackColor = System.Drawing.Color.Teal;
            this.btnFulltext.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFulltext.ForeColor = System.Drawing.Color.Yellow;
            this.btnFulltext.Location = new System.Drawing.Point(524, 70);
            this.btnFulltext.Name = "btnFulltext";
            this.btnFulltext.Size = new System.Drawing.Size(112, 44);
            this.btnFulltext.TabIndex = 12;
            this.btnFulltext.Text = "全文检索";
            this.btnFulltext.UseVisualStyleBackColor = false;
            this.btnFulltext.Click += new System.EventHandler(this.btnFulltext_Click);
            this.btnFulltext.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnFulltext.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.Teal;
            this.btnIssue.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIssue.ForeColor = System.Drawing.Color.Yellow;
            this.btnIssue.Location = new System.Drawing.Point(634, 70);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(120, 44);
            this.btnIssue.TabIndex = 13;
            this.btnIssue.Text = "发文机构检索";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            this.btnIssue.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnIssue.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnPlace
            // 
            this.btnPlace.BackColor = System.Drawing.Color.Teal;
            this.btnPlace.Font = new System.Drawing.Font("STZhongsong", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlace.ForeColor = System.Drawing.Color.Yellow;
            this.btnPlace.Location = new System.Drawing.Point(752, 70);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(110, 44);
            this.btnPlace.TabIndex = 7;
            this.btnPlace.Text = "地点检索";
            this.btnPlace.UseVisualStyleBackColor = false;
            this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
            this.btnPlace.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnPlace.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 129);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView2);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView3);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(932, 405);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 14;
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeView2.ItemHeight = 28;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode1.Name = "Node1";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Tag = "114012";
            treeNode1.Text = "Database of the Chinese Political Campaigns in the 1950s: From Land Reform to Sta" +
    "te-Private Joint Ownership，1949-1956";
            treeNode1.ToolTipText = "Database of the Chinese Political Campaigns in the 1950s: From Land Reform to Sta" +
    "te-Private Joint Ownership，1949-1956";
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode2.Name = "Node3";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Tag = "97306";
            treeNode2.Text = "The Chinese Anti-Rightist Campaign Database，1957–";
            treeNode2.ToolTipText = "The Chinese Anti-Rightist Campaign Database，1957–";
            treeNode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode3.Name = "Node4";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.Tag = "107619";
            treeNode3.Text = "The Chinese Great Leap Forward ──Great Famine Database，1958–1962";
            treeNode3.ToolTipText = "The Chinese Great Leap Forward ──Great Famine Database，1958–1962";
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode4.Name = "Node6";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode4.Tag = "2";
            treeNode4.Text = "The Chinese Cultural Revolution Database， 1966-1976";
            treeNode4.ToolTipText = "The Chinese Cultural Revolution Database， 1966-1976";
            treeNode5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode5.Name = "Node0";
            treeNode5.NodeFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Databases for History of Contemporary Chinese Political Movements, 1949-   ";
            treeNode5.ToolTipText = "Databases for History of Contemporary Chinese Political Movements, 1949-";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeView2.Size = new System.Drawing.Size(307, 405);
            this.treeView2.TabIndex = 8;
            this.treeView2.Tag = "NotAddNotes";
            this.treeView2.Visible = false;
            this.treeView2.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeCollapse);
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick_1);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeView1.ItemHeight = 28;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode6.Name = "Node1";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode6.Tag = "114012";
            treeNode6.Text = "中国五十年代初中期的政治运动数据库：从土地改革到公私合营，1949-1956";
            treeNode6.ToolTipText = "中国五十年代初中期的政治运动数据库：从土地改革到公私合营，1949-1956";
            treeNode7.Name = "Node2";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode7.Tag = "97306";
            treeNode7.Text = "中国反右运动数据库，1957–";
            treeNode7.ToolTipText = "中国反右运动数据库，1957-";
            treeNode8.Name = "Node4";
            treeNode8.NodeFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode8.Tag = "107619";
            treeNode8.Text = "中国大跃进-大饥荒数据库，1958-1962";
            treeNode8.ToolTipText = "中国大跃进-大饥荒数据库，1958-1962";
            treeNode9.Name = "Node5";
            treeNode9.NodeFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode9.Tag = "2";
            treeNode9.Text = "中国文化大革命文库，1966-1976";
            treeNode9.ToolTipText = "中国文化大革命文库，1966-1976";
            treeNode10.Checked = true;
            treeNode10.Name = "NodeMain";
            treeNode10.NodeFont = new System.Drawing.Font("STHupo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode10.Text = " 中国当代政治运动史数据库，1949-    ";
            treeNode10.ToolTipText = " 中国当代政治运动史数据库，1949-";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(307, 405);
            this.treeView1.TabIndex = 5;
            this.treeView1.Tag = "NotAddNotes";
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // treeView3
            // 
            this.treeView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.treeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeView3.Location = new System.Drawing.Point(0, 0);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(620, 405);
            this.treeView3.TabIndex = 9;
            this.treeView3.Visible = false;
            this.treeView3.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView3_NodeMouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 203);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(620, 405);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Resize += new System.EventHandler(this.webBrowser1_Resize);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(133)))), ((int)(((byte)(222)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 67);
            this.panel1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDownload);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnReturn);
            this.panel2.Location = new System.Drawing.Point(867, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(64, 30);
            this.panel2.TabIndex = 18;
            // 
            // btnDownload
            // 
            this.btnDownload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownload.BackgroundImage")));
            this.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownload.Location = new System.Drawing.Point(-2, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(24, 24);
            this.btnDownload.TabIndex = 22;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Location = new System.Drawing.Point(20, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturn.BackgroundImage")));
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Yellow;
            this.btnReturn.Location = new System.Drawing.Point(42, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(24, 24);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(1, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(930, 13);
            this.label1.TabIndex = 19;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.Location = new System.Drawing.Point(0, 70);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(44, 44);
            this.btnHome.TabIndex = 20;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(933, 536);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPlace);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnFulltext);
            this.Controls.Add(this.btnTitle);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.btnSubject);
            this.Controls.Add(this.btnLang);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(949, 300);
            this.Name = "frmMain";
            this.Text = "中国当代政治运动史数据库";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLang;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.Button btnFulltext;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
    }
}

