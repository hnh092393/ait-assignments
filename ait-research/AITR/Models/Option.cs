using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR.Models
{
    public class Option
    {
        public int OptionID { get; set; }
        public int QuestionID { get; set; }
        public string OptionContent { get; set; }
        public int? NextQuestionID { get; set; }
    }
}