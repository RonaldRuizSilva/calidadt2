using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{
    public interface ILibroRepository
    {
        public List<Libro> GetAllLibros();
        public void MarcarComoLeyendoLibro(int libroId, int idUser);
        public void MarcarComoTerminado(int libroID, int idUser);
        public Libro DetailsLibro(int libroId);
        public void AddComentarioLibro(Comentario comentario, int idUser);
    }
    public class LibroRepository : ILibroRepository
    {
        private readonly AppBibliotecaContext _context;

        public LibroRepository(AppBibliotecaContext context)
        {
            this._context = context;
        }
        public List<Libro> GetAllLibros()
        {
            var model = _context.Libros.Include(o => o.Autor).ToList();
            return model;
        }
        public void MarcarComoLeyendoLibro(int libroId, int idUser)
        {
            try
            {
                var libro = _context.Bibliotecas
               .Where(o => o.LibroId == libroId && o.UsuarioId == idUser)
               .FirstOrDefault();

                libro.Estado = ESTADO.LEYENDO;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }

        }

        public void MarcarComoTerminado(int libroID, int idUser)
        {
            try
            {
                var libro = _context.Bibliotecas
               .Where(o => o.LibroId == libroID && o.UsuarioId == idUser)
               .FirstOrDefault();

                libro.Estado = ESTADO.TERMINADO;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            
        }
        //Testeado
        public Libro DetailsLibro(int libroId)
        {
            try
            {
                var libro = _context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == libroId)
                .FirstOrDefault();//detalle de un libro
                return libro;
            }
            catch(Exception ex)
            {

            }

            return null;
        }
        //testeado
        public void AddComentarioLibro(Comentario comentario, int idUser)
        {
            try
            {
                comentario.UsuarioId = idUser;
                comentario.Fecha = DateTime.Now;
                _context.Comentarios.Add(comentario);

                var libro = _context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
                libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
