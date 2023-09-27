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
    }
}
