using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma configuração obrigatória está ausente,
/// inválida ou inconsistente, impossibilitando a execução da operação.
///
/// Representa falhas técnicas relacionadas ao ambiente ou à
/// parametrização da aplicação, e não erros de negócio.
///
/// Exemplos comuns incluem:
/// - Credenciais não configuradas
/// - Região AWS inválida ou ausente
/// - Configurações obrigatórias incompletas
/// - Inconsistência entre parâmetros de execução
///
/// Esta exceção é transversal e pode ocorrer em qualquer componente
/// da LibraryAwsIntegration.
/// </summary>
public sealed class ConfigurationException : IntegrationException
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="ConfigurationException"/>.
    /// </summary>
    /// <param name="message">
    /// Mensagem descritiva da falha de configuração.
    /// </param>
    /// <param name="componentType">
    /// Componente onde a configuração inválida foi detectada.
    /// </param>
    /// <param name="correlationId">
    /// Identificador de correlação da operação.
    /// </param>
    /// <param name="innerException">
    /// Exceção interna que originou a falha, se aplicável.
    /// </param>
    public ConfigurationException(
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
