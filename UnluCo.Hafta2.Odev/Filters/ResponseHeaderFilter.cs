using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace UnluCo.Hafta2.Odev.Filters
{
    public class ResponseHeaderFilter : IResultFilter
    {
        
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //throw new NotImplementedException();
            context.HttpContext.Response.Headers.Add("customHeader", DateTime.Now.ToString());
        }
    }
}
