using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Questions
{
    public class MCQ : Question
    {
        #region Coonstructor
        public MCQ(string? header, string? body, int mark) : base(header, body, mark)
        {
            
        }

        public MCQ()
        {
            Header = "MCQ Question";
        }

        #endregion

        #region Methods


        public override void CreateQuestion()
        {
            Console.WriteLine(Header);
            SetBody();
            SetAndValidateMark();
            SetChoices();
            SetAndValidateRightAnswer();
            Console.Clear();
        }

        private void SetChoices()
        {
            Console.WriteLine("Choices of Question:");
            for (int i = 1; i <= 3; i++)
            {

                string choice = Helper.ReadAndValidateString($"please Enter Choice {i}:");

                Answers.Add(new Answer(i, choice));
            }
        }

        protected override void SetAndValidateRightAnswer()
        {
            int rightAnswerId = Helper.ReadAndValidateInt($"Please Enter The Right answer id (1-{Answers.Count}):", 1, Answers.Count);
            RightAnswer = Answers[rightAnswerId - 1];
        }


        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
