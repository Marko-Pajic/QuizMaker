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

            while (true)
            {

                QuizCategory questionContainer = new QuizCategory(); // Object containing all category name and questions

                questionContainer.Name = UIMethod.CategoryName();  // Category name

                List<Question> categoryQuestions = new List<Question>();


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

                    string directoryPath = @"xml.files";
                    string fileName = $@"{questionContainer.Name}.xml";
                    string filePath = Path.Combine(directoryPath, fileName);

                    Directory.CreateDirectory(directoryPath);

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
                    using (FileStream file = File.Create(filePath))
                    {
                        serializer.Serialize(file, categoryQuestions);
                    }

                    string createNewQuestions = UIMethod.CreateNewQuestion();

                    if (createNewQuestions != "y")
                    {
                        break;
                    }

                }while (true);

                questionContainer.Questions = categoryQuestions;

                string createNewCategory = UIMethod.CreateNewCategory();

                if (createNewCategory != "y")
                {
                    break;
                }
            }


            
        }

    }
}