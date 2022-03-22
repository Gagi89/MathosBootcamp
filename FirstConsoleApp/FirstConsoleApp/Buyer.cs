using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    public class Buyer : Data
    {
        public int BuyerID { get; set; }
        public static List<Buyer> buyers = new List<Buyer>();
        public void InputBuyer()
        {
            Buyer buyer = new Buyer();
            var InputKey = "";
            do
            {
                int i = 1;
                buyer.BuyerID = i;
                Console.WriteLine("Enter the name of the buyer: ");
                buyer.Name = Console.ReadLine();
                Console.WriteLine("Enter the adress of the buyer: ");
                buyer.Adress = Console.ReadLine();
                Console.WriteLine("Enter OIB of the buyer: ");
                buyer.Oib = Convert.ToInt32(Console.ReadLine());
                buyers.Add(buyer);
                Console.WriteLine("To return to main menu press +, otherwise continue");
                InputKey = Console.ReadLine();
                i++;
            } while (InputKey != "+");
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
