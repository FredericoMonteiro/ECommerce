using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }

        [Display(Name = "Distributors")]
        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Distributor")]
        [Index("Product_Description_CompanyId_Index", 1, IsUnique = true)]
        [Index("Product_BarCode_CompanyId_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "This field is required")]
        [Index("Product_Description_CompanyId_Index", 2, IsUnique = true)]
        [MaxLength(100, ErrorMessage = "This field is limited to 100 caraters")]
        public string Description { get; set; }

        [Display(Name = "BarCode")]
        [Required(ErrorMessage = "This field is required")]
        [Index("Product_BarCode_CompanyId_Index", 2, IsUnique = true)]
        [MaxLength(100, ErrorMessage = "This field is limited to 100 caraters")]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Tax")]
        [Display(Name = "Tax")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Category")]
        [Display(Name = "Category")]
        public int CategoryId{ get; set; }

        [Display(Name = "Stock")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get { return Inventory.Sum(i => i.Stock); } }


        [Display(Name = "Price")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual Company Company { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }


    }
}