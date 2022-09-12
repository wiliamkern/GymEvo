using System;

namespace GymEvo.Domain.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string GymPlan { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
