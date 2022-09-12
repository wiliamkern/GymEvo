using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Domain.Entity
{
    public class ClassExercise
    {
        public int ClassId { get; set; }
        public int ExerciseId { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
