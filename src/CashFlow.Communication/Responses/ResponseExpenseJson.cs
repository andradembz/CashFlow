using CashFlow.Communication.Enums;
using System.Reflection.Metadata;

namespace CashFlow.Communication.Responses;

public class ResponseExpenseJson
{
    public long id { get; set; }
    public string title { get; set; } = string.Empty;
    public string? description { get; set; }
    public DateTime date { get; set; }
    public decimal amount { get; set; }
    public PaymentType paymentType { get; set; }
}
