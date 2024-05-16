using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IDeliverymanService
    {
        Task<ResponseViewModel<Guid>> InsertDeliveryman(DeliverymanViewModel deliverymanViewModel);

        Task<ResponseViewModel<DeliverymanViewModel>> GetDeliverymanByGuid(string guid);
    }
}
