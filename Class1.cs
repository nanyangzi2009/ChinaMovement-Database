using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Drawing;

namespace chinamovementdb
{
    public static class GENERAL
    {
        public static OleDbConnection _dbConnection;
        
        public static string[] chNodeHead = { "中国五十年代初中期的政治运动数据库：从土地改革到公私合营，1949-1956", "中国反右运动数据库，1957-", "中国大跃进-大饥荒数据库, 1958-1962", "中国文化大革命文库" };
        public static int[] MvID = { 6, 3, 4, 1 };
        public static string[] fileClassID = { "114012", "97306", "107619", "2" };
        public static string[] MvName = {"CPC50S","ARCD","GLF","CCRD" };
        public static string[] enNodeHead = { 
            "Database of the Chinese Political Campaigns in the 1950s, 1949-1956",
            "Chinese Anti-Rightist Campaign Database, 1957 -",
            "Chinese Great Leap Forward and Great Famine Database,1958-1962",
            "Chinese Cultural Revolution Database" };
        public static bool Chinese = true;
        public static string txtAbout;
        public static string[] MONTHS = {"No month", "January", "February", "March", "April","May","June","July","August","September","October","November","December" };
        public static int selectedIndex = 0;
        public static Point formLocation;
        public static Size formSize;
        public static bool returnHome = false;
        public static string verSelect = "";
    }
    public static class Class1
    {
        public static string htmlHeader;
        public static SortedList<int, string> htmlStyles;
        public static string exeFilepath = System.IO.Directory.GetCurrentDirectory();

        public static void InitDatabase()
        {
            string _connString;
            string _mdbFilepath = exeFilepath + "\\20211231.dat";
            string pass = Class1.GetMD5Hash(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            pass = pass.Substring(0, 20);
            //MessageBox.Show(pass); 
            _connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _mdbFilepath + ";User Id=admin;Jet OLEDB:Encrypt Database=True;Jet OLEDB:Database Password =" + pass;
            GENERAL._dbConnection = new OleDbConnection(_connString);
        }

        public static void InitApp()
        {
            
            htmlHeader = File.ReadAllText(exeFilepath + "\\htmlheader.txt");
            GENERAL.txtAbout = File.ReadAllText(exeFilepath + "\\About.html");
            Class1.htmlStyles = new SortedList<int, string>();
            Class1.htmlStyles.Add(0, "titleR");
            Class1.htmlStyles.Add(1, "titleB");
            Class1.htmlStyles.Add(2, "titleN");
            Class1.htmlStyles.Add(3, "headingRB");
            Class1.htmlStyles.Add(4, "contents");
            Class1.htmlStyles.Add(5, "contents_C");
            Class1.htmlStyles.Add(7, "titles");
            Class1.htmlStyles.Add(8, "headingB");
            Class1.htmlStyles.Add(9, "headingN");
            Class1.htmlStyles.Add(10, "inscriberR");
            InitDatabase();
        }

        public static string GetMD5Hash(string _strHash)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(_strHash);
            byte[] encoded = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; ++i)
            {
                sb.Append(encoded[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GetContents(string fileID, string lang)
        {
            string text = "";
            string content = (lang == "English" ? "EContents" : "Contents");
            OleDbCommand cmd = GENERAL._dbConnection.CreateCommand();
            OleDbDataReader reader = null;
            cmd.CommandText = "select " + content + " from MainFile where DocID =" + fileID;
            StringBuilder sBuilder = new StringBuilder();
            Encoding chs = Encoding.GetEncoding(936);
            try
            {
                GENERAL._dbConnection.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    long length = reader.GetBytes(0, 0, null, 0, 0);
                    byte[] bytes = new byte[length];
                    reader.GetBytes(0, 0, bytes, 0, (int)length);
                    text = chs.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"reading err:"+lang);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (GENERAL._dbConnection.State != ConnectionState.Closed)
                    GENERAL._dbConnection.Close();
            }
            return text;
        }
        private static int leadingSpaces(string stringLine)
        {
            int count = 0;
            if (stringLine != string.Empty)
            {
                while (stringLine[count] == ' ')
                    count++;
            }
            return count;
        }
        public static string GetHTMLfromContent(string text ,string docID)
        {
            StringBuilder builder = new StringBuilder(Class1.htmlHeader);
            StringReader sreader = new StringReader(text);
            string line = string.Empty, contents = string.Empty, cssClass = string.Empty;
            string inscrStart = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: " +
                "collapse\" bordercolor=\"#111111\" width=\"100%\"><tr><td width=\"100%\" nowrap>&nbsp;</td>" +
                "<td nowrap class=\"inscriberR\">";
            string inscrEnd = "</td></tr></table>";
            string inscriber = string.Empty;
            int lineNo = 0, spaces = 0;
            bool found = false;
            while ((line = sreader.ReadLine()) != null)
            {
                if (line.Length > 13)
                {
                    if (line.Substring(0, 12).Trim().ToLower().StartsWith("<html><head>") ||
                        line.Substring(0, 14).Trim().ToLower().StartsWith("</body></html>"))
                        continue;
                }
                contents = line.Trim();
                if (found)
                {
                    if (contents != string.Empty)
                    {
                        spaces = leadingSpaces(line);
                        if (htmlStyles.ContainsKey(spaces))
                            cssClass = htmlStyles[spaces];
                        else
                            cssClass = "contents";
                        if (spaces == 10)
                        {
                            inscriber += (inscriber == string.Empty) ? contents : "<br>" + contents;  //下款
                            continue;
                        }
                        contents = "<p class=\"" + cssClass + "\">" + contents + "</p>";
                    }
                    else
                        contents = "<br>";
                    if (inscriber != string.Empty)
                    {
                        contents = inscrStart + inscriber + inscrEnd + contents;
                        inscriber = string.Empty;
                    }
                    builder.Append(contents);
                }
                else
                {
                    if (lineNo < 9 && lineNo > 0 && contents == string.Empty)
                    {
                        builder.Append("</p><br>");
                        found = true;
                    }
                    else
                    {
                        if (contents != string.Empty)
                        {
                            builder.Append(contents + "<br>");
                            if (lineNo == 9)
                            {
                                builder.Append("</p><br>");
                                found = true;
                            }
                        }
                    }
                }
                lineNo++;
            }
            if (inscriber != string.Empty)
            {
                builder.Append(inscrStart + inscriber + inscrEnd);
            }
            string source = getSource(docID);
           if (source != "") builder.Append(source);
            builder.Append("&nbsp;<br />&nbsp;</body></html>");
            return builder.ToString();
        }// end getHTMLfromContent

        public static string getFullHTML(string DocID, string lang)
        {
            string content = GetContents(DocID, lang);
            content = GetHTMLfromContent(content,DocID);
            return content;
        }
        public static string getSource(string fileID)
        {
            OleDbCommand cmd = GENERAL._dbConnection.CreateCommand();
            OleDbDataReader reader = null;
            cmd.CommandText = "SELECT Sources.Source FROM Sources INNER JOIN Sour2Doc ON Sources.SourceID=Sour2Doc.SourceID WHERE Sour2Doc.DocID =" + fileID;
            string text="";
            int num = 0;
            try
            {
                GENERAL._dbConnection.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    if (num == 0) text += "<br/>";
                    text += "<p class=\"contents\">来源：" + reader[0].ToString() + "。</p>";
                    num++;
                }
                if (num > 1) text += string.Format("<p>共 {0} 条来源。</p>",num);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (GENERAL._dbConnection.State != ConnectionState.Closed)
                    GENERAL._dbConnection.Close();
            }
            return text;
        }//end getSource
    }//end class1
}
