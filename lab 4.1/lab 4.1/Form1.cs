using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace lab_4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Клас для пацієнта
        public class Patient
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            public float Height { get; set; }
            public float Weight { get; set; }
            public DateTime BirthDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public int HospitalNumber { get; set; }
            public int DepartmentNumber { get; set; }
            public string MedicalCardNumber { get; set; }
            public string Diagnosis { get; set; }
            public string BloodGroup { get; set; }

            // Конструктор для ініціалізації всіх полів
            public Patient(string lastName, string firstName, string middleName, string gender, string nationality,
                           float height, float weight, DateTime birthDate, string phoneNumber, string address,
                           int hospitalNumber, int departmentNumber, string medicalCardNumber, string diagnosis,
                           string bloodGroup)
            {
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
                Gender = gender;
                Nationality = nationality;
                Height = height;
                Weight = weight;
                BirthDate = birthDate;
                PhoneNumber = phoneNumber;
                Address = address;
                HospitalNumber = hospitalNumber;
                DepartmentNumber = departmentNumber;
                MedicalCardNumber = medicalCardNumber;
                Diagnosis = diagnosis;
                BloodGroup = bloodGroup;
            }

            public bool IsFromDepartment18() => DepartmentNumber == 18;
        }

        // Читання пацієнтів з файлу
        private List<Patient> ReadPatientsFromFile(string filename)
        {
            var patients = new List<Patient>();

            // Перевіряємо, чи існує файл, якщо ні - створюємо порожній файл
            if (!File.Exists(filename))
            {
                File.Create(filename).Close(); // Створюємо файл і закриваємо потік
                MessageBox.Show($"Файл '{filename}' не знайдено. Створено новий файл.");
                return patients; // Повертаємо порожній список, оскільки файл тільки що створений
            }

            try
            {
                foreach (var line in File.ReadLines(filename))
                {
                    var data = line.Split(';');

                    string lastName = data[0];
                    string firstName = data[1];
                    string middleName = data[2];
                    string gender = data[3];
                    string nationality = data[4];
                    float height = float.Parse(data[5]);
                    float weight = float.Parse(data[6]);
                    DateTime birthDate = DateTime.Parse(data[7]);
                    string phoneNumber = data[8];
                    string address = data[9];
                    int hospitalNumber = int.Parse(data[10]);
                    int departmentNumber = int.Parse(data[11]);
                    string medicalCardNumber = data[12];
                    string diagnosis = data[13];
                    string bloodGroup = data[14];

                    var patient = new Patient(lastName, firstName, middleName, gender, nationality, height, weight,
                                              birthDate, phoneNumber, address, hospitalNumber, departmentNumber,
                                              medicalCardNumber, diagnosis, bloodGroup);
                    patients.Add(patient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
            return patients;
        }

        // Запис пацієнтів з відділення 18 у файл
        private void WriteFilteredPatientsToFile(string filename, List<Patient> patients)
        {
            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    foreach (var patient in patients)
                    {
                        if (patient.IsFromDepartment18())
                        {
                            writer.WriteLine($"{patient.LastName};{patient.FirstName};{patient.MiddleName};{patient.Gender};{patient.Nationality};{patient.Height};{patient.Weight};{patient.BirthDate:yyyy-MM-dd};{patient.PhoneNumber};{patient.Address};{patient.HospitalNumber};{patient.DepartmentNumber};{patient.MedicalCardNumber};{patient.Diagnosis};{patient.BloodGroup}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing file: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var patients = ReadPatientsFromFile("Input Data.txt");
            WriteFilteredPatientsToFile("Output Data.txt", patients);

            // Виведення результатів на форму
            lstResults.Items.Clear();
            foreach (var patient in patients)
            {
                if (patient.IsFromDepartment18())
                {
                    lstResults.Items.Add($"{patient.LastName} {patient.FirstName} {patient.MiddleName} - {patient.Diagnosis}");
                }
            }

            MessageBox.Show("Processing complete. Results saved in 'Output Data.txt'.");
        }
    }
}
