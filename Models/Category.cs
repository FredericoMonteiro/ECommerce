using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "This field is required")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        [MaxLength(100, ErrorMessage = "This field is limited to 100 caraters")]       
        public string Description { get; set; }

        [Display(Name = "Distributors")]
        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Distributor")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        public virtual Company Company {get;set;}

        public virtual ICollection<Products> Products { get; set; }


    }
}