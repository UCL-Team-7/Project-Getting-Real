
namespace NoreaApp.Models.Audio;

public class Lecture : MediaFile
{
    // Teacher -> Tags.Artist?

    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Organization { get; set; }

}
