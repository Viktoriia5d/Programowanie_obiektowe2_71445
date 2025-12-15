using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Lab5
{
    // Zad 5
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<int> Oceny { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Zad 2
            Console.WriteLine("Zadanie 2: Zapis danych do pliku");
            ZapiszDaneDoPliku();

            // Zad 3
            Console.WriteLine("\nZadanie 3: Odczyt danych z pliku");
            OdczytajDaneZPliku();

            // Zad 4
            Console.WriteLine("\nZadanie 4: Dopisywanie danych do pliku");
            DopiszDaneDoPliku();

            // Zad 8
            Console.WriteLine("\nZadanie 8: Serializacja XML");
            SerializujStudentowXML();

            // Zad 9
            Console.WriteLine("\nZadanie 9: Deserializacja XML");
            DeserializujStudentowXML();

            Console.ReadKey();
        }

        // Zad 2
        static void ZapiszDaneDoPliku()
        {
            string nazwaPliku = "dane.txt";
            List<string> linie = new List<string>();

            Console.WriteLine("Podaj 3 linie tekstu:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Linia {i + 1}: ");
                string linia = Console.ReadLine();
                linie.Add(linia);
            }

            File.WriteAllLines(nazwaPliku, linie);
            Console.WriteLine($"Dane zapisano do pliku: {nazwaPliku}");
        }

        // Zad 3
        static void OdczytajDaneZPliku()
        {
            string nazwaPliku = "dane.txt";

            if (!File.Exists(nazwaPliku))
            {
                Console.WriteLine("Plik nie istnieje!");
                return;
            }

            string[] linie = File.ReadAllLines(nazwaPliku);
            Console.WriteLine("Zawartość pliku:");
            foreach (string linia in linie)
            {
                Console.WriteLine(linia);
            }
        }

        // Zad 4
        static void DopiszDaneDoPliku()
        {
            string nazwaPliku = "dane.txt";

            Console.WriteLine("Podaj 2 dodatkowe linie tekstu:");
            List<string> noweLinie = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Nowa linia {i + 1}: ");
                string linia = Console.ReadLine();
                noweLinie.Add(linia);
            }

            File.AppendAllLines(nazwaPliku, noweLinie);
            Console.WriteLine($"Dane dopisano do pliku: {nazwaPliku}");
        }

        // Zad 8
        static void SerializujStudentowXML()
        {
            List<Student> studenci = new List<Student>
            {
                new Student
                {
                    Imie = "Maria",
                    Nazwisko = "Lewandowska",
                    Oceny = new List<int> { 5, 5, 5, 4 }
                },
                new Student
                {
                    Imie = "Tomasz",
                    Nazwisko = "Dąbrowski",
                    Oceny = new List<int> { 4, 3, 4, 4 }
                },
                new Student
                {
                    Imie = "Katarzyna",
                    Nazwisko = "Szymańska",
                    Oceny = new List<int> { 5, 4, 5, 5 }
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter("studenci.xml"))
            {
                serializer.Serialize(writer, studenci);
            }
            Console.WriteLine("Studenci zapisani do pliku studenci.xml");
        }

        // Zad 9
        static void DeserializujStudentowXML()
        {
            if (!File.Exists("studenci.xml"))
            {
                Console.WriteLine("Plik studenci.xml nie istnieje!");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            List<Student> studenci;

            using (StreamReader reader = new StreamReader("studenci.xml"))
            {
                studenci = (List<Student>)serializer.Deserialize(reader);
            }

            Console.WriteLine("Lista studentów z pliku XML:");
            foreach (var student in studenci)
            {
                Console.WriteLine($"Imię: {student.Imie}");
                Console.WriteLine($"Nazwisko: {student.Nazwisko}");
                Console.WriteLine($"Oceny: {string.Join(", ", student.Oceny)}");
                Console.WriteLine();
            }
        }
    }
}
