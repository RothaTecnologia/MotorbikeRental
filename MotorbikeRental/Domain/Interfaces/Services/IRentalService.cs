using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Domain.Interfaces.Services
{
    public interface IRentalService
    {
        Task<ResponseViewModel<Guid>> InsertRental(RentalViewModel rentalEntity);
    }
}
