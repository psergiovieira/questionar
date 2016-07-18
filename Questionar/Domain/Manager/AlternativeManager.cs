using Data;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

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

        public List<Alternative> GetByQuestions(List<Question> questions)
        {
            var idsQuestions = questions.Select(c => c.Id).ToList();
            return Repository.Query().Where(c => idsQuestions.Contains(c.Question.Id)).ToList();
        }

        public List<Alternative> GetByQuestion(Question question)
        {
            return Repository.Query().Where(c => c.Question.Id == question.Id).ToList();
        }
    }
}
