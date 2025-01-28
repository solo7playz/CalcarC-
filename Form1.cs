using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calcar
{
    public partial class Form1 : Form
    {
        public List<System.Windows.Forms.Button> arrOfButtons = new List<System.Windows.Forms.Button>(20);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void FillList()
        {
            arrOfButtons.Add(num1);
            arrOfButtons.Add(num2);
            arrOfButtons.Add(num3);
            arrOfButtons.Add(num4);
            arrOfButtons.Add(num5);
            arrOfButtons.Add(num6);
            arrOfButtons.Add(num7);
            arrOfButtons.Add(num8);
            arrOfButtons.Add(num9);
            arrOfButtons.Add(zero);
            arrOfButtons.Add(ravno);
            arrOfButtons.Add(sum);
            arrOfButtons.Add(root);
            arrOfButtons.Add(point);
            arrOfButtons.Add(division);
            arrOfButtons.Add(multiplication);
            arrOfButtons.Add(substraction);
            arrOfButtons.Add(skobkaL);
            arrOfButtons.Add(skobkaR);
            arrOfButtons.Add(square);
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

        private void square_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^";
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

        private void num3Last_Click(object sender, EventArgs e)
        {
            textBox1.Text = "You're right";
            Thread.Sleep(1000);
            Close();
        }

        private void num1Last_Click(Object sender, EventArgs e)
        {
            textBox1.Text = "You lose!";
            textBox2.Visible = false;
            for (int i = 5; i >= 0; i--)
            {
                textBox1.Text = i.ToString();
                Thread.Sleep(1000);
            }
            if (textBox1.Text == "0")
            {
                Close();
            }
        }
        private void num2Last_Click(Object sender, EventArgs e)
        {
            textBox1.Text = "You lose!";
            textBox2.Visible = false;
            for (int i = 5; i >= 0; i--)
                textBox1.Text = i.ToString();
            Thread.Sleep(1000);
            if (textBox1.Text == "0")
                Close();
        }

        private void ravno_Click(object sender, EventArgs e)
        {
            FillList();
            string resultText = "";
            string finalResult = "0+";
            string squareText = "";
            foreach (var item in textBox1.Text)
            {
                if (double.TryParse(item.ToString(), out _) == false && item != '√' && item != '+' && item != '-' && item != '*' && item != '/' && item != '(' && item != ')' && item.ToString() != square.Text && item != '.')
                {
                    foreach (var item1 in arrOfButtons)
                    {
                        item1.Visible = false;
                    }
                    textBox2.Visible = true;
                    textBox2.Text = "Реши пример, если не хочешь выключения компьютера!\n        √(1111088889 / 123454321)";
                    num3.Visible = true;
                    num1.Visible = true;
                    num2.Visible = true;
                    this.num3.Click += new System.EventHandler(num3Last_Click);
                    this.num1.Click += new System.EventHandler(num1Last_Click);
                    this.num2.Click += new System.EventHandler(num2Last_Click);
                    return;
                }
            }
            textBox1.Text += "+0";
            for (int i = 0; i < textBox1.Text.Length; ++i)
            {
                if (textBox1.Text[i] != '√'/* && textBox1.Text[i].ToString() != square.Text*/) finalResult += textBox1.Text[i];

                if (textBox1.Text[i] == '√')
                {
                    if (textBox1.Text[i + 1] == '-')
                    {
                        return;
                    }
                    else
                    {
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
                    }
                }
                //if (textBox1.Text[i].ToString() == square.Text)
                //{
                //    for(int j = i - 1; j > 0; --j)
                //    {
                //        if(textBox1.Text[j] == '+' || textBox1.Text[j] == '-' || textBox1.Text[j] == '*' || textBox1.Text[j] == '/' || textBox1.Text[j] == ')' || textBox1.Text[j] == '(')
                //        {
                //            finalResult += (double.Parse(squareText) * double.Parse(squareText)).ToString();
                //            i += squareText.Length-1;
                //            MessageBox.Show(squareText);
                //            break;
                //        }
                //        else
                //        {
                //            squareText += textBox1.Text[j];
                //        }
                //    }
                //}
                resultText = "";
            }
            //var result = Parse(finalResult);
            //finalResult = null;
            //textBox1.Clear();
            //textBox1.Text = result.ToString();
            // Заменим "sqrt" на "Math.Sqrt()" для корректной работы
            ExpressionEvaluator calcar = new ExpressionEvaluator();
            calcar.Evaluate(finalResult, textBox1);
            textBox1.Clear();
            textBox1.Text = calcar.Evaluate(finalResult, textBox1).ToString();
        }
    }
    public class ExpressionEvaluator
    {
        public double Evaluate(string expression, System.Windows.Forms.TextBox textbox)
        {
            var tokens = Tokenize(expression);
            var rpn = ConvertToReversePolishNotation(tokens);
            return CalculateRPN(rpn, textbox);
        }

        private static Queue<string> Tokenize(string expression)
        {
            var tokens = new Queue<string>();
            var currentToken = "";

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    currentToken += c;
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
                        tokens.Enqueue(c.ToString());
                    }
                }
            }

            if (currentToken != "")
            {
                tokens.Enqueue(currentToken);
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

                if (double.TryParse(token, out _))
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
                    operatorStack.Pop();
                }
                else
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
                case "^":
                    return 2;
                default:
                    return 0;
            }
        }

        private static double CalculateRPN(Queue<string> rpn, System.Windows.Forms.TextBox textbox)
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
                    stack.Push(ApplyOperator(token, a, b, textbox));
                }
            }

            return stack.Pop();
        }

        private static double ApplyOperator(string op, double a, double b, System.Windows.Forms.TextBox textbox)
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
                    if (b == 0) textbox.Text = "Ты дурак или притворяешься?\nlim->∞";
                    return a / b;
                case "^":
                    double tmp = a;
                    for (int i = 0; i < b - 1; ++i)
                    {
                        tmp *= a;
                    }
                    return tmp;
                default:
                    textbox.Text = $"Unknown operator: {op}";
                    return 0;
            }
        }
    }
}