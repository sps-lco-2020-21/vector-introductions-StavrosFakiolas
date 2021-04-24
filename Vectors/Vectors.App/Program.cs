using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> l1 = new List<double> { 2, 5, 6};
            List<double> l2 = new List<double> { 1, 5};
            List<double> l3 = new List<double> { 0, 5, 10 };
            Vector myVector1 = new Vector(l1);
            Vector myVector2 = new Vector(l2);
            Vector myVector3 = new Vector(l3);
            Vector addition = myVector1.Add(myVector2);
            myVector1.DotProductA(myVector2);
            Console.ReadKey();
        }
    }
}
