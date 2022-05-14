using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2Test.Test.Repositories.Moks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.Test.Repositories
{
    class LibroRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;
        [SetUp]
        public void SetUp()
        {
            mockContext = WebAppContextTest.GetApplicationContextMock();
        }
        [Test]
        public void TestFindByUsername1Biblioteca()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libros = repository.GetAllLibros();


            Assert.IsNotNull(libros);
            Assert.AreEqual(4, libros.Count);
        }
        [Test]
        public void TestMarcarLeyendoLibro1()
        {
            var repository = new LibroRepository(mockContext.Object);

            Assert.Throws(typeof(Exception), () => repository.MarcarComoLeyendoLibro(1, 1));

        }
        [Test]
        public void TestMarcarLibroTerminado()
        {
            var repository = new LibroRepository(mockContext.Object);

            Assert.Throws(typeof(Exception), () => repository.MarcarComoTerminado(1, 1));

        }
        [Test]
        public void TestDetailsLibro()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libro = repository.DetailsLibro(1);
            Assert.IsNotNull(libro);

        }
        [Test]
        public void TestAddComentarioLibro()
        {
            var repository = new LibroRepository(mockContext.Object);
            Assert.Throws(typeof(Exception), () => repository.AddComentarioLibro(new Comentario { Id = 1, LibroId = 1, UsuarioId = 1, Texto = "Esto es un comentario", Fecha = DateTime.Now, Puntaje = 4, Usuario = new Usuario { Id = 1, Nombres = "Pablo Burgos" } }, 1));
        }
    }
}
