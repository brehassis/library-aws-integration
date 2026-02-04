namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa a origem de uma requisição.
///
/// Utilizado para identificar o sistema, serviço ou
/// aplicação consumidora que iniciou a operação,
/// permitindo auditoria, rastreabilidade e análise
/// de uso da LibraryAwsIntegration.
///
/// Este Value Object não possui semântica de segurança
/// ou autorização.
/// </summary>
public sealed record RequestSource
{
    /// <summary>
    /// Identificador da origem da requisição.
    /// </summary>
    public string Value { get; }

    private RequestSource(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(
                "RequestSource não pode ser nulo ou vazio.",
                nameof(value));

        Value = value.Trim();
    }

    /// <summary>
    /// Cria uma nova instância de <see cref="RequestSource"/>.
    /// </summary>
    /// <param name="value">
    /// Nome lógico da origem da requisição
    /// (ex: api-gateway, order-service, backoffice).
    /// </param>
    public static RequestSource Create(string value)
        => new(value);

    /// <inheritdoc />
    public override string ToString()
        => Value;
}
