using PoC_RfcDomainException.Domain.Contract.Models;

namespace PoC_RfcDomainException.Domain.Mappers.Interfaces
{
    internal interface ICarMapper
    {
        Database.Contract.Models.Car MapToDb(CarCreation car);
        Car MapToDomain(Database.Contract.Models.Car car);
    }
}