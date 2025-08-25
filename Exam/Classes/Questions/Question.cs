using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Questions
{
    public abstract class Question
    {

        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public Answer? RightAnswer{ get; set; }
        #endregion

        #region Constructor
        protected Question()
        {

        }
        public Question(string? header, string? body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        #endregion

        #region Methods
        protected bool AddAnswer(Answer answer)
        {
            if (answer is not null)
            {
                Answers.Add(answer);
                return true;
            }
            return false;
        }
        public bool IsRightAnswer(Answer answer)
        {
            if(answer is not null)
            {
                return answer.Id == RightAnswer?.Id;
            }
            return false;
        }
        public void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\t {Mark} Mark");
            Console.WriteLine(Body);
            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine();
        }
        protected void SetBody()
        {
         
            Body = Helper.ReadAndValidateString("Please Enter Question Body:");
        }


        protected void SetAndValidateMark()
        {
            Mark = Helper.ReadAndValidateInt("Please Enter Question Mark:", 1, 20);
        }
        public abstract void CreateQuestion();
        protected abstract void SetAndValidateRightAnswer();
        public override string ToString()
        {
            return $"{Header}\tMark{Mark}\n\n{Body}\n\n{string.Join("\n", Answers)}";
        }
        #endregion
    }
}
