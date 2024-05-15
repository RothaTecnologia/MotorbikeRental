using MotorbikeRental.Domain.Entities;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IMotorbikeRepository
    {
        Task<Guid> InsertAsync(MotorbikeEntity obj);

        Task<MotorbikeEntity> GetMotorbikeByGUID(string guid);

        Task<MotorbikeEntity> GetMotorbikeByLicensePlate(string licensePlate);

        Task<bool> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate);

        Task<bool> DeleteMotorbikeByGuid(string guid);
    }
}
