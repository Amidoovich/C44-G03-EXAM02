using Exam.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Exams
{
    public class Practical : Exam
    {
        #region Constructor
        public Practical(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        #endregion

            #region Methods

        public override void CreateExam()
        {

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Question question;
                question = new MCQ();
                question.CreateQuestion();
                AddQuestion(question);
            }
        }

        #endregion
    }
}
