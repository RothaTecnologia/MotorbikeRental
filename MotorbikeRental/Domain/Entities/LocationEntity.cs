namespace MotorbikeRental.Domain.Entities
{
    public class LocationEntity
    {
        public Guid IDLocation { get; set; } = new Guid();
        public DateTime StartDate { get; set; }
        public DateTime EstimateEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public required PlanEntity Plan { get; set; }
        public required DeliverymanEntity Deliveryman { get; set; }
        public required MotorbikeEntity Motorbike { get; set; }
        public required AdditionalDailyRateEntity AddtionalDailyRate { get; set; }
    }
}
