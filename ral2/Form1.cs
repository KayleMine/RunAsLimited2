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
        private string rd_check;
        private bool rd_checks;
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
            rd_check = Api.ReadCfg("third_check");
            rd_checks = (rd_check == "1" || rd_check == "2");

            if (!string.IsNullOrEmpty(rd_check))
            {
                third_check.Checked = rd_checks;
            }

            if  (!string.IsNullOrEmpty(first_launch))
            {
                no_random = true;
            }

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Login.Text = login;
                Password.Text = password;
                Login.Enabled = false;
                Password.Enabled = false;
            }

            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(path_exe))
            {
                PathBox.Text = path + "/" + path_exe;
            }

            if (!string.IsNullOrEmpty(command_line))
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


            if (!string.IsNullOrEmpty(path3) && !string.IsNullOrEmpty(path_exe3) && rd_checks)
            {
                 await rd_app_run();
            }
        }
               

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            DirectoryInfo userProfileDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            string path = Path.Combine(userProfileDirectory.Parent.FullName, login);

            if (!Directory.Exists(path)) { Alert.ShowWarning("Account not exists! \n Run something first..."); return; };

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
            Directory.SetCurrentDirectory(@path3);
            Process launch = new Process();
            launch.StartInfo.FileName = Path.Combine(path3, path_exe3);
            launch.StartInfo.Arguments = cmd3;
            launch.Start();
            await Task.Run(() => launch.WaitForExit());
        }

        private void third_check_CheckedChanged(object sender, EventArgs e)
        {
            CheckState checkState = third_check.CheckState;
            string checkStateValue = ((int)checkState).ToString();
            Api.SaveCfg(new KeyValuePair<string, string>("third_check", checkStateValue));
        }

    }
}


