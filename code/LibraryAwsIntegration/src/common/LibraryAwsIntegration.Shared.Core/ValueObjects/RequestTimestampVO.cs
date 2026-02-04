namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa o instante de criação de uma requisição.
///
/// Encapsula um timestamp em UTC, garantindo padronização,
/// rastreabilidade e consistência temporal entre todos os
/// componentes da LibraryAwsIntegration.
///
/// Este Value Object existe para evitar o uso direto de
/// tipos primitivos como <see cref="DateTime"/> ou
/// <see cref="DateTimeOffset"/> no core da arquitetura.
/// </summary>
public sealed record RequestTimestampVO
{
    /// <summary>
    /// Valor do timestamp em UTC.
    /// </summary>
    public DateTimeOffset Value { get; }

    private RequestTimestampVO(DateTimeOffset value)
    {
        Value = value.ToUniversalTime();
    }

    /// <summary>
    /// Cria uma instância de <see cref="RequestTimestampVO"/>
    /// utilizando o instante atual em UTC.
    /// </summary>
    public static RequestTimestampVO Now()
        => new(DateTimeOffset.UtcNow);

    /// <summary>
    /// Cria uma instância de <see cref="RequestTimestampVO"/>
    /// a partir de um valor explícito.
    /// </summary>
    /// <param name="value">
    /// Timestamp que será normalizado para UTC.
    /// </param>
    public static RequestTimestampVO From(DateTimeOffset value)
        => new(value);

    /// <inheritdoc />
    public override string ToString()
        => Value.ToString("O");
}
