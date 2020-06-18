using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Exceptions
{
    public class PlayerIsToOldException : Exception
    {
        public PlayerIsToOldException()
        {
        }

        public PlayerIsToOldException(string message) : base(message)
        {
        }

        public PlayerIsToOldException(string message, Exception innerException) : base(message, innerException)
        {
        }

       

    }
}
