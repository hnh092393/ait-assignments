using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionType { get; set; }
        public int? NextQuestionID { get; set; }
    }
}