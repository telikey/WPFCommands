using ClassInjector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFCommands
{
    public class StringToCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IFromObjectForCommandLogic)
            {
                if (parameter is string)
                {
                    var _genericType = typeof(ICommandLogic<ICommand, IFromObjectForCommandLogic>).GetGenericTypeDefinition();
                    _genericType = _genericType.MakeGenericType(new[] { typeof(ICommand), value.GetType() });
                    var _commandLogic = Injector.GetObject(_genericType);
                    var commandName = parameter as string;
                    return _commandLogic.GetCommand(commandName);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
