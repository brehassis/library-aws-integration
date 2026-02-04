using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção base para todas as falhas técnicas da LibraryAwsIntegration.
///
/// Representa erros irrecuperáveis no contexto da execução de uma
/// integração, que impedem a continuidade segura da operação.
///
/// Esta classe centraliza informações essenciais para observabilidade,
/// rastreabilidade e padronização de falhas, sendo a raiz de todas as
/// exceções do Core.
/// </summary>
public abstract class IntegrationException : Exception
{
    /// <summary>
    /// Classificação do tipo de falha associada à exceção.
    /// </summary>
    public EFailureType FailureType { get; }

    /// <summary>
    /// Componente da LibraryAwsIntegration onde a falha ocorreu.
    /// </summary>
    public EComponentType ComponentType { get; }

    /// <summary>
    /// Identificador de correlação da operação.
    /// </summary>
    public CorrelationId? CorrelationId { get; }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="IntegrationException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da falha ocorrida.
    /// </param>
    /// <param name="failureType">
    /// Tipo de falha associada à exceção.
    /// </param>
    /// <param name="componentType">
    /// Componente onde a falha foi detectada.
    /// </param>
    /// <param name="correlationId">
    /// Identificador de correlação da operação.
    /// </param>
    /// <param name="innerException">
    /// Exceção interna que originou a falha, se aplicável.
    /// </param>
    protected IntegrationException(
        string message,
        EFailureType failureType,
        EComponentType componentType,
        CorrelationId? correlationId = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        FailureType = failureType;
        ComponentType = componentType;
        CorrelationId = correlationId;
    }
}
