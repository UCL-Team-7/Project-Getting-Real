using Microsoft.Win32;
using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.Models.Repositories.Interfaces;
using NoreaApp.MVVM;
using Views;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Printing;
using System.Text;

#pragma warning disable CS8600, CS8604 // Converting null literal or possible null value to non-nullable type.

namespace NoreaApp.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<MediaFile> MediaFiles { get; set; }

    private SermonRepository _sermonRepository { get; set; }
    private IRepository _fileRepository = new FileRepository();
    private IMetadataRepository _metadataRepository = new MetadataRepository();

    //public RelayCommand AddCommand => new RelayCommand(_execute => AddMediaFile(), _canExecute => { return true; });
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


    private void SearchFiles()
    {
        ObservableCollection<MediaFile> tempMediaFiles = _fileRepository.ReadCache();

        if (tempMediaFiles.Count == 0)
        {
            return;
        }

        if (SearchBox != "")
        {
            string loweredSearchBox = SearchBox.ToLower();
            List<MediaFile> newFiles = tempMediaFiles.Where(file =>
                    file.Title != null && file.Title.ToLower().Contains(loweredSearchBox) ||
                    file.Artist != null && file.Artist.ToLower().Contains(loweredSearchBox) ||
                    file.Album != null && file.Album.ToLower().Contains(loweredSearchBox) ||
                    file.AlbumArtist != null && file.AlbumArtist.ToLower().Contains(loweredSearchBox) ||
                    file.Genre != null && file.Genre.ToLower().Contains(loweredSearchBox) ||
                    file.Comment != null && file.Comment.ToLower().Contains(loweredSearchBox) ||
                    file.Directory != null && file.Directory.ToLower().Contains(loweredSearchBox) ||
                    file.Composer != null && file.Composer.ToLower().Contains(loweredSearchBox) ||
                    file.NoreaType != null && file.NoreaType.ToLower().Contains(loweredSearchBox)
            ).ToList();

            MediaFiles = new ObservableCollection<MediaFile>(newFiles);
        }
        else
        {
            MediaFiles = tempMediaFiles;
        }

        OnPropertyChanged(nameof(MediaFiles));
    }


    private void FilterList()
    {
        SermonWindow sW = new SermonWindow();
        sW.Show();
    }

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

        // if () ikke har alle customtags
        // så kald metadata repo
        // create som laver alle vores customtags, og sætter dem til empty string


    }

    private void Export()
    {
        //Save to file/db

        string[] headers = ["TITEL", "KUNSTNER", "ALBUM", "ÅR", "SPOR", "ALBUMSKUNSTNER", "GENRE", "KOMMENTAR", "FILSTI", "KOMPONIST"];

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
