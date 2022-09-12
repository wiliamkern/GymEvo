using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Application.DTOs
{
    public class ExerciseDto
    {
        public int? ExerciseId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
