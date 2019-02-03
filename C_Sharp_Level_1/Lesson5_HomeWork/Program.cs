using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using Lesson4_HomeWork;


namespace Lesson5_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.	Создать программу, которая будет проверять корректность ввода логина. 
            //Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита 
            //или цифры, при этом цифра не может быть первой:
            //а) без использования регулярных выражений;   
            Account[] accountList = Account.LoadAccountListFromFile(@"..\..\AccountArray.txt");
            if (accountList.Length == 0)
                Console.WriteLine("Загрузка списка аккаунтов прошла с ошибкой - авторизация отменяется.");
            else
                Account.OutputConsolAccountList(accountList);

            int[] indexOfWrongLogins = Account.LoginVerificationForAccountList(accountList);
            Account.OutputResultVerification(accountList, indexOfWrongLogins);

            //1. б) **с использованием регулярных выражений.  
            Console.WriteLine("\n\nТеперь делаем проверку через регулярные выражения:");
            indexOfWrongLogins = Account.LoginVerificationForAccountList(accountList, @"\b[a-z]{1}[a-z,0-9]{2,9}$");
            Account.OutputResultVerification(accountList, indexOfWrongLogins);

            //2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
            //а) Вывести только те слова сообщения,  которые содержат не более n букв.
            Console.WriteLine("\n\nНачинаем работу со статическим классом Message:");
            string text;
            //text = Message.GetTextFromInternet("https://geekbrains.ru/lessons/33796/homework", 
            //    "div class=\"task-block-teacher\"", "/div");
            text = Message.LoadTextFromFile(@"..\..\Text.txt");
            Console.WriteLine($"Загруженный из файла текст:\n\n{text}");
            
            int maxNumberOfCharsInWord = (int)GetNumberFromConsoleInput("\nВведите максимальное количество букв в слове:", 
                1, isInteger: true);
            Message.OutputWords(text, maxNumberChars: maxNumberOfCharsInWord);

            //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            Console.WriteLine("\nУкажите символ, на который заканчиваются слова, которые нужно удалить:");
            Char symbolOfEndWord = Console.ReadLine()[0];
            Console.WriteLine($"\nУдаляем слова, которые заканчиваются на символ '{symbolOfEndWord}'");
            Console.WriteLine("\nВыводим получившийся текст:\n");
            string textWithoutSomeWords = Message.RemoveWordsFromLastChar(text, symbolOfEndWord);
            Console.WriteLine(textWithoutSomeWords);

            //в) Найти самое длинное слово сообщения.
            Console.WriteLine($"\nПервое самое длинное слово из текста это: {Message.GetFirstLongestWord(text)}");

            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            StringBuilder maxLengthWords = Message.GetAllLongestWords(text);
            Console.WriteLine($"\nВсе самые длинные слова в тексте: {maxLengthWords}");

            Pause();
        }
    }
}
