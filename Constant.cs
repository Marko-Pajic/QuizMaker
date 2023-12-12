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

    public enum GradeBorder
    {
        LowerBorderPassed = 50,
        UpperBorderPassed = 60,
        UpperBorderNice = 70,
        UpperBorderSplendid = 80,
        LowerBorderAwesome = 90
    }

    public enum QuizGrades
    {
        Failed,
        Passed,
        Nice,
        Splendid,
        Awesome
    }
}
