namespace MotorbikeRental.Services.Viewmodels
{
    public class PlanViewModel
    {
        public required Guid IDPlan { get; set; }
        public required string Plan { get; set; }
        public int Days { get; set; }
        public float CostPerDay { get; set; }
        public float Fine { get; set; }
    }
}
