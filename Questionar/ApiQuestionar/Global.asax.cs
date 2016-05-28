using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Net.Http;
using Domain.Exceptions;

namespace ApiQuestionar
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static bool _incluirDetalhesDeErro = Convert.ToBoolean(ConfigurationManager.AppSettings["incluir_detalhes_erro"]);
        private const string INCONFORMIDADE_BANCO_DADOS = "Inconformidade no banco de dados";
        private const string INCONFORMIDADE_NAO_ESPECIFICADA = "Inconformidade não especificada, favor consultar o administrador do sistema.";
        private const string LOGIN_INVALIDO = "Login/Senha inválidos.";

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                            .ContractResolver = new NHibernateContractResolver();

            // Custom generic error handler
            GlobalConfiguration.Configuration.Filters.Add(
                new UnhandledExceptionFilter()
                .Register<QuestionarException>((exception, request) =>
                {
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = exception.Message;
                    return request.CreateResponse(HttpStatusCode.InternalServerError, err);
                })
                .Register<UnauthorizedAccessException>((exception, request) =>
                {
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = "Sua sessão expirou.";
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<AuthenticationException>((exception, request) =>
                {                 
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);                    
                    err.Message = LOGIN_INVALIDO;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<ADOException>((exception, request) =>
                {                   
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_BANCO_DADOS;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<WebException>((exception, request) =>
                {                    
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_NAO_ESPECIFICADA;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<ArgumentNullException>((exception, request) =>
                {                    
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_NAO_ESPECIFICADA;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })                
                .Register<EndOfStreamException>((exception, request) =>
                {                    
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = "Inconformidade ao ler arquivo. Por favor, tente gerar o arquivo novamente e caso o erro persista, contate o administrador do sistema.";
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<PropertyAccessException>((exception, request) =>
                {                    
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_NAO_ESPECIFICADA;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<NullReferenceException>((exception, request) =>
                {                    
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_NAO_ESPECIFICADA;
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                })
                .Register<Exception>((exception, request) =>
                {                   
                    HttpError err = new HttpError(exception, _incluirDetalhesDeErro);
                    err.Message = INCONFORMIDADE_NAO_ESPECIFICADA;
                    return request.CreateResponse(HttpStatusCode.PreconditionFailed, err);
                })
            );      
           
        }
    }
}
