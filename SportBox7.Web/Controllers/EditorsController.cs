using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBox7.Web.Controllers
{
    public class EditorsController: MainController
    {
        [HttpGet]
        [Route("editors/index")]
        public async Task<ActionResult> Index()
            => View(await Task.Run(()=> Url));
    }
}
