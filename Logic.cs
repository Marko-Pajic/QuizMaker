using QuizMaker.Enumerations;

namespace QuizMaker
{
    public class Logic

    {
        /// <summary>
        /// using Knuths algorithm to shuffle list of answers
        /// </summary>
        /// <param name="answers"></param>
        /// <returns>shuffled list of answers</returns>
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
        /// 1.shuffles aquired answers
        /// 2.assigns answers to object
        /// 3.finds the index of correct answer and assignes it to object property
        /// </summary>
        /// <param name="question">object containing answers</param>
        /// <param name="answers">list of answers</param>
        /// <param name="correctAnswer">string containing correct answer</param>
        /// <returns>object containing answers and correct answer index</returns>
        public static Question GetAnswerArranged (Question question, List<string> answers, string correctAnswer)
        {
            answers = Logic.GetIndexShuffle(answers);

            question.Answers = answers;

            question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

            return question;
        }
        /// <summary>
        /// 1.assigns current list of objects to new list
        /// 2.serializes object containg list of objects
        /// </summary>
        /// <param name="questions">new list of objects</param>
        /// <param name="quizCategory">object containing list of objects</param>
        public static void AddQuestionAndSerialize (List<Question> questions, QuizCategory quizCategory)
        {
            quizCategory.Questions = questions;
            FileUtils.SerializeCategoryToFile(quizCategory);
        }
        /// <summary>
        /// 1.instantiates new object
        /// 2.populate the new object
        /// </summary>
        /// <returns>new object populated</returns>
        public static QuizCategory GetCategory()
        {
            QuizCategory quizSection = new QuizCategory();
            quizSection = FileUtils.GetSectionToModify(quizSection);
            return quizSection;
        }
    }
}
