using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Lesson1_HomeWork.UsefulMethods;

namespace Lesson4_HomeWork
{
    class Account
    {
        string login;
        string password;

        public Account (string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string Login
        {
            get => login;
        }

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
    }
}
