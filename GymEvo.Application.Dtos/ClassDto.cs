using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Application.DTOs
{
    public class ClassDto
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public DateTime? ClassEndDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public List<ExerciseDto> ExerciseList { get; set; } = new List<ExerciseDto>();
        public List<CustomerDto> CustomerList { get; set; } = new List<CustomerDto>();
    }
}
