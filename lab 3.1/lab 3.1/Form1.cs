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
            // ��������� �������� ����
            txtInput = new TextBox();
            txtInput.Location = new System.Drawing.Point(20, 20);
            txtInput.Width = 200;
            Controls.Add(txtInput);

            // ��������� ������
            btnConvert = new Button();
            btnConvert.Text = "������������";
            btnConvert.Width = 100;
            btnConvert.Location = new System.Drawing.Point(20, 50);
            btnConvert.Click += Form1_Load; // ��������� ���� ����������
            Controls.Add(btnConvert);

            // ��������� ���� ��� ����������
            lblResult = new Label();
            lblResult.Text = "���������:";
            lblResult.Location = new System.Drawing.Point(20, 80);
            lblResult.Width = 300;
            Controls.Add(lblResult);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            char[] converted = input.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray();
            lblResult.Text = "���������: " + new string(converted);
        }
    }
}
