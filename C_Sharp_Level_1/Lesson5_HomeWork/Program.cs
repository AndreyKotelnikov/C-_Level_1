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

            int[] indexOfWrongLogins = Account.LoginVerificationForAccountList(accountList, useUppercase: true);
            if (indexOfWrongLogins.Length == 0) Console.WriteLine("Все логины успешно прошли проверку!");
            else
            {
                Console.WriteLine("Следующие логины не прошли проверку:");
                foreach (var item in indexOfWrongLogins)
                {
                    Console.WriteLine(accountList[item].Login);
                }
            }


            Pause();
        }
    }
}
