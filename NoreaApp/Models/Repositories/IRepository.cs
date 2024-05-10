using NoreaApp.Models.Audio;
using System.Collections.ObjectModel;


namespace NoreaApp.Models.Repositories;
public interface IRepository
{
    public void Create();
    public MediaFile Read(string filePath);
    public ObservableCollection<MediaFile> ReadAll(string[] filePaths);
    public void Update(MediaFile mediaFile);
    public void Delete(MediaFile mediaFile, string tagKey);
}
