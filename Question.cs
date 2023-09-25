namespace QuizMaker
{
    class Question
    {
        public string Name;
        public string Questions;
        public List<string> Answers;
        

        //public Questions(string aQuestion, List<string>aAnswers) 
        //{
        //    Question = aQuestion;
        //    List<string> Answers = aAnswers;
        //}
        public override string ToString()
        {
            return $"{Answers}";
        }
    }
}
