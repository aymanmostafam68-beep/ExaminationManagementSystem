using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using static ExaminationManagementSystem.Question;

namespace ExaminationManagementSystem
{
    internal class Program
    {
        static List<string> options = new List<string>();
        static int numberOfQuestions = 0;
        static Question.QuestionType questionType = Question.QuestionType.TrueOrFalse;
        static Question.QuestLevel questionLevel = Question.QuestLevel.Easy;
        static string questionText=string.Empty;
        static string correctAnswer = string.Empty;
        static int questionMark = 0;
        static void Main(string[] args)
        {
            Console.Write("How many Question You Want? ");
            numberOfQuestions = int.Parse(Console.ReadLine());
            Exam exam = new Exam();
            bool flag = true;
            do
            {
          
                for (int i = 0; i < numberOfQuestions; i++)
                {

                    SelectTypeLevel();
                    ReadQuestText(i);
                    CheckQuestType(questionType,i,exam);

                    if (i==numberOfQuestions-1)
                    {
                        flag = false;
                    }


                }
            } while (flag);


            StartStudentExam(exam,numberOfQuestions);

        }

        private static  void SelectTypeLevel() 
        {

            Console.WriteLine("\n Question Type: ");
            Console.WriteLine(Question.QuestionTypeInfo());
            Console.WriteLine("Select Type 1 - 2 - 3");
            int QuestType = int.Parse(Console.ReadLine());
            questionType = (Question.QuestionType)(QuestType - 1);


            Console.WriteLine("\n Select Question Level:");

            Console.WriteLine(Question.QuestLevelInfo());

            Console.WriteLine("Select level 1 - 2 - 3");


            int level = int.Parse(Console.ReadLine());
            questionLevel = (Question.QuestLevel)(level - 1);



        }

        private static void ReadQuestText(int id)
        {
            Console.WriteLine($"\n Enter details for Question {id + 1}:");
            Console.Write("Question Text: ");
            questionText = Console.ReadLine();

        }

        private static void CheckQuestType(Question.QuestionType questionType,int i, Exam exam)
        {

            switch (questionType)
            {
                case Question.QuestionType.TrueOrFalse:
                    options = new List<string>();
                    options.Add("true");
                    options.Add("false");
                    Console.Write("Enter Correct Answer (True/False): ");
                    correctAnswer = Console.ReadLine().Trim().ToLower();

                    Console.Write("Enter Question Mark: ");
                    questionMark = int.Parse(Console.ReadLine());

                    exam.AddQuestion
                        (
                        new TrueFalseQuest(i + 1, questionText, questionMark, questionLevel, questionType, correctAnswer)
                        );
                    break;

                case Question.QuestionType.ChoiceOneQuestion:
                    options = new List<string>();

                    for (int j = 1; j < 5; j++)
                    {
                        Console.Write($"Enter Choice Number {j}: ");
                        options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter Correct Answer: ");
                    correctAnswer = Console.ReadLine().Trim().ToLower();

                    Console.Write("Enter Question Mark: ");
                    questionMark = int.Parse(Console.ReadLine());

                    exam.AddQuestion
                        (
                        new ChoiceOneQuest(i + 1, questionText, options, correctAnswer, questionMark, questionLevel, questionType));
                    break;
                case Question.QuestionType.MultipleChoiceQuestion:
                    options = new List<string>();

                    for (int j = 1; j < 5; j++)
                    {
                        Console.Write($"Enter Choice Number {j}: ");
                        options.Add(Console.ReadLine());
                    }
                    Console.Write("Enter Correct Answer: ");
                    correctAnswer = Console.ReadLine().Trim().ToLower();

                    Console.Write("Enter Question Mark: ");
                    questionMark = int.Parse(Console.ReadLine());
                    exam.AddQuestion
                        (
                        new MultipleChoiceQuest(i + 1, questionText, options, correctAnswer, questionMark, questionLevel, questionType)
                        );

                    break;
                default:
                    Console.WriteLine( "Invalid Selection....." );
                    break;
            }

        }


        private static void StartStudentExam(Exam exam, int numberOfQuestions)
        {

            Console.WriteLine("\n\n--- Exam Questions ---\n\n");
            Console.WriteLine($"Time of the exam is: {DateAndTime.Now}");

            Console.Write("Enter Student Name: ");

            string studentName = Console.ReadLine();

            Student student = new Student(studentName);


            for (int i = 0; i < numberOfQuestions; i++)
            {
                Question currentQuestion = exam.GetQuestion1(i);

                Console.Write($"\nQuestion {i + 1}:");

                currentQuestion.PrintQuestion();

                Console.Write("Your answer: ");

                string userAnswer = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userAnswer))
                {
                    userAnswer = "NOAnswer";
                }

                student.AddAnswer(new QuestAnswer(i, userAnswer));


            }


            student.ShowFinalMark(exam);


            Console.WriteLine("\n--- WrongAnswer ---\n");
            foreach (var answer in student.QuestAnswers)
            {
                Question question = exam.GetQuestion1(answer.QuestionIndex);

                if (!question.CheckIfCorrect(answer))
                {
                    question.PrintWrongAnswer(answer);

                    Console.WriteLine("-----------------------------");
                }
            }


        }


    }
}
