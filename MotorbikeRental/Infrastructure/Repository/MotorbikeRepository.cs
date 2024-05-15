using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class MotorbikeRepository: IMotorbikeRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<MotorbikeEntity> _dbSet;

        public MotorbikeRepository(IMongoContext context)
        {
            _mongoContext = context;
            _dbSet = _mongoContext.GetCollection<MotorbikeEntity>("Motorbikes");
        }

        public async Task<Guid> InsertAsync(MotorbikeEntity obj)
        {
            obj.MotorbikeEntityID = Guid.NewGuid();
            await _dbSet.InsertOneAsync(obj);
            return obj.MotorbikeEntityID;
        }

        public async Task<List<MotorbikeEntity>> GetAllMotorbikes()
        {
            var all = await _dbSet.Find(Builders<MotorbikeEntity>.Filter.Empty).ToListAsync();
            return all;
        }

        public async Task<MotorbikeEntity> GetMotorbikeByGUID(string guid) 
        {
            var filterGuid = Builders<MotorbikeEntity>.Filter.Eq("MotorbikeEntityID", guid);
            var motorbike = await _dbSet.FindAsync(Builders<MotorbikeEntity>.Filter.And(filterGuid));
            return motorbike.FirstOrDefault();
        }

        public async Task<MotorbikeEntity> GetMotorbikeByLicensePlate(string licensePlate)
        {
            var filter = Builders<MotorbikeEntity>.Filter.Eq("LicensePlate", licensePlate);
            var motorbike = await _dbSet.FindAsync(Builders<MotorbikeEntity>.Filter.And(filter));
            return motorbike.FirstOrDefault();
        }

        public async Task<bool> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate)
        {
            var filterGuid = Builders<MotorbikeEntity>.Filter.Eq("MotorbikeEntityID", guid);
            var updateLicensèPlate = Builders<MotorbikeEntity>.Update
                .Set(motorbike => motorbike.LicensePlate, licensePlate);

            var ret = await _dbSet.UpdateOneAsync(filterGuid, updateLicensèPlate);

            return true;
        }

        public async Task<bool> DeleteMotorbikeByGuid(string guid)
        {
            var filter = Builders<MotorbikeEntity>.Filter.Eq("Guid", guid);
            var motorbike = await _dbSet.DeleteOneAsync(Builders<MotorbikeEntity>.Filter.And(filter));
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
