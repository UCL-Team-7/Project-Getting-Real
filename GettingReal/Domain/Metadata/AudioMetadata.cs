using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Metadata;
public abstract class AudioMetadata
{
    public abstract string FilePath { get; set; }

    public abstract Dictionary<ITag, string> Tags { get; set; }
}
