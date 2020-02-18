using FOA.GraphQL.Repositories.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOA.GraphQL.Repositories
{
    public class AllocationsRepository
    {
        private readonly GTPSContext _dbContext;
        private readonly IDependencyResolver resolver;

        public AllocationsRepository(GTPSContext dbContext,
            IDependencyResolver resolver)
        {
            _dbContext = dbContext;
            this.resolver = resolver;
        }

        public IEnumerable<Allocations> GetAll()
        {
            return _dbContext.Allocations.Take(500);
        }

        public int GetAllocationsCount()
        {
            return _dbContext.Allocations.Count();
        }

        public async Task<IEnumerable<Allocations>> GetForOrder(int OrderId, string SecurityId)
        {
            return await _dbContext.Allocations.Where(alloc => alloc.OrderId == OrderId)
                .Where(alloc => alloc.SecurityId == SecurityId).ToListAsync();
        }

        public async Task<int> GetCountForOrder(int OrderId)
        {
            var allocationCount = await _dbContext.Allocations.Where(alloc => alloc.OrderId == OrderId).CountAsync();

            return allocationCount;
        }

        public async Task<ILookup<int, Allocations>> GetForOrders(IEnumerable<int> OrderIds)
        {
            var allocations = await _dbContext.Allocations.Where(alloc => OrderIds.Contains(alloc.OrderId)).ToListAsync();

            return allocations.ToLookup(r => r.OrderId);
        }
    }
}
