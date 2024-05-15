using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Responses;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IMotorbikeRepository
    {
        Task<ResponseViewModel<Guid>> InsertAsync(MotorbikeEntity obj);

        Task<ResponseViewModel<MotorbikeEntity>> GetMotorbikeByGUID(string guid);

        Task<ResponseViewModel<MotorbikeEntity>> GetMotorbikeByLicensePlate(string licensePlate);

        Task<ResponseViewModel<bool>> UpdateMotorbikeLicensePlateByGuid(string guid, string licensePlate);

        Task<ResponseViewModel<bool>> DeleteMotorbikeByGuid(string guid);
    }
}
