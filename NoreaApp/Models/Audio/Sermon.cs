using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TagLib;

namespace NoreaApp.Models.Audio;

public class Sermon : MediaFile
{

    public string? Priest { get; set; }
    public string? Church { get; set; }
    public string? Country { get; set; }



    /// <summary>
    /// Writes Sermon properties to a string
    /// </summary>
    /// <returns></returns>
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



