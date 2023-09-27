namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string questionNaire = Console.ReadLine();// Naming a category of guestions

            QuestionContainer questionContainer = new QuestionContainer(); // Object containing all questions

            questionContainer.Name = questionNaire;  // Category name

            string quizQuestion = Console.ReadLine();

            Question question1 = new Question(); // Questions container

            question1.Inquiry = quizQuestion;// Actual question

            List<string> answers1 = new List<string>();// Answers container
            question1.Answers = answers1;
            string correctAnswer = Console.ReadLine();
            answers1.Add(correctAnswer);
            int incorrectAnswerCount = 0;

            do
            {
                string incorrectAnswer = Console.ReadLine();
                answers1.Add(incorrectAnswer);
                incorrectAnswerCount++;

            } while (incorrectAnswerCount < 2);

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

            questionContainer.firstQuestion = question1;
            questionContainer.secondQuestion = question2;
            questionContainer.thirdQuestion = question3;
            questionContainer.fourthQuestion = question4;
            questionContainer.fifthQuestion = question5;

            Console.WriteLine(answers1);
        }

    }
}