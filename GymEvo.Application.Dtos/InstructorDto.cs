using System;
using System.ComponentModel.DataAnnotations;

namespace GymEvo.Application.DTOs
{
    public class InstructorDto
    {
        public int? InstructorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Observation { get; set; }
        [Required]
        public string Graduation { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
