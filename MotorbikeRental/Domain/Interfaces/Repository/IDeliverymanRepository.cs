using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Responses;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IDeliverymanRepository
    {
        Task<ResponseViewModel<Guid>> InsertAsync(DeliverymanEntity obj);

        Task<ResponseViewModel<DeliverymanEntity>> GetDeliverymanByGUID(string guid);

        Task<ResponseViewModel<DeliverymanEntity>> GetDeliverymanByCNH(string cnh);
    }
}
