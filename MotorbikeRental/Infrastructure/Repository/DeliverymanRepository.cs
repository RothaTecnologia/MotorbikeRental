using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Services.Responses;

namespace MotorbikeRental.Infrastructure.Repository
{
    public class DeliverymanRepository: IDeliverymanRepository
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<DeliverymanEntity> _dbSet;

        public DeliverymanRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbSet = _mongoContext.GetCollection<DeliverymanEntity>("Deliv0erymen"); ;
        }

        public async Task<ResponseViewModel<Guid>> InsertAsync(DeliverymanEntity obj)
        {
            try
            {
                var response = new ResponseViewModel<Guid>();
                obj.DeliverymanID = Guid.NewGuid();
                response.Response = obj.DeliverymanID;
                await _dbSet.InsertOneAsync(obj);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseViewModel<DeliverymanEntity>> GetDeliverymanByGUID(string guid)
        {
            var response = new ResponseViewModel<DeliverymanEntity>();
            try
            {
                var filterGuid = Builders<DeliverymanEntity>.Filter.Eq("DeliverymanID", guid);
                var deliveryman = await _dbSet.FindAsync(Builders<DeliverymanEntity>.Filter.And(filterGuid));
                if (deliveryman != null)
                {
                    response.Response = deliveryman.FirstOrDefault();
                    response.Message = "Success";
                }

                response.Message = "Deliveryman not found";
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ResponseViewModel<DeliverymanEntity>> GetDeliverymanByCNH(string cnh)
        {
            var response = new ResponseViewModel<DeliverymanEntity>();
            try
            {
                var filterCnh = Builders<DeliverymanEntity>.Filter.Eq("CNH", cnh);
                var deliveryman = await _dbSet.FindAsync(Builders<DeliverymanEntity>.Filter.And(filterCnh));
                if (deliveryman != null)
                {
                    response.Response = deliveryman.FirstOrDefault();
                    response.Message = "Success";
                }

                response.Message = "Deliveryman not found";
                return response;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
