using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Sort
    {
        public static List<Music_Info> SortMusic(List<Music_Info> list)
        {
            Console.WriteLine("Введите исполнителя");
            string performer = Console.ReadLine();
            Console.WriteLine("Введите год");
            int year;
            int.TryParse(Console.ReadLine(), out year);
            List<Music_Info> sortedList = list.Where(item => item.Perfomer == performer && item.Year > year)
                                          .OrderBy(item => item.Year)
                                          .ToList();
            return sortedList;
        }
    }
}
