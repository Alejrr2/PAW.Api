using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Architecture.Exceptions
{
    public class PAWException : Exception
    {
        public PAWException(string message, Exception innerException)
            : base(message, innerException) { }

        public PAWException(Exception innerException)
            : base("An error occurred in the repository.", innerException) { }
    }
}

