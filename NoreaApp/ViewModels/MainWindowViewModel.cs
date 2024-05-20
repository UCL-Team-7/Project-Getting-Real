using Microsoft.Win32;
using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.Models.Repositories.Interfaces;
using NoreaApp.MVVM;
using Views;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

#pragma warning disable CS8600, CS8604 // Converting null literal or possible null value to non-nullable type.

namespace NoreaApp.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<MediaFile> MediaFiles { get; set; }

    private SermonRepository _sermonRepository { get; set; }
    private IRepository _fileRepository = new FileRepository();
    private IMetadataRepository _metadataRepository = new MetadataRepository();

    // Commandbindings
    public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMediaFile(), canExecute => SelectedItem != null);
    public RelayCommand ExportCommand => new RelayCommand(execute => Export(), canExecute => CanExport());
    public RelayCommand DisplayCommand => new RelayCommand(execute => Display(), canExecute => { return true; });
    public RelayCommand UpdateCommand => new RelayCommand(execute => UpdateMediaFile(), canExecute => SelectedItem != null);
    public RelayCommand CreateCommand => new RelayCommand(execute => CreateCustomTag(), canExecute => SelectedItem != null);
    public RelayCommand SearchMediaFiles => new RelayCommand(execute => SearchFiles(), canExecute => SearchBox != null);
    public RelayCommand DeleteCustomTagCommand => new RelayCommand(execute => DeleteCustomTag(), canExecute => SelectedItem != null);
    public RelayCommand FilterListCommand => new RelayCommand(execute => FilterList(), canExecute => { return true; });


    public MainWindowViewModel()
    {
        MediaFiles = new ObservableCollection<MediaFile>();
        _sermonRepository = new SermonRepository();
    }


    private MediaFile? _selectedItem;
    public MediaFile? SelectedItem
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

    private static bool ContainsIgnoreCase(string source, string toCheck) => source?.ToLower().Contains(toCheck) ?? false;

    /// <summary>
    /// Gets the list of MediaFiles and filters them by search results
    /// </summary>
    private void SearchFiles()
    {
        ObservableCollection<MediaFile> tempMediaFiles = _fileRepository.ReadCache();

        if (tempMediaFiles.Count == 0 || string.IsNullOrWhiteSpace(SearchBox))
        {
            MediaFiles = tempMediaFiles;
            OnPropertyChanged(nameof(MediaFiles));
            return;
        }

        string loweredSearchBox = SearchBox.ToLower();

        List<MediaFile> newFiles = tempMediaFiles.Where(file =>
            ContainsIgnoreCase(file.Title, loweredSearchBox) ||
            ContainsIgnoreCase(file.Artist, loweredSearchBox) ||
            ContainsIgnoreCase(file.Album, loweredSearchBox) ||
            ContainsIgnoreCase(file.AlbumArtist, loweredSearchBox) ||
            ContainsIgnoreCase(file.Genre, loweredSearchBox) ||
            ContainsIgnoreCase(file.Comment, loweredSearchBox) ||
            ContainsIgnoreCase(file.Directory, loweredSearchBox) ||
            ContainsIgnoreCase(file.Composer, loweredSearchBox) ||
            ContainsIgnoreCase(file.NoreaType, loweredSearchBox)
        ).ToList();

        MediaFiles = new ObservableCollection<MediaFile>(newFiles);
        OnPropertyChanged(nameof(MediaFiles));
    }


    private void FilterList()
    {
        SermonWindow sW = new SermonWindow();
        sW.Show();
    }


    /// <summary>
    /// Creates a custom tag on the SelectedItem in the datagrid
    /// </summary>
    private void CreateCustomTag()
    {
        MediaFile mediaFile = SelectedItem;

        int index = MediaFiles.IndexOf(mediaFile);

        _metadataRepository.Create(mediaFile);


        MediaFile updateMediaFile = _fileRepository.Read(mediaFile.Directory);

        MediaFiles.RemoveAt(index);

        MediaFiles.Insert(index, updateMediaFile);

        _sermonRepository.Create(updateMediaFile);
    }


    /// <summary>
    /// Deletes all customstags on SelectedItem in the datagrid
    /// </summary>
    private void DeleteCustomTag()
    {
        MediaFile mediaFile = SelectedItem;

        int index = MediaFiles.IndexOf(mediaFile);

        _metadataRepository.DeleteCustomTag(mediaFile);


        MediaFile updateMediaFile = _fileRepository.Read(mediaFile.Directory);

        MediaFiles.RemoveAt(index);

        MediaFiles.Insert(index, updateMediaFile);
    }




    private void AddMediaFile()
    {
        throw new NotImplementedException();

        //MediaFiles.Add(new MediaFile
        //{
        //    Title = "Not set yet",
        //    Artist = "Not set yet",
        //    Comment = "Not set yet",
        //});

    }

    public void Display()
    {
        OpenFileDialog dialog = new OpenFileDialog();

        dialog.Multiselect = true;

        bool? userClicksOK = dialog.ShowDialog();

        if (userClicksOK == true)
        {
            MediaFiles.Clear();
            MediaFiles = _fileRepository.ReadAll(dialog.FileNames);

            foreach (MediaFile file in MediaFiles)
            {
                if (file.NoreaType == "Prædiken")
                {
                    _sermonRepository.Create(file);
                }
            }

            OnPropertyChanged(nameof(MediaFiles));
        }
    }

    private void Export()
    {
        //Save to file/db

        string[] headers = ["TITEL", "KUNSTNER", "ALBUM", "ÅR", "SPOR", "ALBUMSKUNSTNER", "GENRE", "KOMMENTAR", "FILSTI", "KOMPONIST", "NOREA TYPE"];

        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaFiles.csv"), false, Encoding.UTF8))
        {

            string headerLine = string.Join(";", headers);
            sw.WriteLine(headerLine);

            foreach (MediaFile file in MediaFiles)
            {
                sw.WriteLine(file);
            }
        }

    }

    private bool CanExport() => MediaFiles.Any();
    private void DeleteMediaFile() => MediaFiles.Remove(SelectedItem);
    private void UpdateMediaFile() => _fileRepository.Update(SelectedItem);

}
#pragma warning restore CS8600, CS8604 // Converting null literal or possible null value to non-nullable type.
