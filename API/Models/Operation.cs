using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Operation
    {
        public long Id { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string Result { get; set; }
    }
}
