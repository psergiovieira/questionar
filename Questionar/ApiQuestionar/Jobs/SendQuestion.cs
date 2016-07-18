using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Security;
using Domain.Manager;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Quartz;

namespace ApiQuestionar.Jobs
{
    public class SendQuestion : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var unitOfWork = new NhibernateUnitOfWork();
            var userManager = new UserManager(new NHibernateRepository<User>(unitOfWork), unitOfWork);
            var questionManager = new QuestionManager(new NHibernateRepository<Question>(unitOfWork), unitOfWork);
            var coursemanager = new CourseManager(new NHibernateRepository<Course>(unitOfWork), unitOfWork);
            var subscriptionManager = new SubscribeManager(new NHibernateRepository<Subscription>(unitOfWork), unitOfWork);
            var sendQuestionManager = new SendQuestionManager(new NHibernateRepository<UserQuestion>(unitOfWork), unitOfWork);
            
            sendQuestionManager.SendQuestions(userManager, questionManager, coursemanager, subscriptionManager);
        }
    }
}