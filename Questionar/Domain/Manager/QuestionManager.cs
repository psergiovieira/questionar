using Data;
using Data.Security;
using Domain.Exceptions;
using Domain.Models;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

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

        public List<MQuestion> ListByTeacher(AlternativeManager alternativeManager, User teacher)
        {
            var questions = Repository.Query().Where(c => c.Course.Teacher.Id == teacher.Id).OrderByDescending(c=>c.Id).ToList();
            var alternatives = alternativeManager.GetByQuestions(questions);

            return GroupAlternatives(questions, alternatives);
        }

        public List<MQuestion> GroupAlternatives(List<Question> questions, List<Alternative> alternatives)
        {
            return questions.Select(c => new MQuestion()
            {
                Course = c.Course,
                Description = c.Description,
                Alternatives = alternatives.Where(a => a.Question.Id == c.Id).ToList()
            }).ToList();
        }
    }
}
