using QuizMaker.Enumerations;

namespace QuizMaker
{
    public static class UI
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
        /// displays a string
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
            int numOfAnswers;
            if (int.TryParse(Console.ReadLine(), out numOfAnswers))
            {
                return numOfAnswers;
            }
            else
            {
               Console.WriteLine("Incorrect input.");
                return GetNumOfAnswers();
            }
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
            Console.WriteLine("Lets fill in the decoy/incorrect answers first!");
            Console.WriteLine("Decoy/incorrect answers:");
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
            Console.WriteLine("Lets move to the correct answer!");
            Console.WriteLine("Correct answer:");
            Console.Write("Enter answer:");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        /// <summary>
        /// displays question and input field
        /// </summary>
        /// <returns>boolean</returns>
        public static bool GetNewQuestion()
        {
            Console.WriteLine("Wanna add more questions");
            Console.WriteLine("Answer with y or n");
            char createNewQuestions = Console.ReadKey().KeyChar;

            return Constant.POSITIVE_ANSWER.Equals(createNewQuestions);

        }

        /// <summary>
        /// displays question and input field
        /// </summary>
        /// <returns>boolean</returns>
        public static bool GetNewCategory()
        {
            Console.WriteLine("Wanna create new category?");
            Console.WriteLine("Answer with y or n");
            char createNewCategory = Console.ReadKey().KeyChar;

            return Constant.POSITIVE_ANSWER.Equals(createNewCategory);
        }


        /// <summary>
        /// displays a string
        /// </summary>
        public static void ShowCategoryInquiry()
        {
            Console.WriteLine("Chose the category you would like to play");
        }

        /// <summary>
        /// Loops through array of files displaying them as option menu
        /// </summary>
        /// <param name="fileEntries">array of files</param>
        /// <returns>chosen file</returns>
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

        /// <summary>
        /// displays a quiz question  
        /// </summary>
        /// <param name="question">object where question is stored in propertie</param>
        public static void ShowCategoryQuestion(Question question)
        {
            Console.WriteLine(question.Inquiry);
        }

        /// <summary>
        /// displays incremented answers
        /// </summary>
        /// <param name="question">object where answers are stored in propertie</param>
        /// <param name="ans">index position</param>
        public static void ShowAnswerOption(Question question, int ans)
        {
            Console.WriteLine($"{ans + 1} {question.Answers[ans]}");
        }

        /// <summary>
        /// displays input inqury for user 
        /// </summary>
        /// <returns>int substracted by 1 to relate to index position</returns>
        public static int GetAnswerPosition()
        {
            Console.WriteLine("Enter the number infront of the answer you think is right");
            int givenAnswer = int.Parse(Console.ReadLine()) - 1;
            return givenAnswer;
        }

        /// <summary>
        /// displays positive outcome message to user
        /// </summary>
        public static void ShowAffirmingMessage()
        {
            Console.WriteLine("Thats correct!");
        }

        /// <summary>
        /// 1. displays negative outcome message to user
        /// 2. displays correct option to user
        /// </summary>
        /// <param name="question">object from which correct option is extracted through index position</param>
        public static void ShowCorrectAnswer(Question question)
        {
            Console.WriteLine("Wrong answer");
            Console.WriteLine($"Correct answer is {question.Answers[question.CorrectAnswerIndex]}");
        }

        /// <summary>
        /// displays warning message to user
        /// </summary>
        public static void ShowNotification()
        {
            Console.WriteLine("That was your last question!");
        }

        /// <summary>
        /// conditional expression method
        /// </summary>
        /// <param name="result">int representing user score of correct answers</param>
        /// <param name="lowerBound">enum</param>
        /// <param name="upperBound">enum</param>
        /// <returns>boolean result of conditional expression</returns>
        public static bool IsAnswerCountWithinRange(int result, GradeBorder lowerBound, GradeBorder upperBound)
        {
            return result > (int)lowerBound && result <= (int)upperBound;
        }

        /// <summary>
        /// conditional expression method
        /// </summary>
        /// <param name="result">int representing user score of correct answers</param>
        /// <param name="lowerBound">enum</param>
        /// <returns>boolean result of conditional expression</returns>
        public static bool IsAnswerCountBelowRange(int result, GradeBorder lowerBound)
        {
            return result <= (int)lowerBound;
        }

        /// <summary>
        /// conditional expression method
        /// </summary>
        /// <param name="result">int representing user score of correct answers</param>
        /// <param name="upperBound">enum</param>
        /// <returns>boolean result of conditional expression</returns>
        public static bool IsAnswerCountRemarkable(int result, GradeBorder upperBound)
        {
            return result >= (int)upperBound;
        }

        /// <summary>
        /// 1. calculates percentage of correct answers based on num of questions
        /// 2. checks which condition is met and displays appropriate message using enums
        /// </summary>
        /// <param name="correctAnswerCount">number of correct answers</param>
        /// <param name="numberOfQuestions">number of asked questions</param>
        public static void ShowGradingResult(int correctAnswerCount, int numberOfQuestions)
        {
            Console.WriteLine($"You had {correctAnswerCount} correct answers out of {numberOfQuestions} questions.");

            double calResult = ((double)correctAnswerCount / numberOfQuestions) * Constant.PERCENTAGE_FACTOR;

            Console.WriteLine($"Procentage: {calResult}%");

            int result = (int)Math.Floor(calResult);

            if (IsAnswerCountBelowRange(result, GradeBorder.BorderFailed))
            {
                Console.WriteLine(QuizGrades.Failed);
                return;
            }
            if (IsAnswerCountRemarkable(result, GradeBorder.BorderAwesome))
            {
                Console.WriteLine(QuizGrades.Awesome);
                return;
            }
            if (IsAnswerCountWithinRange(result, GradeBorder.BorderFailed, GradeBorder.BorderPassed))
            {
                Console.WriteLine(QuizGrades.Passed);
                return;
            }
            if (IsAnswerCountWithinRange(result, GradeBorder.BorderPassed, GradeBorder.BorderNice))
            {
                Console.WriteLine(QuizGrades.Nice);
                return;
            }
            if (IsAnswerCountWithinRange(result, GradeBorder.BorderNice, GradeBorder.BorderSplendid))
            {
                Console.WriteLine(QuizGrades.Splendid);
                return;
            }

        }

        public static void ShowSectionInquiry()
        {
            Console.WriteLine("Lets start with category you would like to modify");
        }

        public static ModifySection GetOptionSelection()
        {
            Console.WriteLine("What would you like to modify:");
            Console.WriteLine("1. Category name");
            Console.WriteLine("2. Category questions");
            Console.WriteLine("3. Question answers");
            Console.WriteLine("4. Exit");
            int optionMenu = int.Parse(Console.ReadLine());
            switch (optionMenu)
            {
                case 1:
                    return ModifySection.Name;
                case 2:
                    return ModifySection.Questions;
                case 3:
                    return ModifySection.Answers;
                case 4:
                    return ModifySection.Exit;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    return GetOptionSelection();
            }
        }

        public static string GetCategoryModifiedName(QuizCategory quizChapter)
        {
            Console.WriteLine($"Whats the new name for {quizChapter.Name} category?");
            string questionNaire = Console.ReadLine();
            return questionNaire;
        }

        public static List<Question> GetModifiedQuestionInput(List<Question> chapterQuestions)
        {
            for (int i = 0; i < chapterQuestions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chapterQuestions[i]}");
            }

            Console.WriteLine("Which question would you like to change?");
            int questionPosition = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Write the new question...");
            chapterQuestions[questionPosition].Inquiry = Console.ReadLine();

            return chapterQuestions;
        }



    }
}
