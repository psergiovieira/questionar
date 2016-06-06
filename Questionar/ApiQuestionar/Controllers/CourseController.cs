using Data;
using Domain.Manager;

namespace ApiQuestionar.Controllers
{
    public class CourseController : BaseController<Course>
    {
        public CourseManager _manager;

        public CourseController()
        {
            _manager = new CourseManager(Repository, UnitOfWork);
        }
    }
}