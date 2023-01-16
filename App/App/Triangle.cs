using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        
        public Triangle()
        {

        }

        public Triangle(double a, double b, double c)
        {
            (A, B, C) = (a, b, c);

            if(!this.IsValid())
            {
                throw new ArgumentException($"({A}, {B}, {C}) is not valid triangle");
            }
        }

        public bool IsValid()
        {
            if (A <= 0 || B <= 0 || C <= 0) return false;

            return (A + B > C) && (A + C > B) && (B + C > A);
        }

        public bool IsRight()
        {
            double epsilon = 1e-14;

            return IsValid() && (
                Math.Abs(A*A + B*B - C*C) < epsilon * C*C 
                || 
                Math.Abs(C *C + B*B - A*A) < epsilon * C*C
                || 
                Math.Abs(A*A + C*C - B*B) < epsilon * C*C);
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public override bool Equals(object? obj)   
        {  
            if (obj is Triangle t2)
            {
                List<double> t1list = new List<double>() { A, B, C };
                List<double> t2list = new List<double>() { t2.A, t2.B, t2.C };

                t1list.Sort();
                t2list.Sort();

                return t1list[0] == t2list[0] && t1list[1] == t2list[1] && t1list[2] == t2list[2];
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
