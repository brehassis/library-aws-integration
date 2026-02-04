namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa um identificador de correlação utilizado
/// para rastrear uma operação ao longo de múltiplos
/// componentes, camadas e serviços.
///
/// Permite a associação de logs, métricas e eventos
/// relacionados a uma mesma execução, facilitando
/// observabilidade, auditoria e troubleshooting.
///
/// Este Value Object existe para evitar o uso direto
/// de tipos primitivos como <see cref="string"/> para
/// correlação de operações na arquitetura.
/// </summary>
public sealed record CorrelationId
{
    /// <summary>
    /// Valor do identificador de correlação.
    /// </summary>
    public string Value { get; }

    private CorrelationId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(
                "CorrelationId não pode ser nulo ou vazio.",
                nameof(value));

        Value = value;
    }

    /// <summary>
    /// Cria um novo <see cref="CorrelationId"/> único,
    /// baseado em <see cref="Guid"/>.
    /// </summary>
    public static CorrelationId New()
        => new(Guid.NewGuid().ToString("N"));

    /// <inheritdoc />
    public override string ToString()
        => Value;
}
