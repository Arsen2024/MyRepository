using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._2 {
    public class Notes: IStudyMaterial, IExam {
        public string Topic { get; set; }
        public string StudentName { get; set; }
        public int PageCount { get; set; }

        public Notes(string topic, string studentName, int pageCount) {
            Topic = topic;
            StudentName = studentName;
            PageCount = pageCount;
        }

        public void DisplayMaterialInfo() {
            MessageBox.Show($"Notes on: {Topic}\nStudent: {StudentName}\nPages: {PageCount}");
        }

        public string GetSummary() {
            return $"Notes on \"{Topic}\" by student {StudentName}.";
        }

        public bool IsExamRequired() {
            return false;
        }

        public string GetExamType() {
            return "No exam required";
        }

        // Method specific to this class
        public void Review() {
            MessageBox.Show("You're reviewing the notes...");
        }
    }
}
