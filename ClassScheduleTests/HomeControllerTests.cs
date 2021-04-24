using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using Microsoft.AspNetCore.Http;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            //arrange
            var unit = new Mock<IClassScheduleUnitOfWork>();
            var http = new Mock<IHttpContextAccessor>();
            var days = new Mock<IRepository<Day>>();
            var classes = new Mock<IRepository<Class>>();
            var controller = new HomeController(unit.Object, http.Object);

            unit.Setup(r => r.Days).Returns(days.Object);
            unit.Setup(r => r.Classes).Returns(classes.Object);

            //act
            var result = controller.Index(0);

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
