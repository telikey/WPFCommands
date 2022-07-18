using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCommands.Exceptions
{
    public class WPFCommandsException : Exception
    {
        public WPFCommandsException(string message): base("WPFCommands: " + message)
        {

        }
    }
}
