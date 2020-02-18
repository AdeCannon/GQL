﻿using FOA.GraphQL.Repositories.Repositories;
using FOA.Thinkfolio.ControlReports.Domain.Record;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class UnsolicitedTradingType : ObjectGraphType<UnsolicitedTradingRecord>
    {
        public UnsolicitedTradingType
            (IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.TradeId);
            Field(t => t.FirstDealDate);
            Field(t => t.FirstAuthorisedDate);
            Field(t => t.ReportedDate);
            Field(t => t.InputDate);
            Field(t => t.AssetIdentifier);
            Field(t => t.AssetClass);
            Field(t => t.AssetSubClass);
            Field(t => t.Description);
            Field(t => t.InputBy);
            Field(t => t.AuthorisedBy);
            Field(t => t.WorkedBy);
            Field(t => t.FilledBy);
            Field(t => t.PlacedBy);
            Field(t => t.ReportedBy);
            Field(t => t.Counterparty);
            Field(t => t.Reason);
            Field(t => t.DealDate);
            Field(t => t.AuthorisedDate);
            Field(t => t.FilledDate);
            Field(t => t.Status);
            Field(t => t.StatusCode);
            Field(t => t.UserId);
            Field(t => t.UpdatedDate);
        }
    }
}