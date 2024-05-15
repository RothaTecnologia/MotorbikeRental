using MotorbikeRental.Domain.Interfaces.JWT;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Responses;
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

        public async Task<ResponseViewModel<string>> LoginAsync(LoginViewModel login)
        {
            var ret = new ResponseViewModel<string>();
            var success = await _loginRepository.GetAuthentication(login);

            if (success != null)
            {
                var token = _tokenService.Generate(success);
                ret.Message = "Login success";
                ret.Response = token;
                return ret;
            }

            return new ResponseViewModel<string>
            {
                Message = "Login Error",
                Response = ""
            };
        }
    }
}
