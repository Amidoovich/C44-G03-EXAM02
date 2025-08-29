using Exam.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Exams
{
    public class Final : Exam
    {
        #region Constructor
        public Final(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {

        } 
        #endregion

        #region Methods


        public override void CreateExam()
        {

            for (int i = 0; i < NumberOfQuestions; i++) 
            {
                Question question;

                int choice = Helper.ReadAndValidateInt("Please Enter The type of Question (1 for MCQ | 2 For True | False):", 1, 2);

                if (choice == 1)
                    question = new MCQ();
                else
                    question = new TrueFalse();

                question.CreateQuestion();
         
                AddQuestion(question);
            }


        }
        #endregion
    }
}
