using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories;
public interface IRepository
{
    public void Create(string filePath, string tagKey, string tagValue);
    public void Read(string filePath);
    public void ReadAll();
    public void Update();
    public void Delete();
}
