using MongoDB.Driver;

namespace MotorbikeRental.Domain.Interfaces.DataContext
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
