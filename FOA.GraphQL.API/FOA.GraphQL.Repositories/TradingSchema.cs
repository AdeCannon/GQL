using FOA.GraphQL.Repositories.GraphQL;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOA.GraphQL.Repositories
{
    public class TradingSchema : Schema
    {
        public TradingSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TradingQuery>();
        }
    }
}
