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

            //д) ***Создать метод, который производит частотный анализ текста.В качестве параметра в него передается
            //массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит
            //в этот текст. Здесь требуется использовать класс Dictionary.
            Console.WriteLine("\n\nСчитаем чатоту вхождения заданных слов в тексте:\n");
            string[] wordsForCalculateFrequency = { "message", "from", "the", "longest", "StringBuilder1" };
            Dictionary<string, int> frequencyWordsInText = Message.GetFrequencyWordsInText(text, wordsForCalculateFrequency);
            foreach (var item in frequencyWordsInText)
            {
                Console.WriteLine($"{item.Key, 20} => {item.Value}");
            }

            //3.	*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
            //Например:
            //badc являются перестановкой abcd
            Console.WriteLine("\n\nОпределяем, является ли одна строка перестановкой другой:");
            string s1 = "badc";
            string s2 = "abcd";
            Console.WriteLine($"Строка \"{s1}\" {(Message.IsPermutationOfLetters(s1, s2) ? "является": "не является")} " +
                $"перестановкой строки\"{s2}\"");
            string s3 = "bfdc";
            string s4 = "abcd";
            Console.WriteLine($"Строка \"{s3}\" {(Message.IsPermutationOfLetters(s3, s4) ? "является" : "не является")} " +
                $"перестановкой строки\"{s4}\"");
            
            //*Задача ЕГЭ.
            //На вход программе подаются сведения о сдаче экзаменов учениками 9 - х классов некоторой средней школы. 
            //В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
            //каждая из следующих N строк имеет следующий формат:
            //< Фамилия > < Имя > < оценки >,
            //где < Фамилия > — строка, состоящая не более чем из 20 символов, < Имя > — строка, 
            //состоящая не более чем из 15 символов, < оценки > — через пробел три целых числа, 
            //соответствующие оценкам по пятибалльной системе. < Фамилия > и<Имя>, 
            //а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:
            //Иванов Петр 4 5 3
            //Требуется написать как можно более эффективную программу, 
            //которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
            //Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, 
            //следует вывести и их фамилии и имена.
            Console.WriteLine("\nЗадача ЕГЭ");
            Pupil[] pupilsList = Pupil.GetPupilsListFromFile(@"..\..\ListOfPuples.txt");
            Pupil.OutputListOfPuples(pupilsList);
            int numberOfLastPuplesWithLowPerformance = (int)GetNumberFromConsoleInput("\nВведите количество последних " +
                "учеников по успеваимости:", 1, pupilsList.Length, true);
            Pupil[] listOfPuplesWithLowPerformance = Pupil.GetListOfPuplesWithLowPerformance(pupilsList, 
                numberOfLastPuplesWithLowPerformance, 2);
            Console.WriteLine($"\nОпределяем список последних {numberOfLastPuplesWithLowPerformance} по успеваемости учеников");
            Pupil.OutputListOfPuples(listOfPuplesWithLowPerformance, false);


            Pause();
        }
    }
}
