namespace QuizMaker
{
    public class Logic

    {
        public static List<string> IndexShuffle(List<string> answers)
        {
            Random rng = new Random();

            for (int i = answers.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                string temp = answers[i];
                answers[i] = answers[j];
                answers[j] = temp;
            }

            return answers;
        }
    }
}
