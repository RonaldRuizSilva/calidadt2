using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly AppBibliotecaContext _app;
        private readonly IBibliotecaRepository _biblioRepos;
        private readonly ILibroRepository _libroRepository;
        private readonly IUserRepository _userRepos;

        public BibliotecaController(AppBibliotecaContext app,IBibliotecaRepository biblioRepos, ILibroRepository libroRepository, IUserRepository _userRepos)
        {
            this._app = app;
            this._biblioRepos = biblioRepos;
            this._libroRepository = libroRepository;
            this._userRepos = _userRepos;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();
            //
            var model = _biblioRepos.BibliotecasUsuario(user.Id);
            //
            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();
           
            _biblioRepos.AddLibroBibliotecaUser(libro, user.Id);
          
            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            _libroRepository.MarcarComoLeyendoLibro(libroId, user.Id);

             TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            _libroRepository.MarcarComoTerminado(libroId, user.Id);

             TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            //var user = _app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            var user = _userRepos.GetUsuarioLogin(claim.Value);
            return user;
        }
    }
}
