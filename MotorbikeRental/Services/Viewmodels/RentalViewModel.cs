using MotorbikeRental.Domain.Entities;

namespace MotorbikeRental.Services.Viewmodels
{
    public class RentalViewModel
    {
        public Guid RentalID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimateEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public required PlanViewModel Plan { get; set; }
        public required DeliverymanViewModel Deliveryman { get; set; }
        public required MotorbikeEntity Motorbike { get; set; }
        public required AdditionalDailyRateViewModel AddtionalDailyRate { get; set; }
    }
}
