using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.MVVM;
using Views;
using System.Collections.ObjectModel;
using NoreaApp.Models.Repositories.Interfaces;
using System.IO;
using System.Text;

namespace NoreaApp.ViewModels;
internal class SermonWindowsViewModel : ViewModelBase
{
    private SermonRepository _sermonRepository { get; set; }
    public ObservableCollection<Sermon> sermons { get; set; }


    public RelayCommand DeleteCommand => new(execute => DeleteSemon(), canExecute => SelectedItem != null);
    public RelayCommand UpdateCommand => new(execute => UpdateSermon(), canExecute => SelectedItem != null);
    public RelayCommand ExportSermonsCommand => new(execute => ExportSermons(), canExecute => { return true; });


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

#pragma warning disable CS8604 // Possible null reference argument.
    public void UpdateSermon() => _sermonRepository.Update(SelectedItem);
    public void DeleteSemon() => sermons.Remove(SelectedItem);
#pragma warning restore CS8604 // Possible null reference argument.

    public SermonWindowsViewModel()
    {
        _sermonRepository = new SermonRepository();
        sermons = _sermonRepository.Read();
    }


    private void ExportSermons()
    {
        //Save to file/db
       
        string[] headers = ["TITEL", "PRÆST", "ALBUM", "ÅR", "KIRKE", "LAND", "KOMMENTAR", "FILSTI", "NOREA TYPE"];


        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sermons.csv"), false, Encoding.UTF8))
        {

            string headerLine = string.Join(";", headers);
            sw.WriteLine(headerLine);

            foreach (Sermon file in sermons)
            {
                sw.WriteLine(file);
            }
        }

    }


}
