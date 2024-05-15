using MotorbikeRental.Domain.Interfaces.JWT;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class AuthenticationMBRService: IAuthenticationMBRService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationMBRService(ILoginRepository loginRepository, ITokenService tokenService)
        {
            _loginRepository = loginRepository;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginViewModel login)
        {
            var success = await _loginRepository.GetAuthentication(login);

            var token  = _tokenService.Generate(success);

            return token;
        }
    }
}
