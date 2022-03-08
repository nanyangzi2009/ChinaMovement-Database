using System;
//using System.Collections.Generic;
using System.Drawing;
//using System.Data;
using System.IO;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chinamovementdb
{
    public partial class frmIdSearch : Form
    {
        
        string sqlCondition = "",sqlCondition1="",sqlCondition2="",firstID ="";
        string searchID="", searchItem="",searchTable="",search2DocTable="";
        bool statusSearch = true;
        bool returnHome = false;
        public frmIdSearch()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GENERAL.Chinese)
                this.pictureBox1.BackgroundImage = Image.FromFile(GENERAL.MvName[comboBox1.SelectedIndex] + "C.jpg");
            else
                this.pictureBox1.BackgroundImage = Image.FromFile(GENERAL.MvName[comboBox1.SelectedIndex] + "E.jpg");
            
            treeView1.Nodes.Clear();
            this.statusSearch = true;
            this.showInstruction();
            this.reset();
            if (this.Text == "日期检索" || this.Text == "Search By Date")
            {
                //this.txtEqualMonth.Text = "1";
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:     this.comboYear.Text = "1949"; 
                        break;
                    case 1:     this.comboYear.Text = "1957";
                        break;
                    case 2:
                        this.comboYear.Text = "1958";
                        break;
                    case 3:
                        this.comboYear.Text = "1966";
                        break;
                }
                this.FillComboYear();
            }
            if (this.Text == "标题检索" || this.Text == "全文检索" || this.Text == "日期检索"
                || this.Text == "Search By Title" || this.Text == "Full Text Search" || this.Text == "Search By Date") return; //标题检索、全文检索和日期检索不需要列出关键字

            this.listSearchItems();
            GENERAL.selectedIndex = this.comboBox1.SelectedIndex;
       }

        private void listSearchItems()
        {
            string dbID = GENERAL.MvID[comboBox1.SelectedIndex].ToString();
            OleDbDataReader reader = null;

            try
            {
                GENERAL._dbConnection.Open();
                OleDbCommand cmdDB = GENERAL._dbConnection.CreateCommand();
                cmdDB.CommandText = "select " + this.searchID + "," + this.searchItem + " from " + this.searchTable + " where MovementID=" + dbID + " ORDER BY " + this.searchItem;
                //MessageBox.Show(cmdDB.CommandText);
                reader = cmdDB.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString().Trim();
                    if (s != "")
                    {
                        TreeNode tmpnode = new TreeNode(s);
                        tmpnode.Tag = reader[0].ToString();
                        treeView1.Nodes.Add(tmpnode);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                GENERAL._dbConnection.Close();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            string conj = (radioAnd.Checked ? " and " : " or ");
            if (this.statusSearch) // 如果是检索状态则把选中的项目填入条件框
            {
                if (!this.textBox2.Visible || firstID=="")
                {
                    textBox1.Text = e.Node.Text;
                    firstID = e.Node.Tag.ToString();
                    sqlCondition1 = this.search2DocTable + "." + this.searchID + "=" + firstID;
                    this.textBox1.Enabled = false;
                    //if (this.Text == "发文机关检索" || this.Text == "Search By Issuer" || this.Text == "地点检索" || this.Text == "Search By Place") treeView1.Enabled = false;
                    
                }
                else
                {
                    sqlCondition2 = this.search2DocTable + "1." + this.searchID + "=" + firstID + conj + this.search2DocTable + "2." + this.searchID + "=" + e.Node.Tag.ToString();
                    textBox2.Text = e.Node.Text;
                    treeView1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.groupBox1.Enabled = false;
                    /*if (textBox1.Text.Trim() == "")
                    {
                        textBox1.Text = e.Node.Text;
                    }
                    else
                        textBox2.Text = e.Node.Text;*/
                }
            }
            else //如果是点击标题，则在右侧显示文章内容
            {
                if (e.Node.Tag != null)
                {
                    string docID = e.Node.Tag.ToString();
                    if (docID != "")
                    {
                        string txt = Class1.getFullHTML(docID, "Chinese");
                        if (txt != "")
                        {
                            this.Preview(txt);
                        }
                    }
                }
            }
            
         
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
                    if (s.Substring(1, 4) == "文章全文") s = s.Substring(7);
                    //MessageBox.Show(s);
                    File.WriteAllText(fd1.FileName, s, Encoding.UTF8);
                }

                else
                    File.WriteAllText(fd1.FileName, this.webBrowser1.DocumentText, Encoding.GetEncoding("GB2312"));
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintDialog();
        }

        private void Preview(string htmlText)
        {
            string txt = htmlText;
           if (this.Text == "全文检索" || this.Text=="Full Text Search")
            {
                txt = HighlightHTML(txt, this.textBox1.Text);
                string s = this.textBox2.Text.ToString().Trim();
                if(s!="") txt = HighlightHTML(txt, s);
            }
            
            this.webBrowser1.DocumentText = txt;
            this.btnDownload.Show();
            this.btnPrint.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl != null) ctl.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl != null) ctl.BackColor = Color.Teal;
        }

  
        private string HighlightHTML(string htmlText, string words)
        {
            string replace = "<span style=\"background-color:yellow\">"+ words + "</span>";
            return htmlText.Replace(words, replace);
        }
      
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            if (!this.statusSearch)
            {
                this.comboBox1_SelectedIndexChanged(sender, e);
            }
            else
                reset();
        }
        private void reset()
        {
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox2.Text = "";
            textBox2.Enabled = true;
            this.firstID = "";
            this.groupBox1.Enabled = true;
            if (!treeView1.Enabled) treeView1.Enabled = true;
            sqlCondition = "";
            sqlCondition1 = "";
            sqlCondition2 = "";
            this.button1.Enabled = true;
        }

        private void frmIdSearch_Activated(object sender, EventArgs e)
        {
            //this.Ydif = this.Height - splitContainer1.Height;
            //this.Xdif = this.Width - splitContainer1.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                if (GENERAL.Chinese)
                    MessageBox.Show("请首先选定数据库!");
                else
                    MessageBox.Show("PLease select a database first!");
                return;
            }
            if (!this.panel2.Visible && this.textBox1.Text.Trim() == "")
            {
                if (GENERAL.Chinese)
                    MessageBox.Show("请选定查询关键字!");
                else
                    MessageBox.Show("PLease select a key word to search!");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            OleDbDataReader reader;
            int recNumber = 0;
            try
            {
                GENERAL._dbConnection.Open();
                string titleName = GENERAL.Chinese ? "Title" : "ETitle";
                string relation = radioAnd.Checked ? " AND " : " OR ";
                string contentName = GENERAL.Chinese ? "Contents" : "EContents";
                OleDbCommand cmdDB = GENERAL._dbConnection.CreateCommand();
                if (this.Text == "发文机构检索" || this.Text == "Search By Issuer" || this.Text == "地点检索" || this.Text == "Search By Place")
                {
                    if(this.sqlCondition1 == "")
                    {
                        if (!this.checkList(textBox1.Text.Trim(), true))
                        {
                            GENERAL._dbConnection.Close();
                            string s = GENERAL.Chinese ? "您输入的" + this.lblsearchItem.Text + "没有在库中,请重新输入或者选择。" : "The " + this.lblsearchItem.Text + " is not in the list, please input again or select fromt the list.";
                            MessageBox.Show(s);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    cmdDB.CommandText = "select DocID, "+ titleName +", Year,Month,Day from MainFile where MovementID=" + GENERAL.MvID[comboBox1.SelectedIndex].ToString() + " and DocID in (SELECT DocID from "+this.search2DocTable +" WHERE " + this.sqlCondition1 + ")";
                }
                else if (this.Text == "标题检索" || this.Text == "Search By Title")
                {
                    cmdDB.CommandText = "select DocID, "+ titleName + ", Year,Month,Day from MainFile where MovementID=" + GENERAL.MvID[comboBox1.SelectedIndex].ToString()+ " and ("+ titleName +" like '%" + textBox1.Text.Trim() + "%'" ;
                    if (this.textBox2.Text.Trim() != "") cmdDB.CommandText += relation + titleName + " like '%" + textBox2.Text.Trim() + "%')";
                    else cmdDB.CommandText += ")";
                }
                else if(this.Text == "全文检索" || this.Text == "Full Text Search")
                {
                    cmdDB.CommandText = "SELECT MainFile.DocID," + titleName +", Year,Month,Day FROM MainFile INNER JOIN MainFile1 ON MainFile.DocID=MainFile1.DocID where MainFile1.MovementID=" + GENERAL.MvID[comboBox1.SelectedIndex].ToString() + " and (MainFile1."+contentName +" like '%" + textBox1.Text.Trim() + "%'";
                    if (this.textBox2.Text.Trim() != "") cmdDB.CommandText += relation + "MainFile1." +contentName + " like '%" + textBox2.Text.Trim() + "%')";
                    else cmdDB.CommandText += ")";
                }
                else if (this.Text == "日期检索" || this.Text == "Search By Date")
                {
                   if (!CheckDate())
                    {
                        GENERAL._dbConnection.Close();
                        if (GENERAL.Chinese) MessageBox.Show("年份不能为空，月日可以同时为空，日期也可单独为空。年月日不能超出正常范围。", "日期查询错误！");
                        else MessageBox.Show("Year could not be empty; Month and Day can be both empty; Day can be empty alone.  Year,Month and Day can not be out of normal range.", "Error in Specific Date Research!");
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    
                    string sEqual="";
                    
                        sEqual = "(Year=" + comboYear.Text + ")";
                        if (this.comboMonth.Text.Trim()!="")
                        {
                            sEqual += " and (Month=" + this.comboMonth.Text + ")";
                        }
                        if (this.txtEqualDay.Text.Trim() != "")
                        {
                            sEqual += " and (Day=" + this.txtEqualDay.Text + ")";
                        }
                        sqlCondition = sEqual;
                    
                    if(GENERAL.Chinese)
                        cmdDB.CommandText = "select DocID, Title, Year,Month,Day from MainFile where MovementID=" + GENERAL.MvID[comboBox1.SelectedIndex].ToString() + " and (" + sqlCondition + ")";
                    else
                        cmdDB.CommandText = "select DocID, ETitle, Year,Month,Day from MainFile where MovementID=" + GENERAL.MvID[comboBox1.SelectedIndex].ToString() + " and (" + sqlCondition + ")";
                }// finished research by Date
                else //包括主题检索、作者检索
                {
                    
                        if(!this.checkList(textBox1.Text.Trim(),true))
                        {
                            GENERAL._dbConnection.Close();
                            string s = GENERAL.Chinese ? "您输入的第一个"+ this.lblsearchItem.Text  +"没有在库中,请重新输入或者选择。" : "The first " + this.lblsearchItem.Text + " is not in the list, please input again or select from the list.";
                            MessageBox.Show(s);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    
                    if (textBox2.Text.Trim()!="" )
                    {
                        if (!this.checkList(textBox2.Text.Trim(),false))
                        {
                            GENERAL._dbConnection.Close();
                            string s = GENERAL.Chinese ? "您输入的第二个" + this.lblsearchItem.Text + "没有在库中,请重新输入或者选择。" : "The Second " + this.lblsearchItem.Text + " is not in the list, please input again or select from the list.";
                            MessageBox.Show(s);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    string sT = this.search2DocTable;
                    string sT1 = sT + "1", sT2 = sT + "2";
                    string sqlText = "select MainFile.DocID, MainFile.ETitle, MainFile.Year,MainFile.Month,MainFile.Day from MainFile where MainFile.MovementID=";
                    if (GENERAL.Chinese) sqlText = "select MainFile.DocID, MainFile.Title , MainFile.Year,MainFile.Month,MainFile.Day from MainFile where MainFile.MovementID=";
                    sqlText += GENERAL.MvID[comboBox1.SelectedIndex].ToString() + " and MainFile.DocID in (SELECT ";

                    if (this.textBox2.Text .Trim ()== "") //只有一个条件
                        sqlText += "DocID from " + sT + " WHERE " + this.sqlCondition1 + ")";
                    else //两个条件
                    {
                        sqlText += sT1 + ".DocID from " + sT + " AS " + sT1 + " INNER JOIN " + sT + " AS " + sT2 + " ON " + sT1 + ".DocID=" + sT2 + ".DocID WHERE(" + sqlCondition2 + "))";
                    }

                    cmdDB.CommandText = sqlText;
                }
                //this.textBox1.Enabled = false;
                //this.textBox2.Enabled = false; 
                cmdDB.CommandText += " ORDER BY Year,Month,Day";
                //MessageBox.Show(cmdDB.CommandText);
                reader = cmdDB.ExecuteReader();
                
                while (reader.Read())
                {
                    if (recNumber == 0)
                    {
                        treeView1.Nodes.Clear();
                        this.statusSearch=false;
                    }
                    
                    if (reader[1].ToString().Trim() != "")
                    {
                        string month = reader[3].ToString();
                        if (month.Length == 1) month = "0" + month;
                        string day = reader[4].ToString();
                        if (day.Length == 1) day = "0" + day;
                        string s = reader[2].ToString() + "." + month +"."+ day+"  "+ reader[1].ToString().Trim();
                        TreeNode tmpnode = new TreeNode(s);
                        tmpnode.Tag = reader[0].ToString();
                        treeView1.Nodes.Add(tmpnode);
                        recNumber++;
                    }
                }
                if (recNumber > 0)
                {
                    reader.Close();
                    if (GENERAL.Chinese)
                        this.webBrowser1.DocumentText = string.Format("找到{0}篇符合条件的文章！", recNumber);
                    else
                        this.webBrowser1.DocumentText = string.Format("Found {0} articles qualified！", recNumber);
                }
                else
                {
                    if(GENERAL.Chinese)
                        this.webBrowser1.DocumentText = "没有找到符合条件的文章！";
                    else
                        this.webBrowser1.DocumentText = "No qualified articles found！";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                GENERAL._dbConnection.Close();
            }
            if (!treeView1.Enabled) treeView1.Enabled = true;
            this.Cursor = Cursors.Default;
            this.btnPrint.Hide();
            this.btnDownload.Hide();
            if (this.Text == "发文机构检索" || this.Text == "Search By Issuer" || this.Text == "地点检索" || this.Text == "Search By Place" || this.Text == "主题检索" || this.Text == "Search By Subject" || this.Text == "作者检索" || this.Text == "Search By Author")
                this.button1.Enabled = false;
        }
        void FillComboYear()
        {
            this.Cursor = Cursors.WaitCursor;
            GENERAL._dbConnection.Open();
            OleDbCommand cmdDB = GENERAL._dbConnection.CreateCommand();
            cmdDB.CommandText = "select distinct Year from MainFile where MovementID =" + GENERAL.MvID[comboBox1.SelectedIndex].ToString();
            OleDbDataReader yearReader = cmdDB.ExecuteReader();
            this.comboYear.Items.Clear();
            while (yearReader.Read())
            {
                this.comboYear.Items.Add(yearReader[0].ToString());
            }
            yearReader.Close();
            GENERAL._dbConnection.Close();
            this.Cursor = Cursors.Default;
         }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.returnHome = true;
            this.Close();
        }

        private void frmIdSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            GENERAL.returnHome = this.returnHome;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0 || this.statusSearch)
            {
                if (GENERAL.Chinese)
                    MessageBox.Show("请在查询结果出来后再使用本功能。"); 
                else
                    MessageBox.Show("Please download the list after the result has been turned out.");
                return;
            }
            SaveFileDialog fd1 = new SaveFileDialog();
            fd1.Filter = "Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv";
            if (fd1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                
                    
                
                if (fd1.FileName.EndsWith("txt"))
                {
                    sb.Append(this.Text + "\n");
                    sb.Append(this.comboBox1.SelectedItem.ToString() + "\n");
                    if (this.Text == "日期检索" || this.Text == "Search By Date")
                    {
                        sb.Append(this.lblYear3.Text+":"+ this.comboYear.Text + ";");
                        sb.Append(this.lblMonth3.Text + ":" + this.comboMonth.Text + ";");
                        sb.Append(this.lblDay3.Text + ":" + this.txtEqualDay.Text + "\n");
                    }
                    else
                    {
                        sb.Append(this.lblsearchItem.Text + ":" + this.textBox1.Text);
                        if(this.textBox2.Text.Trim ()!="")
                        {
                            if (radioAnd.Checked)
                            {
                                if (GENERAL.Chinese) sb.Append(" 以及 ");
                                else sb.Append(" AND ");
                            }
                            else
                            {
                                if (GENERAL.Chinese) sb.Append(" 或者 ");
                                else sb.Append(" OR ");
                            }
                            sb.Append(this.textBox2.Text + "\n");
                        }
                    }
                }
                int num = treeView1.Nodes.Count;
                for (int i = 0; i < num; i++)
                {
                    string s = this.treeView1.Nodes[i].Text;
                    sb.Append(s.Substring(0,10)+","+s.Substring(12) + "\n");
                }
                File.WriteAllText(fd1.FileName,sb.ToString(), Encoding.UTF8);
                
            }
        }

        private bool checkList(string text, bool bFirstItem)
        {
            int num = this.treeView1.Nodes.Count;
            string conj = radioAnd.Checked ? " AND " : " OR ";
            for(int i=0; i<num; i++)
            {
                if (treeView1.Nodes[i].Text == text)
                {
                    if(bFirstItem)
                    {
                        this.firstID = treeView1.Nodes[i].Tag.ToString();
                        this.sqlCondition1 = this.search2DocTable + "." + this.searchID + "=" + this.firstID;
                    }
                     else
                        this.sqlCondition2 = this.search2DocTable + "1." + this.searchID + "=" + this.firstID + conj + this.search2DocTable + "2." + this.searchID + "=" + treeView1.Nodes[i].Tag.ToString();
                    return true; 
                }
            }
            return false;
        }
        private bool CheckDate()
        {
            int thisYear = System.DateTime.Now.Year;
            int equalYear, equalMonth, equalDay;
            
                string txtDay = txtEqualDay.Text.Trim();
                string txtMonth = comboMonth.Text.Trim();
                string txtYear = comboYear.Text.Trim();
                if (txtYear == "") return false;
                try
                    {
                        equalYear = Convert.ToInt32(txtYear);
                    }
                catch (Exception exp)
                    {
                        return false;
                    }
                if (equalYear < 1900 || equalYear > thisYear) return false;
                
                if (txtMonth == "" && txtDay != "") return false;
                if (txtMonth == "" && txtDay == "") return true;
                try
                {
                    equalMonth = Convert.ToInt32(txtMonth);
                }
                catch (Exception exp)
                {
                    return false;
                }
                if (equalMonth > 12 || equalMonth < 1) return false;

                if( txtDay == "") return true;
                try
                    {
                        equalDay = Convert.ToInt32(txtEqualDay.Text);
                    }
                catch (Exception exp)
                    {
                        return false;
                    }
                if (equalDay > 31 || equalDay < 1) return false;
                return true;
           
        }

        private void showItme2()
        {
            this.textBox2.Show();
            this.groupBox1.Show();
        }

        private void showInstruction()
        {
            this.webBrowser1.DocumentText =File.ReadAllText("SearchInstruction.html");
        }
        private void frmIdSearch_Load(object sender, EventArgs e)
        {
            this.Size = GENERAL.formSize;
            this.Location = GENERAL.formLocation;
            this.splitContainer1.Top = this.panel1.Height + 6;
            this.splitContainer1.Width = this.Width - 20;
            this.splitContainer1.Height = this.Height - 220;


            if (GENERAL.Chinese)
            {
                for (int i = 0; i < 4; i++)
                {
                    this.comboBox1.Items.Add(GENERAL.chNodeHead[i]);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    this.comboBox1.Items.Add(GENERAL.enNodeHead[i]);
                }
            }
            
            switch (this.Text)
            {
                case "主题检索":
                    this.searchID = "SubID";
                    this.searchItem = "Subject";
                    this.searchTable = "Subjects";
                    this.search2DocTable = "Sub2doc";
                    this.lblsearchItem.Text = "主题词";
                    this.showItme2();
                    break;
                case "作者检索":
                    this.searchID = "AuthorID";
                    this.searchItem = "Author";
                    this.searchTable = "Authors";
                    this.search2DocTable = "Auth2doc";
                    this.lblsearchItem.Text = "作者";
                    this.showItme2();
                    break;
                case "地点检索":
                    this.searchID = "PlaceID";
                    this.searchItem = "Place";
                    this.searchTable = "Places";
                    this.search2DocTable = "Place2doc";
                    this.lblsearchItem.Text = "地点";
                    this.textBox1.Enabled = false;
                    break;
                case "发文机构检索":
                    this.searchID = "IssuerID";
                    this.searchItem = "Issuer";
                    this.searchTable = "Issuers";
                    this.search2DocTable = "Iss2doc";
                    this.lblsearchItem.Text = "发文机构";
                    this.textBox1.Enabled = false;
                    this.textBox1.Width = this.comboBox1.Width;
                    break;
                case "标题检索":
                    this.lblsearchItem.Text = "标题包含:";
                    this.searchItem = "Title";
                    this.showItme2();
                    break;
                case "日期检索":
                    this.lblsearchItem.Text = "日期:";
                    //this.textBox1.Visible = false;
                    this.panel2.Visible = true;
                    //this.radioAnd.Checked = true;
                    break;
                case "全文检索":
                    this.lblsearchItem.Text = "文章包含:";
                    this.searchItem = "Contents";
                    this.showItme2();
                    break;
                case "Search By Subject":
                    this.searchID = "SubID";
                    this.searchItem = "ESubject";
                    this.searchTable = "Subjects";
                    this.search2DocTable = "Sub2doc";
                    this.lblsearchItem.Text = "Sujects";
                    this.showItme2();
                    break;
                case "Search By Author":
                    this.searchID = "AuthorID";
                    this.searchItem = "EAuthor";
                    this.searchTable = "Authors";
                    this.search2DocTable = "Auth2doc";
                    this.lblsearchItem.Text = "Authors";
                    this.showItme2();
                    break;
                case "Search By Place":
                    this.searchID = "PlaceID";
                    this.searchItem = "EPlace";
                    this.searchTable = "Places";
                    this.search2DocTable = "Place2doc";
                    this.lblsearchItem.Text = "Location";
                    this.textBox1.Enabled = false;
                    break;
                case "Search By Issuer":
                    this.searchID = "IssuerID";
                    this.searchItem = "EIssuer";
                    this.searchTable = "Issuers";
                    this.search2DocTable = "Iss2doc";
                    this.lblsearchItem.Text = "Issuer";
                    this.textBox1.Width = this.comboBox1.Width;
                    this.textBox1.Enabled = false;
                    break;
                case "Search By Title":
                    this.lblsearchItem.Text = "Title Includes:";
                    this.searchItem = "ETitle";
                    this.showItme2();
                    break;
                case "Search By Date":
                    this.lblsearchItem.Text = "Date:";
                    //this.textBox1.Visible = false;
                    this.panel2.Visible = true;
                    break;
                case "Full Text Search":
                    this.lblsearchItem.Text = "Article Includes:";
                    this.searchItem = "EContents";
                    this.showItme2();
                    break;
            }
            if (!GENERAL.Chinese)
            {
                this.lblSelectDatabase.Text = "Select a database:";
                this.lblDay3.Text = "Day";
                this.lblMonth3.Text = "Month";
                this.lblYear3.Text = "Year";
                this.btnClear.Text = "Clear";
                this.button1.Text = "Search";
                //this.groupBox1.Text = "Relation";
                this.radioAnd.Text = "AND";
                this.radioOr.Text = "OR";
               
                if(this.Text =="Search By Date")
                {
                    int move = 30;
                    this.txtEqualDay.Left += move;
                    this.comboMonth.Left += move;
                    this.comboYear.Left += move;
                     this.lblYear3.Left = this.comboYear.Left - lblYear3.Width - 2;
                    this.lblMonth3.Left = this.comboMonth.Left - lblMonth3.Width - 1;
                    this.lblDay3.Left = this.txtEqualDay.Left - lblDay3.Width - 2;
                }
            }
            comboBox1.SelectedIndex = GENERAL.selectedIndex;
        }

       
        private void frmSubject_Resize(object sender, EventArgs e)
        {
            this.splitContainer1.Top = this.panel1.Height + 6;
            this.splitContainer1.Width = this.Width - 20;
            this.splitContainer1.Height = this.Height - 220;
            if (this.Width > 918)
                this.pictureBox1.Left = 720 + (this.Width - 918) / 2;
            else
                this.pictureBox1.Left = 720;
        }
    }
}
