using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ApexaApp.API.Dtos
{
    public class AdvisorDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(9, ErrorMessage = "Max length is 9")]
        [MinLength(9, ErrorMessage = "Min length is 9")]
        public string SIN { get; set; } = string.Empty;
        public string? Address { get; set; }
        [MaxLength(10, ErrorMessage = "Max length is 10")]
        [MinLength(10, ErrorMessage = "Min length is 10")]
        public string? PhoneNumber { get; set; }
        public string HealthStatus { get; set; } = string.Empty;
    }
}