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

namespace lab_9._3
{
    public partial class Form1 : Form
    {
        private ParenthesesChecker checker = new ParenthesesChecker();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "expression.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не знайдено!");
                return;
            }

            string expression = File.ReadAllText(path);
            textBox1.Text = expression;

            var checker = new ParenthesesChecker();
            var resultLines = checker.CheckBalance(expression);

            listBox1.Items.Clear();
            listBox1.Items.AddRange(resultLines.ToArray());
        }
    }
}
