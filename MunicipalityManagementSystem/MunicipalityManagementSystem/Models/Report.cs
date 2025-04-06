using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        
        public int CitizenID { get; set; }

        [Required]
        [StringLength(255)]
        public string ReportType { get; set; }

        [Required]
        public string Details { get; set; }
        
        public DateTime SubmissionDate { get; set; }

        [StringLength(60)]
        public string? Status { get; set; }

        [ForeignKey("CitizenID")]
        public Citizen Citizen { get; set; }
    }
}
