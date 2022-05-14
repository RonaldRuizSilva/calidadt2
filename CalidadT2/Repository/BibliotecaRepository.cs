using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{
    public interface IBibliotecaRepository
    {
        public List<Biblioteca> BibliotecasUsuario(int idUser);
        public void AddLibroBibliotecaUser(int idLibro, int idUser);
    }


    public class BibliotecaRepository: IBibliotecaRepository
    {
        private readonly AppBibliotecaContext _context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this._context = context;
        }
        //testeado
        public void AddLibroBibliotecaUser(int idLibro, int idUser)
        {
            try
            {
                var biblioteca = new Biblioteca//libro para leer-> añade a biblioteca del usuario
                {
                    LibroId = idLibro,
                    UsuarioId = idUser,
                    Estado = ESTADO.POR_LEER
                };

                _context.Bibliotecas.Add(biblioteca);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
           
        }
        //testeado
        public List<Biblioteca> BibliotecasUsuario(int idUser)
        {
            var model = _context.Bibliotecas
               .Include(o => o.Libro.Autor)
               .Include(o => o.Usuario)
               .Where(o => o.UsuarioId == idUser)//devuelve libros o biblioteca del usuario logeado
               .ToList();
            return model;
        }
    }
}
