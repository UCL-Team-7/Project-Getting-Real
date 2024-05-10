using NoreaApp.Models.Audio;
using TagLib;

namespace NoreaApp.Models.Repositories;
internal class MetadataRepository : IMetadataRepository
{

    // create custom tag
    // todo: Lav flere options end kun id3tags
    public void Create(MediaFile mediaFile)
    {
        var tfile = TagLib.File.Create(mediaFile.Directory);

        if (tfile != null)
        {
            var id3tag = tfile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;
            id3tag.SetTextFrame("NRTP", "Prædiken");
            tfile.Save();
            tfile.Dispose();
        }
        
    }


    //(TagTypes.Id3v2)

    //[Test]
    //public void URLLinkFrameTest()
    //{
    //    string tempFile = TestPath.Samples + "tmpwrite_sample_v2_only.mp3";

    //    System.IO.File.Copy(sample_file, tempFile, true);

    //    var urlLinkFile = File.Create(tempFile);
    //    var id3v2tag = urlLinkFile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;
    //    id3v2tag.SetTextFrame("WCOM", "www.commercial.com");
    //    id3v2tag.SetTextFrame("WCOP", "www.copyright.com");
    //    id3v2tag.SetTextFrame("WOAF", "www.official-audio.com");
    //    id3v2tag.SetTextFrame("WOAR", "www.official-artist.com");
    //    id3v2tag.SetTextFrame("WOAS", "www.official-audio-source.com");
    //    id3v2tag.SetTextFrame("WORS", "www.official-internet-radio.com");
    //    id3v2tag.SetTextFrame("WPAY", "www.payment.com");
    //    id3v2tag.SetTextFrame("WPUB", "www.official-publisher.com");
    //    urlLinkFile.Save();
    //    urlLinkFile.Dispose();

    //    urlLinkFile = File.Create(tempFile);
    //    id3v2tag = urlLinkFile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;
    //    Assert.AreEqual("www.commercial.com", id3v2tag.GetTextAsString("WCOM"));
    //    Assert.AreEqual("www.copyright.com", id3v2tag.GetTextAsString("WCOP"));
    //    Assert.AreEqual("www.official-audio.com", id3v2tag.GetTextAsString("WOAF"));
    //    Assert.AreEqual("www.official-artist.com", id3v2tag.GetTextAsString("WOAR"));
    //    Assert.AreEqual("www.official-audio-source.com", id3v2tag.GetTextAsString("WOAS"));
    //    Assert.AreEqual("www.official-internet-radio.com", id3v2tag.GetTextAsString("WORS"));
    //    Assert.AreEqual("www.payment.com", id3v2tag.GetTextAsString("WPAY"));
    //    Assert.AreEqual("www.official-publisher.com", id3v2tag.GetTextAsString("WPUB"));
    //    urlLinkFile.Dispose();

    //    System.IO.File.Delete(tempFile);
    //}

    /// <summary>
    /// If we construct a new Id3v2 tag, then try to copy that onto a File.Tag
    /// We observe that simple text frames are copied, but APIC and GEOB aren't
    /// </summary>



    public void Read() => throw new NotImplementedException();
    public void ReadAll() => throw new NotImplementedException();
    public void Update() => throw new NotImplementedException();


    // delete custom tag (field)
    public void Delete(MediaFile mediaFile, string tagKey)
    {
        var tfile = TagLib.File.Create(mediaFile.Directory);

        if (tfile != null)
        {
            var id3tag = (TagLib.Id3v2.Tag)tfile.GetTag(TagTypes.Id3v2);
            id3tag.SetTextFrame(tagKey, "");
        }
    }





}
