using FOA.Entity.Domain;
using GraphQL.Types;

namespace FOA.GraphQL.Repositories.GraphQL.Types
{
    public class TransmissionTypeUrl : ObjectGraphType<Transmission>
    {
        public TransmissionTypeUrl()
        {
            Field(t => t.TransmissionId);
            Field(t => t.AllocationId);
            Field(t => t.DestinationListitemCode);
            Field(t => t.TypeListitemCode);
            Field(t => t.ProcListitemCode);
            Field(t => t.StatusListitemCode);
            Field(t => t.PurposeListCode);
            Field(t => t.Comment, nullable: true);
        }
    }
}
