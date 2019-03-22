using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Kontoverwaltung
{
    abstract class Konto
    {
        public string Nummer { get; }

        public string inhaber;

        public List<Umsatz> umsätze { get; }

        public abstract string Type { get; }

        public double Kontostand
        {
            get
            {
                double kontostand = 0.0;
                foreach (Umsatz umsatz in umsätze)
                {
                    if (umsatz.Buchungsart == Buchungsart.Einzahlung)
                    {
                        kontostand += umsatz.Menge;
                    }
                    else if (umsatz.Buchungsart == Buchungsart.Auszahlung)
                    {
                        kontostand -= umsatz.Menge;
                    }
                }

                return kontostand;
            }
            set => Kontostand = value;
        }
        protected double Zinssatz { get; set; }

        public Konto(string inhaber, double zinssatz)
        {
            this.inhaber = inhaber;
            this.Nummer = (new Random().Next()).ToString();
            this.umsätze = new List<Umsatz>();
            this.Zinssatz = zinssatz;
        }

        public void Einzahlen(double menge)
        {
            this.umsätze.Add(new Umsatz(Buchungsart.Einzahlung, menge));
        }

        public void Auszahlen(double menge)
        {
            this.umsätze.Add(new Umsatz(Buchungsart.Auszahlung, menge));
        }
    }
}
