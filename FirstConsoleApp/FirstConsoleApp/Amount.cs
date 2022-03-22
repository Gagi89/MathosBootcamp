using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public abstract class Amount
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual int GetQuantity()
        {
            return Quantity;
        }
        public virtual int GetPrice()
        {
            return Price;
        }
    }
}
