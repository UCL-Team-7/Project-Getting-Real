using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal._3._Models.Metadata;

namespace GettingReal.Models.Audio;
public class BibleStudy : AudioMetadata
{
    // Esajas' Bog 1,18-31
    // Johannes' Åbenbaring, indl. 3

    public string BibleReference { get; set; }
    public Guid BibleReferenceGuid { get; set; }
    public string BookTitle { get; set; }
    public int Chapter { get; set; }
    public int Section {  get; set; }
    public int minSection { get; set; }
    public int maxSection { get; set; }

    
    // producer -> Tags["artist"]



    public BibleStudy() { }
    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
