using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories.Interfaces;
using TagLib;
using TagLib.Id3v2;

namespace NoreaApp.Models.Repositories;

public class FileRepository : IRepository
{

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
        var id3tag = file.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;

        // Find the custom frame "TXXX" with description "TNRT"
        UserTextInformationFrame? customFrame = id3tag?.GetFrames<UserTextInformationFrame>()
                                 .FirstOrDefault(f => f.FrameId == "TXXX" && f.Description == "TNRT");
        string noreaType = customFrame?.Text.FirstOrDefault() ?? string.Empty;

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
            NoreaType = noreaType
        };

        return mediaFile;
    }

    // update existing tags metadata
    public void Update(MediaFile mediaFile)
    {
        var file = TagLib.File.Create(mediaFile.Directory);

        file.Tag.Title = mediaFile.Title;
        file.Tag.Album = mediaFile.Album;
        file.Tag.Comment = mediaFile.Comment;
        file.Tag.Year = (uint)mediaFile.Year;
        file.Tag.Track = (uint)mediaFile.Track;


        if (mediaFile.Genre != null)
        {
            file.Tag.Genres = [mediaFile.Genre];
        }

        if (mediaFile.Composer != null)
        {
            file.Tag.Composers = [mediaFile.Composer];
        }

        if (mediaFile.Artist != null)
        {
            file.Tag.Performers = [mediaFile.Artist];
        }

        if (mediaFile.AlbumArtist != null)
        {
            file.Tag.AlbumArtists = [mediaFile.AlbumArtist];
        }

        file.Save();
    }

    public void Create() => throw new NotImplementedException();
    public void Delete() => throw new NotImplementedException();
}
