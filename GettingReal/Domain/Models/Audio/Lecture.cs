using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.Domain.Models.Metadata;

namespace GettingReal.Domain.Models.Audio;
public class Lecture : AudioMetadata
{
    // Teacher -> Tags.Artist?


    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Organization { get; set; }
    public override string FilePath { get; set; }



    public Lecture() { }
    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
