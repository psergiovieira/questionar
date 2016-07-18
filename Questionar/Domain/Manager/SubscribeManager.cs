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
    public class SubscribeManager : Business<Subscription>
    {
        public SubscribeManager(IRepository<Subscription> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public void Subscribe(User user, Course course)
        {
            if (user.IsTeacher)
                throw new QuestionarException("Apenas alunos podem se cadastrar em disciplinas.");
            if (!user.Active)
                throw new QuestionarException("Usuários inativos não podem se cadastrar.");

            if (Repository.Query().Any(c => c.Student.Id == user.Id && c.Course.Id == course.Id))
                throw new QuestionarException("Usuário já inscrito nesta disciplina.");
            Transaction(() =>
            {
                var subscription = new Subscription
                {
                    Course = course,
                    Entered = DateTime.Now,
                    Student = user
                };

                Repository.Create(subscription);
            });
        }

        public List<User> UsersByCourse(Course course)
        {
            return Repository.Query().Where(c => c.Course.Id == course.Id && c.Student.Active).Select(c => c.Student).ToList();
        }
    }
}
