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

            Pause();
        }
    }
}
