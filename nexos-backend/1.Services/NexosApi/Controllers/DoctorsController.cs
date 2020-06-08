using Application.Contracts.Nexos;
using AutoMapper;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NexosApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class DoctorsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IDoctorApplicationService _doctorApplicationService;

    public DoctorsController(IMapper mapper, ILogger logger, IDoctorApplicationService doctorApplicationService)
    {
      _mapper = mapper;
      _logger = logger;
      _doctorApplicationService = doctorApplicationService;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
      _logger.LogInformation("GET Doctors List called");
      var data = _doctorApplicationService.List().Select(_mapper.Map<Doctor>);
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
      _logger.LogInformation($"GET Doctors by id: {id} called");
      var data = await _doctorApplicationService.GetById(id);
      return Ok(_mapper.Map<Doctor>(data));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(Doctor doctor)
    {
      _logger.LogInformation($"POST create new Doctor called");
      var data = await _doctorApplicationService.Create(_mapper.Map<Domain.Entities.Doctor>(doctor));
      if (!data.Status) return BadRequest(data.Errors);
      return Created("", data.Data);
    }
  }
}