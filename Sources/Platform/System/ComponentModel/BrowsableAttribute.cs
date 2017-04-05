using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public sealed class BrowsableAttribute : Attribute
    {
        public BrowsableAttribute(bool browsable)
        {
            Browsable = browsable;
        }
        
        public bool Browsable { get; private set; }
    }
}
