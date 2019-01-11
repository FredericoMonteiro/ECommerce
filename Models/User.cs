using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(250, ErrorMessage = "This field is limited to 250 caraters")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="E-Mail")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name")]
        [MaxLength(190, ErrorMessage = "This field is limited to 190 caraters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Last Name")]
        [MaxLength(190, ErrorMessage = "This field is limited to 190 caraters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "This field is limited to 50 caraters")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(200, ErrorMessage = "This field is limited to 200 caraters")]
        public string Address { get; set; }

        [Display(Name ="Profile picture")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Department")]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Display(Name = "User")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Departments Departments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }

    }
}