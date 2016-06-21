using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Business;
using Data;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.UnitOfWork;

namespace Domain.Manager
{
    public class AlternativeManager : Business<Alternative>
    {
        public AlternativeManager(IRepository<Alternative> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public void Create(Alternative alternative)
        {
            Repository.Create(alternative);
        }

        public void Create(List<Alternative> alternatives, Question question)
        {
            if(alternatives.Count(c=>c.IsCorrect) > 1)
                throw new QuestionarException("Apenas uma das alternativas deve estar marcada como correta.");

            if (alternatives.All(c => !c.IsCorrect))
                throw new QuestionarException("Marque a alternativa correta.");

            if(alternatives.Any(c =>string.IsNullOrEmpty(c.Description)))
                throw new QuestionarException("Descrição é um campo obrigatório.");

            foreach (var alternative in alternatives)
            {
                alternative.Question = question;
                Repository.Create(alternative);
            }
        }
    }
}
