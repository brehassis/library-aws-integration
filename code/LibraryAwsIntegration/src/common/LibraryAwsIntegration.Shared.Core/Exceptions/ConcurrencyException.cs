using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre um conflito técnico de concorrência
/// durante a execução de uma operação.
///
/// Representa cenários onde o estado do recurso foi modificado
/// simultaneamente por outra operação, impossibilitando a conclusão
/// segura da ação atual.
///
/// Exemplos comuns incluem:
/// - Optimistic locking
/// - Conditional writes
/// - Version mismatch
/// - Controle de concorrência em recursos distribuídos
///
/// Esta exceção é de natureza técnica e transversal, podendo ocorrer
/// em qualquer componente da LibraryAwsIntegration.
/// </summary>
public sealed class ConcurrencyException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="ConcurrencyException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva do conflito de concorrência ocorrido.
    /// </param>
    /// <param name="componentType">
    /// Componente onde o conflito foi detectado.
    /// </param>
    /// <param name="correlationId">
    /// Identificador de correlação da operação.
    /// </param>
    /// <param name="innerException">
    /// Exceção interna que originou o conflito, se existir.
    /// </param>
    public ConcurrencyException(
        string message,
        EComponentType componentType,
        CorrelationId? correlationId = null,
        Exception? innerException = null)
        : base(
            message,
            EFailureType.Technical,
            componentType,
            correlationId,
            innerException)
    {
    }
}
