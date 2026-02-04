namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa o instante em que uma resposta foi gerada.
///
/// Encapsula um timestamp em UTC, garantindo padronização,
/// rastreabilidade e consistência temporal entre todos os
/// componentes da LibraryAwsIntegration.
///
/// Este Value Object existe para evitar o uso direto de
/// tipos primitivos como <see cref="DateTime"/> ou
/// <see cref="DateTimeOffset"/> nos contratos de resposta
/// da arquitetura.
/// </summary>
public sealed record ResponseTimestampVO
{
    /// <summary>
    /// Valor do timestamp em UTC.
    /// </summary>
    public DateTimeOffset Value { get; }

    private ResponseTimestampVO(DateTimeOffset value)
    {
        Value = value.ToUniversalTime();
    }

    /// <summary>
    /// Cria uma instância de <see cref="ResponseTimestampVO"/>
    /// utilizando o instante atual em UTC.
    /// </summary>
    public static ResponseTimestampVO Now()
        => new(DateTimeOffset.UtcNow);

    /// <inheritdoc />
    public override string ToString()
        => Value.ToString("O");
}
