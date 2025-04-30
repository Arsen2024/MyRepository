using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9._3
{
    public class ParenthesesChecker
    {
        private int[] stack;
        private int top;
        private List<(int openIndex, int closeIndex)> matchedPairs;

        public ParenthesesChecker()
        {
            stack = new int[1000]; 
            top = -1;
            matchedPairs = new List<(int, int)>();
        }

        public List <string> CheckBalance(string expression)
        {
            matchedPairs.Clear();
            top = -1;

            List<string> result = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    Push(i);
                }
                else if (expression[i] == ')')
                {
                    if (IsEmpty())
                    {
                        result.Add("Дужки не збалансовані: зайва закриваюча дужка на позиції " + i);
                        return result;
                    }
                    int openIndex = Pop();
                    matchedPairs.Add((openIndex, i));
                }
            }

            if (!IsEmpty()) {
                result.Add("Дужки не збалансовані: залишилися відкриваючі дужки.");
                return result;
            }

            matchedPairs.Sort((a, b) => a.closeIndex.CompareTo(b.closeIndex));

            result.Add("Дужки збалансовані. Пари дужок:");
            foreach (var pair in matchedPairs) {
                result.Add($"Відкрита на {pair.openIndex}, закрита на {pair.closeIndex}");
            }

            return result;
        }

        private void Push(int index)
        {
            stack[++top] = index;
        }

        private int Pop()
        {
            return stack[top--];
        }

        private bool IsEmpty()
        {
            return top == -1;
        }
    }
}
