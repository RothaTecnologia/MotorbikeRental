using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IAuthenticationMBRService
    {
        Task<string> LoginAsync(LoginViewModel login);
    }
}
