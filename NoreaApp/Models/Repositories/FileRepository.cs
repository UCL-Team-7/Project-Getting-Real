using System.Collections.ObjectModel;
using System.IO;
using NoreaApp.Models.Audio;
using TagLib;

namespace NoreaApp.Models.Repositories;

public class FileRepository : IRepository
{

    //private Music _music;


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


    // todo: Lav en collection til at gemme alle vores klasser
    // todo: Differentiere mellem klasser vha metadata
    //public void Read(string filePath)
    //{
    //    Dictionary<string, string> metadataCollection = [];

    //    var tFile = TagLib.File.Create(filePath);

    //    metadataCollection.Add("Title", tFile.Tag.Title);
    //    metadataCollection.Add("Artist", tFile.Tag.FirstPerformer);
    //    metadataCollection.Add("Album", tFile.Tag.Album);
    //    metadataCollection.Add("Year", tFile.Tag.Year.ToString());
    //    metadataCollection.Add("Track", tFile.Tag.Track.ToString());
    //    metadataCollection.Add("AlbumArtist", tFile.Tag.FirstAlbumArtist);
    //    metadataCollection.Add("Genre", tFile.Tag.FirstGenre);
    //    metadataCollection.Add("Comment", tFile.Tag.Comment);
    //    metadataCollection.Add("Directory", filePath);
    //    metadataCollection.Add("Composer", tFile.Tag.FirstComposer);

    //    Music music = new Music(metadataCollection);
    //}

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
    public void Update()
    {

    }

    // delete custom tag (field)
    public void Delete() => throw new NotImplementedException();
}
