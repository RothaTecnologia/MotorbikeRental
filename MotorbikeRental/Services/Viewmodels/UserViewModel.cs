namespace MotorbikeRental.Services.Viewmodels
{
    public class UserViewModel
    {
        public Guid UserID { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public UserTypeViewModel UserType { get; set; } = new UserTypeViewModel();
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
