using System;

namespace FOA.Entity.Domain
{
    public class Order
    {
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
    }
}
