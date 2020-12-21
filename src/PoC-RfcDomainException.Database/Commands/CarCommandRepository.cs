using System.Threading;
using System.Threading.Tasks;
using PoC_RfcDomainException.Database.Contract.Commands;
using PoC_RfcDomainException.Database.Contract.Models;

namespace PoC_RfcDomainException.Database.Commands
{
    internal class CarCommandRepository : ICarCommandRepository
    {
        private readonly CarDbContext _dbContext;

        public CarCommandRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertCarAsync(Car car, CancellationToken token)
        {
            await _dbContext.Cars.AddAsync(car, token);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}