using MongoDB.Driver;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Services.Responses;

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

        public async Task<ResponseViewModel<Guid>> InsertAsync(MotorbikeEntity obj)
        {
            try
            {
                var response = new ResponseViewModel<Guid>();
                obj.MotorbikeEntityID = Guid.NewGuid();
                var validateRegistry = await GetMotorbikeByLicensePlate(obj.LicensePlate);

                if (validateRegistry != null)
                {
                    response.Response = obj.MotorbikeEntityID;
                    response.Message = "Motorbike registration already exists";
                    return response;
                }

                await _dbSet.InsertOneAsync(obj);
                var guid = obj.MotorbikeEntityID;
                response.Response = guid;
                response.Message = "Success";
                
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ResponseViewModel<List<MotorbikeEntity>>> GetAllMotorbikes()
        {
            var response = new ResponseViewModel<List<MotorbikeEntity>> ();
            try
            {
                var all = await _dbSet.Find(Builders<MotorbikeEntity>.Filter.Empty).ToListAsync();
                response.Response = all;
                response.Message = "Success";
                return response ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseViewModel<MotorbikeEntity>> GetMotorbikeByGUID(string guid) 
        {
            try
            {
                var ret = new ResponseViewModel<MotorbikeEntity>();
                var filterGuid = Builders<MotorbikeEntity>.Filter.Eq("MotorbikeEntityID", guid);
                var motorbike = await _dbSet.FindAsync(Builders<MotorbikeEntity>.Filter.And(filterGuid));
                if (motorbike != null) 
                {
                    ret.Response = motorbike.FirstOrDefault();
                    ret.Message = "Success";
                }

                return new ResponseViewModel<MotorbikeEntity> { Response = null, Message = "No motorbike found with the code" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        public async Task<ResponseViewModel<MotorbikeEntity>> GetMotorbikeByLicensePlate(string licensePlate)
        {
            try
            {
                var responseViewModel = new ResponseViewModel<MotorbikeEntity>();
                var filter = Builders<MotorbikeEntity>.Filter.Eq("LicensePlate", licensePlate);
                var motorbike = await _dbSet.FindAsync(Builders<MotorbikeEntity>.Filter.And(filter));
                if (motorbike != null)
                {
                    responseViewModel.Response = motorbike.FirstOrDefault();
                    responseViewModel.Message = "Success";
                    return responseViewModel;
                }
                return new ResponseViewModel<MotorbikeEntity> { Message = "Motorbike not found", Response = null };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ResponseViewModel<bool>> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate)
        {
            try
            {
                var response = new ResponseViewModel<bool>();
                var filterGuid = Builders<MotorbikeEntity>.Filter.Eq("MotorbikeEntityID", guid);
                var updateLicensèPlate = Builders<MotorbikeEntity>.Update
                    .Set(motorbike => motorbike.LicensePlate, licensePlate);

                var ret = await _dbSet.UpdateOneAsync(filterGuid, updateLicensèPlate);

                
                response.Response = true;
                response.Message = "Success";

                return response ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ResponseViewModel<bool>> DeleteMotorbikeByGuid(string guid)
        {
            try
            {
                var response = new ResponseViewModel<bool>();
                var filter = Builders<MotorbikeEntity>.Filter.Eq("Guid", guid);
                var motorbike = await _dbSet.DeleteOneAsync(Builders<MotorbikeEntity>.Filter.And(filter));

                response.Response = true;
                response.Message = "Success";

                return response ;
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
