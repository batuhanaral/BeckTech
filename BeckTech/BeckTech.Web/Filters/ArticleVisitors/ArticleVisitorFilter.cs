using BechTech.Entity.Entities;
using BeckTech.Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace BeckTech.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
     
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            List<Visitor> visitors = await unitOfWork.GetRepository<Visitor>().GetAllAsync();

            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string gerUserAgent = context.HttpContext.Request.Headers["user-Agent"];

            Visitor visitor = new(getIp, gerUserAgent); 

            if (visitors.Any(x=>x.IpAddress==visitor.IpAddress))
                await next();
            else
            {
                await unitOfWork.GetRepository<Visitor>().AddAsycn(visitor);
                await unitOfWork.SaveAsync();
                await next();
            }

        }
    }
}
