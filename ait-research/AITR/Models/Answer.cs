using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerContent { get; set; }
        public int QuestionID { get; set; }
        public int QuestionOptionID { get; set; }
    }
}