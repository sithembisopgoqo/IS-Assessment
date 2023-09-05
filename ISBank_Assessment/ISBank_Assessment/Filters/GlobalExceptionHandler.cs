using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ISBank_Assessment.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = context.Exception.InnerException != null ?
                context.Exception.InnerException.Message.Replace("\r\n", " ") :
                !string.IsNullOrEmpty(context.Exception.Message) ? context.Exception.Message
                : context.Exception.GetType().ToString(),
            };

            var username = result.ReasonPhrase.Split(' ')[0];
            #region TODO- Error Log

            //var unitOfWork = new DL.UnitOfWork(new DL.DbContextFactory(null, new DL.DataBaseManager()));
            //BL.ErrorLogLogic errorLogLogic = new BL.ErrorLogLogic(unitOfWork);
            //BL.CustomMembership customMembership = new BL.CustomMembership(unitOfWork);

            //BE.User user = customMembership.GetLoginUser(username);
            ////BE.User user = new BE.User();
            ////if user is trying to reset password, user is not logged in, therefore substring username from header
            //if (context.Request.RequestUri.ToString().Contains("?Username"))
            //{
            //    var item1 = context.Request.RequestUri.ToString().Substring(0, context.Request.RequestUri.ToString().IndexOf('&'));
            //    var item2 = item1.Substring(item1.IndexOf('?') + 1);
            //    var item3 = item2.Replace("%40", "@");
            //    var item4 = item3.Substring(item3.IndexOf('=') + 1);

            //    user = customMembership.GetLoginUser(item4);
            //}
            //else
            //{
            //    try
            //    {
            //        user = customMembership.GetLoginUser(context.Request.Headers.Where(a => a.Key == "x-ms-username").FirstOrDefault().Value.FirstOrDefault());
            //    }
            //    catch
            //    {
            //        //if user cannot be found, do nothing
            //    }
            //}

            //if (user.UserId > 0) //if user is null, do not log error to table
            //{
            //    //TODO Error Log
            //    BE.ErrorLog errorLog = new BE.ErrorLog()
            //    {
            //        UserId = user.UserId,
            //        ResellerId = user.ResellerId,
            //        ErrorReference = "",
            //        ExceptionMessage = (int)((HttpStatusCode)result.StatusCode) + " - " + result.ReasonPhrase,
            //        LogDate = DateTime.Now,
            //        StackTrace = context.ExceptionContext.Exception.StackTrace,
            //    };

            //    BE.ErrorLog error = errorLogLogic.AddErrorLog(errorLog);
            //    result.ReasonPhrase = error.ErrorReference + " : " + result.ReasonPhrase;
            //}

            #endregion            

            context.Result = new ExceptionResult(context.Request, result);
            //Log.Error(context.Exception, $"Exception Message: {(context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message)}");
        }

        public class ExceptionResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;

            public ExceptionResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }
    }
}