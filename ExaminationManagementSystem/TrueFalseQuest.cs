using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExaminationManagementSystem.Question;

namespace ExaminationManagementSystem
{
    internal class TrueFalseQuest : Question
    {
        public TrueFalseQuest(int id, string quest, int questMark, QuestLevel questLevel,QuestionType questionType,string correctOption)
            :base(id, quest, questMark, questLevel)
        {
            CorrectOption = correctOption;
            QuestionType = questionType;

        }

        public string CorrectOption { get; set; }
        public QuestionType QuestionType { get; set; }

        public override bool CheckIfCorrect(QuestAnswer answer)
        {
                string correctText = answer.QuestionAnswer.Trim().ToLower();

                if (correctText == CorrectOption.Trim().ToLower())
                {
                    return true;
                }
                return false;

        }

        public override void PrintQuestion()
        {
            Console.WriteLine($"{Quest}");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override void PrintWrongAnswer(QuestAnswer answer)
        {
            Console.WriteLine($"Question: {Quest}");
            Console.WriteLine($"QuestionType:  {QuestionType}");

            Console.WriteLine($"Your Answer: {answer.QuestionAnswer}");
            Console.WriteLine($"Correct Answer: {CorrectOption}");
        }


    }
}
