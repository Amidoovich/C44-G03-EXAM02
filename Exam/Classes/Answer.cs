using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes
{
    public class Answer
    {
        #region Properties
        public int Id { get; set; }
        public string? AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int id, string? answerText)
        {
            Id = id;
            AnswerText = answerText;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Id}.{AnswerText}";
        }
        #endregion
    }
}
