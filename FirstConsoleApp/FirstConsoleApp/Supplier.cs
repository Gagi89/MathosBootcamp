using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public class Supplier : Data
    {
        public int SupplierID { get; set; }
        public string Iban { get; set; }
        public List<Supplier> suppliers = new List<Supplier>();
        public void InputSupplier ()
        { 
            Supplier supplier = new Supplier();
            var InputKey = "";
            do
            {
                int i = 1;
                supplier.SupplierID = i;
                Console.WriteLine("Enter the name of the supplier: ");
                supplier.Name = Console.ReadLine();
                Console.WriteLine("Enter the adress of the supplier: ");
                supplier.Adress = Console.ReadLine();
                Console.WriteLine("Enter OIB of the supplier: ");
                supplier.Oib = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter IBAN of the supplier: ");
                supplier.Iban = Console.ReadLine();
                suppliers.Add(supplier);
                Console.WriteLine("To return to main menu press +, otherwise continue");
                InputKey = Console.ReadLine();
                i++;
            } while (InputKey != "+");
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
