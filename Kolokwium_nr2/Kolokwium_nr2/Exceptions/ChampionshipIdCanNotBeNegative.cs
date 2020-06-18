using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Exceptions
{
    public class ChampionshipIdCanNotBeNegative : Exception
    {
        public ChampionshipIdCanNotBeNegative()
        {
        }

        public ChampionshipIdCanNotBeNegative(string message) : base(message)
        {
        }

        public ChampionshipIdCanNotBeNegative(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}
