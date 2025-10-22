using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationManagementSystem
{
    internal class MultipleChoiceQuest : Question
    {
        public List<string> Options { get; set; }
        public string CorrectOptions { get; set; }

        public QuestionType QuestionType{ get; set; }
        public MultipleChoiceQuest(int id, string quest, List<string> options, string correctOptions, int questMark, Question.QuestLevel questLevel, QuestionType questionType )
            : base(id, quest, questMark, questLevel)
        {
            Options = options;
            CorrectOptions = correctOptions;
            QuestionType = questionType;
        }

        public override bool CheckIfCorrect(QuestAnswer answer)
        {
            // chatGpt helped me in this function
            string userAnswer = answer.QuestionAnswer.Trim().ToLower();

            var userParts = userAnswer.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Trim().ToLower())
                                .Distinct()
                                .ToList();

            var correctParts = CorrectOptions.Trim().ToLower()
                                            .Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(x => x.Trim().ToLower())
                                            .Distinct()
                                            .ToList();
            if (userParts.Count == correctParts.Count && !userParts.Except(correctParts).Any())
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
            Console.WriteLine("Correct Answers: " + string.Join(", ", CorrectOptions));
        }

    }
}
