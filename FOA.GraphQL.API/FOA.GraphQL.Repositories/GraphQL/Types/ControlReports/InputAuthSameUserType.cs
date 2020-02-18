using FOA.GraphQL.Repositories.Repositories;
using FOA.Thinkfolio.ControlReports.Domain.Record;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class InputAuthSameUserType : ObjectGraphType<InputAuthSameUserRecord>
    {
        public InputAuthSameUserType
            (IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.TradeId);
            Field(t => t.UpdatedByAuthorised);
            Field(t => t.UpdatedByDateAuthorised);
            Field(t => t.UpdatedByInput);
            Field(t => t.UpdatedByDateInput);
            Field(t => t.AssetIdentifier);
            Field(t => t.AssetClass);
            Field(t => t.AssetSubClass);
            Field(t => t.Description);
            Field(t => t.InputBy);
            Field(t => t.AuthorisedBy);
            Field(t => t.PlacedBy);
            Field(t => t.FilledBy);
            Field(t => t.InputDate);
            Field(t => t.AuthorisedDate);
            Field(t => t.Counterparty);
            Field(t => t.Reason);
            Field(t => t.FilledDate);
            Field(t => t.Status);
            Field(t => t.StatusCode);
            Field(t => t.UserId);
            Field(t => t.UpdatedDate);
        }
    }
}