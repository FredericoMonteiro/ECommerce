using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "This field is limited to 50 caraters")]
        [Index("Department_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "This field is limited to 50 caraters")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(200, ErrorMessage = "This field is limited to 200 caraters")]       
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Department")]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual Departments Departments { get; set; }

        public virtual City Cities { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }

        public virtual ICollection<Products> Products { get; set; }




    }
}