using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class BinaryFile : IFileManager
    {
        public List<Music_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Music_Info>)bf.Deserialize(f);
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
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, list);
                    f.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //убрать
                return false;
            }
        }
    }
}
