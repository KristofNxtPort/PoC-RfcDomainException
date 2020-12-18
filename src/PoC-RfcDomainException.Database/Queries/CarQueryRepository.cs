using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoC_RfcDomainException.Database.Contract.Models;
using PoC_RfcDomainException.Database.Contract.Queries;

namespace PoC_RfcDomainException.Database.Queries
{
    internal class CarQueryRepository : ICarQueryRepository
    {
        private readonly CarDbContext _dbContext;

        public CarQueryRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Car>> GetCarsAsync(CancellationToken token)
        {
            return await _dbContext.Cars.ToListAsync(token);
        }
    }
}