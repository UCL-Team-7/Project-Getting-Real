using NoreaApp.Models.Audio;
using System.Collections.ObjectModel;


namespace NoreaApp.Models.Repositories;
public interface IRepository
{
    public void Create(string filePath, string tagKey, string tagValue);
    public MediaFile Read(string filePath);
    public ObservableCollection<MediaFile> ReadAll(string[] filePaths);
    public MediaFile Update(MediaFile mediaFile);
    public void Delete(MediaFile mediaFile, string tagKey);
}
