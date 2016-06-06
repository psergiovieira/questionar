using Data;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System;

namespace Domain.Manager
{
    public class CourseManager : Business<Course>
    {
        public CourseManager(IRepository<Course> repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
        }

        public void Create(Course course)
        {
            var emptyField = string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.Description);
            if (emptyField)
                throw new QuestionarException("Preencha os campos obrigatórios!");
            
            Transaction(() =>
            {
                course.Created = DateTime.Now;
                Repository.Create(course);
            });
        }
    }
}
