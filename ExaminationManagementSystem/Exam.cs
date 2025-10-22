using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static ExaminationManagementSystem.Question;

namespace ExaminationManagementSystem
{
    internal class Exam
    {
        List<Question> Questions;
        public Exam()
        {
                Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }


        public Question GetQuestion1(int index)
        {
            return Questions[index];
        }

        public int GetFinalMark(List<QuestAnswer> studentAnswers)
        {
            int totalScore = 0;

            foreach (var answer in studentAnswers)
            {
               
                   Question question = Questions[answer.QuestionIndex];

                    if (question.CheckIfCorrect(answer))
                    {
                        totalScore += question.QuestMark;
                    }
               
            }

            return totalScore;
        }

        public double GetTotalMark()
        {
            double TotalExamMark = 0;
            foreach (var quest in Questions)
            {
                TotalExamMark += quest.QuestMark;
            }

            return TotalExamMark;
        }

        public void StartStudentExam(Exam exam,int numberOfQuestions)
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
