using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using MyLibraryForArray;

namespace Lesson4_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.	Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения
            //от –10 000 до 10 000 включительно. Заполнить случайными числами.  Написать программу, позволяющую найти
            //и вывести количество пар элементов массива, в которых только одно число делится на 3. 
            //В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, 
            //для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
            //ноль рассматриваем как число, которое делится на 3.
            Console.WriteLine("Реализуем алгоритм поиска количества пар, делящихся на 3, через метод класса MyArray");
            MyArray arrayDividedBy = new MyArray(20, -10_000, 10_000);
            arrayDividedBy.OutputArrayWithMessage("Выводим значения массива");
            Console.WriteLine($"\nКоличество пар, делящихся на 3, равно: {arrayDividedBy.NumberOfPairsDividedBy(3)}");

            //2.	Реализуйте задачу 1 в виде статического класса StaticClass;
            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу
            Console.WriteLine("\nРеализуем алгоритм поиска количества пар, делящихся на 3, через " +
                "статический метод класса StaticClass");
            int[] arrayInt = new int[20];
            StaticClass.FillingArrayWithRandomNumbers(ref arrayInt, -10_000, 10_000);
            StaticClass.OutputArray(arrayInt);
            Console.WriteLine($"\nКоличество пар, делящихся на 3, равно: {StaticClass.NumberOfPairsDividedBy(arrayInt, 3)}");

            //2. б) *Добавьте статический метод для считывания массива из текстового файла. 
            //Метод должен возвращать массив целых чисел;
            //в)**Добавьте обработку ситуации отсутствия файла на диске.
            Console.WriteLine("\nзаполняем массив из файла");
            int[] arrayFile = new int[6];

            //Привязываемся к относительной директории, 
            //чтобы при запуске проекта на другом компьютере не приходилось заново указывать путь к файлу
            string path = CurrentPath("Array.txt");
                        
            StaticClass.GetArrayFromFile(ref arrayFile, path);
            StaticClass.OutputArray(arrayFile);

            //3. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив 
            //определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
            //Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий 
            //новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
            //метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, 
            //возвращающее количество максимальных элементов.
            Console.WriteLine("\n\n\nЗаполняем массив начальным значением с его увеличиваем на величину шага.");
            MyArray arrayStep = new MyArray(10, (Int64)(-5), 3);
            arrayStep.OutputArrayWithMessage("Выводим элементы массива:");
            Console.WriteLine($"\nСумма элементов массива равна {arrayStep.Sum}");
            MyArray arrayInverse = arrayStep.Inverse();
            arrayInverse.OutputArrayWithMessage("\nВыводим инверсированный по знакам массив");
            arrayStep.OutputArrayWithMessage("\nВыводим элементы базового массива:");
            arrayStep.Multi(3);
            arrayStep.OutputArrayWithMessage("\nВыводим элементы массива после вызова метода arrayStep.Multi(3):");
            Console.WriteLine($"\nКоличество максимальных элементов: {arrayStep.MaxCount}");

            //3. б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
            //
            //Перенёс класс MyArray в библиотеку классов MyLibraryForArray и подключил эту библиотеку к текущему проекту.
            //Работа класса MyArray в текущем проекте демонстрирует работоспособность новой библиотеки.
            //Создавать сборку dll и подключать ссылку на неё я не стал, поскольку это увеличивает время на подключение
            //этой dll на другом компьютере при проверке моей работы.


            //3. е) ***Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary< int,int>)
            arrayStep.OutputConsoleFrequencyOfOccurrenceItemInArray();

            //4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
            //Создайте структуру Account, содержащую Login и Password.
            Console.WriteLine("\n\nПроизводим авторизацию из файла:");
            Account account = new Account("root", "GeekBrains");

            //Привязываемся к относительной директории, 
            //чтобы при запуске проекта на другом компьютере не приходилось заново указывать путь к файлу
            account.Authorization(@"..\\..\\Account.txt");

            //5. *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
            //Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают
            //сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
            //возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
            //возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).



            Pause();
        }

        /// <summary>
        /// Привязываемся к относительной директории: файл должен лежать в корневой папке текущего проекта Lesson4_HomeWork
        /// </summary>
        /// <param name="fileName">Только имя файла, без указания пути</param>
        /// <returns>Возвращаем полный относительный путь к фалу</returns>
        private static string CurrentPath(string fileName)
        {
            string path = Environment.CurrentDirectory;
            string newPath;
            newPath = path.Remove(path.LastIndexOf(@"\bin\Debug") + 1);
            newPath = String.Concat(newPath, fileName);
            return newPath;
        }

    }
}
