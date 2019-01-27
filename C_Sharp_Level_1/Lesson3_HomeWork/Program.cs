using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using Lesson3_PracticalPart;

namespace Lesson3_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
            //Продемонстрировать работу структуры.
            Console.WriteLine("Struct\n");

            ComplexStruct complexStruct1 = new ComplexStruct(4, 4);
            ComplexStruct complexStruct2 = new ComplexStruct(7, 7);
            Console.WriteLine(complexStruct1);
            Console.WriteLine(complexStruct2);

            ComplexStruct complexStruct3 = new ComplexStruct();
            complexStruct3 = complexStruct1.Plus(complexStruct2);
            Console.WriteLine(complexStruct3);

            ComplexStruct complexStruct4 = new ComplexStruct();
            complexStruct4 = complexStruct1 + complexStruct2;
            Console.WriteLine(complexStruct4);

            complexStruct3 = complexStruct1.Minus(complexStruct2);
            Console.WriteLine(complexStruct3);

            complexStruct4 = complexStruct1 - complexStruct2;
            Console.WriteLine(complexStruct4);

            //1. б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            Console.WriteLine("\n\nClass\n");

            Complex complex1 = new Complex(10, 10);
            Complex complex2 = new Complex(5, 5);
            Console.WriteLine(complex1);
            Console.WriteLine(complex2);

            Complex complex3 = new Complex();
            complex3 = complex1.Plus(complex2);
            Console.WriteLine($"complex1.Plus(complex2) = {complex3}");

            Complex complex4 = new Complex();
            complex4 = complex1 + complex2;
            Console.WriteLine($"complex1 + complex2 = {complex4}");

            complex3 = complex1.Minus(complex2);
            Console.WriteLine($"complex1.Minus(complex2) = {complex3}");

            complex4 = complex1 - complex2;
            Console.WriteLine($"complex1 - complex2 = {complex4}");

            complex3 = complex1.Multiplication(complex2);
            Console.WriteLine($"complex1.Multiplication(complex2) = {complex3}");

            complex4 = complex1 * complex2;
            Console.WriteLine($"complex1 * complex2 = {complex4}");

            complex3 = complex1.Division(complex2);
            Console.WriteLine($"complex1.Division(complex2) = {complex3}");

            complex4 = complex1 / complex2;
            Console.WriteLine($"complex1 / complex2 = {complex4}");

            //1. в) Добавить диалог с использованием switch демонстрирующий работу класса.
            Console.WriteLine(Complex.ArithmeticOperationsWithTwoNumbers(Complex.InputFormatArithmeticOperation()));

            //2. а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
            //Требуется подсчитать сумму всех нечётных положительных чисел. 
            //Сами числа и сумму вывести на экран, используя tryParse.
            double sumEvenPositiveNumbers = 0;
            double number;
            List<string> answer = new List<string>();

            Console.WriteLine("\n\nВводите числа (каждое число в новой строке) или 0 для начала рассчётов:");
            do
            {
                answer.Add(Console.ReadLine());
                
            } while (answer.Last() != "0");

            Console.WriteLine("\n\nВыводим нечётные положительные числа:");

            foreach (var item in answer)
            {
                if (Double.TryParse(item, out number) && number > 0 && !EvenCheck(number))
                {
                    Console.Write($"{number}, ");
                    sumEvenPositiveNumbers += number;
                }
            }

            Console.WriteLine($"\nСумма нечётных положительных чисел равна: {sumEvenPositiveNumbers}");
            
            //3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
            //Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
            //Написать программу, демонстрирующую все разработанные элементы класса.
            Console.WriteLine("\n\nКласс дробей\n");
            Fraction fraction1 = new Fraction(4, 9);
            Fraction fraction2 = new Fraction(2, 3);
            Console.WriteLine($"fraction1 = {fraction1}");
            Console.WriteLine($"fraction2 = {fraction2}\n");

            Fraction fraction3 = new Fraction();
            Fraction fraction4 = new Fraction();

            fraction3 = fraction1.Plus(fraction2);
            Console.WriteLine($"fraction1.Plus(fraction2) = {fraction3}");
            fraction4 = fraction1 + fraction2;
            Console.WriteLine($"fraction1 + fraction2 = {fraction3}\n");

            fraction3 = fraction1.Minus(fraction2);
            Console.WriteLine($"fraction1.Minus(fraction2) = {fraction3}");
            fraction4 = fraction1 - fraction2;
            Console.WriteLine($"fraction1 - fraction2 = {fraction3}\n");

            fraction3 = fraction1.Multiplication(fraction2);
            Console.WriteLine($"fraction1.Multiplication(fraction2) = {fraction3}");
            fraction4 = fraction1 * fraction2;
            Console.WriteLine($"fraction1 * fraction2 = {fraction3}\n");

            fraction3 = fraction1.Division(fraction2);
            Console.WriteLine($"fraction1.Division(fraction2) = {fraction3}");
            fraction4 = fraction1 / fraction2;
            Console.WriteLine($"fraction1 / fraction2 = {fraction3}\n");

            //3. *Добавить свойства типа int для доступа к числителю и знаменателю;

            //3. * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            Console.WriteLine($"fraction1 (4, 9) = {fraction1.DecimalFraction:0.###}\n");

            //3. **Добавить проверку, чтобы знаменатель не равнялся 0.
            //Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            Fraction fraction5 = new Fraction(0, 0);
            Console.WriteLine($"fraction5 (0, 0) = {fraction5}");

            //3. *** Добавить упрощение дробей.
            Fraction fraction6 = new Fraction(10, 5);
            Console.WriteLine($"\n\nfraction6 (10, 5) = {fraction6}");
            fraction6.SimplifyFraction();
            Console.WriteLine($"Упрощаем fraction6 (10, 5) = {fraction6}");
        
            //Дополнительная задача "Задание 2. Делимость": условие было на скрине.
            Console.WriteLine("\n\nДополнительная задача на делимость\n");
            List<List<int>> listCollection = new List<List<int>>();
            bool needCreateNewList = true;
            DateTime start = DateTime.Now;

            int maxNumber = (int)GetNumberFromConsoleInput("Введите максимальное число (до 1 млд) для подсчёта " +
                "количества групп:", 1, 1_000_000_000, true);

            for (int i = 1; i <= maxNumber; i++)
            {
                foreach (var list in listCollection)
                {
                    if (!IsDevided(list, i))
                    {
                        list.Add(i);
                        needCreateNewList = false;
                        break;
                    }
                    if (needCreateNewList != true) needCreateNewList = true;
                }
                if (needCreateNewList == true) listCollection.Add(CreatNewList(i));
            }
            Console.WriteLine($"Минимальное количество групп чисел равно: {listCollection.Count}\n");
            Console.WriteLine("Теперь выводим состав по группам:");

            int countGroup = 1;
            foreach (var list in listCollection)
            {
                Console.Write($"Группа {countGroup}: ");
                foreach (var item in list)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine("\n");
                countGroup++;
            }

            DateTime finish = DateTime.Now;
            TimeSpan duration = finish - start;
            Console.WriteLine($"Время выполнения задачи по разбивки чисел на группы равно {duration.Milliseconds} " +
                $"миллисекунд");

            Pause();
        }

        static bool IsDevided(List<int> list, int number)
        {
            foreach (var item in list)
            {
                if (number % item == 0) return true;
            }
            return false;
        }

        static List<int> CreatNewList(int number)
        {
            List<int> listOut = new List<int> { number };
            return listOut;
        }

    }
}
