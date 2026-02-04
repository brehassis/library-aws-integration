using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando o tempo máximo de execução de uma operação
/// é excedido, impossibilitando sua conclusão dentro do limite esperado.
///
/// Representa falhas técnicas relacionadas a tempo de resposta,
/// e não a regras de negócio ou validação de dados.
///
/// Exemplos comuns incluem:
/// - Timeout configurado no AWS SDK
/// - Extrapolação de tempo em chamadas remotas
/// - Retry policy esgotada
/// - Circuit breaker impedindo a execução após tempo limite
///
/// Esta exceção é transversal e pode ocorrer em qualquer componente
/// da LibraryAwsIntegration.
/// </summary>
public sealed class TimeoutException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="TimeoutException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva do estouro de tempo ocorrido.
    /// </param>
    /// <param name="componentType">
    /// Componente onde o timeout foi detectado.
    /// </param>
    /// <param name="correlationId">
    /// Identificador de correlação da operação.
    /// </param>
    /// <param name="innerException">
    /// Exceção interna que originou o timeout, se aplicável.
    /// </param>
    public TimeoutException(
        string message,
        EComponentType componentType,
        CorrelationId? correlationId = null,
        Exception? innerException = null)
        : base(
            message,
            EFailureType.Timeout,
            componentType,
            correlationId,
            innerException)
    {
    }
}
