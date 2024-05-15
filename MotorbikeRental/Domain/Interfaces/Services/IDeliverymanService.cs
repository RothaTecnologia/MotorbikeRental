using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IDeliverymanService
    {
        Task<Guid> InsertDeliveryman(DeliverymanViewModel deliverymanViewModel);

        Task<DeliverymanViewModel> GetDeliverymanByGuid(string guid);
    }
}
