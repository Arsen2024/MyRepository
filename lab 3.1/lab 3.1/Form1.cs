using System;
using System.Linq;
using System.Windows.Forms;

namespace lab_3._1
{
    public partial class Form1 : Form
    {
        private TextBox txtInput;
        private Button btnConvert;
        private Label lblResult;
        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Створюємо текстове поле
            txtInput = new TextBox();
            txtInput.Location = new System.Drawing.Point(20, 20);
            txtInput.Width = 200;
            Controls.Add(txtInput);

            // Створюємо кнопку
            btnConvert = new Button();
            btnConvert.Text = "Конвертувати";
            btnConvert.Width = 100;
            btnConvert.Location = new System.Drawing.Point(20, 50);
            btnConvert.Click += Form1_Load; // Прив’язуємо подію натискання
            Controls.Add(btnConvert);

            // Створюємо мітку для результату
            lblResult = new Label();
            lblResult.Text = "Результат:";
            lblResult.Location = new System.Drawing.Point(20, 80);
            lblResult.Width = 300;
            Controls.Add(lblResult);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            char[] converted = input.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray();
            lblResult.Text = "Результат: " + new string(converted);
        }
    }
}
