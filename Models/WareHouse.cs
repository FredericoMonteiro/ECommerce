using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class WareHouse
    {
        [Key]
        [Display(Name = "WareHouse ID")]
        public int WareHouseId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Company")]
        [Index("WareHouse_CompanyId_Name_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(250, ErrorMessage = "This field is limited to 250 caraters")]
        [Display(Name = "WareHouse")]
        [Index("WareHouse_CompanyId_Name_Index", 2, IsUnique = true)]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "This field is limited to 50 caraters")]
        [Display(Name = "Phone")]
        //[Index("Departament_Name_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "This field is limited to 100 caraters")]
        [Display(Name = "Address")]

        public string Address { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Departments")]
        public int DepartmentsId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual Departments Departments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }

        //public virtual ICollection<Inventory> Inventory { get; set; }
    }
}