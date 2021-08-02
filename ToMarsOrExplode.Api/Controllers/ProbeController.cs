using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToMarsOrExplode.Api.Controllers
{
    public class ProbeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
