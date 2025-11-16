using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    // zad 2
    public interface IModular
    {
        double Module();
    }

    // zad 1 i 3
    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular
    {
        private double re;
        private double im;

        public double Re
        {
            get => re;
            set => re = value;
        }

        public double Im
        {
            get => im;
            set => im = value;
        }

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            string imPart;
            if (im >= 0)
                imPart = $"+ {im}i";
            else
                imPart = $"- {Math.Abs(im)}i";

            return $"{re} {imPart}";
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re + b.re, a.im + b.im);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re - b.re, a.im - b.im);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double real = a.re * b.re - a.im * b.im;
            double imag = a.re * b.im + a.im * b.re;
            return new ComplexNumber(real, imag);
        }

        public static ComplexNumber operator -(ComplexNumber a)
        {
            return new ComplexNumber(a.re, -a.im);
        }

        public object Clone()
        {
            return new ComplexNumber(this.re, this.im);
        }

        public bool Equals(ComplexNumber other)
        {
            if (ReferenceEquals(other, null)) return false;
            double eps = 1e-9;
            return Math.Abs(this.re - other.re) < eps && Math.Abs(this.im - other.im) < eps;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ComplexNumber);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + re.GetHashCode();
                hash = hash * 23 + im.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        public double Module()
        {
            return Math.Sqrt(re * re + im * im);
        }
    }

    // zad 4
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lab3 - liczby zespolone (ComplexNumber)\n");

            
            ComplexNumber z1 = new ComplexNumber(3, 4);
            ComplexNumber z2 = new ComplexNumber(1, -2);
            ComplexNumber z3 = new ComplexNumber(3, 4);

            Console.WriteLine("z1 = " + z1);
            Console.WriteLine("z2 = " + z2);
            Console.WriteLine("z3 = " + z3);
            Console.WriteLine();

            var suma = z1 + z2;
            Console.WriteLine($"z1 + z2 = {suma}");

            var roznica = z1 - z2;
            Console.WriteLine($"z1 - z2 = {roznica}");

            var iloczyn = z1 * z2;
            Console.WriteLine($"z1 * z2 = {iloczyn}");

            var sprzezenie = -z2;
            Console.WriteLine($"sprzezenie z2 = {sprzezenie}");

            var kopia = (ComplexNumber)z1.Clone();
            Console.WriteLine($"kopia z1 = {kopia}");

            Console.WriteLine($"z1.Equals(z3) = {z1.Equals(z3)}");
            Console.WriteLine($"z1 == z3 : {z1 == z3}");
            Console.WriteLine($"z1 != z2 : {z1 != z2}");

            Console.WriteLine($"|z1| = {z1.Module()}");

            Console.WriteLine("\nNaciśnij Enter aby zakończyć.");
            Console.ReadLine();
        }
    }
}
