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
    public RelayCommand SearchSermons => new(execute => SearchSermonList(), canExecute => SearchBox != null);

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

    private string _searchBox = "";
    public string SearchBox
    {
        get { return _searchBox; }
        set
        {
            _searchBox = value;
            OnPropertyChanged();
        }
    }


    private void SearchSermonList()
    {
        ObservableCollection<Sermon> tempSermons = _sermonRepository.Read();

        if (tempSermons.Count == 0)
        {
            return;
        }

        if (SearchBox != "")
        {
            string loweredSearchBox = SearchBox.ToLower();
            List<Sermon> newFiles = tempSermons.Where(file =>
                    file.Priest != null && file.Priest.ToLower().Contains(loweredSearchBox) ||
                    file.Church != null && file.Church.ToLower().Contains(loweredSearchBox) ||
                    file.Country != null && file.Country.ToLower().Contains(loweredSearchBox)
            ).ToList();

            sermons = new ObservableCollection<Sermon>(newFiles);
        }
        else
        {
            sermons = tempSermons;
        }

        OnPropertyChanged(nameof(sermons));

    }

#pragma warning disable CS8604 // Possible null reference argument.
    private void UpdateSermon() => _sermonRepository.Update(SelectedItem);
    private void DeleteSemon() => sermons.Remove(SelectedItem);
#pragma warning restore CS8604 // Possible null reference argument.

    public SermonWindowsViewModel()
    {
        _sermonRepository = new SermonRepository();
        sermons = _sermonRepository.Read();
    }
}
