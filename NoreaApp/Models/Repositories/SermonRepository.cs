using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories.Interfaces;

namespace NoreaApp.Models.Repositories;
internal class SermonRepository : ISermonRepository
{
    private static List<Sermon> _sermons = [];

    public void Create(MediaFile mediaFile) {
        Sermon sermon = new()
        {
            NoreaType = mediaFile.NoreaType,
            Priest = mediaFile.Artist ?? mediaFile.AlbumArtist ?? "",
            Church = "Test",
            Country = "Test Test"
        };

        _sermons.Add(sermon);
    }
    public void Delete(Sermon sermon) => _sermons.Remove(sermon);
    public ObservableCollection<Sermon> Read() => new ObservableCollection<Sermon>(_sermons);
    public void Update(Sermon sermon) {

    }
}
