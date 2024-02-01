using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livecode.core
{
    public interface IMapping
    {
        dynamic Input { get; set; }

        string Target { get; set;  }
    }
}
