using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethod.ShowIntroAndQuizRules();

            QuizState state = FileUtils.GetMenuOption();

            if (state == QuizState.Build)
            {

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
                
                state = QuizState.Play;
            }

            if (state == QuizState.Play)
            {
                QuizCategory questionContainer = new QuizCategory();
                List<Question> categoryQuestions = new List<Question>();

                string fileToPlay = FileUtils.GetCategorySelection();

                questionContainer = FileUtils.DeserializeFileToCategory(fileToPlay);

                Question question = new Question();

                int correctAnswear = Logic.GetSumOfCorrectAnswer(categoryQuestions, question);

            }
        }

    }

}
