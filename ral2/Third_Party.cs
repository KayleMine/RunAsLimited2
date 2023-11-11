using RunAsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ral2
{
    public partial class Third_Party : Form
    {
        public Third_Party()
        {
            InitializeComponent();
            Sync();
        }
        RunAsLibrary.Api Api = new RunAsLibrary.Api();

        private string path3;
        private string path_exe3;
        private string cmd3;
        private string delay3;

        private void Sync()
        {
            path3 = Api.ReadCfg("path_3rd");
            path_exe3 = Api.ReadCfg("path_exe_3rd");
            cmd3 = Api.ReadCfg("command_line_3rd");
            delay3 = Api.ReadCfg("delay_3rd");

 
            if (path3 != null && path3.Length > 0 && path_exe3 != null && path_exe3.Length > 0)
            {
                path3_box.Text = path3 + "/" + path_exe3;
            }

            if (cmd3 != null && cmd3.Length > 0)
            {
                cmd3_box.Text = cmd3;
            }

            if (delay3 != null && delay3.Length > 0)
            {
                delay.Text = delay3;
            }


        }

        private void select_path_Click(object sender, EventArgs e)
        {
            path3 = Api.Get_FolderPath();
            path_exe3 = Api.Get_Exe();

            if (string.IsNullOrEmpty(path3) || string.IsNullOrEmpty(path_exe3))
            {
                return;
            }

            if (path3.Length == 0 || path_exe3.Length == 0)
            {
                return;
            }

            Api.SaveCfg(
            new KeyValuePair<string, string>("path_3rd", path3),
            new KeyValuePair<string, string>("path_exe_3rd", path_exe3),
            new KeyValuePair<string, string>("command_line_3rd", cmd3_box.Text),
            new KeyValuePair<string, string>("delay_3rd", delay.Text)
            );
            Sync();
        }

        private void save_cfg_Click(object sender, EventArgs e)
        {
            Api.SaveCfg(
            new KeyValuePair<string, string>("command_line_3rd", cmd3_box.Text),
            new KeyValuePair<string, string>("delay_3rd", delay.Text)
            );
            Sync();
        }
    }
}
