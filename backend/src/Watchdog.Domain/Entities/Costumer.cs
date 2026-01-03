namespace Watchdog.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public CustomerType Type { get; private set; } //PF ou PJ
    public double Income { get; private set; } 
    public string Country { get; private set; }
    public RiskLevel CRiskLevel { get; private set; }
    public int KycStatus { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Customer() { } //utilizada apenas pelo EF Core

    public Customer(string name, string document, double income)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome é obrigatório");

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException("Documento é obrigatório");

        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public enum CustomerType
    {
        PessoaFisica = 1,
        PessoaJuridica = 2
    }

    public enum RiskLevel
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
