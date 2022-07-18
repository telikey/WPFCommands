# WPF Commands
Библиотка для того, чтобы использовать команды в WPF из классов, а не из модели. В XAML привязка делается на основе названия команды. В модель добавляется с реализованными командами.
___
Использует:
- [Class Injector](https://github.com/telikey/ClassInjector)

___
Примеры:
- Xaml
```xaml
Command="{Binding Path=NamePageCommands, Converter={StaticResource StringToCommandConverter}, ConverterParameter='Name_Command'}"
```
- Model class
```c#
private NamePageCommands _namePageCommands = null;
public NamePageCommands NamePageCommands { get => _namePageCommands; }

public ClassVM(NamePageCommands commands)
{
     this._NamePageCommands = commands;
}
```
- Commands Class
```c#
public class NameCommands: IFromObjectForCommandLogic
{
    [GetCommandMethod]
    private ICommand Name_Command()
    {
        return new RelayCommand((x) =>
        {
                
        });
    }
}
```
