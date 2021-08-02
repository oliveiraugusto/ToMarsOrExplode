using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToMarsOrExplode.Api.Models
{
    public class ProbeModel
    {
        public string ProbeNumber { get; set; }
        public string xPoint { get; set; }
        public string yPoint { get; set; }
        public string cardinalPoint { get; set; }
        public string command { get; set; }
    }
}
