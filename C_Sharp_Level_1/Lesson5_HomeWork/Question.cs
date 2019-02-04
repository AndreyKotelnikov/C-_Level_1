using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_HomeWork
{
    class Question
    {
        public string QuestionText { get; private set; }
        public bool IsTrue { get; private set; }
        public string Answer { get; private set; }

        public Question(string questionText, bool isTrue, string answer = "")
        {
            QuestionText = questionText;
            IsTrue = isTrue;
            Answer = answer;
        }

        /// <summary>
        /// Возвращает массив вопросов, которые загружаются из указанного файла. 
        /// Каждый вопрос пишется на отдельной строке. 
        /// </summary>
        /// <param name="fileName">Путь и имя файла, из которого нужно загружать список аккаунтов</param>
        /// <returns>Возвращает массив вопросов, которые загружаются из указанного файла.</returns>
        public static Question[] LoadQuestionListFromFile(string fileName)
        {
            try
            {
                string[] questions = File.ReadAllLines(fileName, Encoding.GetEncoding(1251));
                Question[] questionsArray = new Question[questions.Length];
                bool isTrue;
                int count = 0;
                string[] trueSeparator = { " (Да" };
                string[] falseSeparator = { " (Нет" };
                string[] onequestion;

                for (int i = 0; i < questions.Length; i++)
                {
                    if (String.IsNullOrEmpty(questions[i])) continue;
                    if (questions[i].Contains(trueSeparator[0]))
                    {
                        isTrue = true;
                        onequestion = questions[i].Split(trueSeparator, StringSplitOptions.None);
                    }
                    else if (questions[i].Contains(falseSeparator[0]))
                    {
                        isTrue = false;
                        onequestion = questions[i].Split(falseSeparator, StringSplitOptions.None);
                    }
                    else throw new FormatException("Неверный формат данных в файле!");

                    onequestion[1] = onequestion[1].Remove(0, 1);
                    if (onequestion[1].Length > 0) onequestion[1] = onequestion[1].Remove(onequestion[1].Length - 1).Remove(0, 1);
                    
                    questionsArray[count++] = new Question(onequestion[0], isTrue, onequestion[1]);
                }
                Array.Resize<Question>(ref questionsArray, count);
                return questionsArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (Question[])Array.CreateInstance(typeof(Question), 0);
        }

        public static void OutputListOfQuestions(Question[] listOfQuestions)
        {
            foreach (var item in listOfQuestions)
            {
                Console.WriteLine($"{item.QuestionText} ({(item.IsTrue?"Это правда":"Это ложь")}) {item.Answer}");
            }
        }

        public static int[] RandomNambersOfQuestions(Question[] listOfQuestions, int number)
        {
            Random rand = new Random();
            int[] arrayOut = new int[number];
            for (int i = 0; i < arrayOut.Length; i++)
            {
                arrayOut[i] = rand.Next(listOfQuestions.Length);
            }
            return arrayOut;
        }

        public static bool GetUserAnswer(Question question, ConsoleKey keyForTrue)
        {
            Console.WriteLine(question.QuestionText);
            ConsoleKeyInfo answer =  Console.ReadKey();
            Console.WriteLine($"({(question.IsTrue ? "Это правда" : "Это ложь")}) {question.Answer}");
            if ((answer.Key == keyForTrue && question.IsTrue == true) 
                || (answer.Key != keyForTrue && question.IsTrue == false)) return true;
            else return false;
        }

        public static int OneRaundOfGame(Question[] listOfQuestions, ConsoleKey keyForTrue, int numberOfQuestions, int score = 0)
        {
            int newScore = score;
            Console.WriteLine($"\nДобро пожаловать в игру \"Верю - не верю\"!\n" +
                $"Вам будет по очереди выдано {numberOfQuestions} утверждений. Нажимая на клавишу {keyForTrue.ToString()}," +
                $" Вы соглашаетесь, что утверждение правдиво.\nНажимая на любую другую клавишу - вы утверждаете, что это не правда");
            Console.WriteLine($"Ваш счёт за предыдущие игры равен {score}, сколько вы ещё дадите верных ответов?\n");
            int[] randomNumbers = Question.RandomNambersOfQuestions(listOfQuestions, numberOfQuestions);
            foreach (var item in randomNumbers)
            {
                if (Question.GetUserAnswer(listOfQuestions[item], keyForTrue)) newScore++;
            }
            return newScore;
        }


    }
}
