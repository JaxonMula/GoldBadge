using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goldbadge.Data.Entities;

namespace GoldBadge.Repository
{
    public class DeliveryRepository
    {
         //fake database
        private readonly List<Delivery> _deliveries = new List<Delivery>();

        //Database Package ID base value;
        private int _count = 0;

        public bool AddDelivery(Delivery delivery)
    {
        if (delivery is null)
        {
            return false;
        }
        else{
            _count ++;
            delivery.ItemNumber = _count;
            _deliveries.Add(delivery);
            return true;
        }
    }
 

    public List<Delivery> GetEnRouteDeliveries()
    {
        List<Delivery> enrouteDeliveries = _deliveries.Where(delivery => delivery.Status == "EnRoute").ToList();
        return enrouteDeliveries;
    }

    public List<Delivery> GetCompletedDeliveries()
    {
        List<Delivery> completedDeliveries = _deliveries.Where(delivery => delivery.Status == "Complete").ToList();
    return completedDeliveries;

    }

    public void UpdateDeliveryStatus(int deliveryId, string newStatus)
    {
       Delivery deliveryToUpdate = _deliveries.FirstOrDefault(delivery => delivery.Id == delivery.Id);

       if (deliveryToUpdate != null)
       {
        deliveryToUpdate.Status = newStatus;
        System.Console.WriteLine($"Delivery {deliveryId} updated to {newStatus}");
       }
       else{
        System.Console.WriteLine($"Delivery with ID {deliveryId} not found.");
       }
    }

    public void CancelDelivery(int customerId)
    {
        Delivery deliveryToCancel = _deliveries.FirstOrDefault(delivery => delivery.Id == delivery.Id);

        if(deliveryToCancel != null){

        deliveryToCancel.Status = "Canceled";
        System.Console.WriteLine($"Customer {customerId} has been canceled.");
        }
        else{
            System.Console.WriteLine($"Customer with ID {customerId} not found.");
        }


    }
    }
}