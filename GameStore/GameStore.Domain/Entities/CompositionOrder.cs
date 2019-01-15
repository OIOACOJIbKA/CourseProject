using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class CompositionOrder
    {
        public int CompositionOrderID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public int Count { get; set; }
    }
}
