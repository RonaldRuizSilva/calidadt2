using CalidadT2.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.Test.Controllers
{
    class BibliotecaControllerTest
    {
        private Mock<IUserRepository> repository;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IUserRepository>();
        }

    }
}
