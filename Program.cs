using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethod.IntroAndQuizRules();

            while (true)
            {

                QuestionContainer questionContainer = new QuestionContainer(); // Object containing all category name and questions

                questionContainer.Name = UIMethod.CategoryName();  // Category name

                List<Question> categoryQuestions = new List<Question>();


                do
                {
                    Question question = new Question(); // Questions container

                    question.Inquiry = UIMethod.QuestionInput();// Actual question

                    List<string> answers = new List<string>();// Answers container

                    Console.Write("Enter the number of answers: ");
                    int numOfAnswers = int.Parse(Console.ReadLine());

                    int incorrectAnswerCount = 0;

                    do
                    {
                        incorrectAnswerCount++;
                        Console.Write($"Enter answer {incorrectAnswerCount}. ");
                        answers.Add(Console.ReadLine());

                    } while (incorrectAnswerCount < numOfAnswers - 1);

                    Console.Write("Write down the correct answer to your question: ");
                    string correctAnswer = Console.ReadLine();
                    answers.Add(correctAnswer);
                    question.Answers = answers;

                    categoryQuestions.Add(question);

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
                    string path = $@"C:\Users\pajic\source\repos\QuizMaker\xml.files\{questionContainer.Name}.xml";
                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, categoryQuestions);
                    }

                    Console.WriteLine("Wanna add more questions");
                    Console.WriteLine("Answer with y or n");
                    string createNewQuestions = Console.ReadLine().ToLower();

                    if (createNewQuestions != "y")
                    {
                        break;
                    }

                }while (true);

                questionContainer.Questions = categoryQuestions;

                Console.WriteLine("Wanna create new category?");
                Console.WriteLine("Answer with y or n");
                string createNewCategory = Console.ReadLine().ToLower();

                if (createNewCategory != "y")
                {
                    break;
                }
            }
            

            //categoryQuestions.Add(question1);
            //categoryQuestions.Add(question2);
            //categoryQuestions.Add(question3);
            //categoryQuestions.Add(question4);
            //categoryQuestions.Add(question5);

            
        }

    }
}