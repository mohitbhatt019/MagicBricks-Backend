using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MagicBricks.Applications.DTOs.DTOMapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<PropertyDTO, Property>();
            CreateMap<Property, PropertyDTO>();

        }

    }
}
