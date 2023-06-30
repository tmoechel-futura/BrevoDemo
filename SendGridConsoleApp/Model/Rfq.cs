using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrevoConsoleApp.Model
{
    internal class Rfq
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string ClosingDate { get; set; }

        public string ContactPersonName { get; set; }
        public string ContactPersonEmail { get; set; }
    }
}
