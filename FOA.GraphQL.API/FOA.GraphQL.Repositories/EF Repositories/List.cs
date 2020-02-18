using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class List
    {
        public List()
        {
            Listitem = new HashSet<Listitem>();
        }

        public string ListCode { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public long? AuditId { get; set; }

        public ICollection<Listitem> Listitem { get; set; }
    }
}
