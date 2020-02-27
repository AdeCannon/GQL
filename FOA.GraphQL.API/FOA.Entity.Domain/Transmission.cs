using System;

namespace FOA.Entity.Domain
{
    public class Transmission
    {
        public int TransmissionId { get; set; }
        public int AllocationId { get; set; }
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
    }
}
