using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProjectAPI.Models
{
    public class Order
    {
        public Order()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
