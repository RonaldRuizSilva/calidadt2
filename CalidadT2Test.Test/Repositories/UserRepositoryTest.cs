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
    class UserRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockuserContext;
        [SetUp]
        public void SetUp()
        {
            mockuserContext = WebAppContextTest.GetApplicationContextMock();
        }
        [Test]
        public void TestGetUsuarioForLogin1()
        {
            var repository = new UserRepository(mockuserContext.Object);
            var usuario = repository.GetUsuarioForLogin("Pablo", "123");

            Assert.IsNotNull(usuario);
        }
        [Test]
        public void TestGetUsuarioLogin1()
        {
            var repository = new UserRepository(mockuserContext.Object);
            var usuario = repository.GetUsuarioLogin("Pablo");

            Assert.IsNotNull(usuario);
        }
    }
}
