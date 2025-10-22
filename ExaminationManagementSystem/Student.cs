using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationManagementSystem
{
    internal class Student
    {
        public Student(string name)
        {
            Name = name;
            QuestAnswers = new List<QuestAnswer>();
        }

        public string Name { get; set; }
       public  List<QuestAnswer> QuestAnswers { get; set; }


        public void AddAnswer(QuestAnswer answer)
        {
            QuestAnswers.Add(answer);
        }

        public void ShowFinalMark(Exam exam)
        {
            int TotalMark = exam.GetFinalMark(QuestAnswers);

            double Total = exam.GetTotalMark();

            Console.WriteLine($"\n--- Exam Result ---");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Final Mark: {TotalMark} / {Total}");

   
        }


    }
}
