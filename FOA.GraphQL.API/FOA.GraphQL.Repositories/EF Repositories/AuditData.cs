using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class AuditData
    {
        public long AuditId { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ChangedType { get; set; }
        public string ChangedBy { get; set; }
        public string ApplicationName { get; set; }
        public string HostName { get; set; }
        public long? LastAuditId { get; set; }
    }
}
