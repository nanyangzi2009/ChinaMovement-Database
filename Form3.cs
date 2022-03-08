using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chinamovementdb
{
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            if (GENERAL.Chinese)
            {
                label1.Text = "您没有安装Access数据库引擎，请在关闭本软件后双击运行安装包里的AccessDatabaseEngine.exe,安装完毕后重新启动本软件。如果安装后仍然出现本提示，也许您需要更换位32位程序。您也可以更换为64bit应用程序或者恢复先前版本。";
                btn32.Text = "换32位";
                btn64.Text = "换64位";
                btnRestore.Text = "恢复旧版本";
                
            }
            else
                label1.Text = "Please double click the AccessDatabaseEngine.exe in the installation package. If this prompt still appears, perhaps you need to change to 32 bit program. You can also change to 64 bit or to restore the previous version.";
            btn32.Focus();
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            GENERAL.verSelect = "chinamovementdb 32";
            this.Close();
        }

        private void btn64_Click(object sender, EventArgs e)
        {
            GENERAL.verSelect = "chinamovementdb 64";
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            GENERAL.verSelect = "chinamovementdb restore";
            this.Close();
        }
    }
}
