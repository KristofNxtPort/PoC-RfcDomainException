using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Database.Contract.Models;

namespace PoC_RfcDomainException.Database.Contract.Commands
{
    public interface ICarCommandRepository
    {
        Task InsertCarAsync(Car car, CancellationToken token);
    }
}