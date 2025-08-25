using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Exam.Classes.Exams;

namespace Exam.Classes
{
    internal class Subject
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }

        private Exams.Exam? SubjectExam;

        #endregion

        #region Constructor

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Methods

        public void TakeExamDetails()
        {
            int choice;
            bool isParse;

            choice = Helper.ReadAndValidateInt("Please Enter the type of Exam (1 for Practical | 2 for Final):", 1, 2);

            Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min)):");
            int time;
            do
            {
                isParse = int.TryParse(Console.ReadLine(), out time);
                if (!isParse || time < 30 || time > 180)
                {
                    Console.WriteLine("Invalid input\nPlease enter a valid time between 30 and 180 minutes:");
                }
            } while (!isParse || time < 30 || time > 180);



            int numberOfQuestions = Helper.ReadAndValidateInt("Please Enter the Number of questions:", 1, 60);


            MakeExam(choice,time,numberOfQuestions);
        }
        public void MakeExam(int choice,int time,int numberOfQuestions)
        {

            switch(choice)
            {
                case 1:
                    SubjectExam = new Practical(time, numberOfQuestions);
                    break;
                case 2:
                    SubjectExam = new Final(time, numberOfQuestions);
                    break;
            }

            Console.Clear();
            SubjectExam?.CreateExam();
            Console.Clear();
            if (IsStartExam('Y'))
            {
                SubjectExam?.AnswerExam();
            }
            else
            {
                Console.WriteLine("Exam Created Successfully");
            }

        }

        public static bool IsStartExam(char input)
        {
            Console.WriteLine("Do you want to Start Exam (Y|N):");
            char startExam;
            bool isParse;
            do
            { 
                isParse = char.TryParse(Console.ReadLine(), out startExam);
                startExam = char.ToUpper(startExam);
                if (!isParse || (startExam != 'Y' && startExam != 'N'))
                {
                    Console.WriteLine("Invalid input\nPlease enter Y to start the exam or N to cancel:");
                }
            } while (!isParse || (startExam != 'Y' && startExam != 'N'));
            Console.Clear();

            return startExam == 'Y';

        }

        public override string ToString()
        {
            return $"Id : {Id}\nName : {Name}\nSubject Exam : {SubjectExam}";
        }

        #endregion

    }
}
