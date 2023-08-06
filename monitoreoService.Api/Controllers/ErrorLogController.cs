using AutoMapper;
using monitoreo.Commons.RequestFilter;
using monitoreo.Commons.Response;
using FluentValidation;
using monitoreo.Core.DTOs.Request;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;
using monitoreo.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Identity.API.Controllers
{
    [ApiController]
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ErrorLogController : ControllerBase
    {
        private readonly IErrorLogService _errorLogService;
        private readonly IMapper _mapper;
        private readonly IValidator<ErrorLogRequestDTO> _validator;

        public ErrorLogController(IErrorLogService errorLogService, IMapper mapper, 
            IValidator<ErrorLogRequestDTO> validator)
        {
            _errorLogService = errorLogService;
            _mapper = mapper;
            _validator = validator;
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ErrorLogRequestDTO request)
        {
            var response = await _errorLogService.Guardar(request);

            return Ok(response);
        }

    }
}
