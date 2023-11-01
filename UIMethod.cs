namespace QuizMaker
{
    public static class UIMethod
    {
        public static void IntroAndQuizRules()
        {
            Console.WriteLine("Welcome to game of Quiz bla bla");
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

        public static string CreateNewQuestion()
        {
            Console.WriteLine("Wanna add more questions");
            Console.WriteLine("Answer with y or n");
            string createNewQuestions = Console.ReadLine().ToLower();
            return createNewQuestions;
        }

        public static string CreateNewCategory() 
        {
            Console.WriteLine("Wanna create new category?");
            Console.WriteLine("Answer with y or n");
            string createNewCategory = Console.ReadLine().ToLower();
            return createNewCategory;
        }
    }
}
