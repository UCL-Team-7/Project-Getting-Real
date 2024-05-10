using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using NoreaApp.Models.Audio;
using TagLib;

namespace NoreaApp.Models.Repositories;

public class FileRepository : IRepository
{

    // create custom tag
    // todo: Lav flere options end kun id3tags
    public void Create(string filePath, string tagKey, string tagValue)
    {
        var tfile = TagLib.File.Create(filePath);

        if (tfile != null)
        {
            var id3tag = (TagLib.Id3v2.Tag)tfile.GetTag(TagTypes.Id3v2);
            id3tag.SetTextFrame(tagKey, tagValue);
            tfile.Save();
        }
    }

    public ObservableCollection<MediaFile> ReadAll(string[] filePaths)
    {
        ObservableCollection<MediaFile> mediaFiles = [];
        
        // Loop over each file
        foreach (string filePath in filePaths)
        {
            // Call the Read method for each file
            mediaFiles.Add(Read(filePath));
        }

        return mediaFiles;
    }

    public MediaFile Read(string filePath)
    {        
        var file = TagLib.File.Create(filePath);

        MediaFile mediaFile = new MediaFile()
        {
            Title = file.Tag.Title,
            Artist = file.Tag.FirstPerformer,
            Album = file.Tag.Album,
            Year = file.Tag.Year,
            Track = file.Tag.Track,
            AlbumArtist = file.Tag.FirstAlbumArtist,
            Genre = file.Tag.FirstGenre,
            Comment = file.Tag.Comment,
            Directory = filePath,
            Composer = file.Tag.FirstComposer,
        };
    
        return mediaFile;
    }


    // update existing tags metadata
    public MediaFile Update(MediaFile mediaFile)
    {
        var file = TagLib.File.Create(mediaFile.Directory);

        file.Tag.Title = mediaFile.Title;
        file.Tag.Album = mediaFile.Album;
        file.Tag.Comment = mediaFile.Comment;
        file.Tag.Year = (uint)mediaFile.Year;
        file.Tag.Track = (uint)mediaFile.Track;

        file.Tag.Genres = [ mediaFile.Genre ];
        file.Tag.Composers = [ mediaFile.Composer ];
        file.Tag.Performers = [ mediaFile.Artist ];
        file.Tag.AlbumArtists = [ mediaFile.AlbumArtist ];

        file.Save();

        return mediaFile;
    }

    // delete custom tag (field)
    public void Delete(MediaFile mediaFile, string tagKey)
    {
        var tfile = TagLib.File.Create(mediaFile.Directory);

        if (tfile != null)
        {
            var id3tag = (TagLib.Id3v2.Tag)tfile.GetTag(TagTypes.Id3v2);
            id3tag.SetTextFrame(tagKey, "");
        }
    }
}
