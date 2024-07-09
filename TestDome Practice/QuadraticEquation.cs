using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
    /*
    
    Implement the function FindRoots to find the roots of the quadratic equation: ax2 + bx + c = O. The
    function should return a tuple containing roots in any order. If the equation has only one solution, the
    function should return that solution as both elements of the tuple. The equation will always have at least
    one solution.

    x = (-b +- sqrt(b^2 - 4ac)) / 2a

    For example, FindRoots(2, 10, 8) should return (-1, -4) or (-4, -1) as the roots of the equation 2x^2 + 10X + 8 =
    0 are -1 and -4.

    */


    internal static class QuadraticEquation
    {
        public static Tuple<double, double> FindRoots(double a, double b, double c)
        {
            var root1 = ((b * -1) + Math.Sqrt(Math.Pow(b, 2) - (4*a*c))) / (2*a);
            var root2 = ((b * -1) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);

            return new Tuple<double, double>(root1, root2);
        }

        public static void Main_QuadraticEquation()
        {
            Tuple<double, double> roots = QuadraticEquation.FindRoots(2, 10, 8);
            Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
        }
    }
}
