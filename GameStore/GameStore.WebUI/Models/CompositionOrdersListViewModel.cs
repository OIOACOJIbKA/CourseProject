using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;

namespace GameStore.WebUI.Models
{
    public class CompositionOrdersListViewModel
    {
        public IEnumerable<CompositionOrder> compositionOrders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}