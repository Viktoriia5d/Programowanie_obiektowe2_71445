using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_71445.Laboratorium
{
    internal class Lab2
    {
    }
}

// Laboratorium 2
// zadania 1

public class Zwierze
    {
        protected string nazwa;

        public Zwierze(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public virtual void daj_glos()
        {
            Console.WriteLine("...");
        }
    }

// zadania 2

public class Pies : Zwierze
{
    public Pies(string nazwa) : base(nazwa)
    { 
    }

    public override void daj_glos()
    {
        Console.WriteLine($"{nazwa} robi woof woof");
    }
}

// zadania 3 

