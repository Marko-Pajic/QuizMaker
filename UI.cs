using QuizMaker.Enumerations;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

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
            Console.WriteLine("4. Exit QuizMaker");
            if (int.TryParse(Console.ReadLine(), out int optionMenu))
            {
                switch (optionMenu)
                {
                    case 1:
                        return QuizState.Build;
                    case 2:
                        return QuizState.Play;
                    case 3:
                        return QuizState.Modify;
                    case 4:
                        return QuizState.Exit;
                }
            }
            ShowWrongInputMessage();
            return GetOptionPreferences();
        }

        public static void ShowWrongInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
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
            if (int.TryParse(Console.ReadLine(), out int numOfAnswers))
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

            int numOfChosenCategory;
            if (int.TryParse(Console.ReadLine(), out numOfChosenCategory) && numOfChosenCategory >= 1 && numOfChosenCategory <= fileEntries.Length)
            {
                string fileToPlay = fileEntries[numOfChosenCategory - 1];
                return fileToPlay;
            }
            else
            {
                Console.WriteLine("Incorrect input.");
                return GetSelectedFileName(fileEntries);
            }
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
            if (int.TryParse(Console.ReadLine(), out int givenAnswer))
            {
                return givenAnswer - 1;
            }
            else
            {
                Console.WriteLine("Incorrect input!");
                return GetAnswerPosition();
            }
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

            if (int.TryParse(Console.ReadLine(), out int optionMenu))
            {
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
                }
            }
            ShowWrongInputMessage();
            return GetOptionSelection();
        }

        public static string GetCategoryModifiedName(QuizCategory quizChapter)
        {
            Console.WriteLine($"Whats the new name for {quizChapter.Name} category?");
            string questionNaire = Console.ReadLine();
            return questionNaire;
        }

        public static int GetQuestionIndex(List<Question> chapterQuestions)
        {
            Console.WriteLine("Questions:");

            for (int qn = 0; qn < chapterQuestions.Count; qn++)
            {
                Console.WriteLine($"{qn + 1}. {chapterQuestions[qn]}");
            }

            Console.WriteLine("Which question would you like to change?");

            bool positionNotRetrived = true;

            int questionPosition = 0;

            while (positionNotRetrived)
            {
                if (int.TryParse(Console.ReadLine(), out questionPosition))
                {
                    questionPosition -= 1;
                    if (questionPosition >= 0 && questionPosition < chapterQuestions.Count)
                    {
                        positionNotRetrived = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid question number.");
                        Console.WriteLine("Please enter the number standing before desired question.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            return questionPosition;
        }

        public static bool IsQuestionModified(int questionPosition, List<Question> chapterQuestions)
        {
            bool modified = false;
            Console.WriteLine("Write the new question...");
            string response = Console.ReadLine();

            if (response != chapterQuestions[questionPosition].Inquiry)
            {
                modified = true;
                chapterQuestions[questionPosition].Inquiry = response;
            }

            return modified;
        }


        public static int GetQuestionPositionIndex(List<Question> chapterQuestions)
        {
            Console.WriteLine("Questions:");

            for (int qn = 0; qn < chapterQuestions.Count; qn++)
            {
                Console.WriteLine($"{qn + 1}. {chapterQuestions[qn]}");
            }

            Console.WriteLine("Answers to which question would you like to change?");

            bool positionNotRetrived = true;

            int questionPosition = 0;

            while (positionNotRetrived)
            {
                if (int.TryParse(Console.ReadLine(), out questionPosition))
                {
                    questionPosition -= 1;
                    if (questionPosition >= 0 && questionPosition < chapterQuestions.Count)
                    {
                        positionNotRetrived = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid question number.");
                        Console.WriteLine("Please enter the number standing before desired question.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            return questionPosition;
        }

        public static List<string> GetAnswerList(List<Question> chapterQuestions, int questionPosition)
        {
            List<string> answers = new List<string>();
            answers = chapterQuestions[questionPosition].Answers;

            Console.WriteLine("Answers:");
            for (int ans = 0; ans < answers.Count; ans++)
            {
                Console.WriteLine($"{ans + 1}. {answers[ans]}");
            }

            int correctAnswerIndex = chapterQuestions[questionPosition].CorrectAnswerIndex;
            Console.WriteLine($"{answers[correctAnswerIndex]} is a current correct answer!");

            return answers;
        }

        public static int GetAnswerIndex(List<string> answers)
        {

            Console.WriteLine("Which answer would you like to change?");

            bool positionNotRetrived = true;

            int answerPosition = 0;

            while (positionNotRetrived)
            {
                if (int.TryParse(Console.ReadLine(), out answerPosition))
                {
                    answerPosition -= 1;
                    if (answerPosition >= 0 && answerPosition < answers.Count)
                    {
                        positionNotRetrived = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer number.");
                        Console.WriteLine("Please enter the number standing before desired answer.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            return answerPosition;
        }

        public static bool IsAnswerModified(int answerPosition, List<string> answers)
        {
            bool modified = false;
            Console.WriteLine("Write the new question...");
            string response = Console.ReadLine();

            if (response != answers[answerPosition])
            {
                modified = true;
                answers[answerPosition] = response;
            }

            return modified;
        }
        //public static List<string> GetCurrentAnswerList(List<Question> chapterQuestions)
        //{
        //    for (int qn = 0; qn < chapterQuestions.Count; qn++)
        //    {
        //        Console.WriteLine($"{qn + 1}. {chapterQuestions[qn]}");
        //    }
        //    Console.WriteLine("Answers to which question would you like to change?");

        //    if (int.TryParse(Console.ReadLine(), out int questionPosition))
        //    {
        //        List<string> answers = new List<string>();
        //        questionPosition -= 1;
        //        answers = chapterQuestions[questionPosition].Answers;

        //        for (int ans = 0; ans < answers.Count; ans++)
        //        {
        //            Console.WriteLine($"{ans + 1}. {answers[ans]}");
        //        }

        //        int correctAnswerIndex = chapterQuestions[questionPosition].CorrectAnswerIndex;
        //        Console.WriteLine($"{answers[correctAnswerIndex]} is a current correct answer!");

        //        return answers;
        //    }
        //    else
        //    {
        //        Console.WriteLine();
        //        return GetCurrentAnswerList(chapterQuestions);
        //    }
        //}
        //public static bool IsAnswerModified(List<string> answers)
        //{
        //    bool modified = false;
        //    Console.WriteLine("Which answer would you like to change?");
        //    if (int.TryParse(Console.ReadLine(), out int answerPosition))
        //    {
        //        Console.WriteLine("Write the new answer...");
        //        string response = Console.ReadLine();
        //        answerPosition -= 1;

        //        if (response != answers[answerPosition])
        //        {
        //            modified = true;
        //            answers[answerPosition] = response;
        //        }

        //        return modified;

        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid input. Please enter a number.");
        //        return IsAnswerModified(answers);
        //    }
    }

    //public static bool IsAnswerModified(List<Question> chapterQuestions)
    //{
    //    for (int qn = 0; qn < chapterQuestions.Count; qn++)
    //    {
    //        Console.WriteLine($"{qn + 1}. {chapterQuestions[qn]}");
    //    }
    //    Console.WriteLine("Answers to which question would you like to change?");

    //    List<string> answers = new List<string>();

    //    while (int.TryParse(Console.ReadLine(), out int questionPosition))
    //    {
    //        if (questionPosition >= 0 && questionPosition < chapterQuestions.Count)
    //        {
    //            questionPosition -= 1;
    //            answers = chapterQuestions[questionPosition].Answers;

    //            for (int ans = 0; ans < answers.Count; ans++)
    //            {
    //                Console.WriteLine($"{ans + 1}. {answers[ans]}");
    //            }

    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid question number.");
    //            Console.WriteLine("Please enter the number standing before desired question.");
    //            continue;
    //        }

    //        int correctAnswerIndex = chapterQuestions[questionPosition].CorrectAnswerIndex;
    //        Console.WriteLine($"{answers[correctAnswerIndex]} is a current correct answer!");


    //        bool modified = false;
    //        Console.WriteLine("Which answer would you like to change?");
    //        while (!modified)
    //        {
    //            while (int.TryParse(Console.ReadLine(), out int answerPosition))
    //            {
    //                if (answerPosition >= 0 && answerPosition < answers.Count)
    //                {
    //                    Console.WriteLine("Write the new answer...");
    //                    string response = Console.ReadLine();
    //                    answerPosition -= 1;

    //                    if (response != answers[answerPosition])
    //                    {
    //                        modified = true;
    //                        answers[answerPosition] = response;
    //                    }

    //                    return modified;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Invalid question number.");
    //                    Console.WriteLine("Please enter the number standing before desired question.");
    //                }
    //            }

    //            Console.WriteLine("Invalid input. Please enter a number.");
    //        }
    //    }

    //    Console.WriteLine("Invalid input. Please enter a number.");
    //    return IsAnswerModified(chapterQuestions);

    //}

    ////public static bool IsAnswerModified(List<string> answers)
    ////{
    ////}
}
