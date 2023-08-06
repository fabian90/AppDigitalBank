using AutoMapper;
using monitoreo.Commons.RequestFilter;
using monitoreo.Commons.Response;
using monitoreo.Core.DTOs.Request;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;
using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Core.Interfaces.Services;
using System.Text.RegularExpressions;

namespace monitoreo.Core.Services
{
    public class ErrorLogService : IErrorLogService
    {
        private string table = "ErrorLog";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ErrorLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      

        public async Task<ApiResponse<ErrorLogResponseDTO>> Guardar(ErrorLogRequestDTO request)
        {
            try
            {

                var errorLog = _mapper.Map<ErrorLog>(request);

                //errorLog.Password = _passwordService.Hash(request.Password);
                //errorLog.IsActive = true;

                await _unitOfWork.ErrorLogRepository.Add(errorLog);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<ErrorLogResponseDTO>(errorLog);

                return new ApiResponse<ErrorLogResponseDTO>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }catch(Exception ex) {
            Console.WriteLine(ex.ToString());
                return new ApiResponse<ErrorLogResponseDTO>();
            }
          
        }
    }
}