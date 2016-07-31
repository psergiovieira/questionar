using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Security;
using Domain.Exceptions;
using Domain.Models;
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

        public int CorrectAnswersCount(int idCourse)
        {
            return
                Repository.Query()
                    .Count(c => c.Alternative.Question.Course.Id == idCourse && c.Alternative.IsCorrect);
        }

        public int WrongAnswersCount(int idCourse)
        {
            return
                Repository.Query()
                    .Count(c => c.Alternative.Question.Course.Id == idCourse && !c.Alternative.IsCorrect);
        }

        public MGroup HardestQuestion(List<Course> courses)
        {
            var idsCourses = courses.Select(c => c.Id).ToList();
            return Repository.Query().Where(c => idsCourses.Contains(c.Alternative.Question.Course.Id) && !c.Alternative.IsCorrect)
                                                .GroupBy(c => c.Alternative.Question.Id, c => c.Id)
                                                .Select(c => new MGroup { Id = c.Key, Count = c.Count() })
                                                .OrderByDescending(c => c.Count)
                                                .FirstOrDefault();
        }

        public MGroup EasierQuestion(List<Course> courses)
        {
            var idsCourses = courses.Select(c => c.Id).ToList();
            return Repository.Query().Where(c => idsCourses.Contains(c.Alternative.Question.Course.Id) && c.Alternative.IsCorrect)
                                                .GroupBy(c => c.Alternative.Question.Id, c => c.Id)
                                                .Select(c => new MGroup { Id = c.Key, Count = c.Count() })
                                                .OrderByDescending(c=>c.Count)
                                                .FirstOrDefault();
        }

        public MGroup BetterStudent(List<Course> courses)
        {
            var idsCourses = courses.Select(c => c.Id).ToList();
            return Repository.Query().Where(c => idsCourses.Contains(c.Alternative.Question.Course.Id) && c.Alternative.IsCorrect)
                                                .GroupBy(c => c.Student.Id, c => c.Id)
                                                .Select(c => new MGroup { Id = c.Key, Count = c.Count() })
                                                .OrderByDescending(c => c.Count)
                                                .FirstOrDefault();
        }
    }
}
