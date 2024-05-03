using GettingReal.Domain.Models.Repositories;

namespace deleteLater;

internal class Program
{
    static void Main(string[] args)
    {
        FileRepository repo = new FileRepository();

        repo.ReadAll();
    }
}
