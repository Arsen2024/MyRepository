using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_9._5 {
    public partial class Form1 : Form {
        private List<string> vertices = new List<string> {"a", "b", "c", "d", "e", "f"};
        private List<(string from, string to)> edges = new List<(string, string)> {
            ("a", "e"),
            ("b", "b"),
            ("b", "e"),
            ("c", "c"),
            ("c", "e"),
            ("c", "f"),
            ("d", "e"),
            ("d", "f"),
            ("f", "e")
        };
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            int[,] matrix = new int[vertices.Count, vertices.Count];

            foreach(var edge in edges) {
                int fromIndex = vertices.IndexOf(edge.from);
                int toIndex = vertices.IndexOf(edge.to);
                matrix[fromIndex, toIndex] = 1;
            }

            ShowMatrix(matrix, "Матриця суміжності");
        }

        private void ShowMatrix(int[,] matrix, string title) {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            label1.Text = title;

            for(int j = 0; j < matrix.GetLength(1); j++) {
                string header = (title.Contains("інцидентності") && j < edges.Count) ? $"{edges[j].from}→{edges[j].to}": vertices[j];

                dataGridView1.Columns.Add($"col{j}", header);
            }

            for(int i = 0; i < matrix.GetLength(0); i++) {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                for(int j = 0; j < matrix.GetLength(1); j++) {
                    row.Cells[j].Value = matrix[i, j];
                }

                row.HeaderCell.Value = vertices[i];
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button2_Click(object sender, EventArgs e) {
            int[,] matrix = new int[vertices.Count, edges.Count];

            for(int k = 0; k < edges.Count; k++) {
                var edge = edges[k];
                int fromIndex = vertices.IndexOf(edge.from);
                int toIndex = vertices.IndexOf(edge.to);

                if (fromIndex == -1 || toIndex == -1)
                    continue;

                if(fromIndex == toIndex) {
                    matrix[fromIndex, k] = 2;
                }
                else {
                    matrix[fromIndex, k] = -1;
                    matrix[toIndex, k] = 1;
                }
            }

            ShowMatrix(matrix, "Матриця інцидентності");
        }
    }
}
