﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class PurchaseItem
    {      
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Provied quantity")]
        [DataType(DataType.PhoneNumber)]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        public float Price { get; set; }

        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
