using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal._3._Models.Persistence;
public abstract class Repository
{
    public abstract void Create();
    public abstract void Read();
    public abstract void ReadAll();
    public abstract void Update();
    public abstract void Delete();
}
