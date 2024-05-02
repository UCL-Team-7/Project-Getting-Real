using GettingReal.Domai.Models.Video;
using GettingReal.Domain.Models.Audio;

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


    [TestInitialize]
    public void Init()
    {
        b1 = new BibleStudy();

        

    }

        [TestMethod]
    public void BibleStudy_Return_CorrectToStringValue()
    {
        //Act

        //Arrange

        //Assert
        Assert.AreEqual("BibleStudy: BookTitle: {BookTitle}, Chapter: {Chapter}, minVerse: {minVerse}, maxVerse: {maxVerse}, filePath: {FilePath}", b1.ToString());
    }
}
