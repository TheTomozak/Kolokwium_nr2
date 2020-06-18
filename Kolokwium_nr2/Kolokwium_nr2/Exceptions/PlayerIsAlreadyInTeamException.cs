using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Exceptions
{
    public class PlayerIsAlreadyInTeamException : Exception
    {
        public PlayerIsAlreadyInTeamException()
        {
        }

        public PlayerIsAlreadyInTeamException(string message) : base(message)
        {
        }

        public PlayerIsAlreadyInTeamException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
