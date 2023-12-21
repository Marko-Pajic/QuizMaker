using QuizMaker.Enumerations;

namespace QuizMaker
{
    public static class UIMethod
    {
        /// <summary>
        /// displays intro and application instructions
        /// </summary>
        public static void ShowIntroAndQuizRules()
        {
            Console.WriteLine("Welcome to game of Quiz...");
            Console.WriteLine("Your welcome to start using QuizMaker");
        }

        /// <summary>
        /// displays multiple choices
        /// </summary>
        /// <returns>enum of the chosen option</returns>
        public static QuizState GetOptionPreferences()
        {
            Console.WriteLine("Choose from one of following options:");
            Console.WriteLine("1. Create new Quiz");
            Console.WriteLine("2. Play the Quiz");
            Console.WriteLine("3. Modify the current Quiz");
            int optionMenu = int.Parse(Console.ReadLine());
            switch (optionMenu)
            {
                case 1:
                    return QuizState.Build;
                case 2:
                    return QuizState.Play;
                case 3:
                    return QuizState.Modify;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    return GetOptionPreferences();
            }
        }

        /// <summary>
        /// displays a string in form of a question
        /// </summary>
        /// <returns>string in form of an answer</returns>
        public static string GetCategoryName()
        {
            Console.WriteLine("Give you category of questions a name");
            string questionNaire = Console.ReadLine();
            return questionNaire;
        }

        /// <summary>
        /// displays a string in form of a question
        /// </summary>
        /// <returns>string in form of an answer</returns>
        public static string GetQuestionInput()
        {
            Console.WriteLine("Write the question that would fit inside your category");
            string question = Console.ReadLine();
            return question;
        }

        /// <summary>
        /// displays a string in form of a question
        /// </summary>
        /// <returns>integer in form of an answer</returns>
        public static int GetNumOfAnswers()
        {
            Console.Write("Enter the number of answers: ");
            int numOfAnswers = int.Parse(Console.ReadLine());
            return numOfAnswers;
        }

        /// <summary>
        /// creates a list of answers
        /// </summary>
        /// <param name="numOfAnswers"></param>
        /// <returns>list of given answers</returns>
        public static List<string> GetDecoyAnswers(int numOfAnswers)
        {
            int incorrectAnswerCount = 0;
            List<string> answers = new List<string>();

            do
            {
                incorrectAnswerCount++;
                Console.Write($"Enter answer {incorrectAnswerCount}. ");
                answers.Add(Console.ReadLine());

            } while (incorrectAnswerCount < numOfAnswers - 1);

            return answers;
        }

        /// <summary>
        /// displays a string in form of a question
        /// </summary>
        /// <returns>string in form of an answer</returns>
        public static string GetCorrectAnswer()
        {
            Console.Write("Write down the correct answer to your question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        public static bool GetNewQuestion()
        {
            Console.WriteLine("Wanna add more questions");
            Console.WriteLine("Answer with y or n");
            char createNewQuestions = Console.ReadKey().KeyChar;

            return createNewQuestions == Constant.POSITIVE_ANSWER;

        }

        public static bool GetNewCategory()
        {
            Console.WriteLine("Wanna create new category?");
            Console.WriteLine("Answer with y or n");
            char createNewCategory = Console.ReadKey().KeyChar;

            return createNewCategory == Constant.POSITIVE_ANSWER;
        }

        public static void ShowCategoryInquiry()
        {
            Console.WriteLine("Chose the category you would like to play");
        }

        public static string GetSelectedFileName(string[] fileEntries)
        {
            string fileEntry;

            for (int i = 0; i < fileEntries.Length; i++)
            {
                fileEntry = fileEntries[i];
                Console.WriteLine($"{i + 1}.{Path.GetFileNameWithoutExtension(fileEntry)}");
            }

            int numOfChosenCategory = int.Parse(Console.ReadLine());
            string fileToPlay = fileEntries[numOfChosenCategory - 1];
            return fileToPlay;
        }

        public static void ShowCategoryQuestion(Question question)
        {
            Console.WriteLine(question.Inquiry);
        }

        public static void ShowAnswerOption(Question question, int ans)
        {
            Console.WriteLine($"{ans + 1} {question.Answers[ans]}");
        }

        public static int GetAnswerPosition()
        {
            Console.WriteLine("Enter the number infront of the answer you think is right");
            int givenAnswer = int.Parse(Console.ReadLine()) - 1;
            return givenAnswer;
        }

        public static void ShowAffirmingMessage()
        {
            Console.WriteLine("Thats correct!");
        }

        public static void ShowCorrectAnswer(Question question)
        {
            Console.WriteLine("Wrong answer");
            Console.WriteLine($"Correct answer is {question.Answers[question.CorrectAnswerIndex]}");
        }

        public static void ShowNotification()
        {
            Console.WriteLine("That was your last question!");
        }

        public static void ShowGradingResult(int correctAnswer, List<Question> questions)
        {
            Console.WriteLine($"You had {correctAnswer} correct answers out of {questions.Count} questions.");

            double calResult = ((double)correctAnswer / questions.Count) * 100;

            Console.WriteLine($"Procentage: {calResult}%");

            int result = (int)Math.Floor(calResult);

            if (result >= (int)GradeBorder.LowerBorderPassed && result <= (int)GradeBorder.UpperBorderPassed)
            {
                Console.WriteLine(QuizGrades.Passed);
            }
            if (result > (int)GradeBorder.UpperBorderPassed && result <= (int)GradeBorder.UpperBorderNice)
            {
                Console.WriteLine(QuizGrades.Nice);
            }
            if (result > (int)GradeBorder.UpperBorderNice && result <= (int)GradeBorder.UpperBorderSplendid)
            {
                Console.WriteLine(QuizGrades.Splendid);
            }
            if (result >= (int)GradeBorder.LowerBorderAwesome)
            {
                Console.WriteLine(QuizGrades.Awesome);
            }
            if (result < (int)GradeBorder.LowerBorderPassed)
            {
                Console.WriteLine(QuizGrades.Failed);
            }
        }

    }
}
