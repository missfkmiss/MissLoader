using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualMapInjection.Injection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MissLoader
{
    internal class Injections
    {
        public static void ManualMapInjection(string id, string processname)
        {
            try
            {
                Process process = Process.GetProcessesByName(processname).FirstOrDefault<Process>();
                if (process != null)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.Proxy = null;
                        byte[] inject = MissLoader.Form1.KeyAuthApp.download(id); ;
                        ManualMapInjector manualMapInjector = new ManualMapInjector(process)
                        {
                            AsyncInjection = true
                        };
                        string.Format("hmodule = 0x{0:x8}", manualMapInjector.Inject(inject).ToInt64());
                        //MessageBox.Show("Injected !");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    MessageBox.Show("Open the Game First", "Open Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        public static void LoadLibraryInjection(string dllpath,string injectpath, string shellpath, string linkdll, string linkinject, string linkshell)
        {

            if (File.Exists(dllpath) == false)
            {
                WebClient wb = new WebClient();
                try
                {
                    wb.DownloadFile(linkinject, injectpath);
                }
                catch
                {
                    // Erro 01 representa erro ao baixar injector
                    MessageBox.Show("Error while downloading files", "Error 01", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    wb.DownloadFile(linkshell, shellpath);
                }
                catch
                {
                    // Erro 02 representa erro ao baixar shell
                    MessageBox.Show("Error while downloading files", "Error 02", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    wb.DownloadFile(linkdll, dllpath);
                }
                catch
                {
                    // Erro 03 representa erro ao baixar DLL
                    MessageBox.Show("Error while downloading files", "Error 03", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = shellpath;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.Start();
                }
                catch
                {
                    // Erro 04 representa erro ao injetar
                    MessageBox.Show("Error while injecting", "Error 04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            
            }
            else
            {
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = shellpath;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.Start();
                }
                catch
                {
                    // Erro 04 representa erro ao injetar
                    MessageBox.Show("Error while injecting", "Error 04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

    }
}
