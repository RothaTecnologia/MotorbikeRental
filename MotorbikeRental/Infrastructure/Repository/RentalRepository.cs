using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Services.Responses;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class RentalRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<RentalEntity> _dbSet;

        public RentalRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbSet = _mongoContext.GetCollection<RentalEntity>("Rentals");
        }

        public async Task<ResponseViewModel<Guid>> InsertAsync(RentalEntity obj)
        {
            try
            {
                var response = new ResponseViewModel<Guid>();
                obj.RentalID = Guid.NewGuid();
                
                await _dbSet.InsertOneAsync(obj);
                var guid = obj.RentalID;
                response.Response = guid;
                response.Message = "Success";

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
