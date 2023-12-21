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

        public static int GetSumOfCorrectAnswer(List<Question> questions)/*, Question question)*/
        {
            int correctAnswer = 0;

            Question question = new Question();

            for (int qn = 0; qn < questions.Count; qn++)
            {
                question = questions[qn];

                UIMethod.ShowCategoryQuestion(question);

                for (int ans = 0; ans < question.Answers.Count; ans++)
                {
                    UIMethod.ShowAnswerOption(question, ans);
                }

                int givenAnswer = UIMethod.GetAnswerPosition();

                if (givenAnswer == question.CorrectAnswerIndex)
                {
                    correctAnswer++;
                    UIMethod.ShowAffirmingMessage();
                }
                else
                {
                    UIMethod.ShowCorrectAnswer(question);
                }
            }
            UIMethod.ShowNotification();

            return correctAnswer;
        }
    }
}
