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

                                answers = Logic.GetIndexShuffle(answers);

                                question.Answers = answers;

                                question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

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

                        int correctAnswerCount = Logic.GetSumOfCorrectAnswer(sectionQuestions);

                        int numberOfQuestions = sectionQuestions.Count;

                        UI.ShowGradingResult(correctAnswerCount, numberOfQuestions);

                        break;


                    case QuizState.Modify:

                        //List<QuizCategory> quizCategories = new List<QuizCategory>();

                        //var x = quizCategories.Where(q => q.Name == "Food");

                        //QuizCategory quizChapter = new QuizCategory();

                       // UI.ShowSectionInquiry();

                       // string[] categoryNames = FileUtils.GetCategorySelection();

                       // string fileToModify = UI.GetSelectedFileName(categoryNames);

                       // quizChapter = FileUtils.DeserializeFileToCategory(fileToModify);

                       // //quizChapter = Logic.GetSectionToModify(quizChapter);

                       // List<Question> chapterQuestions = new List<Question>();/* Consider to remove*/

                       // chapterQuestions = quizChapter.Questions;/* Consider to remove*/

                       // Question inquiry = new Question();

                       // bool endModification = true;

                       // do
                       // {
                       //     bool nameModified = false;
                       //     bool QorAModified = false;

                       //     ModifySection option = UI.GetOptionSelection();

                       //     switch (option)
                       //     {
                       //         case ModifySection.Name:

                       //             string newName = UI.GetCategoryModifiedName(quizChapter);
                       //             nameModified = UI.IsNameModified(newName, quizChapter);
                       //             break;

                       //         case ModifySection.Questions:

                       //             UI.ShowQuestionList(chapterQuestions);
                       //             UI.ShowQuestionInquiry();
                       //             int questionPosition = UI.GetQuestionIndexPosition(chapterQuestions);
                       //             QorAModified = UI.IsQuestionModified(questionPosition, chapterQuestions);
                       //             break;

                       //         case ModifySection.Answers:

                       //             UI.ShowQuestionList(chapterQuestions);
                       //             UI.ShowAnswerInquiry();
                       //             int questionIndex = UI.GetQuestionIndexPosition(chapterQuestions);
                       //             inquiry.Answers = UI.GetAnswerList(chapterQuestions, questionIndex);
                       //             int answerPosition = UI.GetAnswerIndex(inquiry.Answers);
                       //             QorAModified = UI.IsAnswerModified(answerPosition, inquiry.Answers);
                       //             break;

                       //         case ModifySection.Exit:

                       //             endModification = false;
                       //             break;
                       //     }

                       //     if (nameModified)
                       //     {
                       //         FileUtils.UpdateAndSerializeNewCategoryName(quizChapter, fileToModify);
                       //     }
                       //     if (QorAModified)
                       //     {
                       //         FileUtils.SerializeModifiedCategoryToFile(quizChapter, fileToModify);
                       //     }
                       //     /* Data saved*/
                       // } while (endModification);

                       QuizCategory quizChapter = Logic.GetSectionModify();

                        break;

                        case QuizState.Exit:

                        runningProgram = false;
                        Console.WriteLine("Thank you for playing our Quiz Maker!\nGoodbye!");
                        break;
                }
            }
        }

    }

}
