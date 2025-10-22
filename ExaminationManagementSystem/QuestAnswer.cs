using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationManagementSystem
{
    internal class QuestAnswer
    {
        public QuestAnswer(int questionIndex, string questionAnswer)
        {
            QuestionIndex = questionIndex;
            QuestionAnswer = questionAnswer.Trim().ToLower();
        }


        public int QuestionIndex { get; set; }
        public string QuestionAnswer { get; set; }







    }
}
