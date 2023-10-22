namespace QuizMaker
{
    class QuestionContainer
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Question> _questions;

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        //public override string ToString()
        //{
        //    return $"{Questions}";
        //}
    }
}
