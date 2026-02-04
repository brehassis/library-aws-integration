namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa o resultado de uma operação executada
/// por um componente da LibraryAwsIntegration.
///
/// Encapsula o estado de sucesso ou falha controlada
/// de uma execução, separando explicitamente
/// falhas de negócio de falhas técnicas, que devem
/// ser representadas por exceções.
///
/// Este Value Object existe para evitar o uso direto
/// de tipos primitivos como <see cref="bool"/> nos
/// contratos de resposta da arquitetura.
/// </summary>
public sealed record OperationResult
{
    /// <summary>
    /// Indica se a operação foi executada com sucesso.
    /// </summary>
    public bool IsSuccess { get; }

    private OperationResult(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    /// <summary>
    /// Cria um resultado de operação bem-sucedida.
    /// </summary>
    public static OperationResult Success()
        => new(true);

    /// <summary>
    /// Cria um resultado de operação com falha controlada.
    /// </summary>
    public static OperationResult Failure()
        => new(false);
}
