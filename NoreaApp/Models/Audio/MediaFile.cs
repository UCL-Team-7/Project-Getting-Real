namespace NoreaApp.Models.Audio
{
    public class MediaFile : IMediaFile
    {
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public uint? Year { get; set; }
        public uint? Track {  get; set; }
        public string? AlbumArtist { get; set; }
        public string? Genre { get; set; }
        public string? Comment { get; set; }
        public string? Directory { get; set; }
        public string? Composer { get; set; }
        public string? filePath { get; set; }


        public override string ToString()
        {
            return $"TITEL: {Title}, KUNSTNER: {Artist}, ALBUM: {Album}, ÅR: {Year}, SPOR: {Track}, ALBUMSKUNSTNER: {AlbumArtist}, GENRE {Genre}, KOMMENTAR: {Comment}, FILSTI: {Directory}, KOMPONIST: {Composer}";

        }

    }
}
