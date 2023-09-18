using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    class QuizQuestionsAndAnswears
    {
        public string Question;
        List<string> answers;
        //public string RightAnswer;
        //public string WrongAnswer1;
        //public string WrongAnswer2;

        public override string ToString()
        {
            return $"{answers}";
        }
    }
}
