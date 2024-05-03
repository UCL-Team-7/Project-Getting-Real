using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Domain.Models.Repositories;
public interface IRepository
{
    public void Create();
    public void Read(string filePath);
    public void ReadAll();
    public void Update();
    public void Delete();
}
