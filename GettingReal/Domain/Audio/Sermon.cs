using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models.Metadata;

namespace Models.Audio;
public class Sermon : AudioMetadata
{
    public string Church { get; set; }
    public string Country { get; set; }
    public override string FilePath { get; set; }

    // Priest -> Tags.Artist/Tags.Author
    // Year -> Tags.Year
    // Title -> Tags.Title

    public Sermon() { }

    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
