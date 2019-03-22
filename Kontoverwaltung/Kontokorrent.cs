using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontoverwaltung
{
    class Kontokorrent : Konto
    {
        public Kontokorrent(string inhaber, double zinssatz) : base(inhaber, zinssatz)
        {
        }

        public override string Type => "Kontokorrent";
    }
}
