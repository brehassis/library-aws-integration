using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma operação solicitada não é suportada
/// no contexto técnico atual.
///
/// Representa limitações técnicas da plataforma, do provider ou da
/// configuração ativa, e não erros de negócio.
///
/// Exemplos comuns incluem:
/// - Funcionalidade não suportada pelo serviço AWS utilizado
/// - Operação indisponível na região configurada
/// - Modo de execução incompatível com a ação solicitada
/// - API não disponível para o recurso configurado
///
/// Esta exceção é transversal e pode ocorrer em qualquer componente
/// da LibraryAwsIntegration.
/// </summary>
public sealed class UnsupportedOperationException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="UnsupportedOperationException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da operação não suportada.
    /// </param>
    /// <param name="componentType">
    /// Componente onde a limitação foi detectada.
    /// </param>
    /// <param name="correlationId">
    /// Identificador de correlação da operação.
    /// </param>
    /// <param name="innerException">
    /// Exceção interna que originou a falha, se aplicável.
    /// </param>
    public UnsupportedOperationException(
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
