using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsPizza.DTO;

namespace PapaBobsPizza.Domain
{
    public class PriceManager
    {
        public static decimal CalculateTotalCost(OrderDTO order)
        {
            PricesDTO prices = getPrices();
            decimal totalCost = 0M;
            totalCost += getSizeCost(order,  prices);
            totalCost += getCrustCost(order, prices);
            totalCost += getToppingsCost(order, prices);
            return totalCost;
        }

        private static DTO.PricesDTO getPrices() => Persistence.PriceRepository.GetPrices();

        private static decimal getSizeCost(OrderDTO order, PricesDTO prices)
        {
            decimal cost = 0M;

            switch (order.Size)
            {
                case DTO.Enums.PizzaSize.Small:
                    cost = prices.Small;
                    break;
                case DTO.Enums.PizzaSize.Medium:
                    cost = prices.Medium;
                    break;
                case DTO.Enums.PizzaSize.Large:
                    cost = prices.Large;
                    break;
                default:
                    break;
            }

            return cost;
        }

        private static decimal getCrustCost(OrderDTO order, PricesDTO prices)
        {
            decimal cost = 0M;

            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    cost = prices.Regular;
                    break;
                case DTO.Enums.CrustType.Thin:
                    cost = prices.Thin;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = prices.Thick;
                    break;
                default:
                    break;
            }

            return cost;
        }

        private static decimal getToppingsCost(OrderDTO order, PricesDTO prices)
        {
            decimal cost = 0M;

            cost += (order.Sausage) ? prices.Sausage : 0M;
            cost += (order.Pepperoni) ? prices.Pepperoni : 0M;
            cost += (order.Onions) ? prices.Onions : 0M;
            cost += (order.GreenPeppers) ? prices.GreenPeppers : 0M;

            return cost;
        }        
    }
}
