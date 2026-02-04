using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha técnica relacionada à
/// segurança durante a execução de uma operação.
///
/// Representa problemas de natureza técnica, não relacionados a
/// autorização ou regras de negócio.
///
/// Exemplos comuns incluem:
/// - Assinatura inválida de requisição
/// - Token técnico corrompido ou malformado
/// - Falha em processos de criptografia ou descriptografia
/// - Violação de integridade de dados
///
/// Esta exceção é transversal e pode ocorrer em qualquer componente
/// da LibraryAwsIntegration.
/// </summary>
public sealed class SecurityException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="SecurityException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da falha de segurança ocorrida.
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
    public SecurityException(
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
