using System.Web.Mvc;

namespace MalweeCodeChallenge.Controllers.Filters
{
    public class ErrorHandlerAttribute: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, message = filterContext.Exception.Message },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}