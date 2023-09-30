using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Goldbadge.Data.Entities;
using GoldBadge.Repository;

namespace GoldBadge.UI
{
    public class ProgramUI
    {
        private readonly DeliveryRepository _DeliveryRepo = new DeliveryRepository();

        private bool IsRunning = true;



        public void RunApplication()
        {
            Run();
        }




        public void Run()
        {
            while (IsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Warner Transit Federal Delivery System\n" +
                                    "1. Add a new delivery\n" +
                                    "2. List all en route deliveries\n" +
                                    "3. List all completed deliveries\n" +
                                    "4. Update the status of a delivery\n" +
                                    "5. Cancel a delivery\n" +
                                    "0. Exit\n" +
                                    "Enter your choice: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDelivery();
                        break;

                    case "2":
                        ListEnRoute();
                        break;

                    case "3":
                        ListCompletedDeliveries();
                        break;

                    case "4":
                        UpdateStatus();
                        break;

                    case "5":
                        CancelDelivery();
                        break;

                    case "0":
                        IsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private void CancelDelivery()
        {
            Console.Clear();
            Console.Write("Enter the ID of the delivery you want to Cancel: ");
            if (int.TryParse(Console.ReadLine(), out int customerId))
            {
            Console.Write("Enter Canceled to confirm): ");
            string newStatus = Console.ReadLine();

            _DeliveryRepo.CancelDelivery(customerId);
            }
            else
            {
                Console.WriteLine("Invalid delivery ID.");
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void UpdateStatus()
        {
            Console.Clear();
            Console.Write("Enter the ID of the delivery you want to update: ");
            if (int.TryParse(Console.ReadLine(), out int CustomerId))
            {
            Console.Write("Enter the new status (Scheduled, EnRoute, Complete, or Canceled): ");
            string newStatus = Console.ReadLine();

            _DeliveryRepo.UpdateDeliveryStatus(CustomerId, newStatus);
            }
            else
            {
                Console.WriteLine("Invalid delivery ID.");
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ListCompletedDeliveries()
        {
            Console.Clear();
            List<Delivery> completedDeliveries = _DeliveryRepo.GetCompletedDeliveries();

            if (completedDeliveries.Count > 0)
            {
                System.Console.WriteLine("These are the completed deliveries:");
                foreach (var delivery in completedDeliveries)
                {
                    System.Console.WriteLine($"Customer ID: {delivery.CustomerId}, Status: {delivery.Status}");
                }
            }
            else
            {
                System.Console.WriteLine("No deliveries are currently en route");
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void AddDelivery()
        {
            Console.Clear();
            System.Console.WriteLine("Enter order date (mm-dd-yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
            {
                Console.Write("Enter status (Scheduled, EnRoute, Complete, or Canceled): ");
                string status = Console.ReadLine();
                Console.Write("Enter delivery date (mm-dd-yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime deliveryDate))
                {

                    Console.Write("Enter item number: ");
                    if (int.TryParse(Console.ReadLine(), out int itemNumber))
                    {
                        Console.Write("Enter item quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int itemQuantity))
                        {
                            Console.Write("Enter customer ID: ");
                            if (int.TryParse(Console.ReadLine(), out int customerId))
                            {
                                Delivery newDelivery = new Delivery(orderDate, deliveryDate, status, itemNumber, itemQuantity, customerId);

                                bool success = _DeliveryRepo.AddDelivery(newDelivery);

                                if (success)
                                {
                                    Console.WriteLine("Delivery added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to add the delivery.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid customer ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid item quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                    }
                }
            }
        }

        private void ListEnRoute()
        {
            Console.Clear();
            List<Delivery> enRouteDeliveries = _DeliveryRepo.GetEnRouteDeliveries();


            if (enRouteDeliveries.Count > 0)
            {
                System.Console.WriteLine("These are the deliveries that are on route: ");
                foreach (var delivery in enRouteDeliveries)
                {
                    System.Console.WriteLine($"Customer ID: {delivery.CustomerId}, Status: {delivery.Status}");
                }
            }
            else
            {
                System.Console.WriteLine("No deliveries are currently en route");
            }
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }

    }

}
