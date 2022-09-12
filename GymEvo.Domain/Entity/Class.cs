using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Domain.Entity
{
    public class Class : Base
    {
        public string Description { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public DateTime? ClassEndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public List<Exercise> ExerciseList { get; set; } = new List<Exercise>();
        public List<Customer> CustomerList { get; set; } = new List<Customer>();
    }
}
