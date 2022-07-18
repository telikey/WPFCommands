using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPFCommands.Exceptions;

namespace WPFCommands
{

    public interface IFromObjectForCommandLogic{}

    public interface ICommandLogic<ICommand, FromObjectForCommandLogic> where FromObjectForCommandLogic : IFromObjectForCommandLogic
    {
        public ICommand GetCommand(string name);
    }
    public class CommandLogic<ICommand, FromObjectForCommandLogic> : ICommandLogic<ICommand, FromObjectForCommandLogic> where FromObjectForCommandLogic: IFromObjectForCommandLogic
    {
        Dictionary<string, ICommand> _commandDict = null;
        public CommandLogic(FromObjectForCommandLogic FromObject)
        {
            var methods = FromObject
                .GetType()
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var getCommandMethods = methods
                .Where(method => method.IsPrivate && method.GetCustomAttribute(typeof(GetCommandMethod)) != null).ToArray();

            _commandDict = getCommandMethods
                .Select(method => {
                    var command = (ICommand)method.Invoke(FromObject, null);
                    return new KeyValuePair<string, ICommand>(method.Name, command);
                     
                })
                .ToDictionary(method => method.Key, method => method.Value);
        }
        public ICommand GetCommand(string name)
        {
            var commandName = name;

            if (_commandDict.ContainsKey(commandName))
            {
                return _commandDict[commandName];
            }
            else
            {
                throw new NoCommand(name);
            }
        }
    }
}
