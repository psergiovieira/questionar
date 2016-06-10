using Data;
using Domain.Manager;
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
            _manager.Create(course);
            return Ok("Disciplina cadastrada com sucesso!");
        }
    }
}