using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string RecipientName { get; set; }
        public string Adress { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
