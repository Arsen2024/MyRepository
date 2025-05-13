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

namespace lab_12._1
{
    public partial class Form1 : Form
    {
        private string inputText = "";
        private string outputText = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RecognizeNumbers()
        {
            var results = NumberRecognizer.RecognizeNumber(inputText, Culture.English);

            List<string> infoList = new List<string>();
            outputText = inputText;

            int offset = 0;

            foreach(var result in results) {
                string original = result.Text;
                int start = result.Start;
                int end = result.End;
                string value = result.Resolution["value"].ToString();

                start += offset;
                end += offset;

                outputText = outputText.Remove(start, end - start + 1);
                outputText = outputText.Insert(start, value);

                offset += value.Length - original.Length;
                
                infoList.Add($"Розпізнаний текст (число): {original}\r\n" +
                    $"Початковий індекс у рядку: {result.Start}\r\n" +
                    $"Кінцевий індекс у рядку: {result.End}\r\n" +
                    $"Розпізнане значення числа: {value}\r\n");
            }
           
            textBox2.Text = outputText;
            textBox3.Text = string.Join("\r\n", infoList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                inputText = File.ReadAllText(ofd.FileName);
                textBox1.Text = inputText;

                RecognizeNumbers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            File.WriteAllText(outputPath, outputText);
            MessageBox.Show("Файл збережено у: " + outputPath);
        }
    }
}
