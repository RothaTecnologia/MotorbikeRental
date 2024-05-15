using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _map;

        public UserService(IUserRepository userRepository, IMapper map)
        {
            _repository = userRepository;
            _map = map;
        }

        public async Task<Guid> InsertUser(UserViewModel userViewModel)
        {
            var dto = _map.Map<UserEntity>(userViewModel);
            var guid = await _repository.InsertAsync(dto);
            return guid;
        }
    }
}
