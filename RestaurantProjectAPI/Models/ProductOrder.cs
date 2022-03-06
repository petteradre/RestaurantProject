using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantProjectAPI.Models
{
    public class ProductOrder
    {
        public ProductOrder()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
