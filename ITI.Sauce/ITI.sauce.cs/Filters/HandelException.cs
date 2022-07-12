using ITI.Sauce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITI.Sauce.MVC.Filters
{
    public class HandelException:ExceptionFilterAttribute
    {
        EmailServices emailServices;
        public HandelException(EmailServices _emailServices)
        {
            emailServices=_emailServices;
        }
        public override async Task OnExceptionAsync(ExceptionContext context)
        {

            try
            {
                SendEmailOptions Options = new SendEmailOptions()
                {
                    Subject = "Exception At Sauce App",
                    FromEmail = "Info@Sauce.com",
                    FromEmailDisplayName = "Sauce App",
                    IsBodyHTML = false,
                    Body = $"Date : {DateTime.Now.ToString()}," + Environment.NewLine +
                $"Eroor : {context.Exception.Message}" + Environment.NewLine +
                $"Stack Trace : {context.Exception.StackTrace}"
                };
                Options.ToEmails.Add("itisauce@gmail.com");
                await emailServices.SendEmail(Options);
                context.Result = new ViewResult()
                {
                    ViewName = "Error",
                };
                context.ExceptionHandled = true;
            }catch
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Error",

                };
                context.ExceptionHandled = true;

            }
        }
    }
}
