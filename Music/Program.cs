using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Music_Info> list;
            do
            {
                list = ConsoleMethods.InputData();
            }
            while (list == null);
            ConsoleMethods.PrintToConsole(list);
            int input;
            do
            {
                Console.WriteLine("Меню" +
                    "\n1 - Добавить композицию" +
                    "\n2 - Найти все композиции автора после заданного года" +
                    "\n3 - Сохранить в файл" +
                    "\n4 - Изменить данные о композиции" +
                    "\n5 - Удалить данные о композиции" +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        list = list.Concat(ConsoleMethods.InputData()).ToList();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                    case 2:
                        List<Music_Info> sortedList = Sort.SortMusic(list);
                        ConsoleMethods.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = ConsoleMethods.ChooseFile(out name);
                        if (file.SaveToFile(list, name))
                        {
                            Console.WriteLine("Запись выполнена");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Выберите элемент для изменения, начиная с 0"); //method
                        int numEd;
                        int.TryParse(Console.ReadLine(), out numEd);
                        Console.WriteLine("Введите новое название");
                        list[numEd].Name = Console.ReadLine();
                        Console.WriteLine("Введите нового исполнителя");
                        list[numEd].Perfomer = Console.ReadLine();
                        Console.WriteLine("Введите новый год");
                        int newYear;
                        int.TryParse(Console.ReadLine(), out newYear);
                        list[numEd].Year = newYear;
                        Console.WriteLine("Введите новый альбом");
                        list[numEd].Album = Console.ReadLine();
                        Console.WriteLine("Изменение завершено");
                        Console.ReadLine();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                    case 5:
                        Console.WriteLine("Выберите элемент для удаления, начиная с 0"); //method
                        int numDel;
                        int.TryParse(Console.ReadLine(), out numDel);
                        list.RemoveAt(numDel);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                }
            }
            while (input != 0);
        }
    }
}
