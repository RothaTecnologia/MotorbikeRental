using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Services.Responses;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Services
{
    public class RentalService: IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _map;

        public RentalService(IRentalRepository rentalRepository, IMapper map)
        {
            _rentalRepository = rentalRepository;
            _map = map;
        }

        public async Task<ResponseViewModel<Guid>> InsertRental(RentalViewModel rentalViewModel)
        {
            var response = await _rentalRepository.InsertAsync(_map.Map<RentalEntity>(rentalViewModel));
            return response;
        }
    }
}
