using Data;
using Data.Security;
using Domain.Exceptions;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

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

            if (!course.Teacher.IsTeacher)
                throw new QuestionarException("Apenas professores podem cadastrar disciplinas!");
            Transaction(() =>
            {
                course.Created = DateTime.Now;
                Repository.Create(course);
            });
        }

        public List<Course> GetAll(User user)
        {
            return Repository.Query().Where(c => c.Teacher.Id == user.Id).ToList();
        }

        public Course GetById(int id)
        {
            return Repository.GetById(id);
        }

        public List<Course> GetByNameOrTeacher(string nameOrTeacher)
        {
            var query = Repository.Query();           
            return query.Where(c => c.Name.ToLower().Contains(nameOrTeacher.ToLower()) || c.Teacher.Name.ToLower().Contains(nameOrTeacher.ToLower())).ToList();
        }
    }
}
