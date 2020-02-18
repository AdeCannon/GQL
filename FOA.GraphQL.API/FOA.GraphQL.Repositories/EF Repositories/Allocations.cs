using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class Allocations
    {
        public Allocations()
        {
            AllocationTransmissionRef = new HashSet<AllocationTransmissionRef>();
        }

        public int AllocationId { get; set; }
        public int OrderId { get; set; }
        public string PortfolioCode { get; set; }
        public string SecurityDesc { get; set; }
        public string SecurityCcy { get; set; }
        public string SecurityId { get; set; }
        public string SideListCode { get; set; }
        public string SideListitemCode { get; set; }
        public decimal Quantity { get; set; }
        public string SettlCcy { get; set; }
        public decimal Price { get; set; }
        public decimal NetAmount { get; set; }
        public string ExecBroker { get; set; }
        public string ClearBroker { get; set; }
        public string GamFundCode { get; set; }
        public string ExecBrokerBic { get; set; }
        public string ClearBrokerBic { get; set; }
        public long? AuditId { get; set; }
        public byte[] RowVersion { get; set; }

        public Orders Order { get; set; }
        public Listitem SideList { get; set; }
        public ICollection<AllocationTransmissionRef> AllocationTransmissionRef { get; set; }
    }
}
