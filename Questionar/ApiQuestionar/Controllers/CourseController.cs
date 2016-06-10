﻿using ApiQuestionar.Auxiliary;
using Data;
using Domain.Manager;
using System.Linq;
using System.Web.Http;

namespace ApiQuestionar.Controllers
{
    public class CourseController : BaseController<Course>
    {
        public CourseManager _manager;

        public CourseController()
        {
            _manager = new CourseManager(Repository, UnitOfWork);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(Course course)
        {
            course.Teacher = this.GetUser();
            _manager.Create(course);
            return Ok("Disciplina cadastrada com sucesso!");
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var user = this.GetUser();
            var result  =_manager.GetAll(user).Select(c=> new
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var course = _manager.GetById(id);
            var result = new
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            };

            return Ok(result);
        }
    }
}