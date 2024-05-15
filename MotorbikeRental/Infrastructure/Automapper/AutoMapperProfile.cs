using AutoMapper;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Services.Viewmodels;

namespace MotorbikeRental.Infrastructure.Automapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MotorbikeViewModel, MotorbikeEntity>()
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(dest => dest.LicensePlate))
                .ForMember(dest => dest.Year, opt => opt.MapFrom<int>(dest => dest.Year))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(dest => dest.Model));

            CreateMap<MotorbikeEntity, MotorbikeViewModel>()
                .ForMember(dest => dest.MotorbikeEntityID, opt => opt.MapFrom(dest => dest.MotorbikeEntityID))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(dest => dest.LicensePlate))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(dest => dest.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(dest => dest.Year));

            CreateMap<DeliverymanEntity, DeliverymanViewModel>()
                .ForMember(dest => dest.CNHImage, opt => opt.MapFrom(dest => dest.CNHImage))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(dest => dest.CNPJ))
                .ForMember(dest => dest.DateBirth, opt => opt.MapFrom(dest => dest.DateBirth))
                .ForMember(dest => dest.DeliverymanID, opt => opt.MapFrom(dest => dest.DeliverymanID));

            CreateMap<DeliverymanViewModel, DeliverymanEntity>()
                .ForMember(dest => dest.CNHImage, opt => opt.MapFrom(dest => dest.CNHImage))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(dest => dest.CNPJ))
                .ForMember(dest => dest.DateBirth, opt => opt.MapFrom(dest => dest.DateBirth));

            CreateMap<UserViewModel, UserEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(dest => dest.Email))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(dest => dest.Login));

            CreateMap<UserEntity, UserViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(dest => dest.Email))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(dest => dest.Login))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(dest => dest.UserID));

            CreateMap<UserTypeViewModel, UserTypeEntity>()
                .ForMember(dest => dest.UserTypeID, opt => opt.MapFrom(dest => dest.UserTypeID))
                .ForMember(dest => dest.UserTypeDescription, opt => opt.MapFrom(dest => dest.UserTypeDescription));

            CreateMap<UserTypeEntity, UserTypeViewModel > ()
                .ForMember(dest => dest.UserTypeID, opt => opt.MapFrom(dest => dest.UserTypeID))
                .ForMember(dest => dest.UserTypeDescription, opt => opt.MapFrom(dest => dest.UserTypeDescription));
        }
    }
}
