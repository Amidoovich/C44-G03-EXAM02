using Exam.Classes;
using Exam.Classes.Questions;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("please Enter Subject Id :");
            int subjectId;
            bool isParse;
            do
            {
                isParse = int.TryParse(Console.ReadLine(), out subjectId);
                if (!isParse || subjectId <= 0)
                {
                    Console.WriteLine("Invalid input\nPlease enter a valid positive integer for Subject Id:");
                }
            } while (!isParse || subjectId <= 0);

    
            string subjectName = Helper.ReadAndValidateString("please Enter Subject Name :");


            Subject subject = new Subject(subjectId, subjectName);
            Console.Clear();
            subject.TakeExamDetails();


        }
    }
}
