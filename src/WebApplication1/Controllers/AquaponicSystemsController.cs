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
            return View(_getSystemsHandler.Handle(new GetSystems()));
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: api/Default
        [Produces("application/json")]
        public AquaponicSystem Get()
        {
            return _getSystemsHandler.Handle(new GetSystems())[0];
        }

    }
}