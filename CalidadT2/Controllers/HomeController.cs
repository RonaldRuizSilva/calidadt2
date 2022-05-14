using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using CalidadT2.Repository;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private AppBibliotecaContext app;
        private readonly ILibroRepository _libroRepository;
        public HomeController(AppBibliotecaContext app, ILibroRepository _libroRepository)
        {
            this.app = app;
            this._libroRepository = _libroRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var model = app.Libros.Include(o => o.Autor).ToList();
            var model = _libroRepository.GetAllLibros();
            return View(model);
        }
    }
}
