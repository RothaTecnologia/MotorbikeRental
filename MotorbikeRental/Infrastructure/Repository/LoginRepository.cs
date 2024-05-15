using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class LoginRepository: ILoginRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<UserEntity> _dbSet;

        public LoginRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbSet = _mongoContext.GetCollection<UserEntity>("Users");
        }

        public async Task<UserEntity> GetAuthentication(LoginViewModel login)
        {
            var filterLogin = Builders<UserEntity>.Filter.Eq("Login", login.Login);
            var filterPassword = Builders<UserEntity>.Filter.Eq("Password", login.Password);
            var success = await _dbSet.FindAsync(Builders<UserEntity>.Filter.And(filterLogin, filterPassword));
            return success.FirstOrDefault();
        }
    }
}
