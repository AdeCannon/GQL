using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class Transmissions
    {
        public Transmissions()
        {
            AllocationTransmissionRef = new HashSet<AllocationTransmissionRef>();
            ScheduledTaskTransmissionRef = new HashSet<ScheduledTaskTransmissionRef>();
            TransmissionLog = new HashSet<TransmissionLog>();
        }

        public int TransmissionId { get; set; }
        public string DestinationListCode { get; set; }
        public string DestinationListitemCode { get; set; }
        public string TypeListCode { get; set; }
        public string TypeListitemCode { get; set; }
        public string PurposeListCode { get; set; }
        public string PurposeListitemCode { get; set; }
        public string StatusListCode { get; set; }
        public string StatusListitemCode { get; set; }
        public string Comment { get; set; }
        public long? AuditId { get; set; }
        public byte[] RowVersion { get; set; }
        public string ProcListCode { get; set; }
        public string ProcListitemCode { get; set; }

        public Listitem DestinationList { get; set; }
        public Listitem ProcList { get; set; }
        public Listitem PurposeList { get; set; }
        public Listitem StatusList { get; set; }
        public Listitem TypeList { get; set; }
        public ICollection<AllocationTransmissionRef> AllocationTransmissionRef { get; set; }
        public ICollection<ScheduledTaskTransmissionRef> ScheduledTaskTransmissionRef { get; set; }
        public ICollection<TransmissionLog> TransmissionLog { get; set; }
    }
}
