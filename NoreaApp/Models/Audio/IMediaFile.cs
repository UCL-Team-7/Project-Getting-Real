using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoreaApp.Models.Audio;

internal interface IMediaFile
{
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public string? Album { get; set; }
    public uint? Year { get; set; }
    public uint? Track { get; set; }
    public string? AlbumArtist { get; set; }
    public string? Genre { get; set; }
    public string? Comment { get; set; }
    public string? Directory { get; set; }
    public string? Composer { get; set; }
    public string? NoreaType { get; set; }

}
