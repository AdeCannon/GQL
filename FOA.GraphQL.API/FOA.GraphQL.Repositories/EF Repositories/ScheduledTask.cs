using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class ScheduledTask
    {
        public ScheduledTask()
        {
            ScheduledTaskTransmissionRef = new HashSet<ScheduledTaskTransmissionRef>();
        }

        public int ScheduledTaskId { get; set; }
        public string ScheduledTaskXml { get; set; }
        public string TypeListCode { get; set; }
        public string TypeListitemCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? AuditId { get; set; }

        public Listitem TypeList { get; set; }
        public ICollection<ScheduledTaskTransmissionRef> ScheduledTaskTransmissionRef { get; set; }
    }
}
