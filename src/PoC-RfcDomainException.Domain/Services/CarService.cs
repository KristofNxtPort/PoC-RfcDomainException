﻿using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Database.Contract.Commands;
using PoC_RfcDomainException.Database.Contract.Queries;
using PoC_RfcDomainException.Domain.Contract.Models;
using PoC_RfcDomainException.Domain.Contract.Services;
using PoC_RfcDomainException.Domain.Mappers.Interfaces;

namespace PoC_RfcDomainException.Domain.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarMapper _mapper;
        private readonly ICarCommandRepository _commandRepository;
        private readonly ICarQueryRepository _queryRepository;

        public CarService(ICarMapper mapper, ICarCommandRepository commandRepository, ICarQueryRepository queryRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        
        public async Task<Car> CreateCarAsync(CarCreation car, CancellationToken token)
        {
            var dbModel = _mapper.MapToDb(car);
            await _commandRepository.InsertCarAsync(dbModel, token);
            var dbCar = await _queryRepository.FindCarByBrandAndModelAsync(car.Brand, car.Model, token);
            return _mapper.MapToDomain(dbCar);
        }
    }
}