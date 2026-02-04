using System;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.Exceptions;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para classificação,
/// análise e extração semântica de exceções.
/// </summary>
/// <remarks>
/// Centraliza o tratamento de exceções no Core,
/// permitindo conversão consistente para contratos
/// de resposta e classificação de falhas.
/// </remarks>
public static class ExceptionExtensions
{
    /// <summary>
    /// Classifica uma exceção em um tipo de falha
    /// arquitetural (<see cref="EFailureType"/>).
    /// </summary>
    /// <param name="exception">Exceção capturada.</param>
    /// <returns>
    /// Tipo de falha correspondente.
    /// </returns>
    public static EFailureType ToFailureType(this Exception exception)
    {
        return exception switch
        {
            ConfigurationException => EFailureType.Technical,
            DependencyException => EFailureType.Dependency,
            TimeoutException => EFailureType.Timeout,
            ConcurrencyException => EFailureType.Technical,
            SerializationException => EFailureType.Technical,
            SecurityException => EFailureType.Technical,
            UnsupportedOperationException => EFailureType.Business,
            IntegrationException => EFailureType.Technical,
            _ => EFailureType.Technical
        };
    }

    /// <summary>
    /// Extrai uma mensagem segura para exposição
    /// externa a partir de uma exceção.
    /// </summary>
    /// <param name="exception">Exceção capturada.</param>
    /// <returns>
    /// Mensagem sanitizada para resposta.
    /// </returns>
    /// <remarks>
    /// Evita vazamento de detalhes internos ou
    /// informações sensíveis.
    /// </remarks>
    public static ResponseMessage ToResponseMessage(this Exception exception)
    {
        return new ResponseMessage(
            exception is BusinessException
                ? exception.Message
                : "Ocorreu um erro durante o processamento da operação."
        );
    }

    /// <summary>
    /// Indica se a exceção representa uma falha
    /// potencialmente transitória.
    /// </summary>
    /// <param name="exception">Exceção capturada.</param>
    /// <returns>
    /// <c>true</c> se a falha puder ser reprocessada;
    /// caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsTransient(this Exception exception)
    {
        return exception switch
        {
            TimeoutException => true,
            DependencyException => true,
            ConcurrencyException => true,
            _ => false
        };
    }
}
