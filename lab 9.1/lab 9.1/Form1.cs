using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab_9._1
{
    public partial class Form1 : Form
    {
        private List<int> L1 = new List<int>();
        private List<int> L2 = new List<int>();
        private List<int> L3 = new List<int>();

        private ListProcessor processor = new ListProcessor();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DisplayList(ListBox listBox, List<int> list)
        {
            listBox.Items.Clear();
            foreach (var item in list)
                listBox.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            L1 = processor.ReadListFromFile("L1.txt");
            L2 = processor.ReadListFromFile("L2.txt");
            L3 = processor.ReadListFromFile("L3.txt");

            DisplayList(listBox1, L1);
            DisplayList(listBox2, L2);
            DisplayList(listBox3, L3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var modified = processor.ReplaceFirstSublist(L1, L2, L3);
            DisplayList(listBox4, modified);
            L1 = modified;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            processor.SaveListToFile(L1, "ModifiedL1.txt");
            MessageBox.Show("Список збережено у файл ModifiedL1.txt");
        }
    }
}
