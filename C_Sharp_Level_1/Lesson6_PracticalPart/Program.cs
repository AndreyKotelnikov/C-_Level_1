using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_PracticalPart
{
    delegate int Sum(int number);

    class ArrSort
    {
        // Реализуем обобщенный метод сортировки
        public static void Sort<T>(IList<T> sortArray, Func<T, T, bool> res)
        {
            bool mySort = true;
            do
            {
                mySort = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (res(sortArray[i + 1], sortArray[i]))
                    {
                        T j = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = j;
                        mySort = true;
                    }
                }
            } while (mySort);
        }
    }

    class UserInfo
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public decimal Salary { get; private set; }

        public UserInfo(string Name, string Family, decimal Salary)
        {
            this.Name = Name;
            this.Family = Family;
            this.Salary = Salary;
        }

        // Переопределим метод ToString
        public override string ToString()
        {
            return string.Format("{0} {1}, {2:C}", Name, Family, Salary);
        }

        // Данный метод введен для соответствия сигнатуре 
        // делегата Func
        public static bool UserSalary(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Salary < obj2.Salary;
        }
    }

    class Program
    {
        static Sum SomeVar()
        {
            int result = 0;

            // Вызов анонимного метода
            Sum del = delegate (int number)
            {
                for (int i = 0; i <= number; i++)
                    result += i;
                return result;
            };
            return del;
        }

        static void Main()
        {
            UserInfo[] userinfo = { new UserInfo("Dmitry","Medvedev",50000000000),
                                  new UserInfo("Alex","Erohin",100),
                                  new UserInfo("Alexey","Volkov",40000),
                                  new UserInfo("Wiley","Coyote",1000000)};

            ArrSort.Sort(userinfo, UserInfo.UserSalary);

            Console.WriteLine("Сортируем исходный объект по доходу: \n" +
                "-------------------------------------\n");
            foreach (var ui in userinfo)
                Console.WriteLine(ui);

            Sum del1 = SomeVar();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Cумма {0} равна: {1}", i, del1(i));
            }

            Console.ReadLine();
        }
    }
}
