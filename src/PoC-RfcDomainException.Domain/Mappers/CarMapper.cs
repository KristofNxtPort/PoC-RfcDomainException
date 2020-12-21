using PoC_RfcDomainException.Domain.Contract.Models;
using PoC_RfcDomainException.Domain.Mappers.Interfaces;

namespace PoC_RfcDomainException.Domain.Mappers
{
    internal class CarMapper : ICarMapper
    {
        public Database.Contract.Models.Car MapToDb(CarCreation car)
        {
            return new Database.Contract.Models.Car
            {
                Brand = car.Brand,
                Model = car.Model
            };
        }

        public Car MapToDomain(Database.Contract.Models.Car car)
        {
            return new Car
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model
            };
        }
    }
}