using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Audio;
using TagLib;

namespace Models.Repositories;

public class FileRepository : IRepository
{

    private Music _music;

    public FileRepository()
    {
    }

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
    public void Read(string filePath)
    {
        Dictionary<string, string> metadataCollection = [];

        var tFile = TagLib.File.Create(filePath);

        metadataCollection.Add("Title", tFile.Tag.Title);
        metadataCollection.Add("Artist", tFile.Tag.FirstPerformer);
        metadataCollection.Add("Album", tFile.Tag.Album);
        metadataCollection.Add("Year", tFile.Tag.Year.ToString());
        metadataCollection.Add("Track", tFile.Tag.Track.ToString());
        metadataCollection.Add("AlbumArtist", tFile.Tag.FirstAlbumArtist);
        metadataCollection.Add("Genre", tFile.Tag.FirstGenre);
        metadataCollection.Add("Comment", tFile.Tag.Comment);
        metadataCollection.Add("Directory", filePath);
        metadataCollection.Add("Composer", tFile.Tag.FirstComposer);

        Music music = new Music(metadataCollection);
    }

    public void ReadAll()
    {
        // Read all files in the directory
        string[] Files = Directory.GetFiles("C:\\temp\\MP3"); //_music.FilePath

        // Loop over each file
        foreach (string filePath in Files)
        {
            // Call the Read method for each file
            Read(filePath);
        }
    }

    // update existing tags metadata
    public void Update()
    {

    }

    // delete custom tag (field)
    public void Delete() => throw new NotImplementedException();
}
