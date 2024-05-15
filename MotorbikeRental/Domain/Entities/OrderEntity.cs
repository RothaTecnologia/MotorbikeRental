namespace MotorbikeRental.Domain.Entities
{
    public class OrderEntity
    {
        public int IDOrder { get; set; }
        public DateTime CreateDate { get; set; }
        public float DeliveryCost { get; set; }
        public required AdditionalDailyRateEntity AdditionalDailyRate { get; set; }
        public StatusOrderEntity StatusOrder { get; set; } = new StatusOrderEntity();
    }
}
