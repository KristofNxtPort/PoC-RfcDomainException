using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoC_RfcDomainException.ApiHost.Contract.Responses;
using PoC_RfcDomainException.Database.Contract.Queries;

namespace PoC_RfcDomainException.ApiHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarQueryRepository _queryRepository;

        public CarsController(ICarQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IReadOnlyCollection<Car>>> GetAllAsync(CancellationToken token)
        {
            return Ok(await _queryRepository.GetCarsAsync(token));
        }
    }
}