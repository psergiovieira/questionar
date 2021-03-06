﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Security;
using Domain.Models;
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
                var questions = questionManager.FirstQuestionsByCourse(courses);
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
                    }

                    question.Sent = true;
                    question.SentDate = DateTime.Now;
                    questionManager.Update(question);
                }
            });
        }

        public void SendQuestion(User user, Course course, QuestionManager questionManager)
        {
            var question = questionManager.Repository.Query().FirstOrDefault(c => c.Course.Id == course.Id && c.SentDate.Date == DateTime.Now.Date && c.Sent);
            if (question != null)
            {
                var userQuestion = new UserQuestion
                {
                    Question = question,
                    User = user,
                    Created = DateTime.Now
                };

                Repository.Create(userQuestion);
            }

        }

        public void SendQuestion(User user, Course course, Question question)
        {
            if (question != null)
            {
                var userQuestion = new UserQuestion
                {
                    Question = question,
                    User = user,
                    Created = DateTime.Now
                };

                Repository.Create(userQuestion);
            }
        }

        public MQuestion DailyQuestion(User user, AlternativeManager alternativeManager)
        {
            var question = Repository.Query()
                .Where(c => c.User.Id == user.Id && c.Question.SentDate.Date == DateTime.Now.Date && !c.Answered)
                .Select(c => c.Question).FirstOrDefault();

            if (question != null)
                return new MQuestion()
                {
                    Course = question.Course,
                    Description = question.Description,
                    Alternatives = alternativeManager.GetByQuestion(question)
                };

            return null;
        }

        public void AnswerQuestion(User user, Question question)
        {
            var questionDay = Repository.Query().FirstOrDefault(c => c.Question.Id == question.Id && c.User.Id == user.Id);
            questionDay.Answered = true;
            Repository.Update(questionDay);
        }
    }
}
