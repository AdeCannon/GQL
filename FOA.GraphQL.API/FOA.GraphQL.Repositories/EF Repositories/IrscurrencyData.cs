using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class IrscurrencyData
    {
        public string Cac { get; set; }
        public string Ccy { get; set; }
        public string Type { get; set; }
        public int Mintenor { get; set; }
        public int Maxtenor { get; set; }
    }
}
