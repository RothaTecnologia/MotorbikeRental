using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> InsertUser(UserViewModel userViewModel);
    }
}
