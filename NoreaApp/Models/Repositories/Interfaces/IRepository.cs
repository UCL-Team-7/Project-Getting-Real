using NoreaApp.Models.Audio;
using System.Collections.ObjectModel;


namespace NoreaApp.Models.Repositories.Interfaces;
public interface IRepository
{
    public MediaFile Read(string filePath);
    public ObservableCollection<MediaFile> ReadAll(string[] filePaths);
    public ObservableCollection<MediaFile> ReadCache();
    public void Update(MediaFile mediaFile);
}
