using System;

namespace testeVOLVO
{
    class Program
    {
        static void Main(string[] args)
        {
            string dref = "";
            string format = "";
            int trade = 0;

            //Ask user to type reference date.
            Console.WriteLine("Type a reference date, and press Enter");
            dref = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dref, "d", System.Globalization.CultureInfo.InvariantCulture);

            //Ask user to type number of trades.
            Console.WriteLine("Type a number of trades, and press Enter");
            trade = Convert.ToInt32(Console.ReadLine());
            string t = "";
            string[] category = new string[trade];
            Console.WriteLine("Type a " + trade + " Trades(s) Amount, Clients Sector and Next Pending Payment (separeted by a space)");
            for (int i=0; i<trade; i++)
            {
                t = Console.ReadLine();
                string[] trades = t.Split(' ');
                DateTime dateTime = date;
                int tradeAmount = 0;
                string clientSector = "";
                string pendingPayment = "";
                foreach (var trd in trades)
                {
                    tradeAmount = Convert.ToInt32(trades[0]);
                    clientSector = trades[1].ToUpper();
                    pendingPayment = trades[2];
                    if (dateTime > DateTime.ParseExact(pendingPayment, "d", System.Globalization.CultureInfo.InvariantCulture))
                    {
                        TimeSpan difference = dateTime - Convert.ToDateTime(trades[2]);
                        if(difference.TotalDays > 30)
                        {
                            category[i] = "EXPIRED";
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(tradeAmount) > 1000000)
                        {
                            if (clientSector == "PUBLIC")
                            {
                                category[i] = "MEDIUMRISK";
                            }
                            else
                            {
                                category[i] = "HIGHRISK";
                            }
                        }
                        else
                        {
                            category[i] = "OTHER";
                        }
                    }
                }
            }

            //Print result
            Console.WriteLine("");
            Console.WriteLine("");
            for(int i=0; i<trade; i++)
            {
                Console.WriteLine(category[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //End
            Console.WriteLine("Press any key to close aplication");
            Console.ReadKey();
        }
    }
}
