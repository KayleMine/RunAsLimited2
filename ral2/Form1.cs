using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Vip.Notification;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ral2
{ 
    public partial class Main : Form
    {
        RunAsLibrary.Api Api = new RunAsLibrary.Api();

        private string path;
        private string path_exe;
        private string login;
        private string password;
        private string command_line;
        private string first_launch;
        private string delay;
        private string path3;
        private string path_exe3;
        private string cmd3;
        private bool no_random;
      
        private void Sync()
        {
            path = Api.ReadCfg("path");
            path_exe = Api.ReadCfg("path_exe");
            login = Api.ReadCfg("Login");
            password = Api.ReadCfg("Password");
            command_line = Api.ReadCfg("command_line");
            first_launch = Api.ReadCfg("first_launch");
            delay = Api.ReadCfg("delay_3rd");
            path3 = Api.ReadCfg("path_3rd");
            path_exe3 = Api.ReadCfg("path_exe_3rd");
            cmd3 = Api.ReadCfg("command_line_3rd");

            if (first_launch != null && first_launch.Length > 0 )
            {
                no_random = true;
            }

            if (login != null && login.Length > 0 && password != null && password.Length > 0)
            {
                Login.Text = login;
                Password.Text = password;
                Login.Enabled = false;
                Password.Enabled = false;
            }

            if (path != null && path.Length > 0 && path_exe != null && path_exe.Length > 0)
            {
                PathBox.Text = path + "/" + path_exe;
            }

            if (command_line != null && command_line.Length > 0)
            {
                Command_Line.Text = command_line;
            }
        }
        public Main()
        {
            InitializeComponent();
            Sync();
            if (!no_random) 
            { 
                random_acc();
            }
        }
        private static Random randoms = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randoms.Next(s.Length)]).ToArray());
        }
        private void random_acc()
        {   
                var account = RandomString(5);
                var pwd = RandomString(8);

                Api.Create(account, pwd);
                Login.Enabled = false;
                Password.Enabled = false;
                Api.SaveCfg(
                new KeyValuePair<string, string>("Login", account),
                new KeyValuePair<string, string>("Password", pwd),
                new KeyValuePair<string, string>("first_launch", "false")
                );
                Sync();
        }

        private void Empty()
        {
            Alert.ShowWarning("Field can't be empty!");
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Login.Text))
            {
                Empty();
                return;
            }

            if (Login.Text.Length == 0 || Password.Text.Length == 0)
            {
                Empty();
                return;
            }

            Api.Create(Login.Text, Password.Text);
            Login.Enabled = false;
            Password.Enabled = false;
            Api.SaveCfg(
            new KeyValuePair<string, string>("Login", Login.Text),
            new KeyValuePair<string, string>("Password", Password.Text)
            );
            Sync();
        }

        private void Remove_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(login))
            {
                Empty();
                return;
            }

            if (login.Length == 0)
            {
                Empty();
                return;
            }
          
            Api.Remove(login);
            Login.Text = "";
            Password.Text = "";
            Login.Enabled = true;
            Password.Enabled = true;
            Api.SaveCfg(
            new KeyValuePair<string, string>("Login", null),
            new KeyValuePair<string, string>("Password", null)
            );
            Sync();
        }

        private void Select_App_Click(object sender, EventArgs e)
        {
            path = Api.Get_FolderPath();
            path_exe = Api.Get_Exe();

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path_exe))
            {
                return;
            }

            Api.SaveCfg(
            new KeyValuePair<string, string>("path", path),
            new KeyValuePair<string, string>("path_exe", path_exe)
            );
            Sync();
        }

        private async void Run_Click(object sender, EventArgs e)
        {
            Api.SaveCfg(
            new KeyValuePair<string, string>("command_line", Command_Line.Text)
            );
            Sync();
            if (!Directory.Exists(path)) { Alert.ShowError("Something wrong with path!"); return; }
            if (!File.Exists(path + "/" + path_exe)) { Alert.ShowError("Something wrong with file!"); return; }
            Alert.ShowSucess("App started!");
            Api.run_target(path, path_exe, login, password, command_line);
         
            if (!string.IsNullOrEmpty(path3) && !string.IsNullOrEmpty(path_exe3))
            {
                await rd_app_run();
            }
        }


        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\" + login;

            if (!Directory.Exists(path)) { Alert.ShowWarning("Acoount not exists! \n Run something first..."); return; };

            Process.Start("explorer.exe", path);
        }

        private void rd_Party_Click(object sender, EventArgs e)
        {
            Third_Party open_cfg = new Third_Party();
            open_cfg.ShowDialog();
        }

        private async Task rd_app_run()
        {
            int delayMilliseconds = 0;

            if (!string.IsNullOrEmpty(delay) && int.TryParse(delay, out int parsedDelay))
            {
                delayMilliseconds = parsedDelay;
            }

            await Task.Delay(delayMilliseconds);
            await async_call();
        }
        private async Task async_call()
        {
            Process launch = new Process();
            launch.StartInfo.FileName = Path.Combine(path3, path_exe3);
            launch.StartInfo.Arguments = cmd3;
            launch.Start();
            await Task.Run(() => launch.WaitForExit());
        }
    }
}


