using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.Persistence
{
    public class OrderRepository
    {
        public static List<DTO.OrderListDTO> GetOrders()
        {
            PapaBobsPizzaDBEntities1 db = new PapaBobsPizzaDBEntities1();
            List<DTO.OrderListDTO> orderList = new List<DTO.OrderListDTO>();

            var dbFlat = db.Orders.Where(o => o.Completed == false).Select(o => new { o.OrderID, o.Size, o.Crust, o.Sausage, o.Pepperoni, o.Onions, o.GreenPeppers }).ToList();
             
            foreach (var order in dbFlat)
            {
                DTO.OrderListDTO temp = new DTO.OrderListDTO()
                {
                    OrderID = order.OrderID,
                    Size = order.Size,
                    Crust = order.Crust,
                    Sausage = order.Sausage,
                    Pepperoni = order.Pepperoni,
                    Onions = order.Onions,
                    GreenPeppers = order.GreenPeppers                                    
                };
                orderList.Add(temp);
            }
            return orderList;
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsPizzaDBEntities1();
            var order = db.Orders.FirstOrDefault(o => o.OrderID == orderId);
            order.Completed = true;
            db.SaveChanges();
        }

        public static void AddOrderToDB(DTO.OrderDTO order)
        {
            PapaBobsPizzaDBEntities1 db = new PapaBobsPizzaDBEntities1();
            Order newOrder = dtoToOrder(order);
            db.Orders.Add(newOrder);
            db.SaveChanges();
        }
        private static Order dtoToOrder(DTO.OrderDTO order)
        {
            return new Order()
            {
                OrderID = Guid.NewGuid(),
                Size = order.Size,
                Crust = order.Crust,
                Sausage = order.Sausage,
                Pepperoni = order.Pepperoni,
                Onions = order.Onions,
                GreenPeppers = order.GreenPeppers,
                Name = order.Name,
                Address = order.Address,
                Zip = order.Zip,
                Phone = order.Phone,
                PaymentType = order.PaymentType,
                TotalCost = order.TotalCost
            };
        } 

        //private void populateOrderList()
    }   
}
