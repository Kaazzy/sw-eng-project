using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using sw_project.Controllers;
using sw_project.Models;
using sw_project.Services.Interfaces;
using sw_project.Tests.TestHelpers;
using Xunit;

namespace sw_project.Tests.Controllers;

public class ExpensesControllerTests
{
    [Fact]
    public async Task Create_Post_SetsUserId_AndRedirects()
    {
        var svc = new Mock<IExpensesService>();
        svc.Setup(s => s.Create(It.IsAny<Expense>())).Returns(Task.CompletedTask);

        var controller = new ExpensesController(svc.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = ClaimsPrincipalFactory.CreateWithUserId("u1")
                }
            }
        };

        Expense? captured = null;
        svc.Setup(s => s.Create(It.IsAny<Expense>()))
            .Callback<Expense>(e => captured = e)
            .Returns(Task.CompletedTask);

        var result = await controller.Create(new Expense { Description = "d", Amount = 1, Category = "c" });

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
        Assert.NotNull(captured);
        Assert.Equal("u1", captured!.UserId);
    }

    [Fact]
    public async Task Edit_Get_ReturnsNotFound_WhenMissing()
    {
        var svc = new Mock<IExpensesService>();
        svc.Setup(s => s.GetById(123, "u1")).ReturnsAsync((Expense?)null);

        var controller = new ExpensesController(svc.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = ClaimsPrincipalFactory.CreateWithUserId("u1")
                }
            }
        };

        var result = await controller.Edit(123);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetChart_ReturnsJson()
    {
        var svc = new Mock<IExpensesService>();
        svc.Setup(s => s.GetChartData("u1")).Returns(new List<object>().AsQueryable());

        var controller = new ExpensesController(svc.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = ClaimsPrincipalFactory.CreateWithUserId("u1")
                }
            }
        };

        var result = controller.GetChart();

        Assert.IsType<JsonResult>(result);
    }
}
