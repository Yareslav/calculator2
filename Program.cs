using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace console1
{
    class Program
    {
        public delegate double calculator(double x, double y);
        public static event calculator Calculate;
        static void Main()
        {
            double Add(double x, double y) => x + y;
            double Sub(double x, double y) => x - y;
            double Mul(double x, double y) => x * y;
            double Div(double x, double y) => y == double.PositiveInfinity ? 0 : x / y;
            string input = Console.ReadLine();
            var actions = new string[] { "/", "*", "-", "+" };
            var signAndNumbersMass = new List<dynamic>();
            foreach (var item in actions)
            {
                input = input.Replace(item, "#" + item + "#");
            }
            var stringsMass = input.Split("#");
            foreach (var item in stringsMass)
            {
                double number;
                if (double.TryParse(item, out number)) signAndNumbersMass.Add(number);
                else signAndNumbersMass.Add(item);
            }
            Calculate -= Add;
            Calculate -= Sub;
            Calculate -= Mul;
            Calculate -= Div;
            string type = signAndNumbersMass[1];
            if (type == "+") Calculate += Add;
            else if (type == "-") Calculate += Sub;
            else if (type == "*") Calculate += Mul;
            else Calculate += Div;
            Console.WriteLine(Calculate(signAndNumbersMass[0], signAndNumbersMass[2]));
        }
        
    }
}
