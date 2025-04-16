using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._2 {
    public class Book: IStudyMaterial, IExam {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int pageCount) {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }

        public void DisplayMaterialInfo() {
            MessageBox.Show($"Book: {Title}\nAuthor: {Author}\nPages: {PageCount}");
        }

        public string GetSummary() {
            return $"This is the book \"{Title}\" by {Author}.";
        }

        public bool IsExamRequired() {
            return true;
        }

        public string GetExamType() {
            return "Written exam";
        }

        // Method specific to this class
        public void Read() {
            MessageBox.Show("You're reading the book...");
        }
    }
}
