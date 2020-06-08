using Application.Contracts.Nexos;
using AutoMapper;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NexosApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class HospitalsController : ControllerBase
  {
    private readonly IHospitalApplicationService _hospitalApplicationService;
    private readonly IMapper _mapper;

    public HospitalsController(IHospitalApplicationService hospitalApplicationService, IMapper mapper)
    {
      _hospitalApplicationService = hospitalApplicationService;
      _mapper = mapper;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
      var data = _hospitalApplicationService.Queryable().Select(_mapper.Map<Hospital>);
      return Ok(data);
    }
  }
}