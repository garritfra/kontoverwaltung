using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontoverwaltung
{
    class Sparkonto : Konto
    {
        public Sparkonto(string inhaber, double zinssatz) : base(inhaber, zinssatz)
        {
        }

        public override string Type => "Sparkonto";
    }
}
