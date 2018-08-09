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
    public partial class QuipCreator : Form
    {
        public List<Quip> listOfQuips = null;
        public Form1 mainScreen;

        public QuipCreator()
        {
            InitializeComponent();
        }

        public void GiveMeQuips(List<Quip> list)
        {
            listOfQuips = list;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void QuipCreator_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(QuipMode)))
            {
                comboBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newQuip = new Quip();
            newQuip.id = 0;
            newQuip.mode = (QuipMode)comboBox1.SelectedItem;
            newQuip.text = textBox1.Text;
            newQuip.displayText = textBox2.Text;
            listOfQuips.Add(newQuip);
            mainScreen.reloadFlowLayout(listOfQuips);
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void GiveMeForm1(Form1 form)
        {
            this.mainScreen = form;
        }
    }
}
