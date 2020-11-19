using AutoMapper;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.Mappings.AutoMapper
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyJobAdvertisement, CompanyJobAdvertisementDto>().ReverseMap();
            CreateMap<UserCv, UserCvDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCvEducation, UserCvEducationDto>().ReverseMap();
            CreateMap<UserCvWorkingExperience, UserCvWorkingExperienceDto>().ReverseMap();

        }
    }
}
