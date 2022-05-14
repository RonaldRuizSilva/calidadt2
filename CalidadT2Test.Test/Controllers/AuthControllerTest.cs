using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.Test.Controllers
{
    class AuthControllerTest
    {

        [Test]
        public void TestLoginPostFail()
        {

            var mock = new Mock<IUserRepository>();

            mock.Setup(o => o.GetUsuarioForLogin("Pablo", "1234")).Returns((Usuario)null);
            var controller = new AuthController(null, mock.Object);

            var result = controller.Login("admin", "1234") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }
    }
}
