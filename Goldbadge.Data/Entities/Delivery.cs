using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goldbadge.Data.Entities
{
    public class Delivery
    {
         public Delivery(){} //Empty Constructor

        public Delivery(DateTime orderDate, DateTime deliveryDate, string status, int itemNumber, int itemQuantity, int customerId)
        {
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Status = status;
            ItemNumber = itemNumber;
            ItemQuantity = itemQuantity;
            CustomerId = customerId;
        }

     public int Id {get;set;}   

    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Status { get; set; } // Scheduled, EnRoute, Complete, or Canceled
    public int ItemNumber { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerId { get; set; }
    }
}