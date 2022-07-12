using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITI.Sauce.MVC.Filters
{
    public class Audit:ActionFilterAttribute
    {
        private readonly string LogFilePath = Directory.GetCurrentDirectory() +
            "/Logs/" + DateTime.Now.ToString("dd-MM-yyyy")+".txt";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringBuilder strBuilder=new StringBuilder();
            strBuilder.Append($"Date:  Executing  {DateTime.Now.ToString()}");
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append($"Executing Of Method {context.HttpContext.Request.Path}");
            strBuilder.Append(Environment.NewLine);
            File.AppendAllText(LogFilePath,strBuilder.ToString());
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Date: Of Executed  {DateTime.Now.ToString()}");
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append($"Executed Method {context.HttpContext.Request.Path}");
            strBuilder.Append(Environment.NewLine);
            File.AppendAllText(LogFilePath, strBuilder.ToString());

        }
    }
}
