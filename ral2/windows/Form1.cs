using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
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
        helper h = new helper();
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
        private int DefaultWidth;

        private List<Account> accounts = new List<Account>();
        private BindingList<Account> accountsBindingList;
        private static string Section = "Settings";
        private DataGridViewTextBoxColumn noteColumn = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
        private DataGridViewTextBoxColumn AppColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn DelayColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn CmdlColumn = new DataGridViewTextBoxColumn();
        private ToolTip toolTip1 = new ToolTip();


        private void Sync()
        {
         
            path = Api.ReadCfg<string>("path");
            path_exe = Api.ReadCfg<string>("path_exe");
            login = Api.ReadCfg<string>("Login");
            password = Api.ReadCfg<string>("Password");
            command_line = Api.ReadCfg<string>("command_line");
            first_launch = Api.ReadCfg<string>("first_launch");
            delay = Api.ReadCfg<string>("delay_3rd");
            path3 = Api.ReadCfg<string>("path_3rd");
            path_exe3 = Api.ReadCfg<string>("path_exe_3rd");
            cmd3 = Api.ReadCfg<string>("command_line_3rd");
            rd_check = Api.ReadCfg<string>("third_check");
         
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

            var st_check = Api.ReadCfg<string>("stream_check");
            var st_checks = (st_check == "1" || st_check == "2");

            if (!string.IsNullOrEmpty(st_check))
            {
                StreamerBox.Checked = st_checks;
            }
            if (StreamerBox.Checked)
            {
                h.Hide(Handle);
            }

            Sync();
            Width = 485;
            DefaultWidth = Width;
            if (!no_random) 
            { 
                random_acc();
            }
            build_table();
        }

        public void build_table()
        {
            RemoveAccount.Enabled = false;
            DataTable.AllowUserToAddRows = false;
            DataTable.AllowUserToResizeRows = false;
            DataTable.AllowUserToResizeColumns = false;

            checkboxColumn.HeaderText = "Selected";
            checkboxColumn.Name = "Selected";
            checkboxColumn.Width = 40;
            DataTable.Columns.Add(checkboxColumn);

            DataTable.RowHeadersVisible = false;
            DataTable.ColumnHeadersVisible = false;
            DataTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DataTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataTable.GridColor = Color.FromArgb(220, 220, 198);

            DelayColumn.HeaderText = "Delay";
            DelayColumn.Name = "Delay";
            DelayColumn.ReadOnly = true;
            DelayColumn.Width = 40;
            DataTable.Columns.Add(DelayColumn);


            AppColumn.HeaderText = "App";
            AppColumn.Name = "App";
            AppColumn.ReadOnly = true;
            AppColumn.Width = 140;
            DataTable.Columns.Add(AppColumn);

            CmdlColumn.HeaderText = "Cmdl";
            CmdlColumn.Name = "Cmdl";
            CmdlColumn.ReadOnly = true;
            CmdlColumn.Width = 143;
            DataTable.Columns.Add(CmdlColumn);

            noteColumn.HeaderText = "Note";
            noteColumn.Name = "Note";
            noteColumn.ReadOnly = true;
            noteColumn.Width = 143;
            DataTable.Columns.Add(noteColumn);


            accountsBindingList = new BindingList<Account>(accounts);
            DataTable.DataSource = accountsBindingList;
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
                new KeyValuePair<string, object>("Login", account),
                new KeyValuePair<string, object>("Password", pwd),
                new KeyValuePair<string, object>("first_launch", false)
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
            new KeyValuePair<string, object>("Login", Login.Text),
            new KeyValuePair<string, object>("Password", Password.Text)
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
            new KeyValuePair<string, object>("Login", null),
            new KeyValuePair<string, object>("Password", null)
            );
            Sync();
        }

        private void Select_App_Click(object sender, EventArgs e)
        {
            path = Api.GetFolderPath();
            path_exe = Api.GetExe();

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path_exe))
            {
                return;
            }

            Api.SaveCfg(
            new KeyValuePair<string, object>("path", path),
            new KeyValuePair<string, object>("path_exe", path_exe)
            );
            Sync();
        }
       
        private async void Run_Click(object sender, EventArgs e)
        {
            Api.SaveCfg(
            new KeyValuePair<string, object>("command_line", Command_Line.Text)
            );
            Sync();
            if (!Directory.Exists(path)) { Alert.ShowError("Something wrong with path!"); return; }
            if (!File.Exists(path + "/" + path_exe)) { Alert.ShowError("Something wrong with file!"); return; }
            if (string.IsNullOrEmpty(login)) { Alert.ShowError("Something wrong with login! \nAccount not exist!"); return; }
            Alert.ShowSucess("App started!");
            Api.RunTarget(path, path_exe, login, password, command_line);
            if (third_check.Checked)
            {
                await StartAllAsync();
            }
        }
               

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            DirectoryInfo userProfileDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            string path = Path.Combine(userProfileDirectory.Parent.FullName, login);

            if (!Directory.Exists(path)) { Alert.ShowWarning("Account not exists! \n Run something first..."); return; };

            Process.Start("explorer.exe", path);
        }

        private void third_check_CheckedChanged(object sender, EventArgs e)
        {
            CheckState checkState = third_check.CheckState;
            string checkStateValue = ((int)checkState).ToString();
            Api.SaveCfg(new KeyValuePair<string, object>("third_check", checkStateValue));
        }

        private void StreamerBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckState checkState = StreamerBox.CheckState;
            string checkStateValue = ((int)checkState).ToString();
            Api.SaveCfg(new KeyValuePair<string, object>("stream_check", checkStateValue));

            if (StreamerBox.Checked)
            {
                h.Hide(Handle);
            }
            else
            {
                h.Unhide(Handle);
            }
        }


        /// ---------------------------------------------------------------------------------------------------------------------------------------------
        /// ---------------------------------------------------------------------------------------------------------------------------------------------

        private void rd_Party_Click(object sender, EventArgs e)
        {
            Width = (Width == DefaultWidth) ? 1234 : DefaultWidth;
        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e) // check edit mode
        {
            if (EditMode.Checked)
            {
                noteColumn.ReadOnly = false;
                AppColumn.ReadOnly = false;
                DelayColumn.ReadOnly = false;
                CmdlColumn.ReadOnly = false;
                RemoveAccount.Enabled = true;
            }
            else
            {
                AppColumn.ReadOnly = true;
                noteColumn.ReadOnly = true;
                DelayColumn.ReadOnly = true;
                CmdlColumn.ReadOnly = true;
                RemoveAccount.Enabled = false;
            }
        }

        private void LoadAccounts()
        {
            try
            {
                string json = File.ReadAllText("Apps.json");
                accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            }
            catch (FileNotFoundException)
            {
                SaveAccounts();
            }
        }

        private void SaveAccounts()
        {
            string json = JsonConvert.SerializeObject(accounts);
            File.WriteAllText("Apps.json", json);
        }

        private void RefreshTable()
        {
            DataTable.DataSource = null;
            DataTable.Rows.Clear();
            foreach (Account account in accounts)
            {
                DataTable.Rows.Add(account.Selected, account.Delay, account.App, account.Cmdl, account.Note);
            }
        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e) // select
        {
            var path = Api.GetFolderPath();
            var path_exe = Api.GetExe();
            siticoneRoundedTextBox1.Text = $"{path}/{path_exe}";

        }
        private void siticoneRoundedButton2_Click(object sender, EventArgs e) // add button
        {
            accounts.Add(new Account
            {
                Note = siticoneRoundedTextBox2.Text,
                Delay = delaybox.Text,
                Cmdl = CmdlT.Text,
                App = siticoneRoundedTextBox1.Text
            });
            SaveAccounts();
            RefreshTable();
        }

        private void RemoveAccount_Click(object sender, EventArgs e)
        {
            bool anySelected = false;
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                {
                    anySelected = true;
                    break;
                }
            }

            if (!anySelected)
            {
                MessageBox.Show("No app selected to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete checked app(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                List<int> rowsToRemove = new List<int>();

                for (int i = 0; i < DataTable.Rows.Count; i++)
                {
                    if (DataTable.Rows[i].Cells["Selected"].Value != null &&
                        (bool)DataTable.Rows[i].Cells["Selected"].Value)
                    {
                        rowsToRemove.Add(i);
                    }
                }

                foreach (int rowIndex in rowsToRemove.OrderByDescending(x => x))
                {
                    DataTable.Rows.RemoveAt(rowIndex);
                    accounts.RemoveAt(rowIndex);
                }

                SaveAccounts();
            }
        }

        private void DataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = DataTable.Rows[e.RowIndex];

                string note = row.Cells["Note"].Value != null ? row.Cells["Note"].Value.ToString() : "";
                string App = row.Cells["App"].Value != null ? row.Cells["App"].Value.ToString() : "";
                string Delay = row.Cells["Delay"].Value != null ? row.Cells["Delay"].Value.ToString() : "";
                string Cmdl = row.Cells["Cmdl"].Value != null ? row.Cells["Cmdl"].Value.ToString() : "";
                bool selected = row.Cells["Selected"].Value != null ? (bool)row.Cells["Selected"].Value : false;
                
                Account account = accounts[e.RowIndex];
                if (EditMode.Checked)
                {
                    Console.WriteLine(Delay);
                    account.App = App;
                    account.Delay = Delay;
                    account.Cmdl = Cmdl;
                    account.Note = note;
                }
                account.Selected = selected;

                SaveAccounts();
            }
            RefreshTable();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            RefreshTable();
        }




        private async Task LaunchTargetAppAsync(string App, string cmdl)
        {

            using (Process appProcess = new Process())
            {
                if (string.IsNullOrEmpty(App))
                {
                    string errorMessage = string.Empty;
                    if (string.IsNullOrEmpty(App))
                    {
                        errorMessage = "App Path";
                    }
                    MessageBox.Show($"{errorMessage} not set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ProcessStartInfo sinfo = new ProcessStartInfo
                {
                    FileName = App.Replace("/", "\\"),
                    Arguments = cmdl ?? "",
                    WorkingDirectory = path
                };
                appProcess.StartInfo = sinfo;
                appProcess.Start();
                await Task.Run(() => appProcess.WaitForExit());
            }
        }



        private async Task StartAllAsync()
        {
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                if (row.Cells["Selected"].Value is bool selected && selected)
                {
                    string app = row.Cells["App"].Value.ToString();
                    try
                    {
                        string delay = row.Cells["Delay"].Value.ToString();
                        string cmdl = row.Cells["Cmdl"].Value?.ToString(); // Handle null value

                        if (!string.IsNullOrEmpty(delay))
                        {
                            await Console.Out.WriteLineAsync(delay);
                            if (int.TryParse(delay, out int delayInSeconds))
                            {
                                await Console.Out.WriteLineAsync(delayInSeconds.ToString());
                                int delayInMilliseconds = delayInSeconds * 1000;
                                await Console.Out.WriteLineAsync(delayInMilliseconds.ToString());
                                await Task.Delay(delayInMilliseconds);
                                await LaunchTargetAppAsync(app, cmdl);
                            }
                        }
                        else
                        {
                            await LaunchTargetAppAsync(app, cmdl);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}


