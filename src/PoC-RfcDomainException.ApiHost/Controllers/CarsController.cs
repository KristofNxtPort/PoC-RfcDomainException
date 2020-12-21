using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoC_RfcDomainException.ApiHost.Mappers.Interfaces;
using PoC_RfcDomainException.ApiHost.Models.Requests;
using PoC_RfcDomainException.ApiHost.Models.Responses;
using PoC_RfcDomainException.Database.Contract.Queries;
using PoC_RfcDomainException.Domain.Contract.Services;

namespace PoC_RfcDomainException.ApiHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarQueryRepository _queryRepository;
        private readonly ICarMapper _mapper;
        private readonly ICarService _service;

        public CarsController(ICarQueryRepository queryRepository, ICarMapper mapper, ICarService service)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<Car>>> GetAllAsync(CancellationToken token)
        {
            var cars = await _queryRepository.GetCarsAsync(token);
            return Ok(_mapper.MapToApi(cars));
        }

        [HttpGet]
        [Route("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Car>> GetAsync(Guid id, CancellationToken token)
        {
            var car = await _queryRepository.GetCarAsync(id, token);
            
            if (car == null)
                return NotFound();
            
            return Ok(_mapper.MapToApi(car));
        }

        [HttpPost]
        [Route("")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<ActionResult<Car>> CreateAsync(CreateCar car, CancellationToken token)
        {
            var domainModel = _mapper.MapToDomain(car);
            var domainCar = await _service.CreateCarAsync(domainModel, token);
            
            var createdCar = _mapper.MapToApi(domainCar);
            return CreatedAtAction(nameof(GetAsync), new { id = createdCar.Id }, createdCar);
        }
    }
}