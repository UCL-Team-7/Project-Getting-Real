using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal._3._Models.Metadata;

namespace GettingReal.Models.Audio;
public class Sermon : AudioMetadata
{
    public string church {  get; set; }
    public string country { get; set; }

    public Sermon() { }

    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
