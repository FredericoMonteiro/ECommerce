using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage ="This field is limited to 50 caraters")]
        [Index("Department_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Company> Company { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<WareHouse> WareHouse { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }


    }
}