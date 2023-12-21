using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethod.ShowIntroAndQuizRules();

            while (true)
            {

                QuizState state = FileUtils.GetMenuOption();

                switch (state)
                {

                    case QuizState.Build:

                        bool createNewCategory = false;

                        do
                        {
                            QuizCategory quizCategory = new QuizCategory(); // Object containing all category name and questions

                            quizCategory.Name = UIMethod.GetCategoryName();  // Category name

                            List<Question> questions = new List<Question>();

                            bool createNewQuestions = false;

                            do
                            {
                                Question question = new Question(); // Questions container

                                question.Inquiry = UIMethod.GetQuestionInput();// Actual question

                                int numOfAnswers = UIMethod.GetNumOfAnswers();

                                List<string> answers = UIMethod.GetDecoyAnswers(numOfAnswers);

                                string correctAnswer = UIMethod.GetCorrectAnswer();

                                answers.Add(correctAnswer);

                                answers = Logic.GetIndexShuffle(answers);

                                question.Answers = answers;

                                question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

                                questions.Add(question);

                                createNewQuestions = UIMethod.GetNewQuestion();

                            } while (createNewQuestions);

                            quizCategory.Questions = questions;

                            createNewCategory = UIMethod.GetNewCategory();

                            FileUtils.SerializeCategoryToFile(quizCategory, questions);

                        } while (createNewCategory);

                        break;


                    case QuizState.Play:

                        QuizCategory quizSection = new QuizCategory();

                        List<Question> sectionQuestions = new List<Question>();

                        UIMethod.ShowCategoryInquiry();

                        string[] fileEntires = FileUtils.GetCategorySelection();

                        string fileToPlay = UIMethod.GetSelectedFileName(fileEntires);

                        quizSection = FileUtils.DeserializeFileToCategory(fileToPlay);

                        sectionQuestions = quizSection.Questions;

                        int correctAnswerCount = Logic.GetSumOfCorrectAnswer(sectionQuestions);

                        UIMethod.ShowGradingResult(correctAnswerCount, sectionQuestions);
                        break;


                    case QuizState.Modify:
                        break;
                }
            }
        }

    }

}
