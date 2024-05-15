namespace MotorbikeRental.Domain.Entities
{
    public class PlanEntity
    {
        public required string IDPlan { get; set; }
        public required string Plan { get; set; }
        public int Days { get; set; }
        public float CostPerDay { get; set; }
        public float Fine { get; set; }
    }
}
