namespace QuizMaker
{
    public class Question
    {
        public string Inquiry { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public List<string> Answers { get; set; }

        public override string ToString()
        {
            return $"{Answers}";
        }
    }
}
