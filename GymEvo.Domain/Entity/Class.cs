using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Domain.Entity
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Description { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public DateTime? ClassEndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }

        public List<ClassExercise> Exercises { get; set; }
        public List<ClassCustomer> Customers { get; set; }
    }
}
