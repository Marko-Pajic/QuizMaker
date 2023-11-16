using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethod.ShowIntroAndQuizRules();

            int numOfChoice = FileUtils.GetExistingFile();

            if (numOfChoice == 1)
            {

                bool createNewCategory = false;

                do
                {
                    QuizCategory questionContainer = new QuizCategory(); // Object containing all category name and questions

                    questionContainer.Name = UIMethod.GetCategoryName();  // Category name

                    List<Question> categoryQuestions = new List<Question>();

                    bool createNewQuestions = false;

                    do
                    {
                        Question question = new Question(); // Questions container

                        question.Inquiry = UIMethod.GetQuestionInput();// Actual question

                        List<string> answers = new List<string>();// Answers container

                        int numOfAnswers = UIMethod.GetNumOfAnswers();

                        answers = UIMethod.GetDecoyAnswers(numOfAnswers, answers);

                        string correctAnswer = UIMethod.GetCorrectAnswer();

                        answers.Add(correctAnswer);

                        answers = Logic.GetIndexShuffle(answers);

                        question.Answers = answers;

                        question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

                        categoryQuestions.Add(question);

                        FileUtils.XmlSerializer(questionContainer, categoryQuestions);

                        createNewQuestions = UIMethod.GetNewQuestion();

                    } while (createNewQuestions);

                    questionContainer.Questions = categoryQuestions;

                    createNewCategory = UIMethod.GetNewCategory();

                } while (createNewCategory);

                numOfChoice = Constants.QUIZ_INITIATOR;
            }

            if (numOfChoice == Constants.QUIZ_INITIATOR)
            {
                QuizCategory questionContainer = new QuizCategory();
                List<Question> categoryQuestions = new List<Question>();

                string fileToPlay = FileUtils.GetCategorySelection();

                FileUtils.XmlDeserializer(fileToPlay, questionContainer, categoryQuestions);
            }

        }

    }
}