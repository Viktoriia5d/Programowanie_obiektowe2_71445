using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        // Zad 2
        static void ZapiszDoPliku()
        {
            using (StreamWriter writer = new StreamWriter("dane.txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Wprowadź tekst {i + 1}: ");
                    string tekst = Console.ReadLine();
                    writer.WriteLine(tekst);
                }
            }

            Console.WriteLine("Dane zostały zapisane do pliku.");
        }

        // Zad 3
        static void OdczytajZPliku()
        {
            try
            {
                if (File.Exists("dane.txt"))
                {
                    using (StreamReader reader = new StreamReader("dane.txt"))
                    {
                        string linia;
                        while ((linia = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(linia);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Plik 'dane.txt' nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
            }
        }

        // Zad 4
        static void DopiszDoPliku()
        {
            using (StreamWriter writer = new StreamWriter("dane.txt", true))
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Dopisz tekst {i + 1}: ");
                    string tekst = Console.ReadLine();
                    writer.WriteLine(tekst);
                }
            }

            Console.WriteLine("Dane zostały dopisane do pliku.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zapisz dane do pliku");
            Console.WriteLine("2. Odczytaj dane z pliku");
            Console.WriteLine("3. Dopisz dane do pliku");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    ZapiszDoPliku();
                    break;
                case "2":
                    OdczytajZPliku();
                    break;
                case "3":
                    DopiszDoPliku();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór!");
                    break;
            }
        }
    }
}
