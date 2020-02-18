using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class Orders
    {
        public Orders()
        {
            Allocations = new HashSet<Allocations>();
            InversePrevOrder = new HashSet<Orders>();
            OrderLog = new HashSet<OrderLog>();
        }

        public int OrderId { get; set; }
        public int? PrevOrderId { get; set; }
        public string SourceListCode { get; set; }
        public string SourceListitemCode { get; set; }
        public string OmsOrderId { get; set; }
        public string OmsOrderVersionId { get; set; }
        public string TradeStatusListCode { get; set; }
        public string TradeStatusListitemCode { get; set; }
        public string SecurityType { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime? SettlDate { get; set; }
        public string GamId { get; set; }
        public string Trader { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? AuditId { get; set; }

        public Orders PrevOrder { get; set; }
        public Listitem SourceList { get; set; }
        public Listitem TradeStatusList { get; set; }
        public ICollection<Allocations> Allocations { get; set; }
        public ICollection<Orders> InversePrevOrder { get; set; }
        public ICollection<OrderLog> OrderLog { get; set; }
    }
}
