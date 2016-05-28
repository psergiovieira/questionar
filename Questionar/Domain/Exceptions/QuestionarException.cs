using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Exceptions
{
    public class QuestionarException : Exception
    {
        public QuestionarException(string message)
           : base(message)
        {
            
        }
    }
}