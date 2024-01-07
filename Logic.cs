namespace QuizMaker
{
    public class Logic

    {
        /// <summary>
        /// using Knuths algorithm to shuffle list of answers
        /// </summary>
        /// <param name="answers"></param>
        /// <returns>list of answers</returns>
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

        /// <summary>
        /// looping through list of questions and prompting for answers 
        /// </summary>
        /// <param name="questions"></param>
        /// <returns>number of correct answers</returns>
        public static int GetSumOfCorrectAnswer(List<Question> questions)
        {
            int correctAnswer = 0;

            Question question = new Question();

            for (int qn = 0; qn < questions.Count; qn++)
            {
                question = questions[qn];

                UI.ShowCategoryQuestion(question);

                for (int ans = 0; ans < question.Answers.Count; ans++)
                {
                    UI.ShowAnswerOption(question, ans);
                }

                int givenAnswer = UI.GetAnswerPosition();

                if (givenAnswer == question.CorrectAnswerIndex)
                {
                    correctAnswer++;
                    UI.ShowAffirmingMessage();
                }
                else
                {
                    UI.ShowCorrectAnswer(question);
                }
            }
            UI.ShowNotification();

            return correctAnswer;
        }
    }
}
