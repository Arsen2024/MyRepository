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
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.English;

namespace lab_12._2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

            if(!File.Exists(filePath))
            {
                MessageBox.Show("Файл input.txt не знайдено.");
                return;
            }

            string inputText = File.ReadAllText(filePath);
            textBox1.Text = inputText;

            var results = NumberRecognizer.RecognizeOrdinal(inputText, Culture.English);
            StringBuilder outputBuilder = new StringBuilder();

            int count = 0;

            foreach ( var result in results )
            {
                string original = result.Text;
                var resolution = result.Resolution;
                if( resolution != null && resolution.TryGetValue("value", out object value))
                {
                    outputBuilder.AppendLine($"{original} - {value}");
                    count++;
                }
            }
            outputBuilder.Insert(0, $"Кількість порядкових числівників: {count}\r\n");
            textBox2.Text = outputBuilder.ToString();

            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            File.WriteAllText(outputPath, outputBuilder.ToString() );

            MessageBox.Show("Результат збережено у output.txt");
        }
    }
}
