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

                int givenAnswer = UI.GetAnswerPosition(question.Answers.Count);

                if (givenAnswer.Equals(question.CorrectAnswerIndex))
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

        public static QuizCategory GetSectionToModify(QuizCategory quizSection)
        {
            string[] fileEntires = FileUtils.GetCategorySelection();

            string fileToPlay = UI.GetSelectedFileName(fileEntires);

            quizSection = FileUtils.DeserializeFileToCategory(fileToPlay);

            return quizSection;
        }

        public static QuizCategory GetSectionModify()
        {
            QuizCategory quizChapter = new QuizCategory();

            UI.ShowSectionInquiry();

            string[] categoryNames = FileUtils.GetCategorySelection();

            string fileToModify = UI.GetSelectedFileName(categoryNames);

            quizChapter = FileUtils.DeserializeFileToCategory(fileToModify);

            //quizChapter = Logic.GetSectionToModify(quizChapter);

            List<Question> chapterQuestions = new List<Question>();/* Consider to remove*/

            chapterQuestions = quizChapter.Questions;/* Consider to remove*/

            Question inquiry = new Question();

            bool endModification = true;

            do
            {
                bool nameModified = false;
                bool QorAModified = false;

                ModifySection option = UI.GetOptionSelection();

                switch (option)
                {
                    case ModifySection.Name:

                        string newName = UI.GetCategoryModifiedName(quizChapter);
                        nameModified = UI.IsNameModified(newName, quizChapter);
                        break;

                    case ModifySection.Questions:

                        UI.ShowQuestionList(chapterQuestions);
                        UI.ShowQuestionInquiry();
                        int questionPosition = UI.GetQuestionIndexPosition(chapterQuestions);
                        QorAModified = UI.IsQuestionModified(questionPosition, chapterQuestions);
                        break;

                    case ModifySection.Answers:

                        UI.ShowQuestionList(chapterQuestions);
                        UI.ShowAnswerInquiry();
                        int questionIndex = UI.GetQuestionIndexPosition(chapterQuestions);
                        inquiry.Answers = UI.GetAnswerList(chapterQuestions, questionIndex);
                        int answerPosition = UI.GetAnswerIndex(inquiry.Answers);
                        QorAModified = UI.IsAnswerModified(answerPosition, inquiry.Answers);
                        break;

                    case ModifySection.Exit:

                        endModification = false;
                        break;
                }

                if (nameModified)
                {
                    FileUtils.UpdateAndSerializeNewCategoryName(quizChapter, fileToModify);
                }
                if (QorAModified)
                {
                    FileUtils.SerializeModifiedCategoryToFile(quizChapter, fileToModify);
                }
                /* Data saved*/
            } while (endModification);

            return quizChapter;
        }
    }
}
