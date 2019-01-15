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
        [HiddenInput(DisplayValue = false)]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Укажите имя получателя")]
        [Display(Name = "Имя")]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "Вставьте адрес доставки")]
        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public decimal Price { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
