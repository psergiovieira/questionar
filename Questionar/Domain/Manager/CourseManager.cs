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
            var emptyField = string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.Description) || course.Teacher == null;
            if (emptyField)
                throw new QuestionarException("Preencha os campos obrigatórios!");

            if(!course.Teacher.IsTeacher)
                throw new QuestionarException("Apenas professores podem cadastrar disciplinas!");
            Transaction(() =>
            {
                course.Created = DateTime.Now;
                Repository.Create(course);
            });
        }

        //public List<Course> GetAll()
        //{
        //    Repository.Query(c=>c.)
        //}
    }
}
