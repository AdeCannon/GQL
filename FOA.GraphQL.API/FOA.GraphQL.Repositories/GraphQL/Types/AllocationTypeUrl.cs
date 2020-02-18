using FOA.Entity.Domain;
using FOA.GraphQL.Repositories.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class AllocationTypeUrl : ObjectGraphType<Allocations>
    {
        public AllocationTypeUrl(
            IDataLoaderContextAccessor dataLoaderAccessor,
            TransmissionsRepositoryUrl transmissionRepositoryUrl)
        {
            Field(t => t.OrderId); 
            Field(t => t.AllocationId);
            Field(t => t.GamFundCode, nullable: true);
            Field(t => t.PortfolioCode);
            Field(t => t.SecurityDesc);
            Field(t => t.SecurityCcy);
            Field(t => t.Price);
            Field(t => t.Quantity);
            Field(t => t.SecurityId);
            Field<ListGraphType<TransmissionTypeUrl>>(
                "transmissions",
                resolve: context =>
                {
                    var loader =
                    dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Transmission>(
                        "GetTransmissionByAllocationId", transmissionRepositoryUrl.GetForAllocationIds);

                    return loader.LoadAsync(context.Source.AllocationId);
                });
        }
    }
}
