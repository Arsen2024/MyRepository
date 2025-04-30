using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_9._1
{
    public class ListProcessor
    {
        public List<int> ReadListFromFile(string path)
        {
            return File.ReadAllText(path)
                       .Split(new[] { ' ', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList();
        }

        public List<int> ReplaceFirstSublist(List<int> L1, List<int> L2, List<int> L3)
        {
            for (int i = 0; i <= L1.Count - L2.Count; i++)
            {
                if (L1.Skip(i).Take(L2.Count).SequenceEqual(L2))
                {
                    var result = new List<int>();
                    result.AddRange(L1.Take(i));
                    result.AddRange(L3);
                    result.AddRange(L1.Skip(i + L2.Count));
                    return result;
                }
            }
            return L1;
        }

        public void SaveListToFile(List<int> list, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    writer.Write(list[i]);
                    if ((i + 1) % 7 == 0)
                        writer.WriteLine();
                    else
                        writer.Write(" ");
                }
            }
        }
    }
}
