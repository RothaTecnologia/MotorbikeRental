using MotorbikeRental.Domain.Entities;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IDeliverymanRepository
    {
        Task<Guid> InsertAsync(DeliverymanEntity obj);

        Task<DeliverymanEntity> GetDeliverymanByGUID(string guid);
    }
}
