using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Security;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;

namespace Domain.Manager
{
    public class AnswerManager : Business<Answer>
    {
        public AnswerManager(IRepository<Answer> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public bool Reply(int idAlternative, User student, AlternativeManager alternativeManager, SendQuestionManager sendQuestionManager)
        {
            var alternative = alternativeManager.Repository.GetById(idAlternative);
            if (alternative == null)
                throw new QuestionarException("Alternativa inválida");

            Transaction(() =>
            {
                var answer = new Answer()
                {
                    Alternative = alternative,
                    Student = student,
                    Created = DateTime.Now
                };

                Repository.Create(answer);
                sendQuestionManager.AnswerQuestion(student, alternative.Question);
            });

            return alternative.IsCorrect;
        }
    }
}
