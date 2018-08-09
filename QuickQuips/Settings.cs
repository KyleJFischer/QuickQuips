using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickQuips
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.QuipFileLocation = textBox1.Text;
            Properties.Settings.Default.HotKey = textBox2.Text;
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.QuipFileLocation;
            textBox2.Text = Properties.Settings.Default.HotKey;
        }
    }
}
