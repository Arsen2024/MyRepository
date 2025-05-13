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
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Sequence;


namespace lab_12._3
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                inputText = File.ReadAllText(ofd.FileName);
                textBox1.Text = inputText;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Завантажте текстовий файл спочатку.");
                return;
            }

            StringBuilder result = new StringBuilder();

            var recognizers = new Dictionary<string, List<ModelResult>>
            {
                {"Currency", NumberWithUnitRecognizer.RecognizeCurrency(inputText, Culture.English)},
                {"Dimension", NumberWithUnitRecognizer.RecognizeDimension(inputText, Culture.English)},
                {"Temperature", NumberWithUnitRecognizer.RecognizeTemperature(inputText, Culture.English)},
                {"DateTime", DateTimeRecognizer.RecognizeDateTime(inputText, Culture.English)},
                {"PhoneName", SequenceRecognizer.RecognizePhoneNumber(inputText, Culture.English)},
                {"IPAddress", SequenceRecognizer.RecognizeIpAddress(inputText, Culture.English)},
                {"Email", SequenceRecognizer.RecognizeEmail(inputText, Culture.English)},
                {"URL", SequenceRecognizer.RecognizeURL(inputText, Culture.English)},
                {"Hashtag", SequenceRecognizer.RecognizeHashtag(inputText, Culture.English)}
            };

            foreach(var entry in recognizers)
            {
                var matches = entry.Value;

                if (matches.Count > 0)
                {
                    result.AppendLine($"{entry.Key}: {matches.Count}");
                    foreach(var m in matches) 
                    {
                        string value = m.Resolution != null && m.Resolution.ContainsKey("value")
                            ? m.Resolution["value"].ToString()
                            : "невідомо";
                        result.AppendLine($"{m.Text} → {value}");
                    }
                    result.AppendLine();
                }
            }
            textBox2.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            File.WriteAllText(outputPath, textBox2.Text);
            MessageBox.Show("Файл збережено у: " + outputPath);
        }
    }
}
