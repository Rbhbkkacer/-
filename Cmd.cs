using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кабельный_журнал
{
    class Cmd : Process
    {
        string ip;
        string login;
        string password;
        public string switch_name = null;
        public System.Timers.Timer timer = new System.Timers.Timer();

        public Cmd(string ip, string login, string password, string protocol = "telnet")
        {
            this.ip = ip;
            this.login = login;
            this.password = password;
            if (protocol == "SSH")
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = "-" + protocol.ToLower() + " " + login + "@" + ip + " -pw " + password,
                    FileName = "klink.exe",
                    WorkingDirectory = Application.StartupPath,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Maximized,
                };
                Start();
                StandardInput.WriteLine("y");
                StandardInput.WriteLine("n");
            }
            else
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = "-" + protocol.ToLower() + " " + ip,
                    FileName = "klink.exe",
                    WorkingDirectory = Application.StartupPath,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Maximized,
                };
                Start();
                StandardInput.WriteLine(login + "\n" + password);
            }
            this.Exited += Cmd_Exited;
            StandardInput.WriteLine("terminal length 0");
            var s = StandardOutput.ReadLine();
            if (s is null)
            {
                Close();
                return;
            }
            StandardInput.WriteLine("terminal length 0");
            s = StandardOutput.ReadLine();
            StandardInput.WriteLine("terminal length 0");
            while (!(s.Contains("terminal length 0")))
            {
                s = StandardOutput.ReadLine();
            }
            switch_name = s.Remove(s.IndexOf('#'));
            timer.Interval = 100000;
            timer.Elapsed += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            StandardInput.WriteLine();
            var s = StandardOutput.ReadLine();
        }
        private void Cmd_Exited(object sender, EventArgs e)
        {
            exit();
        }

        public string[] GetPorts()
        {
            List<string> vs = new List<string>();
            StandardInput.WriteLine("sh int statu");
            var s = StandardOutput.ReadLine();
            while (!(s.Contains("sh int statu")))
            {
                s = StandardOutput.ReadLine();
            }
            while (!(s.Contains("Port      ")))
            {
                s = StandardOutput.ReadLine();
            }
            while (s != switch_name + "#")
            {
                s = StandardOutput.ReadLine();
                if (s == switch_name + "#")
                {
                    StandardInput.WriteLine();
                    break;
                }
                vs.Add(s.Split(' ')[0]);
            }
            return vs.ToArray();
        }

        public List<string> GetPortConfig(string port)
        {
            StandardInput.WriteLine("end");
            List<string> vs = new List<string>();
            StandardInput.WriteLine("sh ru in " + port);
            var s = StandardOutput.ReadLine();
            while (!(s.Contains("sh ru in " + port)))
            {
                s = StandardOutput.ReadLine();
            }
            while (!(s.Contains("!")))
            {
                s = StandardOutput.ReadLine();
            }
            while (s != switch_name + "#")
            {
                s = StandardOutput.ReadLine();
                if (s == switch_name + "#")
                {
                    StandardInput.WriteLine();
                    break;
                }
                if (s.Trim() == "end")
                {
                    break;
                }
                vs.Add(s.Trim());
            }
            return vs;
        }

        private void conf_t()
        {
            StandardInput.WriteLine();
            System.Threading.Thread.Sleep(200);
            StreamReader streamReader = new StreamReader(StandardOutput.BaseStream);
            String s = streamReader.ReadLine();
            while (streamReader.charPos+s.Length!= streamReader.charLen)
            {
                s = streamReader.ReadLine();
            }
            if (s == switch_name + " (config-if)#")
            {
                StandardInput.WriteLine("ex");
                s = StandardOutput.ReadLine();
                return;
            }
            else if (s == switch_name + " (config)#")
            {
                StandardInput.WriteLine();
                s = StandardOutput.ReadLine();
                return;
            }
            StandardInput.WriteLine("conf t");
            while (s != switch_name + "(config)#")
            {
                s = StandardOutput.ReadLine();
            }
            //"(config"
        }
        public void in_(string port)
        {
            conf_t();
            StandardInput.WriteLine("in " + port);
            var s = StandardOutput.ReadLine();
            while (s!= switch_name + "(config-if)#")
            {
                s = StandardOutput.ReadLine();
            }
        }

        public void sh(bool no)
        {
            StandardInput.WriteLine(no ? "no sh" : "sh");
            var s = StandardOutput.ReadLine();
            while (!(s.Contains("sh")))
            {
                s = StandardOutput.ReadLine();
            }
        }

        public void exit()
        {
            StandardInput.WriteLine("end");
            StandardInput.WriteLine("ex");
        }
        
        public void re_vlan(string formattedValue)
        {
            StandardInput.WriteLine("switchport trunk allowed vlan remove " + formattedValue);
            var s = StandardOutput.ReadLine();
            while (!(s.Contains("switchport trunk allowed vlan remove " + formattedValue)))
            {
                s = StandardOutput.ReadLine();
            }
        }

        internal void add_vlan(string editedFormattedValue)
        {
            StandardInput.WriteLine("switchport trunk allowed vlan add " + editedFormattedValue);
            var s = StandardOutput.ReadLine();
            while (!(s.Contains("switchport trunk allowed vlan add " + editedFormattedValue)))
            {
                s = StandardOutput.ReadLine();
            }
        }
    }
}
