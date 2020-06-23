using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class TxtFile : IFileManager
    {
        public List<Music_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    List<Music_Info> list = new List<Music_Info>();
                    while (sr.Peek() > -1)
                    {
                        string name = sr?.ReadLine();
                        string performer = sr?.ReadLine();
                        int year;
                        int.TryParse(sr?.ReadLine(), out year);
                        string album = sr?.ReadLine();
                        sr?.ReadLine();
                        Music_Info tmp = new Music_Info(name, performer, year, album);
                        list.Add(tmp);
                    }
                    sr.Close();
                    return list;
                }
            }
            else
            {
                throw new Exception("Такого файла не существует");
            }

        }

        public bool SaveToFile(List<Music_Info> list, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.Name);
                        sw.WriteLine(item.Perfomer);
                        sw.WriteLine(item.Year.ToString());
                        sw.WriteLine(item.Album);
                        sw.WriteLine();
                    }
                    sw.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //убрать
                return false;
            }
        }
    }
}
