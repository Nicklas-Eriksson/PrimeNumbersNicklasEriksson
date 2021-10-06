using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeNumbersNicklasEriksson.UI;

namespace PrimeNumbersNicklasEriksson
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppMenu();
            app.Menu();
        }
    }
}
