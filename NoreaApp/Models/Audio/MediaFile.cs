using System.Globalization;

namespace NoreaApp.Models.Audio
{
    public class MediaFile : IMediaFile
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



        public override string ToString() => $"{Title ?? ""};" +
            $"{Artist ?? ""};" +
            $"{Album ?? ""};" +
            $"{Year?.ToString() ?? ""};" +
            $"{Track?.ToString() ?? ""};" +
            $"{AlbumArtist ?? ""};" +
            $"{Genre ?? ""};" +
            $"{Comment ?? ""};" +
            $"{Directory ?? ""};" +
            $"{Composer ?? ""}";
    }
}
