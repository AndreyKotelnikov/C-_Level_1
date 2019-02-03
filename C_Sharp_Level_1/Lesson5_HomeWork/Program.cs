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
            string text;
            //text = Message.GetTextFromInternet("https://geekbrains.ru/geek_university/games", 
            //    "div class=\"task-block-teacher\"", "/div");
            text = Message.LoadTextFromFile(@"..\..\Text.txt");
            Console.WriteLine(text);
            string[] wordsFromText = Message.GetWordsFromText(text);
            foreach (var item in wordsFromText)
            {
                Console.WriteLine(item);
            }

            int maxNumberOfCharsInWord = (int)GetNumberFromConsoleInput("\nВведите максимальное количество букв в слове", 
                1, isInteger: true);
            Message.OutputWords(wordsFromText, maxNumberChars: maxNumberOfCharsInWord);


            Pause();
        }
    }
}
