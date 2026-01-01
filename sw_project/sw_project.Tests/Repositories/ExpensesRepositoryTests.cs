using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sw_project.Data;
using sw_project.Models;
using sw_project.Repositories;
using sw_project.Tests.TestHelpers;
using Xunit;

namespace sw_project.Tests.Repositories;

public class ExpensesRepositoryTests
{
    private static FinanceAppContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<FinanceAppContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new FinanceAppContext(options);
    }

    [Fact]
    public async Task GetAll_ReturnsOnlyUserExpenses()
    {
        await using var ctx = CreateContext();
        ctx.Expenses.AddRange(
            new Expense { Description = "a", Amount = 1, Category = "Food", UserId = "u1", Date = DateTime.Now },
            new Expense { Description = "b", Amount = 2, Category = "Food", UserId = "u2", Date = DateTime.Now });
        await ctx.SaveChangesAsync();

        var repo = new ExpensesRepository(ctx);

        var result = (await repo.GetAll("u1")).ToList();

        Assert.Single(result);
        Assert.All(result, e => Assert.Equal("u1", e.UserId));
    }

    [Fact]
    public async Task Delete_DoesNotDeleteOtherUsersExpense()
    {
        await using var ctx = CreateContext();
        var expense = new Expense { Description = "a", Amount = 1, Category = "Food", UserId = "u2", Date = DateTime.Now };
        ctx.Expenses.Add(expense);
        await ctx.SaveChangesAsync();

        var repo = new ExpensesRepository(ctx);

        await repo.Delete(expense.ID, "u1");

        var stillThere = await ctx.Expenses.FindAsync(expense.ID);
        Assert.NotNull(stillThere);
    }

    [Fact]
    public async Task GetChartData_GroupsAndSumsPerCategory()
    {
        await using var ctx = CreateContext();
        ctx.Expenses.AddRange(
            new Expense { Description = "a", Amount = 10, Category = "Food", UserId = "u1", Date = DateTime.Now },
            new Expense { Description = "b", Amount = 5, Category = "Food", UserId = "u1", Date = DateTime.Now },
            new Expense { Description = "c", Amount = 7, Category = "Transport", UserId = "u1", Date = DateTime.Now },
            new Expense { Description = "x", Amount = 999, Category = "Other", UserId = "u2", Date = DateTime.Now });
        await ctx.SaveChangesAsync();

        var repo = new ExpensesRepository(ctx);

        var rows = repo.GetChartData("u1").Cast<object>().ToList();

        Assert.Equal(2, rows.Count);

        var food = rows.Single(r => AnonymousProjectionReader.GetProperty<string>(r, "Category") == "Food");
        Assert.Equal(15m, AnonymousProjectionReader.GetProperty<decimal>(food, "Total"));
    }
}
