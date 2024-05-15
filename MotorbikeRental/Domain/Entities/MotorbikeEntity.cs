namespace MotorbikeRental.Domain.Entities
{
    public class MotorbikeEntity
    {
        public Guid MotorbikeEntityID { get; set; }

        public int Year { get; set; }

        public required string Model { get; set; }

        public required string LicensePlate { get; set; }
    }
}
