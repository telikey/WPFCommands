# WPF Commands
Библиотка для того, чтобы использовать команды в WPF из классов, а не из модели. В XAML привязка делается на основе названия команды. В модель добавляется с реализованными командами.
___
Использует:
- [Class Injector](https://github.com/telikey/ClassInjector)

___
Примеры:
- Xaml
```
Command="{Binding Path=AnimePageCommands, Converter={StaticResource StringToCommandConverter}, ConverterParameter='LoadSeasons_Command'}"
```
- Model class
```c#
        private NamePageCommands _animePageCommands = null;
        public NamePageCommands AnimePageCommands { get => _animePageCommands; }

        public ClassVM(NamePageCommands commands)
        {
            this._NamePageCommands = commands;
        }
```
