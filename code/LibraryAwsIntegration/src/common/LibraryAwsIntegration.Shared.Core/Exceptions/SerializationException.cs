using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha durante processos de
/// serialização ou desserialização de dados.
///
/// Representa erros técnicos relacionados à conversão de objetos,
/// contratos ou payloads, impedindo a comunicação correta entre
/// componentes ou sistemas externos.
///
/// Exemplos comuns incluem:
/// - JSON inválido ou malformado
/// - Falha ao desserializar resposta de um serviço externo
/// - Incompatibilidade entre contrato esperado e payload recebido
/// - Erros de mapeamento de DTOs
///
/// Esta exceção é transversal e pode ocorrer em qualquer componente
/// da LibraryAwsIntegration.
/// </summary>
public sealed class SerializationException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="SerializationException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da falha de serialização.
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
    public SerializationException(
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
