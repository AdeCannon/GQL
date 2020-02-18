using FOA.GraphQL.Repositories.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class MartinType : ObjectGraphType<Orders>
    {
        public MartinType
            (IDataLoaderContextAccessor dataLoaderAccessor,
            AllocationsRepositoryUrl allocationsRepository)
        {
            Field(t => t.OrderId);
            Field(t => t.OmsOrderId);
            Field(t => t.OmsOrderVersionId);
            Field(t => t.GamId);
            Field(t => t.SecurityType);
            Field(t => t.TradeDate);
            Field(t => t.Trader);
            Field(t => t.SourceListCode);
            Field(t => t.SourceListitemCode);
            Field(t => t.CreatedDate);            
            Field<IntGraphType>().Name("allocationCount").ResolveAsync(async (context) =>
            {
                return await allocationsRepository.GetCountForOrder(context.Source.OrderId);
            });

            // Using dataloader
            // ----------------
            Field<ListGraphType<AllocationTypeUrl>>(
                "allocations",
                resolve: context =>
                {
                    var loader =
                    dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Allocations>(
                        "GetAllocationsByOrderId", allocationsRepository.GetForOrders);

                    return loader.LoadAsync(context.Source.OrderId);
                });

        }
    }
}