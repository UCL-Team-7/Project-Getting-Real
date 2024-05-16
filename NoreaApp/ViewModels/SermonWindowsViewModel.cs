using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.MVVM;
using Views;
using System.Collections.ObjectModel;
using NoreaApp.Models.Repositories.Interfaces;

namespace NoreaApp.ViewModels;
internal class SermonWindowsViewModel : ViewModelBase
{
    private SermonRepository _sermonRepository { get; set; }
    public ObservableCollection<Sermon> sermons { get; set; }


    public RelayCommand DeleteCommand => new(execute => DeleteSemon(), canExecute => SelectedItem != null);
    public RelayCommand UpdateCommand => new(execute => UpdateSermon(), canExecute => SelectedItem != null);


    private Sermon? _selectedItem;
    public Sermon? SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public void UpdateSermon()
    {
        _sermonRepository.Update(SelectedItem);
    }

    public void DeleteSemon()
    {
        sermons.Remove(SelectedItem);
    }


    public SermonWindowsViewModel()
    {
        _sermonRepository = new SermonRepository();
        sermons = _sermonRepository.Read();
    }
}
