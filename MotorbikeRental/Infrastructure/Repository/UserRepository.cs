using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<UserEntity> _dbSet;

        public UserRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbSet = _mongoContext.GetCollection<UserEntity>("Users");
        }

        public async Task<Guid> InsertAsync(UserEntity obj)
        {
            obj.UserID = Guid.NewGuid();
            await _dbSet.InsertOneAsync(obj);
            return obj.UserID;
        }
    }
}
