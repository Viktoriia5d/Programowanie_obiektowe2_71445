using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface IModular
    {
        double Module();
    }

    // zad 1
    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
    {
        private double re;
        private double im;
        public double Re { get => re; set => re = value; }
        public double Im { get => im; set => im = value; }

        public ComplexNumber(double re, double im)
        {
            this.re = re; this.im = im;
        }

        public override string ToString()
        {
            string sign = im >= 0 ? "+" : "-";
            return $"{re} {sign} {Math.Abs(im)}i";
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re + b.re, a.im + b.im);

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re - b.re, a.im - b.im);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);

        public static ComplexNumber operator -(ComplexNumber a)
            => new ComplexNumber(a.re, -a.im);

        public object Clone() => new ComplexNumber(re, im);

        public bool Equals(ComplexNumber other)
        {
            if (other == null) return false;
            return re == other.re && im == other.im;
        }

        public override bool Equals(object obj)
            => obj is ComplexNumber other && Equals(other);

        public override int GetHashCode()
        {
            // zminałam na wersje dla C# 7.3
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + re.GetHashCode();
                hash = hash * 23 + im.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
            => a?.Equals(b) ?? b is null;

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
            => !(a == b);

        public double Module()
            => Math.Sqrt(re * re + im * im);

        // zad 1
        public int CompareTo(ComplexNumber other)
        {
            if (other == null) return 1;
            return this.Module().CompareTo(other.Module());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // zad 2
            ComplexNumber[] tablica = new ComplexNumber[]
            {
                new ComplexNumber(3, 4),
                new ComplexNumber(1, -2),
                new ComplexNumber(5, 12),
                new ComplexNumber(2, -1),
                new ComplexNumber(0, 3)
            };

            // zad 2a
            Console.WriteLine("2a Wypisanie tablicy za pomocą foreach:");
            foreach (var liczba in tablica)
            {
                Console.WriteLine($"  {liczba}");
            }

            // zad 2b
            Console.WriteLine("\n2b Tablica posortowana według modułu:");
            Array.Sort(tablica);
            foreach (var liczba in tablica)
            {
                Console.WriteLine($"  {liczba} (moduł: {liczba.Module():F2})");
            }

            // zad 2c
            Console.WriteLine("\n2c Minimum i maksimum tablicy:");
            ComplexNumber min = tablica.Min();
            ComplexNumber max = tablica.Max();
            Console.WriteLine($"  Minimum: {min} (moduł: {min.Module():F2})");
            Console.WriteLine($"  Maksimum: {max} (moduł: {max.Module():F2})");

            // zad 2d
            Console.WriteLine("\n2d Filtrowanie - usunięcie liczb z ujemną częścią urojoną:");
            var tablicaFiltrowana = tablica.Where(z => z.Im >= 0).ToArray();
            foreach (var liczba in tablicaFiltrowana)
            {
                Console.WriteLine($"  {liczba}");
            }

            // zad 3
            List<ComplexNumber> lista = new List<ComplexNumber>
            {
                new ComplexNumber(3, 4),
                new ComplexNumber(1, -2),
                new ComplexNumber(5, 12),
                new ComplexNumber(2, -1),
                new ComplexNumber(0, 3),
                new ComplexNumber(6, -8)
            };

            Console.WriteLine("Lista początkowa:");
            WypiszListe(lista);

            Console.WriteLine("\nLista posortowana według modułu:");
            lista.Sort();
            WypiszListe(lista);

            Console.WriteLine("\nLista po odfiltrowaniu liczb z ujemną częścią urojoną:");
            var listaFiltrowana = lista.Where(z => z.Im >= 0).ToList();
            WypiszListe(listaFiltrowana);

            // zad 3a
            Console.WriteLine("\n3a Usunięcie drugiego elementu z listy:");
            lista.RemoveAt(1);
            WypiszListe(lista);

            // zad 3b
            Console.WriteLine("\n3b Usunięcie najmniejszego elementu z listy:");
            ComplexNumber najmniejszy = lista.Min();
            lista.Remove(najmniejszy);
            WypiszListe(lista);

            // zad 3c
            Console.WriteLine("\n3c Wyczyszczenie całej listy:");
            lista.Clear();
            Console.WriteLine($"  Lista ma {lista.Count} elementów");
            WypiszListe(lista);

            // zad 4
            HashSet<ComplexNumber> zbior = new HashSet<ComplexNumber>
            {
                new ComplexNumber(6, 7),
                new ComplexNumber(1, 2),
                new ComplexNumber(6, 7),
                new ComplexNumber(1, -2),
                new ComplexNumber(-5, 9)
            };

            // zad 4a
            Console.WriteLine("\n4a Zawartość zbioru (duplikaty automatycznie usunięte):");
            foreach (var liczba in zbior)
            {
                Console.WriteLine($"  {liczba}");
            }
            Console.WriteLine($"  Liczba elementów w zbiorze: {zbior.Count}");

            // zad 4b
            Console.WriteLine("\n4b Minimum i maksimum zbioru:");
            ComplexNumber minZbior = zbior.Min();
            ComplexNumber maxZbior = zbior.Max();
            Console.WriteLine($"  Minimum: {minZbior} (moduł: {minZbior.Module():F2})");
            Console.WriteLine($"  Maksimum: {maxZbior} (moduł: {maxZbior.Module():F2})");

            Console.WriteLine("\nZbiór posortowany według modułu:");
            var zbiorPosortowany = zbior.OrderBy(z => z.Module()).ToList();
            foreach (var liczba in zbiorPosortowany)
            {
                Console.WriteLine($"  {liczba} (moduł: {liczba.Module():F2})");
            }

            Console.WriteLine("\nZbiór po odfiltrowaniu liczb z ujemną częścią urojoną:");
            var zbiorFiltrowany = zbior.Where(z => z.Im >= 0);
            foreach (var liczba in zbiorFiltrowany)
            {
                Console.WriteLine($"  {liczba}");
            }

            // zad 5
            Dictionary<string, ComplexNumber> slownik = new Dictionary<string, ComplexNumber>
            {
                { "z1", new ComplexNumber(6, 7) },
                { "z2", new ComplexNumber(1, 2) },
                { "z3", new ComplexNumber(6, 7) },
                { "z4", new ComplexNumber(1, -2) },
                { "z5", new ComplexNumber(-5, 9) }
            };

            // zad 5a
            Console.WriteLine("5a Wszystkie elementy słownika (klucz, wartość):");
            foreach (var para in slownik)
            {
                Console.WriteLine($"  ({para.Key}, {para.Value})");
            }

            // zad 5b
            Console.WriteLine("\n5b Wszystkie klucze:");
            foreach (var klucz in slownik.Keys)
            {
                Console.Write($"  {klucz}");
            }
            Console.WriteLine("\n\nWszystkie wartości:");
            foreach (var wartosc in slownik.Values)
            {
                Console.WriteLine($"  {wartosc}");
            }

            // zad 5c
            Console.WriteLine("\n5c Sprawdzenie czy istnieje klucz 'z6':");
            bool czyIstnieje = slownik.ContainsKey("z6");
            Console.WriteLine($"  Czy istnieje klucz 'z6': {czyIstnieje}");

            // zad 5d
            Console.WriteLine("\n5d Minimum i maksimum wartości ze słownika:");
            ComplexNumber minSlownik = slownik.Values.Min();
            ComplexNumber maxSlownik = slownik.Values.Max();
            Console.WriteLine($"  Minimum: {minSlownik} (moduł: {minSlownik.Module():F2})");
            Console.WriteLine($"  Maksimum: {maxSlownik} (moduł: {maxSlownik.Module():F2})");

            Console.WriteLine("\nWartości z nieujemną częścią urojoną:");
            var slownikFiltrowany = slownik.Where(para => para.Value.Im >= 0);
            foreach (var para in slownikFiltrowany)
            {
                Console.WriteLine($"  {para.Key}: {para.Value}");
            }

            // zad 5e
            Console.WriteLine("\n5e Usunięcie elementu o kluczu 'z3':");
            slownik.Remove("z3");
            foreach (var para in slownik)
            {
                Console.WriteLine($"  ({para.Key}, {para.Value})");
            }

            // zad 5f
            Console.WriteLine("\n5f Usunięcie drugiego elementu ze słownika:");
            var drugiKlucz = slownik.Keys.ElementAt(1);
            slownik.Remove(drugiKlucz);
            foreach (var para in slownik)
            {
                Console.WriteLine($"  ({para.Key}, {para.Value})");
            }

            // zad 5g
            Console.WriteLine("\n5g Wyczyszczenie słownika:");
            slownik.Clear();
            Console.WriteLine($"  Słownik ma {slownik.Count} elementów");
        }

        static void WypiszListe(List<ComplexNumber> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("  (lista pusta)");
            }
            else
            {
                foreach (var liczba in lista)
                {
                    Console.WriteLine($"  {liczba}");
                }
            }
        }
    }
}
