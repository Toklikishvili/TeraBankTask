using AutoMapper;
using TeraBankTask.Aplication.DTOs;
using TeraBankTask.Domain.Entities;

namespace TeraBankTask.Aplication.Common.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<CreateUserDTO,User>().ReverseMap();
    }
}
