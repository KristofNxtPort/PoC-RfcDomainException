using System.Collections.Generic;
using System.Linq;
using PoC_RfcDomainException.ApiHost.Mappers.Interfaces;
using PoC_RfcDomainException.ApiHost.Models.Requests;
using PoC_RfcDomainException.ApiHost.Models.Responses;

namespace PoC_RfcDomainException.ApiHost.Mappers
{
    internal class CarMapper : ICarMapper
    {
        public Car MapToApi(Database.Contract.Models.Car car)
        {
            return new Car
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model
            };
        }

        public IReadOnlyList<Car> MapToApi(IReadOnlyList<Database.Contract.Models.Car> cars)
        {
            return cars.Select(MapToApi).ToList();
        }

        public Car MapToApi(Domain.Contract.Models.Car car)
        {
            return new Car
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model
            };
        }

        public Domain.Contract.Models.CarCreation MapToDomain(CreateCar car)
        {
            return new Domain.Contract.Models.CarCreation
            {
                Brand = car.Brand,
                Model = car.Model
            };
        }
    }
}