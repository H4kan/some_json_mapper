using livecode.core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace livecode.core
{
    public class BaseMapping : IMapping
    {
        [JsonConverter(typeof(InputConverter))]
        public dynamic Input { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

    }
}
