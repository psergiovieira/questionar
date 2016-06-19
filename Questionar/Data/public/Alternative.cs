
using Data.Security;
using System;

namespace Data
{
    public class Alternative : Infraestructure.Types.IIdentity
    {
        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual Question Question
        {
            get { return _question; }
            set { _question = value; }
        }
        private Question _question;


        private string _description;
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual bool IsCorrect { get; set; }
    }
}
