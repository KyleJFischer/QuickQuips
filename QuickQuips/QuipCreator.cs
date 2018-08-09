using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public QuipManager manager;
        public Quip editingQuip;

        public QuipCreator()
        {
            InitializeComponent();
        }

        public void GiveMeQuips(List<Quip> list)
        {
            listOfQuips = list;
        }

        public void init(List<Quip> list, Form1 main, QuipManager manage)
        {
            this.listOfQuips = list;
            this.mainScreen = main;
            this.manager = manage;
        }

        public void init(List<Quip> list, Form1 main, QuipManager manage, Quip quip)
        {
            this.listOfQuips = list;
            this.mainScreen = main;
            this.manager = manage;
            this.editingQuip = quip;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals(QuipMode.Program))
            {
                button2.Show();
            } else
            {
                button2.Hide();
            }
        }

        private void QuipCreator_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(QuipMode)))
            {
                comboBox1.Items.Add(item);
            }
            button2.Hide();
            if (this.editingQuip != null)
            {
                this.textBox1.Text = editingQuip.text;
                this.textBox2.Text = editingQuip.displayText;
                this.comboBox1.SelectedItem = editingQuip.mode;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Quip newQuip = null;
                if (editingQuip != null)
                {
                    newQuip = editingQuip;
                } else
                {
                    newQuip = new Quip();
                }
                newQuip.id = 0;
                newQuip.mode = (QuipMode)comboBox1.SelectedItem;
                newQuip.text = textBox1.Text;
                newQuip.displayText = textBox2.Text;
                if (editingQuip == null)
                {
                    listOfQuips.Add(newQuip);
                }
                
                mainScreen.reloadFlowLayout(listOfQuips);
                manager.loadQuips();
                this.Close();
            }
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void GiveMeForm1(Form1 form)
        {
            this.mainScreen = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName;
               
            }
        }
    }
}
