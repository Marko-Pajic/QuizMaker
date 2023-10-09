namespace QuizMaker
{
    class Question
    {
        private string _inquiry;

        public string Inquiry
        {
            get { return _inquiry; }
            set { _inquiry = value; }
        }

        private List<string> _answers;

        public List<string> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public override string ToString()
        {
            return $"{Answers}";
        }
    }
}
