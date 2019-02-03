using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_HomeWork
{
    static class Message
    {
        /// <summary>
        /// Возвращает текст с указанного сайта между указанными тегами или пустую строку, если данный текст не найден.
        /// </summary>
        /// <param name="url">Адрес сайта</param>
        /// <param name="startTeg">Начальный тег, после которого нужно брать текст</param>
        /// <param name="finishTeg">Закрывающий тег, указывающий на конец возвращаемого текста</param>
        /// <returns>Возвращает текст с указанного сайта между указанными тегами или пустую строку, если данный текст не найден.</returns>
        public static string GetTextFromInternet(string url, string startTeg, string finishTeg)
        {
            try
            {
                WebClient client = new WebClient() { Encoding = Encoding.UTF8 };
                string pageFromSite = client.DownloadString(url);
                int startIndex = pageFromSite.IndexOf($"<{startTeg}>") + $"<{startTeg}>".Length;
                int finishIndex = pageFromSite.IndexOf($"<{finishTeg}>", startIndex);

                string text = pageFromSite.Substring(startIndex, finishIndex - startIndex);
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return String.Empty;
        }

        /// <summary>
        /// Возвращает текст, который загружаются из указанного файла. 
        /// </summary>
        /// <param name="fileName">Путь и имя файла, из которого нужно загружать текст</param>
        /// <returns>Возвращает текст, который загружаются из указанного файла. Или пустую строку при ошибки загрузки</returns>
        public static string LoadTextFromFile(string fileName)
        {
            try
            {
                string text = File.ReadAllText(fileName, Encoding.UTF8);
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return String.Empty;
        }

        /// <summary>
        /// Возвращает массив слов, которые содержатся в указанном тексте
        /// </summary>
        /// <param name="text">текст, из которого нужно извлечь все слова</param>
        /// <returns>Возвращает массив слов, которые содержатся в указанном тексте</returns>
        public static string[] GetWordsFromText(string text)
        {
            string temp = String.Empty;
            foreach (var item in text)
            {
                if (!Char.IsLetterOrDigit(item) && item != '\'') temp += ' ';
                else temp += item;
            }

            char[] separators = { ' ' };
            string[] strArray = temp.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return strArray;
        }

        /// <summary>
        /// Возвращает все самые длинные слова из указанного текста через пробел
        /// </summary>
        /// <param name="text">Текст, в котором требуется найти все самые длинные слова</param>
        /// <returns>Возвращает все самые длинные слова из указанного текста через пробел</returns>
        public static StringBuilder GetAllLongestWords(string text)
        {
            string[] arrayOfWords = GetWordsFromText(text);
            int maxLength = GetFirstLongestWord(text).Length;
            StringBuilder allLongestWords = new StringBuilder();

            foreach (var item in arrayOfWords)
            {
                if (item.Length == maxLength) allLongestWords.Append($" {item}");
            }
            return allLongestWords;
        }

        /// <summary>
        /// Возвращает чатоту вхождения заданных слов в тексте: слово => частота вхождения
        /// </summary>
        /// <param name="text">Текс для определения частоты вхождения в него указанных слов</param>
        /// <param name="wordsForCalculateFrequency">Массив со словами, частоту вхождения которых нужно узнать</param>
        /// <returns>Возвращает чатоту вхождения заданных слов в тексте: слово => частота вхождения</returns>
        public static Dictionary<string, int> GetFrequencyWordsInText(string text, string[] wordsForCalculateFrequency)
        {
            Dictionary<string, int> frequencyWordsInText = new Dictionary<string, int>();
            foreach (var item in wordsForCalculateFrequency)
            {
                frequencyWordsInText.Add(item, 0);
            }
            string[] arrayOfWords = GetWordsFromText(text);
            foreach (var item in arrayOfWords)
            {
                if (frequencyWordsInText.ContainsKey(item)) frequencyWordsInText[item]++;                         
            }
            return frequencyWordsInText;
        }

        /// <summary>
        /// Возвращает самое длинное слово в тексте, если таких слов несколько, то возвращает первое из них.
        /// </summary>
        /// <param name="text">Текст, в котором требуется найти самое длинное слово</param>
        /// <returns>Возвращает самое длинное слово в тексте, если таких слов несколько, то возвращает первое из них.</returns>
        public static string GetFirstLongestWord(string text)
        {
            string[] arrayOfWords = GetWordsFromText(text);
            int maxLength = 0;
            int indexOfLongestWord = 0;

            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                if (arrayOfWords[i].Length > maxLength )
                {
                    maxLength = arrayOfWords[i].Length;
                    indexOfLongestWord = i;
                }
            }
            return arrayOfWords[indexOfLongestWord];
        }

        /// <summary>
        /// Возвращает новую строку с текстом, из которого удалены слова, которые заканчиваются на указанный символ
        /// </summary>
        /// <param name="text">Текст, из которого нужно удалить слова, которые заканчиваются на указанный символ</param>
        /// <param name="symbolOfEndWord">Символ, на который заканчиваются слова, которые нужно удалить</param>
        /// <returns>Возвращает новую строку с текстом, из которого удалены слова, которые заканчиваются на указанный символ</returns>
        public static string RemoveWordsFromLastChar(string text, char symbolOfEndWord)
        {
            string[] arrayOfWords = GetWordsFromText(text);
            string textWithoutSomeWords = text;
            foreach (var item in arrayOfWords)
            {
                if (item[item.Length - 1] == symbolOfEndWord)
                    textWithoutSomeWords = textWithoutSomeWords.Remove(textWithoutSomeWords.IndexOf(item), item.Length);
            }
            return textWithoutSomeWords;
        }

        /// <summary>
        /// Выводит в консоль слова из указанного массива, отвечающие заданным условиям
        /// </summary>
        /// <param name="arrayOfWords">Массив, слова из которого нужно вывести на консоль</param>
        /// <param name="minNumberChars">Минимальное количество символов в слове, которое нужно вывести в консоль</param>
        /// <param name="maxNumberChars">Максимальное количество символов в слове, которое нужно вывести в консоль</param>
        public static void OutputWords(string text, int minNumberChars = 0, int maxNumberChars = int.MaxValue)
        {
            Console.WriteLine("\nВыводим слова:");
            string[] arrayOfWords = GetWordsFromText(text);
            foreach (var item in arrayOfWords)
            {
                if (item.Length >= minNumberChars && item.Length <= maxNumberChars) Console.WriteLine(item);
            }
        }
    }
}
