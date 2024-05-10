using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoreaApp.Models.Audio;

namespace NoreaApp.Models.Repositories;
internal interface IMetadataRepository
{
    public void Create(MediaFile mediaFile);
    public void Read();
    public void ReadAll();
    public void Update();
    public void Delete(MediaFile mediaFile, string tagKey);
}
