using FOA.GraphQL.Repositories.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class OrderTypeUrl : ObjectGraphType<Orders>
    {
        public OrderTypeUrl
            (IDataLoaderContextAccessor dataLoaderAccessor,
            AllocationsRepositoryUrl allocationsRepositoryUrl)
        {
            Field(t => t.OrderId);
            Field(t => t.OmsOrderId);
            Field(t => t.OmsOrderVersionId);
            Field(t => t.GamId, nullable: true);
            Field(t => t.SecurityType);
            Field(t => t.TradeDate);
            Field(t => t.Trader, nullable: true);
            Field(t => t.SourceListCode, nullable: true);
            Field(t => t.SourceListitemCode);
            Field(t => t.CreatedDate);            

            // Using dataloader
            // ----------------
            Field<ListGraphType<AllocationTypeUrl>>(
                "allocations",
                resolve: context =>
                {
                    var loader =
                    dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Allocations>(
                        "GetAllocationsByOrderId", allocationsRepositoryUrl.GetForOrders);

                    return loader.LoadAsync(context.Source.OrderId);
                });

        }
    }
}