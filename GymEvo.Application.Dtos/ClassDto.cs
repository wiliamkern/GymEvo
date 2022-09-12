using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Application.DTOs
{
    public class ClassDto
    {
        public int? ClassId { get; set; }
        public string Description { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public DateTime? ClassEndDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public int? InstructorId { get; set; }
        public List<ClassExerciseDto> Exercises { get; set; } = new List<ClassExerciseDto>();
        public List<ClassCustomerDto> Customers { get; set; } = new List<ClassCustomerDto>();
    }
}
