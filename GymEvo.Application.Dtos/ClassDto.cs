using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Application.DTOs
{
    public class ClassDto
    {
        public int? ClassId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime? ClassStartDate { get; set; }
        [Required]
        public DateTime? ClassEndDate { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public int? InstructorId { get; set; }
        [Required]
        public List<ClassExerciseDto> Exercises { get; set; } = new List<ClassExerciseDto>();
        [Required]
        public List<ClassCustomerDto> Customers { get; set; } = new List<ClassCustomerDto>();
    }
}
