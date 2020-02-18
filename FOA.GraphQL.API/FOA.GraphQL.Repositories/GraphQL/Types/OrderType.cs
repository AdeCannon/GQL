using FOA.GraphQL.Repositories.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class OrderType : ObjectGraphType<Orders>
    {
        public OrderType
            (IDataLoaderContextAccessor dataLoaderAccessor,
            AllocationsRepository allocationsRepository)
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
            Field<ListGraphType<AllocationType>>(
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