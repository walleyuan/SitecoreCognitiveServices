using System.Linq;
using System.Web.Mvc;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Controllers
{
    public class CognitiveLaunchController : Controller
    {
        //protected readonly ISomething Something;
        
        public CognitiveLaunchController(
            //ISomething something
            )
        {
            //Assert.IsNotNull(something, typeof(ISomething));
            
            //Something = something;
        }

        public ActionResult Moderator()
        {
            return View();
        }
    }
}