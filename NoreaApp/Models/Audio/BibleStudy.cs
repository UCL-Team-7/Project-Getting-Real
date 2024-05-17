using System;
using System.Collections.Generic;
namespace NoreaApp.Models.Audio;
public class BibleStudy : MediaFile
{
    // Esajas' Bog 1,18-31
    // Johannes' Åbenbaring, indl. 3

    public string BookTitle { get; set; }
    public int Chapter { get; set; }
    public string Verse { get; set; }

}
