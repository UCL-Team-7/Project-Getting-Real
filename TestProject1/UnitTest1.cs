using TagLib;
using static TestProject1.UnitTest1;

namespace TestProject1;

[TestClass]
public class UnitTest1
{


    [TestInitialize]
    public void Init()
    {

    }

    [TestMethod]
    public void TestMethod1()
    {
        var tfile = TagLib.File.Create("C:\\temp\\MP3\\A_Moment_in_Time_-_Graham_Coe.mp3");
        var id3tag = tfile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;

        id3tag.SetTextFrame("NRTP", "Prædiken");
        tfile.Save();
        tfile.Dispose();

        id3tag = tfile.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;


        Assert.AreEqual("Prædiken", id3tag.GetTextAsString("NRTP"));




    }

    [TestMethod]
    public void TestMethod2()
    {

        var file = TagLib.File.Create("C:\\temp\\MP3\\A_Moment_in_Time_-_Graham_Coe.mp3");
        var id3tag = file.GetTag(TagTypes.Id3v2) as TagLib.Id3v2.Tag;

        Assert.AreEqual("Prædiken", id3tag.GetTextAsString("NRTP"));
    }

}
