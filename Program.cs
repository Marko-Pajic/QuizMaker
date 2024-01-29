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

            while (true)
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

                        string[] fileEntires = FileUtils.GetCategorySelection();

                        string fileToPlay = UI.GetSelectedFileName(fileEntires);

                        quizSection = FileUtils.DeserializeFileToCategory(fileToPlay);

                        sectionQuestions = quizSection.Questions;

                        int correctAnswerCount = Logic.GetSumOfCorrectAnswer(sectionQuestions);

                        int numberOfQuestions = sectionQuestions.Count;

                        UI.ShowGradingResult(correctAnswerCount, numberOfQuestions);

                        break;


                    case QuizState.Modify:

                        List<QuizCategory> quizCategories = new List<QuizCategory>();

                        var x = quizCategories.Where(q => q.Name == "Food");

                        QuizCategory quizChapter = new QuizCategory();

                        UI.ShowSectionInquiry();

                        string[] categoryNames = FileUtils.GetCategorySelection();

                        string fileToModify = UI.GetSelectedFileName(categoryNames);

                        quizChapter = FileUtils.DeserializeFileToCategory(fileToModify);

                        List<Question> chapterQuestions = new List<Question>();/* Consider to remove*/

                        chapterQuestions = quizChapter.Questions;/* Consider to remove*/

                        Question inquiry = new Question();

                        //inquiry.Answers = 

                        bool endModification = true;

                        do
                        {
                            bool nameModified = false;
                            bool QorAModified = false;

                            ModifySection option = UI.GetOptionSelection();

                            switch (option)
                            {
                                case ModifySection.Name:

                                    string newName = UI.GetCategoryModifiedName(quizChapter);
                                    if (newName != quizChapter.Name)
                                    {
                                        quizChapter.Name = newName;
                                        nameModified = true;
                                    }
                                    break;

                                case ModifySection.Questions:

                                    List<Question> newQuestions = UI.GetModifiedQuestionInput(chapterQuestions);
                                    if (!newQuestions.SequenceEqual(quizChapter.Questions))
                                    {
                                        quizChapter.Questions = newQuestions;
                                        QorAModified = true;
                                    }
                                    break;

                                case ModifySection.Answers:

                                    inquiry.Answers = UI.GetCurrentAnswerList(chapterQuestions);
                                    QorAModified = UI.GetModifiedAnswerList(inquiry.Answers);
                                    break;

                                case ModifySection.Exit:
                                    endModification = false;
                                    break;
                            }

                            if (nameModified)
                            {
                                FileUtils.UpdateAndSerializeNewCategoryName(quizChapter, fileToModify);
                            }
                            if (QorAModified)
                            {
                                FileUtils.SerializeModifiedCategoryToFile(quizChapter, fileToModify);
                            }
                            /* Data saved*/
                        } while (endModification);

                       // quizChapter = ;

                        break;

                        case QuizState.Exit:
                        break;
                }
            }
        }

    }

}
