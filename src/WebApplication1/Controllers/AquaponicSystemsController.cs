using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Auto.Aquaponics;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Kernel.Query;

namespace WebApplication1.Controllers
{
    public class AquaponicSystemsController : Controller
    {
        private readonly IQueryHandler<GetSystems, IList<AquaponicSystem>> _getSystemsHandler;

        public AquaponicSystemsController(IQueryHandler<GetSystems, IList<AquaponicSystem>> getSystemsHandler )
        {
            _getSystemsHandler = getSystemsHandler;
        }

        // GET: System
        public ActionResult Index()
        {
            var list = new List<AquaponicSystem>
            {
                new AquaponicSystem("Test 1"),
                new AquaponicSystem("Test 2"),
            };
            return View(_getSystemsHandler.Handle(new GetSystems()));
        }
    }
}