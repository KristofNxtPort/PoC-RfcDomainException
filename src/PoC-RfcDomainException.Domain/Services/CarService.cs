using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Database.Contract.Commands;
using PoC_RfcDomainException.Database.Contract.Queries;
using PoC_RfcDomainException.Domain.Contract.Exceptions;
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
            
            var existingCar = await _queryRepository.FindCarByBrandAndModelAsync(car.Brand, car.Model, token);
            if (existingCar != null)
                throw new BrandAndModelNotUniqueException($"{car.Brand} {car.Model} already exists.");
            
            await _commandRepository.InsertCarAsync(dbModel, token);
            
            var dbCar = await _queryRepository.FindCarByBrandAndModelAsync(car.Brand, car.Model, token);
            if (dbCar == null)
                throw new CarNotFoundException($"{car.Brand} {car.Model} not found in database.");

            return _mapper.MapToDomain(dbCar);
        }

        public void TestHttpError()
        {
            throw new CarNotFoundException("This is just for testing.");
        }
    }
}