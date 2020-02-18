using FOA.GraphQL.Repositories.Repositories;
using FOA.Thinkfolio.ControlReports.Domain.Record;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class BackFromTransferredType : ObjectGraphType<BackFromTransferredRecord>
    {
        public BackFromTransferredType
            (IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.TradeId);
            Field(t => t.AssetIdentifier);
            Field(t => t.AssetClass);
            Field(t => t.AssetSubClass);
            Field(t => t.DealDate);
            Field(t => t.Description);
            Field(t => t.Counterparty);
            Field(t => t.CancelReason);
            Field(t => t.ReasonCode);
            Field(t => t.InputBy);
            Field(t => t.PlacedBy);
            Field(t => t.TransferredBy);
            Field(t => t.WorkingDate);
            Field(t => t.ConfirmedDate);
            Field(t => t.InputDate);
            Field(t => t.Status);
            Field(t => t.StatusCode);
            Field(t => t.UserId);
            Field(t => t.UpdatedDate);
        }
    }
}