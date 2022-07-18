using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCommands.Exceptions
{
    public class NoCommand: WPFCommandsException
    {
        public NoCommand(string name) : base("Команды с именем ("+name+") не существует")
        {

        }
    }
}
