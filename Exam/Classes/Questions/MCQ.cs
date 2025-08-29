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
                Answer answer;

                do
                {
                    
                    string choice = Helper.ReadAndValidateString($"please Enter Choice {i}:");
                    answer = new Answer(i, choice);
                    if (IsAnswerIsExist(answer))
                        Console.WriteLine("please Enter New Choice");

                } while (IsAnswerIsExist(answer));

                

                Answers.Add(answer);
            }
        }

        protected override void SetAndValidateRightAnswer()
        {
            int rightAnswerId = Helper.ReadAndValidateInt($"Please Enter The Right answer id (1-{Answers.Count}):", 1, Answers.Count);
            RightAnswer = Answers[rightAnswerId - 1];
        }

        private bool IsAnswerIsExist(Answer answer)
        {
            if(answer?.AnswerText?.Length > 0)
            {
                for (int i = 0; i < Answers.Count; i++)
                {
                    if (Answers[i].AnswerText == answer.AnswerText)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
