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
    private static readonly List<Sermon> s_sermons = [];

    public void Create(MediaFile mediaFile) {
        var file = TagLib.File.Create(mediaFile.Directory);

        if (file != null)
        {           
            Sermon sermon = new()
            {
                Title = mediaFile.Title,
                Priest = mediaFile.Artist ?? mediaFile.AlbumArtist ?? "",
                Album = mediaFile.Album,
                Year = mediaFile.Year,
                Church = file.Tag.AmazonId,
                Country = file.Tag.Publisher,
                Comment = mediaFile.Comment,
                Directory = mediaFile.Directory,
                NoreaType = mediaFile.NoreaType,                          
            };

            s_sermons.Add(sermon);
        }
    }
    public void Delete(Sermon sermon) => s_sermons.Remove(sermon);
    public ObservableCollection<Sermon> Read() => new ObservableCollection<Sermon>(s_sermons);

    public void Update(Sermon sermon) {
        var file = TagLib.File.Create(sermon.Directory);

        if (file != null)
        {
            file.Tag.Publisher = sermon.Country;
            file.Tag.AmazonId = sermon.Church;

            if (sermon.Priest != null)
            {
                file.Tag.Performers = [sermon.Priest];
            }

            file.Save();
        }
    }
}
