using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace ral2
{ 
    public partial class Main : Form
    {
        RunAsLibrary.Api Api = new RunAsLibrary.Api();

        public string path;
        public string path_exe;
        public string login;
        public string password;
        public string command_line;
        public string first_launch;
        public bool no_random;
      
        private void Sync()
        {
            path = Api.ReadCfg("path");
            path_exe = Api.ReadCfg("path_exe");
            login = Api.ReadCfg("Login");
            password = Api.ReadCfg("Password");
            command_line = Api.ReadCfg("command_line");
            first_launch = Api.ReadCfg("first_launch");
           
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
                PathBox.Text = Path.Combine(path, path_exe);
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
        private void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Login.Text))
            {
                return;
            }

            if (Login.Text.Length == 0 || Password.Text.Length == 0)
            {
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
                return;
            }

            if (login.Length == 0)
            {
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

            if (path.Length == 0 || path_exe.Length == 0)
            {
                return;
            }
            
            Api.SaveCfg(
            new KeyValuePair<string, string>("path", path),
            new KeyValuePair<string, string>("path_exe", path_exe)
            );
            Sync();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Api.SaveCfg(
            new KeyValuePair<string, string>("command_line", Command_Line.Text)
            );
            Sync();

            Api.run_target(path, path_exe, login, password, command_line);
        }

    }
}


