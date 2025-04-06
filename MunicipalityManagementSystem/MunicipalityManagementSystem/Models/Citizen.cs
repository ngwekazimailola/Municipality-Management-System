using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenID { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(60)]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate {  get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<Report> Reports { get; set; }

        public Citizen()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
            Reports = new HashSet<Report>();
        }
    }
}
