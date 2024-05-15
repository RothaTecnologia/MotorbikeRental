using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Infrastructure.Automapper
{
    public class MapperConfig
    {

        public static Mapper InitializeAutomapper()
        {
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MotorbikeViewModel, MotorbikeEntity>()

                    //Ignoring the Address property of the destination type
                    .ForMember(dest => dest.MotorbikeEntityID, act => act.Ignore());
            });

            //Creating the Mapper Instance
            var mapper = new Mapper(config);

            //returning the Mapper Instance
            return mapper;
        }
    }
}
