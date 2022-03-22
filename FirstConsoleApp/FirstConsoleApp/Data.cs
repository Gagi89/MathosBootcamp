using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public abstract class Data : IData
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Oib { get; set; }
    }
}
