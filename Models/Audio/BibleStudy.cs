using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Metadata;

namespace Models.Audio;
public class BibleStudy : AudioMetadata
{
    // Esajas' Bog 1,18-31
    // Johannes' Åbenbaring, indl. 3

    public Guid BibleReferenceGuid { get; set; }
    public string BookTitle { get; set; }
    public int Chapter { get; set; }
    public int minVerse { get; set; }
    public int maxVerse { get; set; }
    public override string FilePath { get; set; }


    // producer -> Tags["artist"]



    public BibleStudy() { }
    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
