using System;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethod.IntroAndQuizRules();

            FileUtils.GetExistingFile();

            if (FileUtils.GetExistingFile() == 1)
            {

                bool createNewCategory = false;

                do
                {
                    QuizCategory questionContainer = new QuizCategory(); // Object containing all category name and questions

                    questionContainer.Name = UIMethod.CategoryName();  // Category name

                    List<Question> categoryQuestions = new List<Question>();

                    bool createNewQuestions = false;

                    do
                    {
                        Question question = new Question(); // Questions container

                        question.Inquiry = UIMethod.QuestionInput();// Actual question

                        List<string> answers = new List<string>();// Answers container

                        int numOfAnswers = UIMethod.NumOfAnswers();

                        answers = UIMethod.DecoyAnswers(numOfAnswers, answers);

                        string correctAnswer = UIMethod.CorrectAnswer();

                        answers.Add(correctAnswer);

                        answers = Logic.IndexShuffle(answers);

                        question.Answers = answers;

                        question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

                        categoryQuestions.Add(question);

                        FileUtils.XmlSerializer(questionContainer, categoryQuestions);

                        createNewQuestions = UIMethod.CreateNewQuestion();

                    } while (createNewQuestions);

                    questionContainer.Questions = categoryQuestions;

                    createNewCategory = UIMethod.CreateNewCategory();

                } while (createNewCategory);

            }

            if(FileUtils.GetExistingFile() == 2)
            {

            }
            
        }

    }
}