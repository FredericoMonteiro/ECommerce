using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }

        [Display(Name = "Tax")]
        [Required(ErrorMessage = "This field is required")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        [MaxLength(100, ErrorMessage = "This field is limited to 100 caraters")]
        public string Description { get; set; }

        [Display(Name = "Tax Value")]
        [Required(ErrorMessage = "This field is required")]
        //[Range(0,1, ErrorMessage = "Only values between 0 and 1")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float Rate { get; set; }

        [Display(Name = "Distributors")]
        [Required(ErrorMessage = "This field is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Distributor")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Products> Products { get; set; }

    }
}