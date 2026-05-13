using Microsoft.AspNetCore.Mvc;

namespace Shop_Klimov.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
