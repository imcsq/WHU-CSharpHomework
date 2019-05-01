﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ordertest
{
    public class OrderItem
    {
        [Key]
        public string Id { get; set; }
        public string Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderItem(string id, string product, double unitPrice, int quantity)
        {
            Id = id;
            Product = product;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null && Id == item.Id;
        }
  }
}