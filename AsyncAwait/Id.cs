using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Id
    {
        [JsonProperty("id")]
        public int Identifier { get; set; }
    }
}
