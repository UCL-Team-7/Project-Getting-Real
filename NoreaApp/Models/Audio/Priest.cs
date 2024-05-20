using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NoreaApp.Models.Audio;
public class Priest
{
    public string? Name { get; set; }
    public string? BiographicalText { get; set; }
    public List<Sermon> Sermons { get; set; }


    // ViewModels skal håndtere filtrering af Sermons på priests, filtreringen sker efter Name, Church, Year
    public Priest() { }


}
