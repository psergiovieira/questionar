using Data.Security;
using Domain.Exceptions;
using Domain.Helper;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System;
using System.Linq;

namespace Domain.Manager
{
    public class UserManager : Business<User>
    {
        private string requiredField = "{0} já registrado, por favor informe um {0} válido!";

        public UserManager(IRepository<User> user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }

        public void Create(User user)
        {
            var emptyField = string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password);
            if (emptyField)
                throw new QuestionarException("Preencha os campos obrigatórios!");

            if (Repository.Query().Any(c => c.Active && c.UserName.ToLower() == user.UserName.ToLower()))
                throw new QuestionarException(String.Format(requiredField,"Nome de usuário"));

            if (Repository.Query().Any(c => c.Active && c.Email.ToLower() == user.Email.ToLower()))
                throw new QuestionarException(String.Format(requiredField, "E-mail"));     
 

            Transaction(()=>
            {
                user.Password = Password.Encrypty(user.Password);
                user.Created = DateTime.Now;
                user.Active = true;
                Repository.Create(user);
            });
        }
    }
}
