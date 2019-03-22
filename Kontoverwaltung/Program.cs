using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontoverwaltung
{
    class Program
    {
        private static List<Konto> konten;

        static void Main(string[] args)
        {
            konten = new List<Konto>();
            while (Menu() == 0);
        }

        private static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Kontoverwaltung");
            Console.WriteLine("===============\n");
            Console.WriteLine("1. Neues Konto anlegen");
            Console.WriteLine("2. Konten anzeigen");
            Console.WriteLine("3. Einzahlen");
            Console.WriteLine("4. Auszahlen");
            Console.WriteLine();
            Console.WriteLine("0. Beenden");

            Console.Write("Ihre Eingabe: ");
            ConsoleKey eingabe = Console.ReadKey().Key;

            switch (eingabe) {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    kontoErstellen();
                    return 0;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    kontenAnzeigen();
                    return 0;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    einzahlen();
                    return 0;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    auszahlen();
                    return 0;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    return 1;
                default:
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe");
                    Console.ReadKey();
                    return 0;
            }
        }

        private static void kontoErstellen()
        {
            Console.Clear();
            Console.WriteLine("Ihr Name: ");
            string name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Art des Kontos:");
            Console.WriteLine("1. Sparkonto");
            Console.WriteLine("2. Kontokorrent");

            ConsoleKey eingabe = Console.ReadKey().Key;
            Konto konto = null;
            switch (eingabe)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    konto = new Sparkonto(name, 1.0);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    konto = new Kontokorrent(name, 1.0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe");
                    Console.ReadKey();
                    return;
            }
            Console.Clear();
            Console.WriteLine("Konto {0} wurde erstellt", konto.Nummer);
            Console.ReadKey();

            konten.Add(konto);
        }

        private static void kontenAnzeigen()
        {
            Console.Clear();

            foreach(Konto konto in konten)
            {
                kontoAusgeben(konto);
            }

            Console.ReadKey();
            
        }

        private static void kontoAusgeben(Konto konto)
        {
            Console.WriteLine("Konto: " + konto.Nummer.ToString());
            Console.WriteLine("Inhaber: " + konto.inhaber.ToString());
            Console.WriteLine("Art des Kontos: " + konto.Type);
            Console.WriteLine("Kontostand: " + konto.Kontostand + " EUR");
            Console.WriteLine("Umsätze:");
            Console.WriteLine();
            konto.umsätze.ForEach((umsatz) => Console.WriteLine("{0}\t\t{1} EUR", umsatz.Buchungsart.ToString(), umsatz.Menge));

            Console.WriteLine();
        }

        private static void einzahlen()
        {
            Console.Clear();
            Console.WriteLine("Geben Sie eine Kontonummer ein: ");
            string kontonummer = Convert.ToString(Console.ReadLine());

            Konto konto = konten.Find(matchedKonto => matchedKonto.Nummer == kontonummer);
            if (konto != null)
            {
                Console.Clear();

                Console.WriteLine("{0}, wie viel möchten Sie einzahlen?", konto.inhaber);
                try {
                    double betrag = Convert.ToDouble(Console.ReadLine());
                    konto.Einzahlen(betrag);
                } catch
                {
                    Console.WriteLine("Falsche Eingabe");
                    Console.ReadKey();
                    return;
                }
                
                Console.Clear();
                Console.WriteLine("Ihr neuer Kontostand beträgt {0}", konto.Kontostand.ToString());
            }

            Console.ReadKey();
        }

        private static void auszahlen()
        {
            Console.Clear();

            Console.Clear();
            Console.WriteLine("Geben Sie eine Kontonummer ein: ");
            string kontonummer = Convert.ToString(Console.ReadLine());

            Konto konto = konten.Find(matchedKonto => matchedKonto.Nummer == kontonummer);
            if (konto != null)
            {
                Console.Clear();

                Console.WriteLine("{0}, wie viel möchten Sie abheben?", konto.inhaber);
                try
                {
                    double betrag = Convert.ToDouble(Console.ReadLine());
                    konto.Auszahlen(betrag);
                }
                catch
                {
                    Console.WriteLine("Falsche Eingabe");
                    Console.ReadKey();
                    return;
                }
                Console.Clear();
                Console.WriteLine("Ihr neuer Kontostand beträgt {0} EUR", konto.Kontostand.ToString());
            }



        }
    }
}
