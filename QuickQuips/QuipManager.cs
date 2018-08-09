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
    public partial class QuipManager : Form
    {
        List<Quip> quips = null;
        Form1 mainScreen = null;

        public QuipManager()
        {
            InitializeComponent();
        }

        private void QuipManager_Load(object sender, EventArgs e)
        {
            loadQuips();
        }

        public void init(List<Quip> listOfQuips, Form1 mainScreen)
        {
            this.mainScreen = mainScreen;
            this.quips = listOfQuips;
        }

        public void loadQuips()
        {
            listBox1.Items.Clear();
            foreach (var item in quips)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var creator = new QuipCreator();
            creator.init(quips, mainScreen, this);
            creator.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            quips.Remove((Quip)listBox1.SelectedItem);
            mainScreen.reloadFlowLayout(quips);
            loadQuips();


        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;
            var creator = new QuipCreator();
            creator.init(quips, mainScreen, this, (Quip) selectedItem);
            creator.Show();
        }
    }
}
