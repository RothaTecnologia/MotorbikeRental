using MotorbikeRental.Domain.Entities;

namespace MotorbikeRental.Domain.Interfaces.JWT
{
    public interface ITokenService
    {
        string Generate(UserEntity user);
    }
}
