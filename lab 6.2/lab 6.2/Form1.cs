using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            string title = textBox1.Text;
            string author = textBox2.Text;
            int pages = int.Parse(textBox3.Text);

            Book book = new Book(title, author, pages);
            book.DisplayMaterialInfo();
            MessageBox.Show(book.GetSummary());
            MessageBox.Show(book.GetExamType());
            book.Read();
        }

        private void button2_Click(object sender, EventArgs e) {
            string topic = textBox4.Text;
            string student = textBox5.Text;
            int pages = int.Parse(textBox6.Text);

            Notes notes = new Notes(topic, student, pages);
            notes.DisplayMaterialInfo();
            MessageBox.Show(notes.GetSummary());
            MessageBox.Show(notes.GetExamType());
            notes.Review();
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) {

        }
    }
}
