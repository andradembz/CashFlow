namespace CashFlow.Communication.Responses;

public class ResponseShortExpenseJson
{
    public long id {  get; set; }
    public string title { get; set; } = string.Empty;
    public decimal amount { get; set; }
}
