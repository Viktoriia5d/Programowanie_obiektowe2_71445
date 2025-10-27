using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// komentarz
namespace Programowanie_obiektowe_71445.Laboratorium
{
    internal class Lab2
    {
    }
}

namespace Zwierzeta
{

    class Program
    {
        public static void Main()
        {
            // zad 10
            Piekarz piekarz = new Piekarz();
            piekarz.Pracuj();


        }

    }

    // Laboratorium 2
    // zadania 1



    namespace Zwierzeta { }

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
        // zadania 6
        public static void powiedz_cos(Zwierze z)
        {
            z.daj_glos();
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
    public class Kot : Zwierze
    {
        public Kot(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi miau miau");
        }

    }

    // zadania 4
    public class Waz : Zwierze
    {
        public Waz(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi sssss");
        }
    }


    // zadania 7

    // zadania 8

    public abstract class Pracownik
    {
        public abstract void Pracuj();
    }

    // zadania 9

    public class Piekarz : Pracownik 
    {
        public override void Pracuj()
        {
            Console.WriteLine("Trwa pieczenie....");
        }
    }



}
