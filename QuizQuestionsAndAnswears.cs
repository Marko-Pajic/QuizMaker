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
        public string RightAnswer;
        public string WrongAnswer1;
        public string WrongAnswer2;

        public override string ToString()
        {
            return $"{Question} {RightAnswer} {WrongAnswer1} {WrongAnswer2}";
        }
    }
}
