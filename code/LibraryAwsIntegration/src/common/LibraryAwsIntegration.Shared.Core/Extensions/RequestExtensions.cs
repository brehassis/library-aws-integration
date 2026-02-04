using System;
using LibraryAwsIntegration.Core.Request;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para validação,
/// normalização e manipulação de requests no Core.
/// </summary>
/// <remarks>
/// Centraliza regras comuns de RequestBase, garantindo
/// que todos os requests sigam o mesmo padrão de
/// inicialização, validação e rastreabilidade.
/// </remarks>
public static class RequestExtensions
{
    /// <summary>
    /// Normaliza o timestamp da requisição para UTC
    /// garantindo padronização em todos os componentes.
    /// </summary>
    /// <param name="request">Request alvo.</param>
    /// <returns>Request com timestamp normalizado.</returns>
    public static T NormalizeTimestamp<T>(this T request)
        where T : RequestBase
    {
        if (request.Timestamp is null)
            request.Timestamp = RequestTimestamp.Now();
        else
            request.Timestamp = RequestTimestamp.From(request.Timestamp.Value.Value);

        return request;
    }

    /// <summary>
    /// Garante que a origem da requisição esteja definida.
    /// </summary>
    /// <param name="request">Request alvo.</param>
    /// <param name="defaultSource">Origem padrão se não definida.</param>
    /// <returns>Request com origem validada.</returns>
    public static T EnsureSource<T>(this T request, RequestSource defaultSource = RequestSource.Internal)
        where T : RequestBase
    {
        if (request.Source is null)
            request.Source = defaultSource;

        return request;
    }

    /// <summary>
    /// Verifica se a requisição é válida para processamento.
    /// </summary>
    /// <param name="request">Request alvo.</param>
    /// <exception cref="ArgumentException">
    /// Lançada caso algum campo essencial não esteja definido.
    /// </exception>
    public static void Validate(this RequestBase request)
    {
        if (request.CorrelationId is null)
            throw new ArgumentException("CorrelationId é obrigatório.", nameof(request.CorrelationId));

        if (request.Timestamp is null)
            throw new ArgumentException("Timestamp é obrigatório.", nameof(request.Timestamp));

        if (request.Source is null)
            throw new ArgumentException("Source é obrigatório.", nameof(request.Source));
    }
}
