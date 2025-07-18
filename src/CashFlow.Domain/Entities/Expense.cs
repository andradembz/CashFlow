using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

public class Expense
{
    public long id { get; set; }
    public string title { get; set; } = string.Empty;
    public string? description { get; set; } 
    public DateTime date { get; set; }
    public decimal amount { get; set; }
    public PaymentType paymentType { get; set; }
    public string guid { get; set; } = string.Empty;
}
