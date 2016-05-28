using Data;
using Data.Security;
using Domain.Exceptions;
using Domain.Helper;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class UserManager : Business<User>
    {
        public UserManager(IRepository<User> user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }

        public void Create(User user)
        {
            var emptyField = string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password);
            if (emptyField)
                throw new QuestionarException("Preencha os campos obrigatórios!");

            if (Repository.Query().Any(c => c.UserName.ToLower() == user.UserName.ToLower()))
                throw new QuestionarException("Nome de usuário já registrado, por favor informe um nome de usuário válido!");

            if (Repository.Query().Any(c => c.Email.ToLower() == user.Email.ToLower()))
                throw new QuestionarException("E-mail já cadastrado, por favor informe um email válido!");      

            Transaction(()=>
            {
                user.Password = Password.Encrypty(user.Password);
                user.Created = DateTime.Now;
                Repository.Create(user);
            });
        }
    }
}
