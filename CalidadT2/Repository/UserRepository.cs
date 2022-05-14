using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{
    public interface IUserRepository
    {
        public Usuario GetUsuarioForLogin(string username, string password);
        public Usuario GetUsuarioLogin(string username);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppBibliotecaContext _context;

        public UserRepository(AppBibliotecaContext context)
        {
            this._context = context;
        }
        public Usuario GetUsuarioForLogin(string username, string password)
        {
            return _context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }

        public Usuario GetUsuarioLogin(string username)
        {
            var usuario = _context.Usuarios.Where(o => o.Username == username).FirstOrDefault();
            return usuario;
        }
    }
}
