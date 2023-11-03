using Newtonsoft.Json;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Security;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ral2
{
    public class lib
    {
        private static string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        public void Create(string NameLog, string Pass)
        {
            SecurityIdentifier everyoneSid = new SecurityIdentifier(
            WellKnownSidType.BuiltinUsersSid,
            null
            );
            string everyone = everyoneSid.Translate(typeof(System.Security.Principal.NTAccount)).ToString();
            string pattern = @"[^\\]*\\";
            string usergroup = Regex.Replace(everyone, pattern, "");

            if (string.IsNullOrEmpty(NameLog) || string.IsNullOrEmpty(Pass))
            {
                return;
            }

            if (NameLog.Length == 0 || Pass.Length == 0)
            {
                return;
            }

            DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry NewUser = AD.Children.Add(NameLog, "user");
            NewUser.Invoke("SetPassword", new object[] { Pass });
            NewUser.Invoke("Put", new object[] { "Description", "" });
            NewUser.CommitChanges();
            DirectoryEntry grp;
            grp = AD.Children.Find(usergroup, "group");
            if (grp != null)
            {
                grp.Invoke("Add", new object[] { NewUser.Path.ToString() });
            }
            // Set the PasswordNeverExpires property
            int ADS_UF_DONT_EXPIRE_PASSWD = 0x10000;
            int userFlags = (int)NewUser.Properties["UserFlags"].Value;
            NewUser.Properties["UserFlags"].Value = userFlags | ADS_UF_DONT_EXPIRE_PASSWD;

            NewUser.CommitChanges();
        }
        public void Remove(string NameLog)
        {
            var proc1 = new ProcessStartInfo();
            string Command;
            proc1.UseShellExecute = true;
            Command = @"net user " + NameLog + " /delete";
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + Command;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }
        public void GetInfo(string NameLog)
        {
            if (NameLog != null &&  NameLog.Length > 0) {  
            var proc1 = new ProcessStartInfo();
            string Command;
            proc1.UseShellExecute = true;
            Command = @"net user " + NameLog + " && pause";
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + Command;
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(proc1);
        }
        else
        { 
            var proc1 = new ProcessStartInfo();
            string Command;
            proc1.UseShellExecute = true;
            Command = @"net user && pause";
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + Command;
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(proc1);
        }
        }

         public string Get_FolderPath()
         {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path_o = dlg.SelectedPath.Replace("\u005C", "\u002F");
                return path_o;
            }

            // Return an empty string if no path is selected
            return "";
        }

         public string Get_ExePath()
         {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                var path_f = string.Empty;

                openFileDialog.Filter = "Exe file (*.exe)|*.exe";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    path_f = Path.GetFileName(filePath);
                    return path_f;
                }
            }

            // Return an empty string if no path is selected
            return "";
        }
        public void run_target(string path, string path_exe, string NameLog, string Pass, string args)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path_exe) || string.IsNullOrEmpty(NameLog) || string.IsNullOrEmpty(Pass))
            {
                return;
            }

            if (path.Length == 0 || path_exe.Length == 0 || NameLog.Length == 0 || Pass.Length == 0)
            {
                return;
            }
            string fullExePath = Path.Combine(path, path_exe);
            Directory.SetCurrentDirectory(path);

            var process = new Process();
            var securePassword = new SecureString();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = fullExePath;
            process.StartInfo.LoadUserProfile = true;
            process.StartInfo.Verb = "runas";
            process.StartInfo.Domain = System.Environment.UserDomainName;
            process.StartInfo.UserName = NameLog;
            process.StartInfo.Arguments = args;
            foreach (char c in Pass)
            {
                securePassword.AppendChar(c);
            }

            process.StartInfo.Password = securePassword;
            process.Start();
        }

        public void SaveCfg(params KeyValuePair<string, string>[] keyValuePairs)
        {
            Dictionary<string, string> configData = new Dictionary<string, string>();

            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                configData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            foreach (var kvp in keyValuePairs)
            {
                configData[kvp.Key] = kvp.Value;
            }

            string jsonString = JsonConvert.SerializeObject(configData);
            File.WriteAllText(ConfigFilePath, jsonString);
        }

        public string ReadCfg(string key)
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                Dictionary<string, string> configData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                if (configData.TryGetValue(key, out string value))
                {
                    return value;
                }
            }

            return null;
        }
    }
}

