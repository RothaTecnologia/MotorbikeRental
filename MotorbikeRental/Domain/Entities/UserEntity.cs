namespace MotorbikeRental.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity() { }

        public Guid UserID { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public UserTypeEntity UserType { get; set; } = new UserTypeEntity();
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
