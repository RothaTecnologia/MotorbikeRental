using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Infrastructure.Configuration;

namespace MotorbikeRental.Infrastructure.Repository.DataContext
{
    public class MongoContext: IMongoContext
    {
        private IMongoDatabase _database { get; }
        private IConfiguration _configuration { get; }

        public MongoContext(IOptions<MongoDBConfiguration> mongoConfig, IConfiguration configuration)
        {
            _configuration = configuration;

            try
            {
                _configuration = configuration;
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var mongoClient = new MongoClient(_configuration["MongoDBConfiguration:ConnectionString"]);

                _database = mongoClient.GetDatabase(_configuration["MongoDBConfiguration:DatabaseName"]);

                var pack = new ConventionPack();
                pack.Add(new IgnoreExtraElementsConvention(true));
                ConventionRegistry.Register("Ignore Extra Elements Convention", pack, t => true);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
            
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
