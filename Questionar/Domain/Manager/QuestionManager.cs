using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;

namespace Domain.Manager
{
    public class QuestionManager : Business<Question>
    {
        public QuestionManager(IRepository<Question> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public void Create(AlternativeManager alternativeManager, Question question, Course course, List<Alternative> alternatives)
        {
            Transaction(() =>
            {
                if (course == null)
                    throw new QuestionarException("O curso selecionado é inválido.");

                if (string.IsNullOrEmpty(question.Description))
                    throw new QuestionarException("Descrição é um campo obrigatório.");

                question.Course = course;
                Repository.Create(question);
                alternativeManager.Create(alternatives, question);
            });
        }
    }
}
