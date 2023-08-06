using AutoMapper;
using monitoreo.Core.DTOs.Request;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;

namespace monitoreo.Infrastructure.Interfaces
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<ErrorLog, ErrorLogRequestDTO>();
            CreateMap<ErrorLog, ErrorLogResponseDTO>();
            CreateMap<ErrorLogRequestDTO, ErrorLog>();
            CreateMap<ErrorLogResponseDTO, ErrorLog>();
            #endregion
        }
    }
}
