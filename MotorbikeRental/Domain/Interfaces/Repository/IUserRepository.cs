using MotorbikeRental.Domain.Entities;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<Guid> InsertAsync(UserEntity obj);
    }
}
