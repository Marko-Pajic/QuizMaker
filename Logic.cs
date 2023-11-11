namespace QuizMaker
{
    public class Logic

    {
        public static List<string> GetIndexShuffle(List<string> answers)
        {

            for (int i = answers.Count - 1; i > 0; i--)
            {
                int j = Program.rng.Next(i + 1);
                string temp = answers[i];
                answers[i] = answers[j];
                answers[j] = temp;
            }

            return answers;
        }
    }
}
