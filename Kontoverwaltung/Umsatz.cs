namespace Kontoverwaltung
{
    class Umsatz
    {

        public Umsatz(Buchungsart buchungsart, double menge)
        {
            Buchungsart = buchungsart;
            Menge = menge;
        }

        public Buchungsart Buchungsart { get; set; }

        public double Menge { get; set; }
    }
}