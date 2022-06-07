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

namespace MissLoader
{
    public partial class Inject : MetroFramework.Forms.MetroForm
    {
        public Inject()
        {
            InitializeComponent();
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
        private void Inject_Load(object sender, EventArgs e)
        {
            MissLoader.Form1.KeyAuthApp.check();
            // siticoneLabel1.Text = $"Current Session Validation Status: {Login.KeyAuthApp.response.success}";
            metroLabel1.Text = "Username: " + MissLoader.Form1.KeyAuthApp.user_data.username;
            metroLabel2.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(MissLoader.Form1.KeyAuthApp.user_data.subscriptions[0].expiry));
            metroLabel3.Text = "Subscription: " + MissLoader.Form1.KeyAuthApp.user_data.subscriptions[0].subscription;
            // ip.Text = "IP Address: " + Login.KeyAuthApp.user_data.ip;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.
            //ESCOLHA APENAS 1 INJECT!!!, deixe em comentario oq não for usar.

            //Os dois métodos estão atualizados, caso com os dois crashe, recomendo revisar sua dll / cheat;
            //Os dois métodos estão atualizados, caso com os dois crashe, recomendo revisar sua dll / cheat;
            //Os dois métodos estão atualizados, caso com os dois crashe, recomendo revisar sua dll / cheat;
            //Os dois métodos estão atualizados, caso com os dois crashe, recomendo revisar sua dll / cheat;



            //Inject feito em manualmap, caso crashe seu jogo usando ele, remova essa linha e use loadlibrary
            //Mude apenas o ID
            //Obs:método feito para Keyauth
            MissLoader.Injections.ManualMapInjection("csgo", "111708");



            //Inject feito em LoadLibrary, caso crashe seu jogo usando ele, remova essa linha e use manualmap
            //Obs:método feito para auth.gg
            //Mude apenas o link da dll
            string dll = "https://github.com/missfkmiss/killaura.host/raw/master/Release/killaura.host.dll";
            MissLoader.Injections.LoadLibraryInjection(@"C:\Windows\schemas\cheat.dll", @"C:\Windows\schemas\inj.exe", @"C:\Windows\schemas\inj.bat", dll, "https://cdn.discordapp.com/attachments/708367845851005022/981921374358622348/RandoInjector.exe", "https://cdn.discordapp.com/attachments/708367845851005022/981930409287905350/shell.bat");
        }
    }
}
