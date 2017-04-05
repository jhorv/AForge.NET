using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SR
    {
        public static readonly string InvalidEnumArgument = "The value of argument '{0}' ({1}) is invalid for Enum type '{2}'.";

        public static string GetString(string format, params object[] args)
        {
            return string.Format(format, args);
        }
        
    }
}
