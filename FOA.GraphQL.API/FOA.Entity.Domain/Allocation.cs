using System;

namespace FOA.Entity.Domain
{
    public class Allocation
    {
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
    }
}