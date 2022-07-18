# WPF Commands
Библиотка для того, чтобы использовать команды в WPF из классов, а не из модели. В XAML привязка делается на основе названия команды. В модель добавляется с реализованными командами.
___
Использует:
- [Class Injector](https://github.com/telikey/ClassInjector)

___
Примеры:
```
Command="{Binding Path=AnimePageCommands, Converter={StaticResource StringToCommandConverter}, ConverterParameter='LoadSeasons_Command'}"
```
