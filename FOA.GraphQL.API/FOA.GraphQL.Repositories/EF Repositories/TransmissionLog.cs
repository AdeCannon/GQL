using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class TransmissionLog
    {
        public int TransmissionLogId { get; set; }
        public int TransmissionId { get; set; }
        public string TypeListCode { get; set; }
        public string TypeListitemCode { get; set; }
        public string StatusListCode { get; set; }
        public string StatusListitemCode { get; set; }
        public string Comment { get; set; }
        public string Content { get; set; }
        public long? AuditId { get; set; }

        public Listitem StatusList { get; set; }
        public Transmissions Transmission { get; set; }
        public Listitem TypeList { get; set; }
    }
}
