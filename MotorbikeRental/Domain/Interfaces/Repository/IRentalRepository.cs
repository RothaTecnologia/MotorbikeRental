using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Responses;

namespace MotorbikeRental.Domain.Interfaces.Repository
{
    public interface IRentalRepository
    {
        Task<ResponseViewModel<Guid>> InsertAsync(RentalEntity obj);
    }
}
