using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calcar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }
        private void num2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void num3_Click(object sender, EventArgs e)
        {
            textBox1.Text += num3.Text;
        }
        private void num4_Click(object sender, EventArgs e)
        {
            textBox1.Text += num4.Text;
        }

        private void num5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void num6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void num7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void num8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void num9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        static double Parse(string expression)
        {
            return CSharpScript.EvaluateAsync<double>(expression).Result;
        }

        private void skobkaL_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void skobkaR_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void sum_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void substraction_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void division_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void root_Click(object sender, EventArgs e)
        {
            textBox1.Text += "√";
        }

        private void point_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void ravno_Click(object sender, EventArgs e)
        {
            string resultText = "";
            string finalResult = "0+";
            //if (textBox1.Text[0] != '√')
            //{
            //    finalResult = textBox1.Text[0].ToString();
            //}

            //else { finalResult = "0+"; }
            //char item;
            //int counter = 0;
            //int c = 0;
            //foreach (var itemI in textBox1.Text)
            //{
            //    if (itemI == '√')
            //    {
            //        counter++;
            //    }
            //}
            //int[] start = new int[counter];
            //for (int i = 0; i < textBox1.Text.Length; ++i)
            //{
            //    item = textBox1.Text[i];
            //    if (item == '√')
            //    {
            //        start[c] = i;
            //        c++;
            //    }
            //}
            //if (start.Length != 0)
            //{
            //    resultText = textBox1.Text[start[0] + 1].ToString();
            //    for (int j = 0; j < start.Length; ++j)
            //    {
            //        resultText = textBox1.Text[start[j] + 1].ToString();
            //        for (int i = start[j] + 2; i < textBox1.Text.Length; ++i)
            //        {
            //            item = textBox1.Text[i];
            //            if (item == '√' || item == '+' || item == '-' || item == '*' || item == '/')
            //            {
            //                break;
            //            }
            //            else { resultText += item.ToString(); }
            //        }
            //    }
            //    foreach (var item1 in textBox1.Text)
            //    {
            //        string tmp = item1.ToString();
            //        if (item1 != '√')
            //        {
            //            tmp += item1.ToString();
            //        }
            //        else
            //        {
            //            tmp += Math.Sqrt(double.Parse(resultText)).ToString();
            //        }
            //    }
            //    for (int j = 0; j < textBox1.Text.Length; ++j)
            //    {
            //        if (textBox1.Text[j] == '√' || textBox1.Text[j] == '+' || textBox1.Text[j] == '-' || textBox1.Text[j] == '*' || textBox1.Text[j] == '/')
            //        {
            //            finalResult += Math.Sqrt(double.Parse(resultText)).ToString();
            //            j += resultText.Length;
            //        }
            //        else { finalResult += textBox1.Text[j].ToString(); }
            //    }
            //    for (int j = 0; j < textBox1.Text.Length; ++j)
            //    {
            //        if (textBox1.Text[j] == '√' || textBox1.Text[j] == '+' || textBox1.Text[j] == '-' || textBox1.Text[j] == '*' || textBox1.Text[j] == '/')
            //        {
            //            finalResult += Math.Sqrt(double.Parse(resultText)).ToString();
            //            j += resultText.Length;
            //        }
            //        else { finalResult += textBox1.Text[j].ToString(); }
            //    }

            //}
            //else
            //{
            //    finalResult = textBox1.Text;
            //}
            textBox1.Text += "+0";
            for(int i = 0; i < textBox1.Text.Length; ++i)
            {
                if (textBox1.Text[i] != '√') finalResult += textBox1.Text[i];
                else
                    for (int j = i + 1; j < textBox1.Text.Length; j++)
                        if (textBox1.Text[j] == '+' || textBox1.Text[j] == '-' || textBox1.Text[j] == '*' || textBox1.Text[j] == '/' || textBox1.Text[j] == ')' || textBox1.Text[j] == '(')
                        {
                            finalResult += Math.Sqrt(double.Parse(resultText)).ToString(); 
                            i += resultText.Length;
                            break;
                        }
                        else
                        {
                            resultText += textBox1.Text[j];
                        }
                resultText = "";
            }
            //var result = Parse(finalResult);
            //finalResult = null;
            //textBox1.Clear();
            //textBox1.Text = result.ToString();
            // Заменим "sqrt" на "Math.Sqrt()" для корректной работы
            ExpressionEvaluator calcar = new ExpressionEvaluator();
            MessageBox.Show(finalResult);
            calcar.Evaluate(finalResult);
            textBox1.Clear();
            textBox1.Text = calcar.Evaluate(finalResult).ToString();
        }
    }
    public class ExpressionEvaluator
    {
        public double Evaluate(string expression)
        {
            var tokens = Tokenize(expression);
            var rpn = ConvertToReversePolishNotation(tokens);
            return CalculateRPN(rpn);
        }

        private static Queue<string> Tokenize(string expression)
        {
            var tokens = new Queue<string>();
            var currentToken = "";

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    currentToken += c; // собираем число или десятичную часть
                }
                else
                {
                    if (currentToken != "")
                    {
                        tokens.Enqueue(currentToken);
                        currentToken = "";
                    }

                    if (!char.IsWhiteSpace(c))
                    {
                        tokens.Enqueue(c.ToString()); // добавляем оператор или скобки
                    }
                }
            }

            if (currentToken != "")
            {
                tokens.Enqueue(currentToken); // добавляем последнее число
            }

            return tokens;
        }

        private static Queue<string> ConvertToReversePolishNotation(Queue<string> tokens)
        {
            var outputQueue = new Queue<string>();
            var operatorStack = new Stack<string>();

            while (tokens.Count > 0)
            {
                string token = tokens.Dequeue();

                if (double.TryParse(token, out _)) // если это число
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop(); // убираем '(' из стека
                }
                else // оператор
                {
                    while (operatorStack.Count > 0 && Precedence(token) <= Precedence(operatorStack.Peek()))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }

        private static int Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        private static double CalculateRPN(Queue<string> rpn)
        {
            var stack = new Stack<double>();

            while (rpn.Count > 0)
            {
                string token = rpn.Dequeue();
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(ApplyOperator(token, a, b));
                }
            }

            return stack.Pop();
        }

        private static double ApplyOperator(string op, double a, double b)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException();
                    return a / b;
                default:
                    throw new InvalidOperationException($"Unknown operator: {op}");
            }
        }
    }
}
