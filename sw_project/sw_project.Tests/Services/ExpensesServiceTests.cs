using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using sw_project.Models;
using sw_project.Repositories.Interfaces;
using sw_project.Services;
using Xunit;

namespace sw_project.Tests.Services;

public class ExpensesServiceTests
{
    [Fact]
    public async Task GetAll_CallsRepository()
    {
        var repo = new Mock<IExpensesRepository>();
        repo.Setup(r => r.GetAll("u1")).ReturnsAsync(new List<Expense>());

        var svc = new ExpensesService(repo.Object);

        await svc.GetAll("u1");

        repo.Verify(r => r.GetAll("u1"), Times.Once);
    }

    [Fact]
    public async Task Create_CallsRepositoryAdd()
    {
        var repo = new Mock<IExpensesRepository>();
        repo.Setup(r => r.Add(It.IsAny<Expense>())).Returns(Task.CompletedTask);

        var svc = new ExpensesService(repo.Object);

        await svc.Create(new Expense { Description = "d", Amount = 1, Category = "c" });

        repo.Verify(r => r.Add(It.IsAny<Expense>()), Times.Once);
    }

    [Fact]
    public void GetChartData_CallsRepository()
    {
        var repo = new Mock<IExpensesRepository>();
        repo.Setup(r => r.GetChartData("u1")).Returns(new List<object>().AsQueryable());

        var svc = new ExpensesService(repo.Object);

        _ = svc.GetChartData("u1");

        repo.Verify(r => r.GetChartData("u1"), Times.Once);
    }
}
