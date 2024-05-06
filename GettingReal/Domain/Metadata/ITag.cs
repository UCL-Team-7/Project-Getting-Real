using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Metadata;
public interface ITag
{
    string Title { get; set; }
    string Artist { get; set; }
    string Album { get; set; }
    string Year { get; set; }
    string Track { get; set; }
    string AlbumArtist { get; set; }
    string Genre { get; set; }
    string Comment { get; set; }
    string Directory { get; set; }
    string Composer { get; set; }
    string DiskNumber { get; set; }
}
