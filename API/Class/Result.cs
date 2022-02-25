using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Class
{
    public class Result
    {
        //reetorno un string porque pueden ser números grandes que no quepan en UInt64
        public string result { get; set; }
        public bool fibonacci { get; set; } = false;
    }
}
