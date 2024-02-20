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

                        bool createNewCategory = false;

                        do
                        {
                            QuizCategory quizCategory = new QuizCategory();

                            quizCategory.Name = UI.GetCategoryName();

                            List<Question> questions = new List<Question>();

                            bool createNewQuestions = false;

                            do
                            {
                                Question question = new Question();

                                question.Inquiry = UI.GetQuestionInput();

                                int numOfAnswers = UI.GetNumOfAnswers();

                                List<string> answers = UI.GetDecoyAnswers(numOfAnswers);

                                string correctAnswer = UI.GetCorrectAnswer();

                                answers.Add(correctAnswer);

                                Logic.GetAnswerArranged(question, answers, correctAnswer);

                                questions.Add(question);

                                createNewQuestions = UI.GetNewQuestion();

                            } while (createNewQuestions);

                            quizCategory.Questions = questions;

                            createNewCategory = UI.GetNewCategory();

                            FileUtils.SerializeCategoryToFile(quizCategory);

                        } while (createNewCategory);

                        break;


                    case QuizState.Play:

                        QuizCategory quizSection = new QuizCategory();

                        List<Question> sectionQuestions = new List<Question>();

                        UI.ShowCategoryInquiry();

                        quizSection = Logic.GetSectionToModify(quizSection);

                        sectionQuestions = quizSection.Questions;

                        int correctAnswerCount = UI.GetSumOfCorrectAnswer(sectionQuestions);

                        int numberOfQuestions = sectionQuestions.Count;

                        UI.ShowGradingResult(correctAnswerCount, numberOfQuestions);

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
