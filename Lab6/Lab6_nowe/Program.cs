using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public class Student
        {
            public int StudentId { get; set; }
            public string Imie { get; set; } = "";
            public string Nazwisko { get; set; } = "";
            public List<Ocena> Oceny { get; set; } = new();
        }
        public class Ocena
        {
            public int OcenaId { get; set; }
            public double Wartosc { get; set; }
            public string Przedmiot { get; set; } = "";
            public int StudentId { get; set; }
        }
    }
}
