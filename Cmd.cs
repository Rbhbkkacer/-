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
        string switch_name = null;

        public Cmd(string ip, string login, string password)
        {
            this.ip = ip;
            StartInfo = new ProcessStartInfo
            {
                Arguments = "-telnet " + ip,
                FileName = "klink.exe",
                WorkingDirectory = Application.StartupPath,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Maximized,
            };
            Start();
            //StandardInput.WriteLine(@"klink.exe -telnet -batch " + ip);
            StandardInput.WriteLine(login+"\n"+password);
            StandardInput.WriteLine("terminal length 512");
            var s = StandardOutput.ReadLine();
            StandardInput.WriteLine("terminal length 512");
            while (!(s.Contains("terminal length 512")))
            {
                s = StandardOutput.ReadLine();
            }
            switch_name = s.Remove(s.IndexOf('#'));
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
                vs.Add(s.Trim());
            }
            return vs;
        }
    }
}
