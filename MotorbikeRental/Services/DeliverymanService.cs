using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class DeliverymanService: IDeliverymanService
    {
        private readonly IMapper _map;
        private readonly IDeliverymanRepository _repository;

        public DeliverymanService(IMapper map, IDeliverymanRepository repository)
        {
            _map = map;
            _repository = repository;
        }

        public async Task<Guid> InsertDeliveryman(DeliverymanViewModel deliverymanViewModel)
        {
            var dto = _map.Map<DeliverymanEntity>(deliverymanViewModel);
            var guid = await _repository.InsertAsync(dto);
            return guid;
        }

        public async Task<DeliverymanViewModel> GetDeliverymanByGuid(string guid)
        {
            var deliverymanEntity = await _repository.GetDeliverymanByGUID(guid);
            var deliveryman = _map.Map<DeliverymanViewModel>(deliverymanEntity);
            return deliveryman;
        }
    }
}
