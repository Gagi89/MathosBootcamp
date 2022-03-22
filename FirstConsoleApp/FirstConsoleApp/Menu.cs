using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public class Menu
    {
        public void MainMenu()
        {
            int Option;
            do
            {
                Console.WriteLine("Select the option:\n1 - Supplier\n2 - Buyer\n3 - Warehouse\n4 - Merchandise list\n5 - Cashier\n6 - EXIT Console\n====================");
                Option = Convert.ToInt32(Console.ReadLine());
                if (Option > 0 && Option < 6)
                {
                    switch (Option)
                    {
                        case 1:
                            {
                                Supplier supplier = new Supplier();
                                supplier.InputSupplier();
                                break;
                            }
                        case 2:
                            {
                                Buyer buyer = new Buyer();
                                buyer.InputBuyer();
                                break;
                            }
                        case 3:
                            {
                                Merchandise merchandise = new Merchandise();
                                merchandise.InputMerchandise();
                                break;
                            }
                        case 4:
                            {
                                List list = new List();
                                list.SupplierList();
                                break;
                            }
                        case 5:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("You had entered non viable option, please choose again\n");
                }
            } while (Option != 6);
        }
    }
}
