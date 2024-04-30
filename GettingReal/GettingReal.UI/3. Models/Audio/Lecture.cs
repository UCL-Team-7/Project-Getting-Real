using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal._3._Models.Metadata;

namespace GettingReal.Models.Audio;
public class Lecture : AudioMetadata
{


    public Lecture() { }
    public override Dictionary<ITag, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
