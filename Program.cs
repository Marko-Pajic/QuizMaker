namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuizQuestionsAndAnswears>FoodAndDrinkTrivia = new List<QuizQuestionsAndAnswears>();

            QuizQuestionsAndAnswears question1 = new QuizQuestionsAndAnswears();

            question1.Question = "What is the common name for dried plums?";
            question1.RightAnswer = "Prunes";
            question1.WrongAnswer1 = "Dates";
            question1.WrongAnswer2 = "Rasins";

            QuizQuestionsAndAnswears question2 = new QuizQuestionsAndAnswears();

            question2.Question = "What’s the primary ingredient in hummus?";
            question2.RightAnswer = "Chickpeas";
            question2.WrongAnswer1 = "Tahini";
            question2.WrongAnswer2 = "Sesame";

            QuizQuestionsAndAnswears question3 = new QuizQuestionsAndAnswears();

            question3.Question = "Which country produces the most coffee in the world?";
            question3.RightAnswer = "Brasil";
            question3.WrongAnswer1 = "Nicaragua";
            question3.WrongAnswer2 = "Colombia";

            QuizQuestionsAndAnswears question4 = new QuizQuestionsAndAnswears();

            question4.Question = "Which European nation was said to invent hot dogs?";
            question4.RightAnswer = "Germany";
            question4.WrongAnswer1 = "Poland";
            question4.WrongAnswer2 = "Italy";

            QuizQuestionsAndAnswears question5 = new QuizQuestionsAndAnswears();

            question5.Question = "Which kind of alcohol is Russia notoriously known for?";
            question5.RightAnswer = "Vodka";
            question5.WrongAnswer1 = "Beer";
            question5.WrongAnswer2 = "Wine";

            FoodAndDrinkTrivia.Add(question1);
            FoodAndDrinkTrivia.Add(question2);
            FoodAndDrinkTrivia.Add(question3);
            FoodAndDrinkTrivia.Add(question4);
            FoodAndDrinkTrivia.Add(question5);
         
            Console.WriteLine(FoodAndDrinkTrivia);
        }
       
    }
}