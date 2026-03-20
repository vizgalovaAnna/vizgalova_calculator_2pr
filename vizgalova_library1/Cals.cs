using System;
using System.Collections.Generic;
using System.Globalization;

namespace vizgalova_library1
{
    public static class Calc
    {
        public static double Add(double x, double y) => x + y;
        public static double Sub(double x, double y) => x - y;
        public static double Mul(double x, double y) => x * y;
        public static double Div(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException("Деление на ноль");
            return x / y;
        }
        public static double Pow(double x, double y) => Math.Pow(x, y);

        public static double Calculate(string exp)
        {
            try
            {
                exp = exp.Replace(',', '.');
                exp = exp.Replace(" ", "");
                System.Diagnostics.Debug.WriteLine("Выражение: " + exp);
                if (exp.StartsWith("-"))
                    exp = "0" + exp;
                while (exp.Contains("("))
                {
                    int start = exp.LastIndexOf('(');
                    int end = exp.IndexOf(')', start);
                    if (start == -1 || end == -1)
                        throw new Exception("Надо закрыть скобки");
                    string subExp = exp.Substring(start + 1, end - start - 1);
                    if (subExp.StartsWith("-"))
                        subExp = "0" + subExp;
                    double subRes = SimpleCalculate(subExp);
                    exp = exp.Substring(0, start) + subRes.ToString(CultureInfo.InvariantCulture) + exp.Substring(end + 1);
                }
                return SimpleCalculate(exp);
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка: " + ex.Message);
            }
        }
        private static double SimpleCalculate(string exp)
        {
            List<string> parts = new List<string>();
            string num = "";

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                bool isOp = (c == '+' || c == '*' || c == '/' || c == '^');
                bool isMinus = (c == '-' && i > 0 && exp[i - 1] != '(' && exp[i - 1] != '+' && exp[i - 1] != '-' && exp[i - 1] != '*' && exp[i - 1] != '/' && exp[i - 1] != '^');
                if (isOp || isMinus)
                {
                    if (num != "")
                    {
                        parts.Add(num);
                        num = "";
                    }
                    parts.Add(c.ToString());
                }
                else
                {
                    num += c;
                }
            }
            if (num != "")
                parts.Add(num);
            for (int i = 1; i < parts.Count - 1; i++)
            {
                if (parts[i] == "^")
                {
                    double a = double.Parse(parts[i - 1], CultureInfo.InvariantCulture);
                    double b = double.Parse(parts[i + 1], CultureInfo.InvariantCulture);
                    double r = Pow(a, b);
                    parts[i - 1] = r.ToString(CultureInfo.InvariantCulture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 1; i < parts.Count - 1; i++)
            {
                if (parts[i] == "*" || parts[i] == "/")
                {
                    double a = double.Parse(parts[i - 1], CultureInfo.InvariantCulture);
                    double b = double.Parse(parts[i + 1], CultureInfo.InvariantCulture);
                    double r = parts[i] == "*" ? Mul(a, b) : Div(a, b);
                    parts[i - 1] = r.ToString(CultureInfo.InvariantCulture);
                    parts.RemoveAt(i);
                    parts.RemoveAt(i);
                    i--;
                }
            }
            double res = double.Parse(parts[0], CultureInfo.InvariantCulture);
            for (int i = 1; i < parts.Count - 1; i += 2)
            {
                double b = double.Parse(parts[i + 1], CultureInfo.InvariantCulture);
                res = parts[i] == "+" ? Add(res, b) : Sub(res, b);
            }
            return res;
        }
        public static double Execute(double a, char op, double b)
        {
            switch (op)
            {
                case '+': return Add(a, b);
                case '-': return Sub(a, b);
                case '*': return Mul(a, b);
                case '/': return Div(a, b);
                case '^': return Pow(a, b);
                default: return 0;
            }
        }
    }
}