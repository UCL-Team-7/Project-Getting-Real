using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.MVVM;
using Views;
using System.Collections.ObjectModel;

namespace NoreaApp.ViewModels;
internal class SermonWindowsViewModel : ViewModelBase
{
    public SermonRepository SermonRepository = new();
    public ObservableCollection<Sermon> sermons { get; set; }


    public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteSemon(), canExecute => SelectedItem != null);


    private Sermon _selectedItem;
    public Sermon SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public void DeleteSemon()
    {
        sermons.Remove(SelectedItem);
        SermonRepository.Delete(SelectedItem);
    }


    public SermonWindowsViewModel()
    {
        sermons = SermonRepository.Read();
    }
}
