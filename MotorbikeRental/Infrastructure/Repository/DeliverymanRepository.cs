using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class DeliverymanRepository: IDeliverymanRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<DeliverymanEntity> _dbSet;

        public DeliverymanRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbSet = _mongoContext.GetCollection<DeliverymanEntity>("Deliverymen"); ;
        }

        public async Task<Guid> InsertAsync(DeliverymanEntity obj)
        {
            obj.DeliverymanID = Guid.NewGuid();
            await _dbSet.InsertOneAsync(obj);
            return obj.DeliverymanID;
        }

        public async Task<DeliverymanEntity> GetDeliverymanByGUID(string guid)
        {
            var filterGuid = Builders<DeliverymanEntity>.Filter.Eq("DeliverymanID", guid);
            var deliveryman = await _dbSet.FindAsync(Builders<DeliverymanEntity>.Filter.And(filterGuid));
            return deliveryman.FirstOrDefault();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
