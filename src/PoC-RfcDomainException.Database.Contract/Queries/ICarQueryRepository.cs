using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Database.Contract.Models;

namespace PoC_RfcDomainException.Database.Contract.Queries
{
    public interface ICarQueryRepository
    {
        Task<IReadOnlyList<Car>> GetCarsAsync(CancellationToken token);
        Task<Car> GetCarAsync(Guid id, CancellationToken token);
        Task<Car> FindCarByBrandAndModelAsync(string brand, string model, CancellationToken token);
    }
}