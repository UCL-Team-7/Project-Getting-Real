using Microsoft.Win32;
using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories;
using NoreaApp.MVVM;
using System.Collections.ObjectModel;
using System.IO;

namespace NoreaApp.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<MediaFile> MediaFiles { get; set; }

        private FileRepository _fileRepository;


        //public RelayCommand AddCommand => new RelayCommand(execute => AddMediaFile(), canExecute => { return true; });
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMediaFile(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
        public RelayCommand DisplayCommand => new RelayCommand(execute => Display(), canExecute => { return true; });


        public MainWindowViewModel()
        {
            _fileRepository = new FileRepository();
            MediaFiles = new ObservableCollection<MediaFile>();
        }


        private MediaFile _selectedItem;
        public MediaFile SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
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
                string[] chosenPaths = dialog.FileNames;

                var tempMediaFiles = _fileRepository.ReadAll(chosenPaths);

                MediaFiles.Clear();

                foreach (MediaFile file in tempMediaFiles)
                {
                    MediaFiles.Add(file);
                }

            }

        }


        private void DeleteMediaFile()
        {
            MediaFiles.Remove(SelectedItem);
        }


        private void Save()
        {
            //Save to file/db

            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaFiles.csv")))
            {
                foreach (MediaFile file in MediaFiles)
                {
                    sw.WriteLine(file);
                }

            }

        }

        private bool CanSave()
        {
            // Could be: is db connected? does the user has permission to save etc.
            // Here: Is there any items in MediaFiles list

            bool result = false;

            if (MediaFiles.Any())
            {
                result = true;
            }

            return result;
        }


    }
}
