using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _8._1_Lesson_8_1_HomeWork
{
    //Котельников Андрей
    //1.	С помощью рефлексии выведите все свойства структуры DateTime
    class Program
    {
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }
        
        static void Main(string[] args)
        {
            
            DateTime dateTime = new DateTime();
            //dateTime.DayOfWeek
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanRead);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanWrite);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null));
            
            var properties = dateTime.GetType().GetRuntimeProperties();
            Console.WriteLine("\nВыводим список всех свойств структуры DateTime:");
            int count = 1;
            foreach (var item in properties)
            {
                Console.WriteLine($"{count++, 2}: {item.Name}");
            }


            Console.ReadKey();

        }
    }
}
