using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_8._1_C_
{
    public partial class Form1 : Form
    {
        private ProductManager manager = new ProductManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            decimal price = numericUpDown1.Value;
            string category = textBox2.Text;
            bool inStock = checkBox1.Checked;

            manager.AddProduct(name, price, category, inStock);

            MessageBox.Show("Продукт додано!");
            ClearInputs();
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            checkBox1.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var p in manager.GetAllProducts())
            {
                string InStockText = p.Item4 ? "Так" : "Ні";
                listBox1.Items.Add($"Назва: {p.Item1}, Ціна: {p.Item2}, Категорія: {p.Item3}, В наявності: {InStockText}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            decimal avg = manager.GetAveragePrice();
            listBox1.Items.Add($"Середня ціна: {avg:F2}");

            var socials = manager.GetSocialProducts();
            foreach (var p in socials)
            {
                listBox1.Items.Add($"Назва: {p.Item1}, Ціна: {p.Item2}");
            }

            listBox1.Items.Add($"Кількість соціальних продуктів: {socials.Count}");
        }
    }
}
