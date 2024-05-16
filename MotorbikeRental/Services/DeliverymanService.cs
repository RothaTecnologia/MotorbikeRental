using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Images;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class DeliverymanService: IDeliverymanService
    {
        private readonly IMapper _map;
        private readonly IDeliverymanRepository _repository;
        private readonly IImageTransform _imageTransform;

        public DeliverymanService(IMapper map, IDeliverymanRepository repository, IImageTransform imageTransform)
        {
            _map = map;
            _repository = repository;
            _imageTransform = imageTransform;
        }

        public async Task<ResponseViewModel<Guid>> InsertDeliveryman(DeliverymanViewModel deliverymanViewModel)
        {
            var response = new ResponseViewModel<Guid>();

            var cnhValidate = _repository.GetDeliverymanByCNH(deliverymanViewModel.CNH);
            if (cnhValidate == null) 
            {
                var dto = _map.Map<DeliverymanEntity>(deliverymanViewModel);

                var guid = await _repository.InsertAsync(dto);

                _imageTransform.saveCNHImage(deliverymanViewModel.CNHImageBytes, deliverymanViewModel.DeliverymanID);

                response.Response = guid.Response;
                response.Message = "Success";
                return response;

            }

            response.Message = "CNH already exists";
            return response;
        }

        public async Task<ResponseViewModel<DeliverymanViewModel>> GetDeliverymanByGuid(string guid)
        {
            try
            {
                var response = new ResponseViewModel<DeliverymanViewModel>();
                var deliverymanEntity = await _repository.GetDeliverymanByGUID(guid);
                if (deliverymanEntity == null)
                {
                    response.Message = "Deliveryman not found";
                    return response;
                }

                response.Response = _map.Map<DeliverymanViewModel>(deliverymanEntity);
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
