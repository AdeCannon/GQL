using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class Listitem
    {
        public Listitem()
        {
            Allocations = new HashSet<Allocations>();
            OrdersSourceList = new HashSet<Orders>();
            OrdersTradeStatusList = new HashSet<Orders>();
            ScheduledTask = new HashSet<ScheduledTask>();
            TransmissionLogStatusList = new HashSet<TransmissionLog>();
            TransmissionLogTypeList = new HashSet<TransmissionLog>();
            TransmissionsDestinationList = new HashSet<Transmissions>();
            TransmissionsProcList = new HashSet<Transmissions>();
            TransmissionsPurposeList = new HashSet<Transmissions>();
            TransmissionsStatusList = new HashSet<Transmissions>();
            TransmissionsTypeList = new HashSet<Transmissions>();
        }

        public string ListitemCode { get; set; }
        public string ListCode { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int? ListOrder { get; set; }
        public long? AuditId { get; set; }

        public List ListCodeNavigation { get; set; }
        public ICollection<Allocations> Allocations { get; set; }
        public ICollection<Orders> OrdersSourceList { get; set; }
        public ICollection<Orders> OrdersTradeStatusList { get; set; }
        public ICollection<ScheduledTask> ScheduledTask { get; set; }
        public ICollection<TransmissionLog> TransmissionLogStatusList { get; set; }
        public ICollection<TransmissionLog> TransmissionLogTypeList { get; set; }
        public ICollection<Transmissions> TransmissionsDestinationList { get; set; }
        public ICollection<Transmissions> TransmissionsProcList { get; set; }
        public ICollection<Transmissions> TransmissionsPurposeList { get; set; }
        public ICollection<Transmissions> TransmissionsStatusList { get; set; }
        public ICollection<Transmissions> TransmissionsTypeList { get; set; }
    }
}
