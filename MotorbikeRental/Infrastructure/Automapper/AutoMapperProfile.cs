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
                .ForMember(dest => dest.DeliverymanID, opt => opt.MapFrom(dest => dest.DeliverymanID))
                .ForMember(dest => dest.CNHImageBytes, opt => opt.MapFrom(dest => dest.CNHImageBytes))
                .ForMember(dest => dest.CNH, opt => opt.MapFrom(dest => dest.CNH));

            CreateMap<DeliverymanViewModel, DeliverymanEntity>()
                .ForMember(dest => dest.CNHImage, opt => opt.MapFrom(dest => dest.CNHImage))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(dest => dest.CNPJ))
                .ForMember(dest => dest.DateBirth, opt => opt.MapFrom(dest => dest.DateBirth))
                .ForMember(dest => dest.CNHImageBytes, opt => opt.MapFrom(dest => dest.CNHImageBytes))
                .ForMember(dest => dest.CNH, opt => opt.MapFrom(dest => dest.CNH));

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

            CreateMap<AdditionalDailyRateEntity, AdditionalDailyRateViewModel>()
                .ForMember(dest => dest.AdditionalDailyCost, opt => opt.MapFrom(dest => dest.AdditionalDailyCost));

            CreateMap<AdditionalDailyRateViewModel, AdditionalDailyRateEntity>()
                .ForMember(dest => dest.AdditionalDailyCost, opt => opt.MapFrom(dest => dest.AdditionalDailyCost));

            CreateMap<PlanEntity, PlanViewModel>()
                .ForMember(dest => dest.Fine, opt => opt.MapFrom(dest => dest.Fine))
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(dest => dest.Plan))
                .ForMember(dest => dest.Days, opt => opt.MapFrom(dest => dest.Days))
                .ForMember(dest => dest.CostPerDay, opt => opt.MapFrom(dest => dest.CostPerDay));

            CreateMap<PlanViewModel, PlanEntity>()
                .ForMember(dest => dest.Fine, opt => opt.MapFrom(dest => dest.Fine))
                .ForMember(dest => dest.CostPerDay, opt => opt.MapFrom(dest => dest.CostPerDay))
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(dest => dest.Plan))
                .ForMember(dest => dest.Days, opt => opt.MapFrom(dest => dest.Days))
                .ForMember(dest => dest.IDPlan, opt => opt.MapFrom(dest => dest.IDPlan));

            CreateMap<RentalEntity, RentalViewModel>()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(dest => dest.EndDate))
                .ForMember(dest => dest.EstimateEndDate, opt => opt.MapFrom(dest => dest.EstimateEndDate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(dest => dest.StartDate));

            CreateMap<RentalViewModel, RentalEntity > ()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(dest => dest.EndDate))
                .ForMember(dest => dest.EstimateEndDate, opt => opt.MapFrom(dest => dest.EstimateEndDate))
                .ForMember(dest => dest.RentalID, opt => opt.MapFrom(dest => dest.RentalID))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(dest => dest.StartDate));
        }
    }
}
