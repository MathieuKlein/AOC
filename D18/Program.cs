using System;
using System.IO;
using System.Linq;

namespace D18
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var result = strings.Sum(expression => EvaluateString(expression, EvaluationMethod1));

            Console.WriteLine(result);

            result = strings.Sum(expression => EvaluateString(expression, EvaluationMethod2));

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static long EvaluateString(string expression, Func<string, long> evaluator)
        {
            var nouvelleExpression = expression;
            while (nouvelleExpression.Contains('('))
            {
                var substring = FindDeepestExpression(nouvelleExpression);
                nouvelleExpression = nouvelleExpression.Replace($"({substring})", evaluator(substring).ToString());
            }

            var evaluate2 = evaluator(nouvelleExpression);
            return evaluate2;
        }

        private static string FindDeepestExpression(string nouvelleExpression)
        {
            var positionDeepestParenthesis = FindOpeningDeepestParenthesis(nouvelleExpression);
            var positionDeepestClosingParenthesis = FindClosingParenthesis(nouvelleExpression, positionDeepestParenthesis);

            return nouvelleExpression.Substring(positionDeepestParenthesis + 1, positionDeepestClosingParenthesis - positionDeepestParenthesis - 1);
        }

        private static int FindClosingParenthesis(string nouvelleExpression, int positionOpeningParenthesis)
        {
            var positionClosingParenthesis = 0;

            for (var i = positionOpeningParenthesis; i < nouvelleExpression.Length; i++)
                if (nouvelleExpression[i] == ')')
                {
                    positionClosingParenthesis = i;
                    break;
                }

            return positionClosingParenthesis;
        }

        private static long EvaluationMethod1(string expression)
        {
            var slip = expression.Split(" ");
            long result = int.Parse(slip[0]);
            string operation = string.Empty;
            for (var i = 1; i < slip.Length; i++)
            {
                var c = slip[i];

                if (int.TryParse($"{c}", out var number))
                {
                    if (operation == "+")
                    {
                        result += number;
                        operation = string.Empty;
                    }
                    else if (operation == "*")
                    {
                        result *= number;
                        operation = string.Empty;
                    }
                }
                else
                {
                    if (c == "+" || c == "*")
                        operation = c;
                }
            }

            return result;
        }

        private static long EvaluationMethod2(string expression)
        {
            var slip = expression.Split(" ").ToList();

            while (slip.Contains("+"))
            {
                var plus = slip.FindIndex(x => x == "+");
                var result2 = long.Parse(slip[plus - 1]) + long.Parse(slip[plus + 1]);
                slip[plus] = result2.ToString();
                slip.RemoveAt(plus - 1);
                slip.RemoveAt(plus);
            }

            while (slip.Contains("*"))
            {
                var time = slip.FindIndex(x => x == "*");
                var result2 = long.Parse(slip[time - 1]) * long.Parse(slip[time + 1]);
                slip[time] = result2.ToString();
                slip.RemoveAt(time - 1);
                slip.RemoveAt(time);
            }

            return long.Parse(slip[0]);
        }

        private static int FindOpeningDeepestParenthesis(string expression)
        {
            var charPos = 0;
            var parenthesis = 0;
            var maxParenthesis = 0;
            for (var i = 0; i < expression.Length; i++)
            {
                var c = expression[i];
                if (c == '(')
                {
                    parenthesis++;

                    if (parenthesis > maxParenthesis)
                    {
                        maxParenthesis = parenthesis;
                        charPos = i;
                    }
                }
                else if (c == ')')
                {
                    parenthesis--;
                }
            }

            return charPos;
        }
    }
}