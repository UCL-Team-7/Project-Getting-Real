using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoreaApp.Models.Audio;

namespace NoreaApp.Models.Repositories.Interfaces;
public interface ISermonRepository
{
    void Create(MediaFile sermon);
    ObservableCollection<Sermon> Read();
    public void Update(Sermon sermon);
    public void Delete(Sermon sermon);

}
