using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Music
{
    class XmlFile : IFileManager
    {
        public List<Music_Info> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Music_Info>));
                    return (List<Music_Info>)s.Deserialize(reader);
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
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Music_Info>));
                    s.Serialize(writer, list);
                    writer.Close();
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
