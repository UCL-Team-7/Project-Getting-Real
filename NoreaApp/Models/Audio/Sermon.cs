using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TagLib;

namespace NoreaApp.Models.Audio;

public class Sermon : MediaFile
{
    //public Priest Priest { get; set; }
    public string? Priest { get; set; }
    public string? Church { get; set; }
    public string? Country { get; set; }





    
    public override string ToString() => $"{Title ?? ""};" +
            $"{Priest ?? ""};" +
            $"{Album ?? ""};" +
            $"{Year?.ToString() ?? ""};" +
            $"{Church ?? ""};" +
            $"{Country ?? ""};" +
            $"{Comment ?? ""};" +
            $"{Directory ?? ""};" +
            $"{NoreaType ?? ""};";
}



