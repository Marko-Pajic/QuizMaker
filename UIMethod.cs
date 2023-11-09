namespace QuizMaker
{
    public static class UIMethod
    {
        public static void IntroAndQuizRules()
        {
            Console.WriteLine("Welcome to game of Quiz...");
            Console.WriteLine("Your welcome to start using QuizMaker");
        }

        public static int OptionMenu()
        {
            Console.WriteLine("Choose from one of following options:");
            Console.WriteLine("1. Create new Quiz");
            Console.WriteLine("2. Play the Quiz");
            Console.WriteLine("3. Modify the current Quiz");
            int optionMenu = int.Parse(Console.ReadLine());
            return optionMenu;
        }

        public static string CategoryName()
        {
            Console.WriteLine("Give you category of questions a name");
            string questionNaire = Console.ReadLine();
            return questionNaire;
        }

        public static string QuestionInput()
        {
            Console.WriteLine("Write the question that would fit inside your category");
            string question = Console.ReadLine();
            return question;
        }

        public static int NumOfAnswers()
        {
            Console.Write("Enter the number of answers: ");
            int numOfAnswers = int.Parse(Console.ReadLine());
            return numOfAnswers;
        }

        public static List<string> DecoyAnswers(int numOfAnswers, List<string> answers)
        {
            int incorrectAnswerCount = 0;

            do
            {
                incorrectAnswerCount++;
                Console.Write($"Enter answer {incorrectAnswerCount}. ");
                answers.Add(Console.ReadLine());

            } while (incorrectAnswerCount < numOfAnswers - 1);

            return answers;
        }

        public static string CorrectAnswer()
        {
            Console.Write("Write down the correct answer to your question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        public static bool CreateNewQuestion()
        {
            Console.WriteLine("Wanna add more questions");
            Console.WriteLine("Answer with y or n");
            string createNewQuestions = Console.ReadLine().ToLower();

            if (createNewQuestions == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CreateNewCategory()
        {
            Console.WriteLine("Wanna create new category?");
            Console.WriteLine("Answer with y or n");
            string createNewCategory = Console.ReadLine().ToLower();

            if (createNewCategory == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
