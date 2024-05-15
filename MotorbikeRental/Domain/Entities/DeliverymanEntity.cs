namespace MotorbikeRental.Domain.Entities
{
    public class DeliverymanEntity
    {
        public Guid DeliverymanID { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime DateBirth { get; set; } = new DateTime();
        public string CNHImage { get; set; }
    }
}
