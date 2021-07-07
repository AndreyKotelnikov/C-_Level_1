using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Lesson1_HomeWork.UsefulMethods;
using System.Text.RegularExpressions;

namespace Lesson4_HomeWork
{
    public class Account
    {
        string password;

        public Account (string login, string password)
        {
            Login = login;
            this.password = password;
        }

        public string Login { get; }
        
        public string Password
        {
            get => password;
            set
            {
                if (String.IsNullOrWhiteSpace(value)) Console.WriteLine("Новый пароль имеет недопустимое значение");
                else password = value;
            }
        }

        /// <summary>
        /// Проверяет совпадение логина и пароля, которые ввёл пользователь через консоль. 
        /// При совпадении возвращает true.
        /// </summary>
        /// <returns>Возвращает true, если провеверка прошла успешно</returns>
        private bool AuthorizationCheckFromConsole()
        {
            string answer;
            Console.WriteLine("\nВведите Ваш логин:");
            answer = Console.ReadLine();
            if (answer == Login)
            {
                Console.WriteLine("Введите Ваш пароль:");
                answer = Console.ReadLine();
                if (answer == Password) return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет совпадение логина и пароля, которые загружаются из указанного файла (каждое слово с новой строки). 
        /// При совпадении возвращает true.
        /// </summary>
        /// <param name="fileName">Путь к файлу, с указанием его названия</param>
        /// <returns>Возвращает true, если провеверка прошла успешно</returns>
        private bool AuthorizationCheckFromFile(string fileName)
        {
            string answer;

            if (File.Exists(fileName))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(fileName);

                    for (int i = 0; i < 2; i++)
                    {
                        if (streamReader.EndOfStream)
                        {
                            Console.WriteLine("В файле меньше двух строк");
                            break;
                        }
                        answer = streamReader.ReadLine();
                        if (i == 0 && answer == Login) continue;
                        else if (i == 1 && answer == Password) return true;
                    }
                    streamReader.Close();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else Console.WriteLine($"В указанной директории файл не обнаружен: {fileName}");
            return false;
        }

        /// <summary>
        /// Запускает авторизацию через консоль и выводит на консоль результат авторизации.
        /// </summary>
        /// <param name="maxCountOfTryForConsole">Максимальное количество попыток у пользователя для авторизации</param>
        /// <returns>Возвращает true, если авторизация прошла успешно</returns>
        public bool Authorization(int maxCountOfTryForConsole = 1)
        {
            int count = 0;

            do
            {
                Console.WriteLine("У Вас осталось {0} {1}",
                        maxCountOfTryForConsole - count, DeclensionWord(maxCountOfTryForConsole - count,
                        "попытка", "попытки", "попыток"));

                if (AuthorizationCheckFromConsole())
                {
                    Console.WriteLine("Авторизация успешно пройдена");
                    return true;
                }
                else
                {
                    count++;
                    Console.WriteLine("Логин или пароль не верны.");
                }
            } while (count < maxCountOfTryForConsole);
            
            Console.WriteLine("Ошибка авторизации!");
            return false;
        }

        /// <summary>
        /// Запускает авторизацию через указанный файл и выводит на консоль результат авторизации.
        /// </summary>
        /// <param name="fileName">Путь к файлу, где хранится логин и пароль (каждое слово на новой строке)</param>
        /// <returns>Возвращает true, если авторизация прошла успешно</returns>
        public bool Authorization(string fileName)
        {
            if (AuthorizationCheckFromFile(fileName))
            {
                Console.WriteLine("Авторизация успешно пройдена");
                return true;
            } else
            {
                Console.WriteLine("Ошибка авторизации!");
                return false;
            }
        }

        /// <summary>
        /// Возвращает массив с аккаунтами (логин - пароль), которые загружаются из указанного файла. 
        /// Каждая пара логин - пароль пишется на отдельной строке и между логином и паролем - пробел. 
        /// </summary>
        /// <param name="fileName">Путь и имя файла, из которого нужно загружать список аккаунтов</param>
        /// <returns></returns>
        public static Account[] LoadAccountListFromFile(string fileName)
        {
            try
            {
                string[] accounts = File.ReadAllLines(fileName, Encoding.UTF8);
                Account[] accountsArray = new Account[accounts.Length];

                for (int i = 0; i < accountsArray.Length; i++)
                {
                    string[] loginPassword = accounts[i].Split(' ');
                    accountsArray[i] = new Account(loginPassword[0], loginPassword[1]);
                }
                return accountsArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (Account[])Array.CreateInstance(typeof(Account), 0);
        }

        public static void OutputConsolAccountList(Account[] accountList)
        {
            Console.WriteLine("\nВыводим список аккаунтов:");
            foreach (var item in accountList)
            {
                Console.WriteLine($"{item.Login, 10} {item.Password}");
            }
        }

        /// <summary>
        /// Проверяет корректность задания логина по указанным условиям. Возращает true в случае успешной проверки.
        /// </summary>
        /// <param name="minLength">Минимальная длина логина (по умолчанию = 2)</param>
        /// <param name="maxLength">Максимальная длина логина (по умолчанию = 10)</param>
        /// <param name="firstCharIsDigit">Может ли первый знак быть цифрой? (по умолчанию = false)</param>
        /// <param name="useUppercase">Могут ли буквы быть в верхнем регистре? (по умолчанию = false)</param>
        /// <returns>Возращает true в случае успешной проверки. И False, если логин не прошёл проверку</returns>
        public bool LoginVerification(int minLength = 2, int maxLength = 10, bool firstCharIsDigit = false, bool useUppercase = false)
        {
            if (Login.Length < maxLength && Login.Length > minLength)
            {
                if (firstCharIsDigit || (firstCharIsDigit == false && (Login[0] < '0' || Login[0] > '9')))
                {
                    for (int i = 0; i < Login.Length - 1; i++)
                    {
                        if ((Login[i] > '0' && Login[i] < '9') || (Login[i] > 'a' && Login[i] < 'z')
                            || (useUppercase && Login[i] > 'A' && Login[i] < 'Z'))
                            return true;
                        else return false;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает массив индексов элементов, логины которых не прошли проверку. 
        /// Или пустой массив, если все логины прошли проверку. 
        /// </summary>
        /// <param name="accountList">Список аккаунтов для проверки</param>
        /// <param name="minLength">Минимальная длина логина (по умолчанию = 2)</param>
        /// <param name="maxLength">Максимальная длина логина (по умолчанию = 10)</param>
        /// <param name="firstCharIsDigit">Может ли первый знак быть цифрой? (по умолчанию = false)</param>
        /// <param name="useUppercase">Могут ли буквы быть в верхнем регистре? (по умолчанию = false)</param>
        /// <returns>Возвращает массив индексов элементов, логины которых не прошли проверку. 
        /// Или пустой массив, если все логины прошли проверку.</returns>
        public static int[] LoginVerificationForAccountList(Account[] accountList, int minLength = 2, int maxLength = 10, 
            bool firstCharIsDigit = false, bool useUppercase = false)
        {
            int[] indexArray = new int[accountList.Length];
            int count = -1;

            for (int i = 0; i < accountList.Length; i++)
            {
                if (!accountList[i].LoginVerification(minLength, maxLength, firstCharIsDigit, useUppercase))
                    indexArray[++count] = i;
            }
            Array.Resize<int>(ref indexArray, count + 1);
            return indexArray;
        }

        /// <summary>
        /// Проверяет корректность задания логина по указанным условиям. Возращает true в случае успешной проверки.
        /// </summary>
        /// <param name="regularExpression">Регулярное выражение</param>
        /// <returns>Возращает true в случае успешной проверки. И False, если логин не прошёл проверку</returns>
        public bool LoginVerification(string regularExpression)
        {
            try
            {
                Regex regEx = new Regex(regularExpression);
                if (regEx.IsMatch(Login)) return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Выводит в консоль результат проверки элементов в массиве.
        /// </summary>
        /// <param name="accountList">массив с аккаунтами</param>
        /// <param name="indexOfWrongLogins">массив с индексами элементов, которые не прошли проверку</param>
        /// <returns>Возвращает true, если все элементы массива прошли успешно проверку</returns>
        public static bool OutputResultVerification(Account[] accountList, int[] indexOfWrongLogins)
        {
            if (indexOfWrongLogins.Length == 0)
            {
                Console.WriteLine("Все логины успешно прошли проверку!");
                return true;
            }
            else
            {
                Console.WriteLine("Следующие логины не прошли проверку:");
                foreach (var item in indexOfWrongLogins)
                {
                    Console.WriteLine(accountList[item].Login);
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает массив индексов элементов, логины которых не прошли проверку. 
        /// Или пустой массив, если все логины прошли проверку. 
        /// </summary>
        /// <param name="accountList">Список аккаунтов для проверки</param>
        /// <param name="regularExpression">Регулярное выражение</param>
        /// <returns>Возвращает массив индексов элементов, логины которых не прошли проверку. 
        /// Или пустой массив, если все логины прошли проверку.</returns>
        public static int[] LoginVerificationForAccountList(Account[] accountList, string regularExpression)
        {
            int[] indexArray = new int[accountList.Length];
            int count = -1;

            for (int i = 0; i < accountList.Length; i++)
            {
                if (!accountList[i].LoginVerification(regularExpression))
                    indexArray[++count] = i;
            }
            Array.Resize<int>(ref indexArray, count + 1);
            return indexArray;
        }
    }
}
