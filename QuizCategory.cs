﻿namespace QuizMaker
{
    public class QuizCategory
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        //public override string ToString()
        //{
        //    return $"{Questions}";
        //}
    }
}
