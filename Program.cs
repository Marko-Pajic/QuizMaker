using System.Xml.Serialization;
using QuizMaker.Enumerations;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UI.ShowIntroAndQuizRules();

            bool runningProgram = true;

            while (runningProgram)
            {

                QuizState state = FileUtils.GetMenuOption();

                switch (state)
                {

                    case QuizState.Build:

                        bool createNewCategory;

                        do
                        {
                            QuizCategory quizCategory = new QuizCategory();

                            quizCategory.Name = UI.GetCategoryName();

                            List<Question> questions = new List<Question>();

                            bool createNewQuestions;

                            do
                            {
                                Question question = UI.GetNewQuestion();
                               
                                questions.Add(question);

                                createNewQuestions = UI.IsNewQuestionUnderway();

                            } while (createNewQuestions);

                            Logic.AddQuestionAndSerialize(questions, quizCategory);

                            createNewCategory = UI.GetNewCategory();

                        } while (createNewCategory);

                        break;


                    case QuizState.Play:

                        UI.ShowQuizChallenge();
                        break;


                    case QuizState.Modify:

                        QuizCategory quizChapter = UI.GetCategoryModification();
                        break;

                    case QuizState.Exit:

                        runningProgram = false;
                        UI.ShowValedictionNotification();
                        break;
                }
            }
        }

    }

}
