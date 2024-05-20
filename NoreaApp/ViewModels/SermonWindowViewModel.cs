using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.MVVM;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace NoreaApp.ViewModels;
internal class SermonWindowViewModel : ViewModelBase
{
    private SermonRepository _sermonRepository { get; set; }
    public ObservableCollection<Sermon> Sermons { get; set; }


    public RelayCommand DeleteCommand => new(execute => DeleteSemon(), canExecute => SelectedItem != null);
    public RelayCommand UpdateCommand => new(execute => UpdateSermon(), canExecute => SelectedItem != null);
    public RelayCommand ExportSermonsCommand => new(execute => ExportSermons(), canExecute => { return true; });
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


    /// <summary>
    /// Gets the list of Sermons and filters them by search results
    /// </summary>
    private void SearchSermonList()
    {
        ObservableCollection<Sermon> tempSermons = _sermonRepository.Read();

        if (tempSermons.Count == 0 || string.IsNullOrWhiteSpace(SearchBox))
        {
            Sermons = tempSermons;
            OnPropertyChanged(nameof(Sermons));
            return;
        }

        static bool ContainsIgnoreCase(string source, string toCheck) => source?.ToLower().Contains(toCheck) ?? false;

        string loweredSearchBox = SearchBox.ToLower();
        List<Sermon> newFiles = tempSermons.Where(file =>
                ContainsIgnoreCase(file.Title, loweredSearchBox) ||
                ContainsIgnoreCase(file.Priest, loweredSearchBox) ||
                ContainsIgnoreCase(file.Church, loweredSearchBox) ||
                ContainsIgnoreCase(file.Country, loweredSearchBox)
        ).ToList();

        Sermons = new ObservableCollection<Sermon>(newFiles);
        OnPropertyChanged(nameof(Sermons));
    }

#pragma warning disable CS8604 // Possible null reference argument.
    private void UpdateSermon() => _sermonRepository.Update(SelectedItem);
    private void DeleteSemon() => Sermons.Remove(SelectedItem);
#pragma warning restore CS8604 // Possible null reference argument.

    public SermonWindowViewModel()
    {
        _sermonRepository = new SermonRepository();
        Sermons = _sermonRepository.Read();
    }

    /// <summary>
    /// Export file-metadata to a CSV-file
    /// </summary>
    private void ExportSermons()
    {
        string[] headers = ["TITEL", "PRÆST", "ALBUM", "ÅR", "KIRKE", "LAND", "KOMMENTAR", "FILSTI", "NOREA TYPE"];

        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sermons.csv"), false, Encoding.UTF8))
        {
            string headerLine = string.Join(";", headers);
            sw.WriteLine(headerLine);

            foreach (Sermon file in Sermons)
                sw.WriteLine(file);
        }

    }


}
