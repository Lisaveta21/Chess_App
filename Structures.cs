using System;

public class NotifyPropertyChanged: INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtyal void OnPropertyChanged([CallerMemeberName] string propertyName = null) => PropertyChanged?.Invoke(this, new NotifyPropertyChanged(propertyName));


}
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
    public void Execute(object parameter) => _execute(parameter);
}

public class Cell : NotifyPropertyChanged
{
    private State _state;
    private bool _active;

    public State State
    {
        get => _state;
        set
        {
            _state = value;
            OnPropertyChanged(); // сообщить интерфейсу, что значение поменялось, чтобы интефейс перерисовался в этом месте
        }
    }
    public bool Active // это будет показывать, что ячейка выделена пользователем
    {
        get => _active;
        set
        {
            _active = value;
            OnPropertyChanged();
        }
    }
}

public class Board : IEnumerable<Cell>
{
    private readonly Cell[,] _area;

    public State this[int row, int column]
    {
        get => _area[row, column].State;
        set => _area[row, column].State = value;
    }

    public Board()
    {
        _area = new Cell[8, 8];
        for (int i = 0; i < _area.GetLength(0); i++)
            for (int j = 0; j < _area.GetLength(1); j++)
                _area[i, j] = new Cell();
    }

    public IEnumerator<Cell> GetEnumerator()
        => _area.Cast<Cell>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _area.GetEnumerator();
}
