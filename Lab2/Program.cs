using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // zad 1
    class Zwierze
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

    // zad 2
    class Pies : Zwierze
    {
        public Pies(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi woof woof!");
        }
    }

    // zad 3
    class Kot : Zwierze
    {
        public Kot(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi miau miau!");
        }
    }

    // zad 4
    class Waz : Zwierze
    {
        public Waz(string nazwa) : base(nazwa) { }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi ssssssss!");
        }
    }

    // zad 6
    class Program
    {
        static void powiedz_cos(Zwierze z)
        {
            z.daj_glos();
            Console.WriteLine($"Typ obiektu: {z.GetType().Name}");
            Console.WriteLine();
        }

        static void Main()
        {
            // zad 7
            Zwierze z1 = new Zwierze("Zwierzątko");
            Pies p1 = new Pies("Burek");
            Kot k1 = new Kot("Mruczek");
            Waz w1 = new Waz("Python");

            powiedz_cos(z1);
            powiedz_cos(p1);
            powiedz_cos(k1);
            powiedz_cos(w1);

            // zad 8 i 9
            Piekarz piekarz = new Piekarz();
            piekarz.Pracuj();

            // zad 11, utworzenia obiektu klasy abstrakcyjnej
            /* Pracownik p = new Pracownik(); 
             nie można tworzyć obiektów klasy abstrakcyjnej */

            Console.WriteLine();

            // zad 12–15 
            A a = new A();
            Console.WriteLine();

            B b = new B();
            Console.WriteLine();

            C c = new C();

            Console.ReadKey();
        }
    }

    // zad 8
    abstract class Pracownik
    {
        public abstract void Pracuj();
    }

    // zad 9
    class Piekarz : Pracownik
    {
        public override void Pracuj()
        {
            Console.WriteLine("Trwa pieczenie...");
        }
    }

    // zad 12
    class A
    {
        public A()
        {
            Console.WriteLine("To jest konstruktor A");
        }
    }

    // zad 13. klasa B dziedzicząca po A
    class B : A
    {
        public B() : base()
        {
            Console.WriteLine("To jest konstruktor B");
        }
    }

    // zad 14. klasa C dziedzicząca po B
    class C : B
    {
        public C() : base()
        {
            Console.WriteLine("To jest konstruktor C");
        }
    }
}
