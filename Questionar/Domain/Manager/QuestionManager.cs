using System;
using Data;
using Data.Security;
using Domain.Exceptions;
using Domain.Models;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Manager
{
    public class QuestionManager : Business<Question>
    {
        public QuestionManager(IRepository<Question> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public void Create(AlternativeManager alternativeManager, SendQuestionManager sendQuestionManager, SubscribeManager subscribeManager, Question question, Course course, List<Alternative> alternatives)
        {
            Transaction(() =>
            {
                if (course == null)
                    throw new QuestionarException("O curso selecionado é inválido.");

                if (string.IsNullOrEmpty(question.Description))
                    throw new QuestionarException("Descrição é um campo obrigatório.");

                question.Course = course;
                question.Order = Order(question);
                Repository.Create(question);
                alternativeManager.Create(alternatives, question);

                var isTheFirst = !Repository.Query().Any(c => c.Id != question.Id && c.Course.Id == course.Id);
                if (isTheFirst)
                {
                    SendFirstQuestion(subscribeManager, sendQuestionManager, course, question);
                    question.Sent = true;
                    question.SentDate = DateTime.Now;
                }
            });
        }

        public void SendFirstQuestion(SubscribeManager subscribeManager, SendQuestionManager sendQuestionManager, Course course, Question question)
        {
            var users = subscribeManager.UsersByCourse(course);
            users.ForEach(user =>
            {
                sendQuestionManager.SendQuestion(user, course, question);
            });
        }

        public int Order(Question question)
        {
            var firstOrDefault = Repository.Query()
                .Where(c => c.Course.Id == question.Course.Id)
                .OrderBy(c => c.Order)
                .FirstOrDefault();
            if (firstOrDefault != null)
                return firstOrDefault
                        .Order + 1;
            return 1;
        }

        public List<MQuestion> ListByTeacher(AlternativeManager alternativeManager, User teacher)
        {
            var questions = Repository.Query().Where(c => c.Course.Teacher.Id == teacher.Id).OrderByDescending(c => c.Id).ToList();
            var alternatives = alternativeManager.GetByQuestions(questions);

            return GroupAlternatives(questions, alternatives);
        }

        public List<MQuestion> GroupAlternatives(List<Question> questions, List<Alternative> alternatives)
        {
            return questions.Select(c => new MQuestion()
            {
                Course = c.Course,
                Description = c.Description,
                Alternatives = alternatives.Where(a => a.Question.Id == c.Id).ToList(),
                SentDate = c.SentDate,
                Sent = c.Sent
            }).ToList();
        }

        internal List<Data.Question> FirstQuestionsByCourse(List<Course> courses)
        {
            var questions = new List<Question>();
            foreach (var course in courses)
            {
                var question = FirstToSendByCourse(course);
                if (question != null)
                    questions.Add(question);
            }

            return questions;
        }

        private Question FirstToSendByCourse(Course course)
        {
            return Repository.Query().Where(c => !c.Sent && c.Course.Id == course.Id).OrderBy(c => c.Order).FirstOrDefault();
        }

        public void Update(Question question)
        {
            Repository.Update(question);
        }
    }
}
