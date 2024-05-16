using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoreaApp.Models.Audio;

namespace NoreaApp.Models.Repositories.Interfaces;
internal interface IMetadataRepository
{
    public void Create(MediaFile mediaFile);
    public void DeleteCustomTag(MediaFile mediaFile);
}
