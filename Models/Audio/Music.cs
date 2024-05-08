using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Metadata;

namespace Models.Audio;

public class Music : AudioMetadata
{


    public List<Music> music = new List<Music>();
    //public string Title { get; set; }
    public string Title
    {
        get { return Metadata["Title"]; }
    }

    //Metadata.GetValueOrDefault("Title")

    public Dictionary<string, string> Metadata { get; set; }


    public EventCategory EventCategory { get; set; }
    public bool IsKoda { get; set; }
    public override string FilePath { get; set; }


    public Music(Dictionary<string, string> metadata)
    {
        Metadata = metadata;
    }


    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
