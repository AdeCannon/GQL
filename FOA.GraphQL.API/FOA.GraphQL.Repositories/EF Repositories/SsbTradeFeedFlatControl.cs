using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class SsbTradeFeedFlatControl
    {
        public int ControlId { get; set; }
        public int ExternalId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
