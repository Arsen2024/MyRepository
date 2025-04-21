using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_8._2_C_
{
    public partial class Form1 : Form
    {
        public enum Month
        {
            Січень = 1,
            Лютий,
            Березень,
            Квітень,
            Травень,
            Червень,
            Липень,
            Серпень,
            Вересень,
            Жовтень,
            Листопад,
            Грудень
        }

        public Dictionary<Month, string> monthAccessories = new Dictionary<Month, string>
        {
            { Month.Січень, "Пуховик" },
            { Month.Лютий, "Шапка" },
            { Month.Березень, "Пальто" },
            { Month.Квітень, "Легка куртка" },
            { Month.Травень, "Сонцезахисні окуляри" },
            { Month.Червень, "Кепка" },
            { Month.Липень, "Шорти" },
            { Month.Серпень, "Футболка" },
            { Month.Вересень, "Куртка" },
            { Month.Жовтень, "Светр" },
            { Month.Листопад, "Шарф" },
            { Month.Грудень, "Рукавиці" }
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для відображення місяця і аксесуара
        public void ShowMonthAndAccessory(int monthNumber)
        {
            if (Enum.IsDefined(typeof(Month), monthNumber))
            {
                Month month = (Month)monthNumber;
                string accessory = monthAccessories[month];

                // Виведення результату у Label на формі
                label1.Text = $"Місяць: {month}\nАксесуар: {accessory}";
            }
            else
            {
                label1.Text = "Невірний номер місяця!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                int monthNumber;

                // Перевіряємо, чи поле не порожнє
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    label1.Text = "Будь ласка, введіть номер місяця.";
                    return;
                }

                // Перевіряємо введення користувача на валідність
                if (!int.TryParse(textBox1.Text, out monthNumber) || monthNumber < 1 || monthNumber > 12)
                {
                    label1.Text = "Будь ласка, введіть коректний номер місяця (від 1 до 12).";
                    return;
                }

                // Викликаємо метод для показу місяця і аксесуара
                ShowMonthAndAccessory(monthNumber);

                // Питання користувачу: завершити чи продовжити
                DialogResult dialogResult = MessageBox.Show("Хочете ввести інший місяць?", "Вибір", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    break;  // Завершення циклу і закриття форми
                }
                else
                {
                    // Очищаємо поле вводу, щоб користувач міг ввести новий номер
                    textBox1.Clear();
                }
            }

            // Завершуємо роботу форми після виходу з циклу
            this.Close();
        }
    }
}

