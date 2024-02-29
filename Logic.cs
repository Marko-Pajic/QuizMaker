using QuizMaker.Enumerations;

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
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answers"></param>
        /// <param name="correctAnswer"></param>
        /// <returns></returns>
        public static Question GetAnswerArranged (Question question, List<string> answers, string correctAnswer)
        {
            answers = Logic.GetIndexShuffle(answers);

            question.Answers = answers;

            question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

            return question;
        }

        public static void AddQuestionAndSerialize (List<Question> questions, QuizCategory quizCategory)
        {
            quizCategory.Questions = questions;
            FileUtils.SerializeCategoryToFile(quizCategory);
        }

        public static QuizCategory GetCategory()
        {
            QuizCategory quizSection = new QuizCategory();
            quizSection = FileUtils.GetSectionToModify(quizSection);
            return quizSection;
        }
    }
}
