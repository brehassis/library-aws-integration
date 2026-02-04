using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha em uma dependência externa
/// necessária para a execução da operação.
///
/// Representa erros originados fora do controle direto da
/// LibraryAwsIntegration, como serviços de terceiros, SDKs,
/// infraestrutura ou comunicação de rede.
///
/// Exemplos comuns incluem:
/// - Falha em chamadas ao AWS SDK
/// - Serviço externo indisponível
/// - Erros de rede ou DNS
/// - Dependência retornando erro inesperado
///
/// Esta exceção é de natureza técnica e transversal, podendo ocorrer
/// em qualquer componente da LibraryAwsIntegration.
/// </summary>
public sealed class DependencyException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="DependencyException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da falha na dependência externa.
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
    public DependencyException(
        string message,
        EComponentType componentType,
        CorrelationId? correlationId = null,
        Exception? innerException = null)
        : base(
            message,
            EFailureType.Dependency,
            componentType,
            correlationId,
            innerException)
    {
    }
}
