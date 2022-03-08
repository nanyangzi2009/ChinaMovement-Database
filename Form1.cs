using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Microsoft.Win32;

namespace chinamovementdb
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        //string[] enNodeHead = { "Database of Movement History of Current China", "Database of the Chinese Political Campaigns in the 1950s: From Land Reform to State-Private Partnership, 1949-1956", "Chinese Anti-Rightist Campaign Database, 1957 -", "Chinese Great Leap Forward and Great Famine Database", "Chinese Cultural Revolution Database" };
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Class1.InitApp(); 
            this.splitContainer1.Anchor = (AnchorStyles.Left |AnchorStyles.Right);
            
            this.webBrowser1.DocumentText = GENERAL.txtAbout;
            this.pictureBox1.Width = this.webBrowser1.Width;
            this.pictureBox1.Height = this.webBrowser1.Height;
            this.treeView1.Nodes[0].Expand();
            this.treeView2.Nodes[0].Expand();
            this.treeView1.Nodes[0].Tag = "";
            this.treeView2.Nodes[0].Tag = "";
            this.splitContainer1.Top = this.label1.Top + this.label1.Height-1;
            this.Check_First_Run();
        }

        private void Check_First_Run()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                RegistryKey key1 = key.OpenSubKey("DHCCPM", true);
                if (key1 == null)
                {
                    key1 = key.CreateSubKey("DHCCPM");
                }
                else
                {
                    string s = key1.GetValue("IEset").ToString();
                    if (s == "yes") return;
                }
                if (SetIE_WebBrower()) key1.SetValue("IEset", "yes");
            }
            catch(Exception exp)
            {
               // MessageBox.Show(exp.Message); 
            }
        }

        private bool SetIE_WebBrower()
        {
            try
            {
                RegistryKey  key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                key.SetValue("chinamovementdb.exe", 10000, RegistryValueKind.DWord);

                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                key.SetValue("chinamovementdb.exe", 10000, RegistryValueKind.DWord);
            }
            catch(Exception exp)
            {
                DialogResult rst= MessageBox.Show(exp.Message + ",注册浏览器引擎失败，您的应用程序有可能看不到理想的显示效果,要继续吗？","Register IE Engine Failed",MessageBoxButtons.OKCancel);
                if (rst == DialogResult.Cancel) return false;
            }
            return true;
        }

        private void load_background_image(string imageFilePath)
        {
            this.pictureBox1.Image=Image.FromFile(imageFilePath) ;
            this.pictureBox1.Show();
            this.panel2.Hide();
        }
        

        private void addNodes(string lang)
        {
            TreeView treeview = ( lang == "Chinese"? this.treeView1: this.treeView2);
            string title = (lang == "Chinese" ? "Title" : "ETitle");
            this.Cursor = Cursors.WaitCursor;
            try
            {

                GENERAL._dbConnection.Open();
                OleDbCommand cmdDB = GENERAL._dbConnection.CreateCommand();
                OleDbDataReader fileClassReader;
                TreeNode nodetmp;
                for (int i = 0; i < 4; i++) //加载每个数据库的大类
                {
                    cmdDB.CommandText = "select  DocID," + title + " from MainFile where ParentID =" + GENERAL.fileClassID[i];
                    fileClassReader = cmdDB.ExecuteReader();
                    
                    while (fileClassReader.Read())
                    {
                        nodetmp = new TreeNode(fileClassReader[1].ToString());
                        nodetmp.Tag = fileClassReader[0].ToString();
                        nodetmp.NodeFont = new Font("Microsoft YaHei", 12); 
                        treeview.Nodes[0].Nodes[i].Nodes.Add(nodetmp);
                    }
                    fileClassReader.Close();
                }
                for (int i = 0; i < 4; i++) //加载年份
                {
                    int nSecs = treeview.Nodes[0].Nodes[i].Nodes.Count;
                    int startIndex = 3;
                    if (i > 0) startIndex = 2;
                    for (int j = startIndex; j < nSecs; j++)
                    {
                        cmdDB.CommandText = "select distinct Year from MainFile where ParentID =" + treeview.Nodes[0].Nodes[i].Nodes[j].Tag.ToString();
                        fileClassReader = cmdDB.ExecuteReader();
                        while (fileClassReader.Read())
                        {
                            nodetmp = new TreeNode(fileClassReader[0].ToString());
                            nodetmp.Tag = treeview.Nodes[0].Nodes[i].Nodes[j].Tag;
                            nodetmp.NodeFont = new Font("Arial", 12);
                            treeview.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(nodetmp);
                        }
                        fileClassReader.Close();
                    }
                }
            }
            catch (Exception err)
            {
                string s = err.Message;
                if(s.IndexOf("provider is not registered") != -1)
                {
                    changeVersion();
                    this.Close();
                }
                MessageBox.Show(err.Message + "\n 请给客服联系：yzlsmlbx@gmail.com");
            }
            finally
            {
                GENERAL._dbConnection.Close();
            }
            this.Cursor = Cursors.Default;
        }

        private void changeVersion()
        {
            FormVersion frmV = new FormVersion();
            frmV.ShowDialog();
            if (GENERAL.verSelect != "")
            {
                try
                {
                    ProcessStartInfo p = new ProcessStartInfo("DBto32bit.exe");
                    p.Arguments = GENERAL.verSelect;
                    Process.Start(p);
                }
                catch(Exception exp)
                {
                    //MessageBox.Show(exp.Message);
                }
            }
            this.Close();
        }

        private void ListTitles(string lang,string year,string parent)
        {
            this.Cursor = Cursors.WaitCursor;
            string title = (lang == "Chinese" ? "Title" : "ETitle");
            this.treeView3.Nodes.Clear() ;
            try
            {
                GENERAL._dbConnection.Open();
                OleDbCommand cmdDB = GENERAL._dbConnection.CreateCommand();
                OleDbDataReader fileClassReader;
                int monthIndex=0,nodeIdx=-1;
                TreeNode tmpNode;
                bool beginMonth = true;
                cmdDB.CommandText = "select DocID ,"+ title + ",Month,Day FROM MainFile WHERE ParentID =" + parent + " and Year =" + year + " ORDER BY Month,Day";
                fileClassReader = cmdDB.ExecuteReader();
                string s;
                while (fileClassReader.Read())
                {
                    while (fileClassReader[2].ToString() != monthIndex.ToString() && monthIndex < 13)
                    {
                        monthIndex++;
                        beginMonth = true;
                    }
                    if(beginMonth)
                    {
                        if (GENERAL.Chinese)
                        {
                            tmpNode = new TreeNode(monthIndex.ToString() + "月");
                            tmpNode.NodeFont = new Font("KaiTi", 12);
                        }
                        else
                            tmpNode = new TreeNode(GENERAL.MONTHS[monthIndex]);
                        
                        this.treeView3.Nodes.Add(tmpNode);
                        beginMonth = false;
                        nodeIdx++;
                    }
                        
                    s = year + "." + monthIndex.ToString() + "." + fileClassReader[3].ToString() + " " + fileClassReader[1].ToString();
                    tmpNode = new TreeNode(s);
                    tmpNode.Tag = fileClassReader[0].ToString();
                    tmpNode.NodeFont = new Font("Microsoft Sans Serif", 11);
                    this.treeView3.Nodes[nodeIdx].Nodes.Add(tmpNode);
                }
                fileClassReader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                GENERAL._dbConnection.Close();
            }
            this.pictureBox1.Hide();
            this.treeView3.Show();
            this.panel2.Hide();
            this.Cursor = Cursors.Default;
        }



        private void Preview(string htmlText)
        {
            this.webBrowser1.DocumentText = htmlText;
            this.pictureBox1.Hide();
            this.treeView3.Hide();
            this.panel2.Show();
        }
       
        private void btnLang_Click(object sender, EventArgs e)
        {
            if(GENERAL.Chinese ==  true) //如果是中文则切换成英文
            {
                GENERAL.Chinese = false ;

                for(int i = 0; i < 4; i++)
                {
                    treeView2.Nodes[0].Nodes[i].Collapse();
                }
                //treeView2.CollapseAll();
                this.webBrowser1.DocumentText = GENERAL.txtAbout;
                this.treeView1.Visible = false;
                this.treeView2.Show();
                btnLang.Text = "中文";
                this.btnAuthor.Text = "By Author";
                this.btnDate.Text = "By Date";
                this.btnIssue.Text = "By Issuer";
                this.btnPlace.Text = "By Location";
                this.btnTitle.Text = "By Title";
                this.btnSubject.Text = "By Subject";
                this.btnFulltext.Text = "By Full-text";

                if (treeView2.Tag.ToString() != "Finished")
                {
                    this.addNodes("English");
                    treeView2.Tag = "Finished";
                }

            }
            else
            {
                GENERAL.Chinese = true;
                this.webBrowser1.DocumentText = GENERAL.txtAbout;
                for (int i = 0; i < 4; i++)
                {
                    treeView1.Nodes[0].Nodes[i].Collapse();
                }
                //treeView1.CollapseAll();
                this.treeView2.Visible=false;
                treeView1.Show();
                btnLang.Text = "English";
                this.btnAuthor.Text = "作者检索";
                this.btnDate.Text = "日期检索";
                this.btnIssue.Text = "发文机构检索";
                this.btnPlace.Text = "地点检索";
                this.btnTitle.Text = "标题检索";
                this.btnSubject.Text = "主题检索";
                this.btnFulltext.Text = "全文检索";
            }
            this.pictureBox1.Visible = false;
            this.treeView3.Hide();
            this.panel2.Hide();
        }

     
       
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                //this.webBrowser1.Navigate("About.html");
                this.Preview(GENERAL.txtAbout);
                return;
            }
                     
         
                string docID = e.Node.Tag.ToString();
                if (docID != "")
                {
                    int i = 0;
                    while (i < 4)
                    {
                        if (docID == GENERAL.fileClassID[i])
                        {
                            this.load_background_image(GENERAL.MvName[i] + "C.jpg");
                            return;
                        }
                        i++;
                    }
                    if (e.Node.Level == 2) 
                    { 
                        string txt = Class1.getFullHTML(docID, "Chinese");
                        this.Preview(txt);
                        
                    }
                    if (e.Node.Level == 3)
                    {
                        this.ListTitles("Chinese", e.Node.Text, e.Node.Tag.ToString ());
                    }
                }
        }

        private void treeView2_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                this.Preview(GENERAL.txtAbout);
                return;
            }

            string docID = e.Node.Tag.ToString();
            if (docID != "")
            {
                int i = 0;
                while (i < 4)
                {
                        if (docID == GENERAL.fileClassID[i])
                        {
                            this.load_background_image(GENERAL.MvName[i] + "E.jpg");
                            return;
                        }
                        i++;
                }
                this.pictureBox1.Visible = false;
                if (e.Node.Level == 2)
                {
                    string txt = Class1.getFullHTML(docID, "English");
                    this.Preview(txt);
                }
                if (e.Node.Level == 3)
                {
                    this.ListTitles("English", e.Node.Text, e.Node.Tag.ToString());
                }
            }
            
        }
        /*
        private string getEContent(TreeNode node)
        {
            string docID = node.Tag.ToString();
            if (node.Level > 0 && node.Level < 3)
            {
                return Class1.GetContents(docID, "English");
            }
            else if (node.Level > 3)
            {
                return Class1.getFullHTML(docID, "Chinese");
            }
            return "";
        }
        */
        private void button3_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text=="English"? "主题检索":"Search By Subject";
            frm.ShowDialog();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "作者检索" : "Search By Author";
            frm.ShowDialog();
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "地点检索" : "Search By Place";
            frm.ShowDialog();

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "发文机构检索" : "Search By Issuer";
            frm.ShowDialog();
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "标题检索" : "Search By Title"; 
            frm.ShowDialog();
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "日期检索" : "Search By Date"; 
            frm.ShowDialog();
        }

     
        private void btnFulltext_Click(object sender, EventArgs e)
        {
            frmIdSearch frm = new frmIdSearch();
            frm.Text = this.btnLang.Text == "English" ? "全文检索" : "Full Text Search";
            frm.ShowDialog();
        }

        private void webBrowser1_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Width = this.webBrowser1.Width;
            this.pictureBox1.Height = this.webBrowser1.Height;
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 0) e.Cancel = true;
        }

        private void treeView2_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 0) e.Cancel = true;
        }

       

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentText = GENERAL.txtAbout;
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.treeView3.Show();
            this.panel2.Hide();
        }

      
        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (this.treeView1.Tag.ToString() != "Finished")
            {
                this.timer1.Start();
            }
            if (GENERAL.returnHome) this.btnHome_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            treeView1.Tag = "Finished";
            this.timer1.Stop();
            this.addNodes("Chinese");
        }

        private void treeView3_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;
            string docID =e.Node.Tag.ToString ();
            if (docID=="") return;
            string htmlText = Class1.getFullHTML(docID, "Chinese");
            this.Preview(htmlText);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd1 = new SaveFileDialog();
            fd1.Filter = "HTML Files(*.html)|*.html | Text Files(*.txt)|*.txt";
            if (fd1.ShowDialog() == DialogResult.OK)
            {
                if (fd1.FileName.EndsWith("txt"))
                {
                    string s = this.webBrowser1.Document.Body.InnerText;
                    //MessageBox.Show(s.Substring(0, 4));
                    if (s.Substring(1,4)=="文章全文")s = s.Substring(7);
                    //MessageBox.Show(s);
                    File.WriteAllText(fd1.FileName, s, Encoding.UTF8);
                }

                else
                    File.WriteAllText(fd1.FileName, this.webBrowser1.DocumentText, Encoding.GetEncoding("GB2312"));
            }
        }

  
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl != null) ctl.BackColor = Color.Red;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl != null) ctl.BackColor = Color.Teal;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintDialog();
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!GENERAL.Chinese)
                this.btnLang_Click(sender, e);
            else
            {
                int num = treeView1.Nodes[0].Nodes.Count;
                for (int i = 0; i < num; i++)
                {
                    treeView1.Nodes[0].Nodes[i].Collapse();
                }
            }
            if (this.WindowState != FormWindowState.Maximized) this.WindowState = FormWindowState.Maximized;
            this.webBrowser1.DocumentText = GENERAL.txtAbout;
            if (treeView3.Visible) treeView3.Hide();
            if (!this.panel2.Visible) this.panel2.Show();
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            GENERAL.formLocation = this.Location;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.splitContainer1.Top = 129;
            this.splitContainer1.Height = this.Height - 170;
            this.panel2.Left = this.Width - 82;
            label1.Width = this.panel1.Width-3;
            this.splitContainer1.Width = this.Width -17;
            GENERAL.formSize = this.Size;
        }

    }
}
