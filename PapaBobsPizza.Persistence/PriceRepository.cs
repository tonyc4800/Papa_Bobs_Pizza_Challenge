using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.Persistence
{
    public class PriceRepository
    {
        public static DTO.PricesDTO GetPrices()
        {
            PapaBobsPizzaDBEntities1 db = new PapaBobsPizzaDBEntities1();
            var dbPrices = db.Prices.First();
            DTO.PricesDTO prices = convertToDTO(dbPrices);
            return prices;
        }

        private static DTO.PricesDTO convertToDTO(Price prices)
        {
            return new DTO.PricesDTO()
            {
                Small = prices.Small,
                Medium = prices.Medium,
                Large = prices.Large,
                Regular = prices.Regular,
                Thin = prices.Thin,
                Thick = prices.Thick,
                Sausage = prices.Sausage,
                Pepperoni = prices.Pepperoni,
                Onions = prices.Onions,
                GreenPeppers = prices.GreenPeppers
            };
        }
    }
}
