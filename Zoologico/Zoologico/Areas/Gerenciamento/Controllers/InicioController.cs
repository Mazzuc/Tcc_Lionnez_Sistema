﻿using Microsoft.AspNetCore.Mvc;

namespace Zoologico.Areas.Gerenciamento.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
