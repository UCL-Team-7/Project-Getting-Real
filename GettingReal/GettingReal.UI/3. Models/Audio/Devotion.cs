using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using GettingReal._3._Models.Audio;
using GettingReal._3._Models.Metadata;

namespace GettingReal.Models.Audio;
internal class Devotion : AudioMetadata
{
    public string Church { get; set; }
    public EventCategory EventCategory { get; set; }
    public override string FilePath { get; set; }


    public Devotion() { }
    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
