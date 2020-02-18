using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class OrderLog
    {
        public int OrderLogId { get; set; }
        public int OrderId { get; set; }
        public string StatusListCode { get; set; }
        public string StatusListitemCode { get; set; }
        public string Comment { get; set; }
        public long? AuditId { get; set; }

        public Orders Order { get; set; }
    }
}
