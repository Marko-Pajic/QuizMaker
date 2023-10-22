namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethod.IntroAndQuizRules();

            //UIMethod.CategoryName();// Naming a category of guestions

            while (true)
            {

                QuestionContainer questionContainer = new QuestionContainer(); // Object containing all category name and questions

                questionContainer.Name = UIMethod.CategoryName();  // Category name

                List<Question> categoryQuestions = new List<Question>();

                questionContainer.Questions = categoryQuestions;

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

                    Console.Write("Write down the correct answer to your question");
                    string correctAnswer = Console.ReadLine();
                    answers.Add(correctAnswer);
                    question.Answers = answers;
                    categoryQuestions.Add(question);
                    Console.WriteLine(answers[0]);
                    Console.WriteLine(answers[1]);

                    Console.WriteLine("Wanna add more questions");
                    Console.WriteLine("Answer with y or n");
                    string createNewQuestions = Console.ReadLine().ToLower();

                    if (createNewQuestions == "y")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }while (true);

                Console.WriteLine("Wanna create new category?");
                Console.WriteLine("Answer with y or n");
                string createNewCategory = Console.ReadLine().ToLower();

                if (createNewCategory == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            Question question2 = new Question();

            question2.Inquiry = "What’s the primary ingredient in hummus?";
            List<string> answers2 = new List<string>();
            answers2.Add("Chickpeas");
            answers2.Add("Tahini");
            answers2.Add("Sesame");

            //question2.RightAnswer = "Chickpeas";
            //question2.WrongAnswer1 = "Tahini";
            //question2.WrongAnswer2 = "Sesame";

            Question question3 = new Question();

            question3.Inquiry = "Which country produces the most coffee in the world?";
            List<string> answers3 = new List<string>();
            answers3.Add("Brasil");
            answers3.Add("Nicaragua");
            answers3.Add("Colombia");

            //question3.RightAnswer = "Brasil";
            //question3.WrongAnswer1 = "Nicaragua";
            //question3.WrongAnswer2 = "Colombia";

            Question question4 = new Question();

            question4.Inquiry = "Which European nation was said to invent hot dogs?";
            List<string> answers4 = new List<string>();
            answers4.Add("Germany");
            answers4.Add("Poland");
            answers4.Add("Italy");

            //question4.RightAnswer = "Germany";
            //question4.WrongAnswer1 = "Poland";
            //question4.WrongAnswer2 = "Italy";

            Question question5 = new Question();

            question5.Inquiry = "Which kind of alcohol is Russia notoriously known for?";
            List<string> answers5 = new List<string>();
            answers5.Add("Vodka");
            answers5.Add("Beer");
            answers5.Add("Wine");

            //question5.RightAnswer = "Vodka";
            //question5.WrongAnswer1 = "Beer";
            //question5.WrongAnswer2 = "Wine";

            //categoryQuestions.Add(question1);
            //categoryQuestions.Add(question2);
            //categoryQuestions.Add(question3);
            //categoryQuestions.Add(question4);
            //categoryQuestions.Add(question5);

            
        }

    }
}