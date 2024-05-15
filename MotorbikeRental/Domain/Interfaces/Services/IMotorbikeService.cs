using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IMotorbikeService
    {
        Task<ResponseViewModel<Guid>> InsertMotorbike(MotorbikeViewModel motorbikeViewModel);
        Task<ResponseViewModel<MotorbikeViewModel>> GetMotorbikeByGuid(string guid);
        Task<ResponseViewModel<MotorbikeViewModel>> GetMotorbikeByLicensePlate(string licensePlate);
        Task<ResponseViewModel<bool>> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate);
        Task<ResponseViewModel<bool>> DeleteMotorbikeByGuid(string guid);
    }
}
