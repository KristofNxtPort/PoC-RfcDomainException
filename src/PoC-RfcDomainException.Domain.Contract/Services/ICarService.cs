using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Domain.Contract.Models;

namespace PoC_RfcDomainException.Domain.Contract.Services
{
    public interface ICarService
    {
        Task<Car> CreateCarAsync(CarCreation car, CancellationToken token);
    }
}