using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AclaimDataConnectionChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = "";
            while (true)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("---------1. Customer Purchase Details---------");
                Console.WriteLine("---------2. Product Order Details-------------");
                Console.WriteLine("---------3. Exit------------------------------");
                Console.WriteLine("----------------------------------------------");
                entry = Console.ReadLine();
                if (entry == "1")
                {
                    Console.Clear();
                    GetCustomerPurchaseDetails();
                    Console.WriteLine("\n\nPress Enter to return to menu...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (entry == "2")
                {
                    Console.Clear();
                    GetProductDetailsView();
                    Console.WriteLine("\n\nPress Enter to return to menu...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (entry == "3")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Invalid Selection, press enter to try again");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        public static void GetCustomerPurchaseDetails()
        {

            Console.WriteLine("Please enter a customer name in the format: Last, First OR press enter to continue");
            string? customerName = Console.ReadLine();
            decimal? lowerBoundD;
            decimal? upperBoundD;
            while (true)
            {
                Console.WriteLine("Enter a lower order amount boundary or press enter for all: ");
                string lowerBoundEnter = Console.ReadLine();
                if (lowerBoundEnter == "")
                {
                    lowerBoundD = null;
                    break;
                }
                if (!Decimal.TryParse(lowerBoundEnter, out decimal tmp))
                {
                    Console.WriteLine("Invalid entry, press Enter to try again");
                    Console.ReadLine();
                    continue;
                }
                lowerBoundD = tmp;
                break;
            }
            while (true)
            {
                Console.WriteLine("Enter an upper order amount boundary or press enter for all: ");
                string upperBoundEnter = Console.ReadLine();

                if (upperBoundEnter == "")
                {
                    upperBoundD = null;
                    break;
                }
                else if (!Decimal.TryParse(upperBoundEnter, out decimal tmp2))
                {
                    Console.WriteLine("Invalid entry, press Enter to try again");
                    Console.ReadLine();
                    continue;
                }
                else
                {

                    upperBoundD = tmp2;
                    break;
                }

            }
            using (var dbcontext = new AdventureWorksLT2016Entities())
            {

                var results = from result in dbcontext.GetCustomerPurchaseData(customerName, lowerBoundD, upperBoundD)
                              select result;
                foreach (var result in results)
                {
                    Console.WriteLine(
                        "Customer ID: " + result.Customer_ID + "    " +
                        "Customer Name: " + result.Customer_Name + "    " +
                        "Customer Email: " + result.Customer_Email + "    " +
                        "Customer Phone: " + result.Customer_Phone + "    " +
                        "Sales Order ID: " + result.Sales_Order_ID + "    " +
                        "Order Subtotal: " + result.Order_Subtotal + "    " +
                        "Order Tax Amount: " + result.Order_Tax_Amount + "    " +
                        "Order Amount Due: " + result.Order_Amount_Due + "    "
                        );
                }
            }
            
        }




        public static void GetProductDetailsView()
        {
          
                Console.WriteLine("Please enter a first, last, or Last, First name OR press enter to continue without name filter");
                string? customerName = Console.ReadLine();
                char? filter;
                while (true)
                {
                    Console.WriteLine("Do you want to filter out products that aren't ordered? y/n: ");
                    string entered = Console.ReadLine();
                    if (entered.ToLower() == "y")
                    {
                        filter = 'y';
                        break;
                    }
                    else if (entered.ToLower() == "n")
                    {
                        filter = 'n';
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                }
                using (var dbcontext = new AdventureWorksLT2016Entities())
                {
                    if (filter == 'n')
                    {
                        if (customerName != null)
                        {
                            var results = from result in dbcontext.vwGetProductOrderInfoes
                                          where result.CustomerName.Contains(customerName)
                                          select result;
                            foreach (var result in results)
                            {
                                Console.WriteLine(
                                    "Pruduct ID: " + result.ProductId + "    " +
                                    "Product Number: " + result.ProductNumber + "    " +
                                    "Order Quantity: " + result.orderqty + "    " +
                                    "Line Total: " + result.linetotal + "    " +
                                    "Customer Name: " + result.CustomerName + "    "

                                    );
                            }
                        }
                        else if (filter == 'y')
                        {
                            var results = from result in dbcontext.vwGetProductOrderInfoes
                                          where result.orderqty > 0
                                          select result;
                            foreach (var result in results)
                            {
                                Console.WriteLine(
                                    "Pruduct ID: " + result.ProductId + "    " +
                                    "Product Number: " + result.ProductNumber + "    " +
                                    "Order Quantity: " + result.orderqty + "    " +
                                    "Line Total: " + result.linetotal + "    " +
                                    "Customer Name: " + result.CustomerName + "    "

                                    );
                            }
                        }
                    }
                    else
                    {
                        if (customerName != null)
                        {
                            var results = from result in dbcontext.vwGetProductOrderInfoes
                                          where result.CustomerName.Contains(customerName)
                                          select result;
                            foreach (var result in results)
                            {
                                Console.WriteLine(
                                    "Pruduct ID: " + result.ProductId + "    " +
                                    "Product Number: " + result.ProductNumber + "    " +
                                    "Order Quantity: " + result.orderqty + "    " +
                                    "Line Total: " + result.linetotal + "    " +
                                    "Customer Name: " + result.CustomerName + "    "

                                    );
                            }
                        }
                        else
                        {
                            var results = from result in dbcontext.vwGetProductOrderInfoes
                                          select result;
                            foreach (var result in results)
                            {
                                Console.WriteLine(
                                    "Pruduct ID: " + result.ProductId + "    " +
                                    "Product Number: " + result.ProductNumber + "    " +
                                    "Order Quantity: " + result.orderqty + "    " +
                                    "Line Total: " + result.linetotal + "    " +
                                    "Customer Name: " + result.CustomerName + "    "

                                    );
                            }
                        }
                    }
              
                    

                }
            
        }

    }



}

