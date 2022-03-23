using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public class List
    {
        public void SupplierList()
        {
            Supplier supplier = new Supplier();
            List<Supplier> supplierlist = supplier.suppliers;
            foreach (var member in supplierlist)
            {
                Console.WriteLine($"Supplier's ID: {member.SupplierID}\t\t\tSupplier's name: {member.Name}\t\t\tSupplier's adress: {member.Adress}\t\t\tSupplier's IBAN: ddd{member.Iban}");
                Console.ReadLine();
            }
        }
    }
}
