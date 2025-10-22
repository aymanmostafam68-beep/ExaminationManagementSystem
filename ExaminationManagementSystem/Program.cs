using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ExaminationManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many Question You Want? ");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            List<string> options = new List<string>();
            string correctAnswer = "";
            int questionMark = 0; ;


            Exam exam = new Exam();
            bool flag = true;
            do
            {
          
                for (int i = 0; i < numberOfQuestions; i++)
                {

                    #region QuestType
                    Console.WriteLine("\n Question Type: ");
                    Console.WriteLine(Question.QuestionTypeInfo());
                    Console.WriteLine("Select Type 1 - 2 - 3");
                    int QuestType = int.Parse(Console.ReadLine());
                    Question.QuestionType questionType = (Question.QuestionType)(QuestType - 1);
                    #endregion

                    #region QuestLevel

                    Console.WriteLine("\n Select Question Level:");

                    Console.WriteLine(Question.QuestLevelInfo());

                    Console.WriteLine("Select level 1 - 2 - 3");


                    int level = int.Parse(Console.ReadLine());
                    Question.QuestLevel questionLevel = (Question.QuestLevel)(level - 1);
                    #endregion

                    #region QuestionText
                    Console.WriteLine($"\n Enter details for Question {i + 1}:");
                    Console.Write("Question Text: ");
                    string questionText = Console.ReadLine();
                    #endregion


                    #region AddQuestion


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
                                new ChoiceOneQuest(i+1, questionText,options,correctAnswer,questionMark,questionLevel,questionType));
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
                            break;
                    }

                    #endregion

                    if (i==numberOfQuestions-1)
                    {
                        flag = false;
                    }


                }
            } while (flag);


            //List<QuestAnswer> studentAnswers = new List<QuestAnswer>();
            exam.StartStudentExam(exam,numberOfQuestions);

        }

    }
    }
