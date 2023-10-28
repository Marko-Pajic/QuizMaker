namespace QuizMaker
{
    public class Logic

    {
        public static List<string> AddingAnswers(int numOfAnswers, List<string> answers) 
        {
            int incorrectAnswerCount = 0;
            //List<string> answers = new List<string>();

            do
            {
                incorrectAnswerCount++;
                Console.Write($"Enter answer {incorrectAnswerCount}. ");
                answers.Add(Console.ReadLine());

            } while (incorrectAnswerCount<numOfAnswers - 1);

            return answers;
        }
    }
}
