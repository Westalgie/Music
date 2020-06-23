using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public interface IFileManager
    {
        bool SaveToFile(List<Music_Info> list, string fileName);
        List<Music_Info> LoadFromFile(string fileName);
    }
}