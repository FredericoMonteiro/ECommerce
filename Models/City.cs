using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Display(Name ="City")]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1,double.MaxValue, ErrorMessage ="Select Department")]
        public int DepartmentsId { get; set; }

        public virtual Departments Department { get; set; }

        public virtual ICollection<Company> Company { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}