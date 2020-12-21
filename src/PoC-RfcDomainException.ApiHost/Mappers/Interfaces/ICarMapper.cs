using System.Collections.Generic;
using PoC_RfcDomainException.ApiHost.Models.Requests;
using PoC_RfcDomainException.ApiHost.Models.Responses;

namespace PoC_RfcDomainException.ApiHost.Mappers.Interfaces
{
    public interface ICarMapper
    {
        Car MapToApi(Database.Contract.Models.Car car);
        IReadOnlyList<Car> MapToApi(IReadOnlyList<Database.Contract.Models.Car> cars);
        Car MapToApi(Domain.Contract.Models.Car car);
        Domain.Contract.Models.CarCreation MapToDomain(CreateCar car);
    }
}