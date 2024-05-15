using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface ILoginRepository
    {
        Task<UserEntity> GetAuthentication(LoginViewModel login);
    }
}
