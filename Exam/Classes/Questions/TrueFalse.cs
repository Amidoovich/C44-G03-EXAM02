using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Questions
{
    public class TrueFalse : Question
    {
        #region Coonstructor
        public TrueFalse(string? header, string? body, int mark) : base(header, body, mark)
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
        }
        public TrueFalse()
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
            Header = "True | False Question";
        }
        #endregion
        #region Methods
        public override void CreateQuestion()
        {
            SetBody();
            SetAndValidateMark();
            SetAndValidateRightAnswer();
            Console.Clear();
        }
        protected override void SetAndValidateRightAnswer()
        {

            int rightAnswerId = Helper.ReadAndValidateInt("Please Enter The Right answer id (1 for True | 2 for False):", 1, 2);
            RightAnswer = Answers[rightAnswerId - 1];
        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
