using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly AppBibliotecaContext app;
        private readonly ILibroRepository _libroRepository;
        private readonly IUserRepository _userRepos;

        public LibroController(AppBibliotecaContext app, ILibroRepository _libroRepository, IUserRepository _userRepos)
        {
            this.app = app;
            this._libroRepository = _libroRepository;
            this._userRepos = _userRepos;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            /*
            var model = app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();//detalle de un libro
            */
            var model = _libroRepository.DetailsLibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            /*
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();*/
            _libroRepository.AddComentarioLibro(comentario, user.Id);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            //var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            var user = _userRepos.GetUsuarioLogin(claim.Value);
            return user;
        }
    }
}
