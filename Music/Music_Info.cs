using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    [Serializable]
    public class Music_Info
    {
        public string Name { get; set; }
        public string Perfomer { get; set; }
        public int Year { get; set; }
        public string Album { get; set; }

        public Music_Info(string Name, string Perfomer, int Year, string Album)
        {
            this.Name = Name;
            this.Perfomer = Perfomer;
            this.Year = Year;
            this.Album = Album;
        }
        
        public Music_Info() { }

        public override string ToString()
        {
            return string.Format("Название: {0}, Исполнитель: {1}, Год выпуска: {2}, Альбом: {3}",
                           Name, Perfomer, Year.ToString(), Album);
        }
    }
}
