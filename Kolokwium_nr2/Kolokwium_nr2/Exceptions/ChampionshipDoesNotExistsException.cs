using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Exceptions
{
    public class ChampionshipDoesNotExistsException : Exception
    {
        public ChampionshipDoesNotExistsException()
        {
        }

        public ChampionshipDoesNotExistsException(string message) : base(message)
        {
        }

        public ChampionshipDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
