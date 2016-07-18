using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;

namespace Domain.Manager
{
    public class SendQuestionManager : Business<UserQuestion>
    {
        public SendQuestionManager(IRepository<UserQuestion> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public void SendQuestions(UserManager userManager, QuestionManager questionManager, CourseManager courseManager, SubscribeManager subscribeManager)
        {
            Transaction(() =>
            {
                var courses = courseManager.EnabledCourses();
                var questions = questionManager.QuestionsByCourse(courses);
                foreach (var question in questions)
                {
                    var users = subscribeManager.UsersByCourse(question.Course);
                    foreach (var user in users)
                    {
                        var userQuestion = new UserQuestion
                        {
                            Question = question,
                            User = user,
                            Created = DateTime.Now
                        };

                        Repository.Create(userQuestion);

                        question.Sent = true;
                        questionManager.Update(question);
                    }
                }
            });
        }
    }
}
