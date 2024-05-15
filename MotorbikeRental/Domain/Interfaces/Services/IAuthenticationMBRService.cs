using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IAuthenticationMBRService
    {
        Task<ResponseViewModel<string>> LoginAsync(LoginViewModel login);
    }
}
