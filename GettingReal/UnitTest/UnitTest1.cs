using Models.Audio;
using Models.Repositories;
using Models.Video;
using TagLib;

namespace UnitTest;

[TestClass]
public class UnitTest1
{
    BibleStudy b1, b2, b3;
    Devotion ad1, ad2, ad3;
    Lecture l1, l2, l3;
    Music m1, m2, m3;
    Priest p1, p2, p3;
    Sermon s1, s2, s3;
    Devotion vd1, vd2, vd3;

    FileRepository fileRepository;


    [TestInitialize]
    public void Init()
    {
        fileRepository = new FileRepository();
    }

    [TestMethod]
    public void Setting_Custom_Id3Tags()
    {
        // Custom key cannot be longer than 4 bytes long
        string customKey = "TEST";
        string customValue = "Cool Custom Text";

        fileRepository.Create(@"C:\mp3\test1.mp3", customKey, customValue);

        var tFile = TagLib.File.Create(@"C:\mp3\test1.mp3");
        var id3v2tag = tFile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;


        if (id3v2tag != null)
        {
            Assert.AreEqual(customValue, id3v2tag.GetTextAsString(customKey));
        }
    }
}
