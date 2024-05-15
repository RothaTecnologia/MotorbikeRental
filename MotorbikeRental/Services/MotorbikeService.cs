using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
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

        public async Task<Guid> InsertMotorbike(MotorbikeViewModel motorbikeViewModel) 
        {
            var dto = _map.Map<MotorbikeEntity>(motorbikeViewModel);
            var guid = await _repository.InsertAsync(dto);
            return guid;
        }

        public async Task<MotorbikeViewModel> GetMotorbikeByGuid(string guid)
        { 
            var motorbikeEntity = await _repository.GetMotorbikeByGUID(guid);
            var motorBike = _map.Map<MotorbikeViewModel>(motorbikeEntity);
            return motorBike;
        }

        public async Task<MotorbikeViewModel> GetMotorbikeByLicensePlate(string licensePlate)
        {
            var motorbikeEntity = await _repository.GetMotorbikeByLicensePlate(licensePlate);
            var motorBike = _map.Map<MotorbikeViewModel>(motorbikeEntity);
            return motorBike;
        }

        public async Task<bool> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate)
        { 
            return await _repository.UpdateMotorbikeLicensePlateByGuid(guid, licensePlate);
        }

        public async Task<bool> DeleteMotorbikeByGuid(string guid)
        {
            return await _repository.DeleteMotorbikeByGuid(guid);
        }
    }
}
