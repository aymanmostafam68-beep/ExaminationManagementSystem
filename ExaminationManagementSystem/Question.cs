using System.Diagnostics.Contracts;

namespace ExaminationManagementSystem
{
    internal class Question
    {
        public Question(int id, string quest, int questMark, QuestLevel questLevel)
        {

            Id = id;
            Quest = quest;
            QuestMark = questMark;
            this.questLevel = questLevel;

        }

        public int Id { get; set; }
        public string Quest { get; set; }
        public int QuestMark { get; set; }
        public QuestLevel questLevel { get; set; }



        public enum QuestLevel
        {
            Easy,
            Medium,
            Hard

        }

        public enum QuestionType 
        { 
            TrueOrFalse,
            ChoiceOneQuestion, 
            MultipleChoiceQuestion 
        }
        public static string QuestionTypeInfo() 
        { 
            string result = "";

            foreach (var type in Enum.GetValues(typeof(QuestionType)))
            { 
                result += ($"{((int)type) + 1} - {type} \n");
            } 
            return result; }

        public static string QuestLevelInfo()
        {
            string result = "";

            foreach (var level in Enum.GetValues(typeof(QuestLevel)))
            {
                result += ($"{((int)level) + 1} - {level} \n");
            }
            return result;
        }


        public virtual bool CheckIfCorrect(QuestAnswer answer) 
        {
            return false;
        }

        public virtual void PrintWrongAnswer(QuestAnswer answer)
        {
  
        }
        public virtual void PrintQuestion() 
        {
            
        }



    }
}
