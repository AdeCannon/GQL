using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class SystemParameters
    {
        public int SystemParameterId { get; set; }
        public string CategoryName { get; set; }
        public string SectionName { get; set; }
        public string Environment { get; set; }
        public string ParamName { get; set; }
        public string TextValue { get; set; }
        public decimal? NumericValue { get; set; }
        public DateTime? DateValue { get; set; }
        public bool? BooleanValue { get; set; }
        public string Description { get; set; }
        public long? AuditId { get; set; }
    }
}
