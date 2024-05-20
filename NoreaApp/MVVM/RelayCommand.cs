using System.Windows.Input;

namespace NoreaApp.MVVM;
internal class RelayCommand : ICommand
{
    private Action<object> _execute;
    private Func<object, bool> _canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    /// <summary>
    /// Constructor for making new commandbindings. Takes in an action object and a function object (bool)
    /// </summary>
    /// <param name="execute"></param>
    /// <param name="canExecute"></param>
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Returns true or false based on our conditions
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Executes a method
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
}
