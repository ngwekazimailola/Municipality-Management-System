using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [Required]
        [StringLength(150)]
        public string Position { get; set; }

        [Required]
        [StringLength(150)]
        public string Department { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
