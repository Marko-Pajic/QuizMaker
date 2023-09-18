namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuizQuestionsAndAnswears>foodAndDrinkTrivia = new List<QuizQuestionsAndAnswears>();

            QuizQuestionsAndAnswears question1 = new QuizQuestionsAndAnswears();

            question1.Question = "What is the common name for dried plums?";
            List<string> answers1 = new List<string>();
            answers1.Add("Prunes");
            answers1.Add("Dates");
            answers1.Add("Rasins");
            
            //question1.RightAnswer = "Prunes";
            //question1.WrongAnswer1 = "Dates";
            //question1.WrongAnswer2 = "Rasins";

            QuizQuestionsAndAnswears question2 = new QuizQuestionsAndAnswears();

            question2.Question = "What’s the primary ingredient in hummus?";
            List<string> answers2 = new List<string>();
            answers2.Add("Chickpeas");
            answers2.Add("Tahini");
            answers2.Add("Sesame");

            //question2.RightAnswer = "Chickpeas";
            //question2.WrongAnswer1 = "Tahini";
            //question2.WrongAnswer2 = "Sesame";

            QuizQuestionsAndAnswears question3 = new QuizQuestionsAndAnswears();

            question3.Question = "Which country produces the most coffee in the world?";
            List<string> answers3 = new List<string>();
            answers3.Add("Brasil");
            answers3.Add("Nicaragua");
            answers3.Add("Colombia");

            //question3.RightAnswer = "Brasil";
            //question3.WrongAnswer1 = "Nicaragua";
            //question3.WrongAnswer2 = "Colombia";

            QuizQuestionsAndAnswears question4 = new QuizQuestionsAndAnswears();

            question4.Question = "Which European nation was said to invent hot dogs?";
            List<string> answers4 = new List<string>();
            answers4.Add("Germany");
            answers4.Add("Poland");
            answers4.Add("Italy");

            //question4.RightAnswer = "Germany";
            //question4.WrongAnswer1 = "Poland";
            //question4.WrongAnswer2 = "Italy";

            QuizQuestionsAndAnswears question5 = new QuizQuestionsAndAnswears();

            question5.Question = "Which kind of alcohol is Russia notoriously known for?";
            List<string> answers5 = new List<string>();
            answers5.Add("Vodka");
            answers5.Add("Beer");
            answers5.Add("Wine");

            //question5.RightAnswer = "Vodka";
            //question5.WrongAnswer1 = "Beer";
            //question5.WrongAnswer2 = "Wine";

            foodAndDrinkTrivia.Add(question1);
            foodAndDrinkTrivia.Add(question2);
            foodAndDrinkTrivia.Add(question3);
            foodAndDrinkTrivia.Add(question4);
            foodAndDrinkTrivia.Add(question5);

            Console.WriteLine(answers1);
        }
       
    }
}