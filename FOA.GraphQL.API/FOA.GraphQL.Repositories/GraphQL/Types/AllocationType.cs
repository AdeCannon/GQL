using FOA.GraphQL.Repositories.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class AllocationType : ObjectGraphType<Allocations>
    {
        public AllocationType()
        {
            Field(t => t.OrderId); 
            Field(t => t.AllocationId);
            Field(t => t.GamFundCode);
            Field(t => t.PortfolioCode);
            Field(t => t.SecurityDesc);
            Field(t => t.SecurityCcy);
            Field(t => t.Price);
            Field(t => t.Quantity);
            Field(t => t.SecurityId);
            //Field<ListGraphType<AllocationTransmissionRef>>(
            //    "AllocationTransmissionRef",
            //    resolve: context =>
            //    {
            //        var loader =
            //        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, AllocationTransmissionRef>(
            //            "GettransmissionRefsByAllocationId", transmissionRefRepository.GetForAllocation);

            //        return loader.LoadAsync(context.Source.OrderId);
            //    });
        }
    }
}
