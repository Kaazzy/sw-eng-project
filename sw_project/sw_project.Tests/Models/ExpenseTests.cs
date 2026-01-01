using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sw_project.Models;
using Xunit;

namespace sw_project.Tests.Models;

public class ExpenseTests
{
    [Fact]
    public void Expense_Defaults_AreExpected()
    {
        var expense = new Expense();

        Assert.Equal(Currency.EGP, expense.Currency);
        Assert.True((DateTime.Now - expense.Date).TotalSeconds < 5);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Expense_InvalidAmount_FailsValidation(decimal amount)
    {
        var expense = new Expense
        {
            Description = "Test",
            Amount = amount,
            Category = "Food",
            Date = DateTime.Now,
            Currency = Currency.EGP
        };

        var results = Validate(expense);

        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Expense.Amount)));
    }

    [Fact]
    public void Expense_MissingDescription_FailsValidation()
    {
        var expense = new Expense
        {
            Description = null!,
            Amount = 10,
            Category = "Food",
            Date = DateTime.Now,
            Currency = Currency.EGP
        };

        var results = Validate(expense);

        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Expense.Description)));
    }

    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(model, new ValidationContext(model), results, validateAllProperties: true);
        return results;
    }
}
