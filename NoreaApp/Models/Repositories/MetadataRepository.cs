using NoreaApp.Models.Audio;
using NoreaApp.Models.Repositories.Interfaces;
using TagLib;
using TagLib.Id3v2;

namespace NoreaApp.Models.Repositories;
internal class MetadataRepository : IMetadataRepository
{

    /// <summary>
    /// Creates custom tag
    /// </summary>
    /// <param name="mediaFile"></param>
    public void Create(MediaFile mediaFile)
    {
        // Load the audio file
        var file = TagLib.File.Create(mediaFile.Directory);

        if (file != null)
        {
            // Access the tag
            var tag = file.GetTag(TagLib.TagTypes.Id3v2, true) as TagLib.Id3v2.Tag;

            // Create a custom text frame
            var customFrame = new UserTextInformationFrame("TNRT");
            customFrame.Text = new string[] { "Prædiken" };

            // Add the custom frame to the tag
            tag?.AddFrame(customFrame);

            // Save changes
            file.Save();
        }
    }

    /// <summary>
    /// Deletes all custom tags
    /// </summary>
    /// <param name="mediaFile"></param>
    public void DeleteCustomTag(MediaFile mediaFile)
    {
        using (var file = TagLib.File.Create(mediaFile.Directory))
        {
            if (file != null)
            {
                var id3tag = (TagLib.Id3v2.Tag)file.GetTag(TagTypes.Id3v2);

                // Get all frames with the specified description
                var framesToRemove = id3tag.GetFrames<UserTextInformationFrame>()
                                            .Where(f => f.Description == "TNRT")
                                            .ToList();

                // Remove all frames with the specified description
                foreach (UserTextInformationFrame? frame in framesToRemove)
                {
                    id3tag.RemoveFrame(frame);
                }

                file.Save();
            }
        }
    }
}
