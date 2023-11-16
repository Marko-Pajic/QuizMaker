namespace QuizMaker
{
    public static class UIMethod
    {
        public static void ShowIntroAndQuizRules()
        {
            Console.WriteLine("Welcome to game of Quiz...");
            Console.WriteLine("Your welcome to start using QuizMaker");
        }

        public static int GetOptionPreferences()
        {
            Console.WriteLine("Choose from one of following options:");
            Console.WriteLine("1. Create new Quiz");
            Console.WriteLine("2. Play the Quiz");
            Console.WriteLine("3. Modify the current Quiz");
            int optionMenu = int.Parse(Console.ReadLine());
            return optionMenu;
        }

        public static string GetCategoryName()
        {
            Console.WriteLine("Give you category of questions a name");
            string questionNaire = Console.ReadLine();
            return questionNaire;
        }

        public static string GetQuestionInput()
        {
            Console.WriteLine("Write the question that would fit inside your category");
            string question = Console.ReadLine();
            return question;
        }

        public static int GetNumOfAnswers()
        {
            Console.Write("Enter the number of answers: ");
            int numOfAnswers = int.Parse(Console.ReadLine());
            return numOfAnswers;
        }

        public static List<string> GetDecoyAnswers(int numOfAnswers, List<string> answers)
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

        public static string GetCorrectAnswer()
        {
            Console.Write("Write down the correct answer to your question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        public static bool GetNewQuestion()
        {
            Console.WriteLine("Wanna add more questions");
            Console.WriteLine("Answer with y or n");
            char createNewQuestions = Console.ReadKey().KeyChar;

            return createNewQuestions == Constants.POSITIVE_ANSWER;

        }

        public static bool GetNewCategory()
        {
            Console.WriteLine("Wanna create new category?");
            Console.WriteLine("Answer with y or n");
            char createNewCategory = Console.ReadKey().KeyChar;

            return createNewCategory == Constants.POSITIVE_ANSWER;
        }

        public static void ShowCategoryInquiry() 
        {
            Console.WriteLine("Chose the category you would like to play");
        }

        //public static int GetChoiceOfCategory(QuizCategory questionContainer)
        //{
        //    Console.WriteLine("Chose the category you would like to play");
        //    int nameCount = questionContainer.Name.Count() ;
        //    for (int i = 1; i < nameCount; i++)
        //    {
        //        Console.WriteLine($"{i}.{questionContainer.Name}");
        //    }
        //    int numOfChosenCategory = int.Parse(Console.ReadLine());
        //    return numOfChosenCategory;
        //} 

    }
}
