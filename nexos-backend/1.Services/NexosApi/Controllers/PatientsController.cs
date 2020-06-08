using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Nexos;
using AutoMapper;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NexosApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IPatientApplicationService _patientApplicationService;

    public PatientsController(IMapper mapper, ILogger logger, IPatientApplicationService patientApplicationService)
    {
      _mapper = mapper;
      _logger = logger;
      _patientApplicationService = patientApplicationService;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
      _logger.LogInformation("GET Patients List called");
      var data = _patientApplicationService.List();
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
      _logger.LogInformation($"GET Patient by Id: {id} called");
      var data = await _patientApplicationService.GetById(id);
      if (data == null)
      {
        _logger.LogInformation($"GET Patient by Id: {id} NOT FOUND");
        return NotFound();
      }
      return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(Patient patient)
    {
      _logger.LogInformation($"POST Patient created called");
      var data = await _patientApplicationService.Create(patient);
      if (!data.Status) return BadRequest(data.Errors);
      return Created("", _mapper.Map<Patient>(data.Data));
    }

    [HttpPut("")]
    public async Task<IActionResult> Update(Patient patient)
    {
      _logger.LogInformation($"PUT Patient updated called");
      var data = await _patientApplicationService.Edit(patient);
      if (!data.Status) return BadRequest(data.Errors);
      return Ok(_mapper.Map<Patient>(data.Data));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      _logger.LogInformation($"DELETE Patient delete called");
      var data = await _patientApplicationService.Remove(x => x.Id == id);
      if (!data.Status) return BadRequest(data.Errors);
      return NoContent();
    }
  }
}