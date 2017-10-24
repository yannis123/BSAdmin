using System.Web;
using System.Web.Mvc;
using web.Filter;

namespace web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PermissionAttribute());
        }
    }
}
