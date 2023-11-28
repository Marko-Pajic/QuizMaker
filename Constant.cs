namespace QuizMaker
{
    public class Constant
    {
        public const char POSITIVE_ANSWER = 'y';
        public const char NEGATIVE_ANSWER = 'n';
        public const string DIRECTORY_FOLDER = @"xml.files";
    }
    
    public enum QuizState
    {
        Build,
        Play,
        Modify
    }
}
