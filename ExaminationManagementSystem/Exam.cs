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

    

    }
}
