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
        //[Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        [Required(ErrorMessage = "Укажите цену заказа")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Укажите статус заказа")]
        [Display(Name = "Статус заказа")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Укажите дату заказа")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }
    }
}
