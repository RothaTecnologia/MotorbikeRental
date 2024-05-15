using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IMotorbikeService
    {
        Task<Guid> InsertMotorbike(MotorbikeViewModel motorbikeViewModel);
        Task<MotorbikeViewModel> GetMotorbikeByGuid(string guid);
        Task<MotorbikeViewModel> GetMotorbikeByLicensePlate(string licensePlate);
        Task<bool> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate);
        Task<bool> DeleteMotorbikeByGuid(string guid);
    }
}
