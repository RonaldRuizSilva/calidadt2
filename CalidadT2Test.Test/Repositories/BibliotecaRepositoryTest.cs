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
    class BibliotecaRepositoryTest
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
            var repository = new BibliotecaRepository(mockContext.Object);
            var biblioteca = repository.BibliotecasUsuario(1);

            Assert.IsNotNull(biblioteca);
            Assert.AreEqual(1, biblioteca.Count);
        }
        [Test]
        public void TestFindByUsername5Bibliotecas()
        {
            var repository = new BibliotecaRepository(mockContext.Object);
            var biblioteca = repository.BibliotecasUsuario(1);

            Assert.IsNotNull(biblioteca);
            Assert.AreEqual(5, biblioteca.Count);
        }
        [Test]
        public void TestAddLibroBibliotecaPrimerLibroAniadidoPorUsuario()
        {
            var repository = new BibliotecaRepository(mockContext.Object);
            repository.AddLibroBibliotecaUser(1, 1);
            Assert.AreEqual(1, repository.BibliotecasUsuario(1).Count);
            Assert.Throws(typeof(Exception), () => repository.AddLibroBibliotecaUser(1, 1));
            Assert.AreEqual(2, repository.BibliotecasUsuario(1).Count);
        }
        [Test]
        public void TestAddLibroBibliotecaPrimerLibroUsuarioAniade2Libros()
        {
            var repository = new BibliotecaRepository(mockContext.Object);
            repository.AddLibroBibliotecaUser(1, 1);
            Assert.AreEqual(1, repository.BibliotecasUsuario(1).Count);
            Assert.Throws(typeof(Exception), () => repository.AddLibroBibliotecaUser(2, 1));
            Assert.Throws(typeof(Exception), () => repository.AddLibroBibliotecaUser(3, 1));
            Assert.Throws(typeof(Exception), () => repository.AddLibroBibliotecaUser(4, 1));
            Assert.AreEqual(4, repository.BibliotecasUsuario(1).Count);
        }

    }
}
