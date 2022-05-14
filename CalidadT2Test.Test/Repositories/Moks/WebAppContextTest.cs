using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalidadT2Test.Test.Repositories.Moks
{
    public static class WebAppContextTest
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            IQueryable<Libro> libroData = GetLibroData();

            var mockDbSetLibro = new Mock<DbSet<Libro>>();
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Provider).Returns(libroData.Provider);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Expression).Returns(libroData.Expression);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.ElementType).Returns(libroData.ElementType);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.GetEnumerator()).Returns(libroData.GetEnumerator());
            mockDbSetLibro.Setup(m => m.AsQueryable()).Returns(libroData);


            IQueryable<Biblioteca> bibliotecaData = GetBibliotecaData();

            var mockDbSetBiblioteca = new Mock<DbSet<Biblioteca>>();
            mockDbSetBiblioteca.As<IQueryable<Biblioteca>>().Setup(m => m.Provider).Returns(bibliotecaData.Provider);
            mockDbSetBiblioteca.As<IQueryable<Biblioteca>>().Setup(m => m.Expression).Returns(bibliotecaData.Expression);
            mockDbSetBiblioteca.As<IQueryable<Biblioteca>>().Setup(m => m.ElementType).Returns(bibliotecaData.ElementType);
            mockDbSetBiblioteca.As<IQueryable<Biblioteca>>().Setup(m => m.GetEnumerator()).Returns(bibliotecaData.GetEnumerator());
            mockDbSetBiblioteca.Setup(m => m.AsQueryable()).Returns(bibliotecaData);


            IQueryable<Usuario> userData = GetUsuarioData();

            var mockDbSetUser = new Mock<DbSet<Usuario>>();
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            mockDbSetUser.Setup(m => m.AsQueryable()).Returns(userData);


            IQueryable<Comentario> comentariosData = GetComentariosData();

            var mockDbSetComentario = new Mock<DbSet<Comentario>>();
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.Provider).Returns(comentariosData.Provider);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.Expression).Returns(comentariosData.Expression);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.ElementType).Returns(comentariosData.ElementType);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.GetEnumerator()).Returns(comentariosData.GetEnumerator());
            mockDbSetComentario.Setup(m => m.AsQueryable()).Returns(comentariosData);


            IQueryable<Autor> autorData = GetAutorData();

            var mockDbSetAutor = new Mock<DbSet<Autor>>();
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.Provider).Returns(autorData.Provider);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.Expression).Returns(autorData.Expression);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.ElementType).Returns(autorData.ElementType);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.GetEnumerator()).Returns(autorData.GetEnumerator());
            mockDbSetAutor.Setup(m => m.AsQueryable()).Returns(autorData);

            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSetUser.Object);
            mockContext.Setup(c => c.Autores).Returns(mockDbSetAutor.Object);
            mockContext.Setup(c => c.Libros).Returns(mockDbSetLibro.Object);
            mockContext.Setup(c => c.Comentarios).Returns(mockDbSetComentario.Object);
            mockContext.Setup(c => c.Bibliotecas).Returns(mockDbSetBiblioteca.Object);
            
           

            return mockContext;
        }
        private static IQueryable<Libro> GetLibroData()
        {
            return new List<Libro>
            {
                new Libro{Id = 1, Nombre="Metro 2033", Imagen="/Images/9788478884452.jpg",AutorId = 1, Puntaje=5, Autor = new Autor{Id = 1, Nombres="Dmitri Glukhovsky"}, Comentarios = new List<Comentario>{ new Comentario{Id = 1, LibroId = 1, UsuarioId = 1, Texto ="Esto es un comentario", Fecha = DateTime.Now, Puntaje = 4, Usuario = new Usuario{Id = 1, Nombres = "Pablo Burgos"} } } }
            }.AsQueryable();
        }
        private static IQueryable<Biblioteca> GetBibliotecaData()
        {
            return new List<Biblioteca>
            {
                new Biblioteca{Id=1, UsuarioId=1, LibroId=1,Estado=1,Usuario = new Usuario{Id=1,Username="Pablo",Password="123",Nombres="Pablo Burgos"},Libro= new Libro{Id = 1, Nombre="Metro 2033", Imagen="/Images/9788478884452.jpg",AutorId = 1, Puntaje=5, Autor = new Autor{Id = 1, Nombres="Dmitri Glukhovsky"} } }
            }.AsQueryable();
        }

        private static IQueryable<Usuario> GetUsuarioData()
        {
            return new List<Usuario>
            {
                new Usuario{Id = 1, Nombres = "Pablo Burgos", Username="Pablo",Password="1234"}
            }.AsQueryable();
        }
        public static IQueryable<Comentario> GetComentariosData()
        {
            return new List<Comentario>
            {
                new Comentario{Id = 1, LibroId = 1, UsuarioId = 1, Texto ="Esto es un comentario", Fecha = DateTime.Now, Puntaje = 4, Usuario = new Usuario{Id = 1, Nombres = "Pablo Burgos"}}
            }.AsQueryable();
        }
        public static IQueryable<Autor> GetAutorData()
        {
            return new List<Autor>
            {
                new Autor{Id = 1, Nombres="Dmitri Glukhovsky"}
            }.AsQueryable();
        }
    }
}
