using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.DTO
{
    public class OrderListDTO
    {
        public System.Guid OrderID { get; set; }
        public Enums.PizzaSize Size { get; set; }
        public Enums.CrustType Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperoni { get; set; }
        public bool Onions { get; set; }
        public bool GreenPeppers { get; set; }
    }
}
