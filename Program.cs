﻿using System.Xml.Serialization;
using QuizMaker.Enumerations;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UI.ShowIntroAndQuizRules();

            while (true)
            {

                QuizState state = FileUtils.GetMenuOption();

                switch (state)
                {

                    case QuizState.Build:

                        bool createNewCategory = false;

                        do
                        {
                            QuizCategory quizCategory = new QuizCategory();

                            quizCategory.Name = UI.GetCategoryName();

                            List<Question> questions = new List<Question>();

                            bool createNewQuestions = false;

                            do
                            {
                                Question question = new Question();

                                question.Inquiry = UI.GetQuestionInput();

                                int numOfAnswers = UI.GetNumOfAnswers();

                                List<string> answers = UI.GetDecoyAnswers(numOfAnswers);

                                string correctAnswer = UI.GetCorrectAnswer();

                                answers.Add(correctAnswer);

                                answers = Logic.GetIndexShuffle(answers);

                                question.Answers = answers;

                                question.CorrectAnswerIndex = answers.IndexOf(correctAnswer);

                                questions.Add(question);

                                createNewQuestions = UI.GetNewQuestion();

                            } while (createNewQuestions);

                            quizCategory.Questions = questions;

                            createNewCategory = UI.GetNewCategory();

                            FileUtils.SerializeCategoryToFile(quizCategory);

                        } while (createNewCategory);

                        break;


                    case QuizState.Play:

                        QuizCategory quizSection = new QuizCategory();

                        List<Question> sectionQuestions = new List<Question>();

                        UI.ShowCategoryInquiry();

                        string[] fileEntires = FileUtils.GetCategorySelection();

                        string fileToPlay = UI.GetSelectedFileName(fileEntires);

                        quizSection = FileUtils.DeserializeFileToCategory(fileToPlay);

                        sectionQuestions = quizSection.Questions;

                        int correctAnswerCount = Logic.GetSumOfCorrectAnswer(sectionQuestions);

                        int numberOfQuestions = sectionQuestions.Count;

                        UI.ShowGradingResult(correctAnswerCount, numberOfQuestions);

                        break;


                    case QuizState.Modify:

                        QuizCategory quizChapter = new QuizCategory();

                        UI.ShowSectionInquiry();

                        string[] categoryNames = FileUtils.GetCategorySelection();

                        string fileToModify = UI.GetSelectedFileName(categoryNames);

                        quizChapter = FileUtils.DeserializeFileToCategory(fileToModify);

                        List<Question> chapterQuestions = new List<Question>();

                        chapterQuestions = quizChapter.Questions;

                        //Console.WriteLine("What would you like to modify:");

                        break;
                }
            }
        }

    }

}
