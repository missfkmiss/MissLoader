using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissLoader
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static api KeyAuthApp = new api(
           name: "MissLoader",
           ownerid: "bugVoCeayb",
           secret: "c66eab2536108bbcf3dfedf5a4b5ed24f7b21592b44f58128f857d1fe96981b2",
           version: "1.0"
       );


        private void Form1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message);
                Environment.Exit(0);
            }
            KeyAuthApp.check();
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(metroTextBox1.Text, metroTextBox2.Text);
            if (KeyAuthApp.response.success)
            {
                Inject main = new Inject();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error", "Login Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            KeyAuthApp.register(metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text);
            if (KeyAuthApp.response.success)
            {
                Inject main = new Inject();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error", "Register Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
