using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeirasNovas.Controllers
{
    public class authoController : Controller
    {
        
        public IActionResult Welcome()
        {
            return View();
        }
    }
}