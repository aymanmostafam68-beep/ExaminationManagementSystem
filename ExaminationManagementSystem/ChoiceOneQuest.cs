using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExaminationManagementSystem.Question;

namespace ExaminationManagementSystem
{
    internal class ChoiceOneQuest : Question
    {
        public List<string> Options { get; set; }
        public string CorrectOption { get; set; }

        public  QuestionType QuestionType {  get; set; }

        public ChoiceOneQuest(int id, string quest, List<string> options, string correctOption, int questMark, QuestLevel questLevel, QuestionType questionType)
        : base(id, quest, questMark, questLevel)
        {
            Options = options;
            CorrectOption = correctOption;
            QuestionType = questionType;
        }

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
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }

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
