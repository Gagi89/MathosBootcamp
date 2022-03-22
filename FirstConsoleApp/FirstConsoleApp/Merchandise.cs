using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public class Merchandise : Amount
    {
        public int MerchandiseID { get; set; }
        public string MerchandiseName { get; set; }
        public int MerchandiseSupplierID { get; set; }
        public static List<Merchandise> merchandises = new List<Merchandise>();
        public void InputMerchandise()
        {
            Merchandise merchandise = new Merchandise();
            var InputKey = "";
            do
            {
                int i = 1;
                merchandise.MerchandiseID = i;
                Console.WriteLine("Enter the name of the merchandise: ");
                merchandise.MerchandiseName = Console.ReadLine();
                Console.WriteLine("Enter the quantity of the merchandise: ");
                merchandise.Quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the price of the merchandise: ");
                merchandise.Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the ID of the supplier of the merchandise: ");
                merchandise.MerchandiseSupplierID = Convert.ToInt32(Console.ReadLine());
                merchandises.Add(merchandise);
                Console.WriteLine("To return to main menu press +, otherwise continue");
                InputKey = Console.ReadLine();
                i++;
            } while (InputKey != "+");
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
