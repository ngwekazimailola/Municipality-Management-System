using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestID { get; set; }
        
        public int CitizenID { get; set; }

        [Required]
        [StringLength(150)]
        public string ServiceType { get; set; }
        
        public DateTime RequestDate { get; set; }

        [StringLength(60)]
        public string? Status { get; set; }

        [ForeignKey("CitizenID")]
        public Citizen Citizen { get; set; }
    }
}
