using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.Domain
{
    public class OrderManager
    {
        public static List<DTO.OrderListDTO> GetOrders()
        {
            return Persistence.OrderRepository.GetOrders();
        }

        public static void AddOrderToDB(DTO.OrderDTO newOrder)
        {
            newOrder.TotalCost = PriceManager.CalculateTotalCost(newOrder);
            Persistence.OrderRepository.AddOrderToDB(newOrder);
        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
        }
    }
}
