using Exam.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes.Exams
{
    public abstract class Exam
    {
        #region Properties
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> QuestionsList { get; set; } = new List<Question>();
        #endregion

        #region Constructor
        protected Exam(int time,int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }
        #endregion

        #region Methods
        public bool AddQuestion(Question question)
        {
            if(question is not null)
            {
                QuestionsList.Add(question);
                return true;
            }
            return false;
        }
        public abstract void CreateExam();
        public void AnswerExam()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                QuestionsList[i].DisplayQuestion();
                int answerId =  Helper.ReadAndValidateInt($"Please Enter The answer Id (1-{QuestionsList[i].Answers.Count}):", 1, QuestionsList[i].Answers.Count);
                answers.Add(QuestionsList[i].Answers[answerId - 1]);
            }

            sw.Stop();
            Console.Clear();
            CalculateMarkAndTime(answers, sw);
        }

        public void CalculateMarkAndTime(List<Answer> answers, Stopwatch sw)
        {
            int userGrades = 0;
            int totalMark = 0;
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                totalMark += QuestionsList[i].Mark;
                if (QuestionsList[i].IsRightAnswer(answers[i]))
                {
                    userGrades += QuestionsList[i].Mark;
                }
                Console.WriteLine($"Question {i + 1} : {QuestionsList[i].Body}");
                Console.WriteLine($"Your Answer => {answers[i]}");
                Console.WriteLine($"Right Answer => {QuestionsList[i].RightAnswer}");
            }
            Console.WriteLine($"Your Grade is {userGrades} from {totalMark}");
            Console.WriteLine($"Time = {sw.Elapsed}");
            Console.WriteLine("Thank You");
        }




        public override string ToString()
        {
            return $"Time : {Time}\nNumber Of Questions : {NumberOfQuestions}\nQuestions List : {string.Join("\n", QuestionsList)}";
        }
        #endregion



    }
}
