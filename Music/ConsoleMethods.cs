using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class ConsoleMethods
    {
        public static void PrintToConsole(List<Music_Info> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", count));
                Console.WriteLine(item.ToString());
                count++;
            }
            Console.WriteLine(String.Format("Количество композиций : {0}", count));
            Console.ReadLine();
            Console.WriteLine();
        }

        public static List<Music_Info> InputData()
        {
            Console.WriteLine("1 - ввод с консоли, 2 - загрузить из файла");
            int inputType;
            int.TryParse(Console.ReadLine(), out inputType);
            switch (inputType)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(name);
                default:
                    Console.WriteLine("Ошибка, повторите ввод");
                    return null;
            }
        }

        public static List<Music_Info> InputDataFromConsole()
        {
            char exitChar;
            List<Music_Info> list = new List<Music_Info>();
            do
            {
                Console.WriteLine("Введите информацию о композиции");
                SetComposition(list);
                Console.WriteLine("Если хотите добавить еще одну композицию - нажмите любую кнопку, для отмены ввода нажмите 0");
                char.TryParse(Console.ReadLine(), out exitChar);
            }
            while (exitChar != '0');
            return list;
        }

        public static void SetComposition(List<Music_Info> list)
        {
            Console.WriteLine("Введите название");
            string name = Console.ReadLine();
            Console.WriteLine("Введите исполнителя");
            string performer = Console.ReadLine();
            Console.WriteLine("Введите год");
            int year;
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine("Введите альбом");
            string album = Console.ReadLine();
            Console.ReadLine();
            Music_Info tmp = new Music_Info(name, performer, year, album);
            list.Add(tmp);
        }
        public static IFileManager ChooseFile(out string fName)
        {
            Console.WriteLine("Введите имя файла: ");
            string input = Console.ReadLine();
            fName = input;
            return FileExtension.GetFile(Path.GetExtension(input));
        }
    }
}
