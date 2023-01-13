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
    }
}
