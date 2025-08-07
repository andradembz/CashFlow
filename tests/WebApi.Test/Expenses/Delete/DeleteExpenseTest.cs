using CashFlow.Exception;
using CommonTestUtilities.Entities;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Expenses.Delete;

public class DeleteExpenseTest : CashFlowClassFixture
{
    private const string METHOD = "api/Expenses";
    private readonly string _token;
    private readonly long _expenseID;

    public DeleteExpenseTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.User_Team_Member.GetToken();
        _expenseID = webApplicationFactory.Expense.GetId();
    }

    [Fact]
    public async Task Success()
    {
        var result = await DoDelete(requestUri: $"{METHOD}/{_expenseID}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);

        result = await DoGet(requestUri: $"{METHOD}/{_expenseID}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error_Expense_Not_Found(string cultureInfo)
    {
        var result = await DoDelete(requestUri: $"{METHOD}/1000", token: _token, culture: cultureInfo);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("EXPENSE_NOT_FOUND", new CultureInfo(cultureInfo));

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }
    
}
