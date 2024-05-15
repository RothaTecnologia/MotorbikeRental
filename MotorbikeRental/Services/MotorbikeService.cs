using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class MotorbikeService: IMotorbikeService
    {
        private readonly IMotorbikeRepository _repository;
        private readonly IMapper _map;

        public MotorbikeService(IMotorbikeRepository repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<ResponseViewModel<Guid>> InsertMotorbike(MotorbikeViewModel motorbikeViewModel) 
        {
            var dto = _map.Map<MotorbikeEntity>(motorbikeViewModel);
            var response = await _repository.InsertAsync(dto);
            return response;
        }

        public async Task<ResponseViewModel<MotorbikeViewModel>> GetMotorbikeByGuid(string guid)
        {
            var response = new ResponseViewModel<MotorbikeViewModel>();
            var motorbikeEntity = await _repository.GetMotorbikeByGUID(guid);
            if (motorbikeEntity != null)
            {
                response.Response = _map.Map<MotorbikeViewModel>(motorbikeEntity.Response);
                response.Message = "Success";
                return response;
            }
            response.Message = "Motorbike not found";
            return response;
        }

        public async Task<ResponseViewModel<MotorbikeViewModel>> GetMotorbikeByLicensePlate(string licensePlate)
        {
            var response = new ResponseViewModel<MotorbikeViewModel>();
            var motorbikeEntity = await _repository.GetMotorbikeByLicensePlate(licensePlate);
            if (motorbikeEntity != null) 
            {
                var motorBike = _map.Map<MotorbikeViewModel>(motorbikeEntity.Response);
                response.Response = motorBike;
                response.Message = "Success";
                return response;
            }

            response.Message = "Motorbike not found.";
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate)
        { 
            var response = new ResponseViewModel<bool>();
            response = await _repository.UpdateMotorbikeLicensePlateByGuid(guid, licensePlate);
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteMotorbikeByGuid(string guid)
        {
            return await _repository.DeleteMotorbikeByGuid(guid);
        }
    }
}
