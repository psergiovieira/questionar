using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Security;

namespace Domain.Manager
{
    public class HomeManager
    {
        public dynamic Get(CourseManager courseManager, User teacher, SubscribeManager subscribeManager, AnswerManager answerManager,
            QuestionManager questionManager, UserManager userManager)
        {
            var courses = courseManager.GetAll(teacher);
            var students = new List<User>();
            int correctAnswers = 0;
            int wrongAnswers = 0; 
            foreach (var course in courses)
            {
                students.AddRange(subscribeManager.UsersByCourse(course));
                correctAnswers += answerManager.CorrectAnswersCount(course.Id);
                wrongAnswers += answerManager.WrongAnswersCount(course.Id);
            }

            var hardestQuestion = answerManager.HardestQuestion(courses);
            var easierQuestion = answerManager.EasierQuestion(courses);
            var betterStudent = answerManager.BetterStudent(courses);

            return new
            {
                CoursesCount = courses.Count,
                Subscribers = students.Count,
                CorrectAnswers = correctAnswers,
                WrongAnswers = wrongAnswers,
                HardestQuestion = hardestQuestion != null ? questionManager.Repository.GetById(hardestQuestion.Id).Description : string.Empty,
                EasierQuestion = easierQuestion != null ? questionManager.Repository.GetById(easierQuestion.Id).Description : string.Empty,
                BetterStudent = betterStudent != null ? userManager.Repository.GetById(betterStudent.Id).Name : string.Empty
            };
        }
    }
}
