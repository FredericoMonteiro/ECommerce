using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Inventory
    {
        [Key]
        [Required(ErrorMessage = "This field is required!")]
        public int InventoryId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public int ProductsId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public int WareHouseId { get; set; }


        public double Stock { get; set; }

        public virtual Products Products { get; set; }

        public virtual WareHouse WareHouse { get; set; }
    }
}