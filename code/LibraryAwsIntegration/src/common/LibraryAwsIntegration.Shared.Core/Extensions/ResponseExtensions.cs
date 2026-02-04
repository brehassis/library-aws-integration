using System;
using LibraryAwsIntegration.Core.Response;
using LibraryAwsIntegration.Shared.Core.Enums;
using LibraryAwsIntegration.Shared.Core.Exceptions;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para construção,
/// validação e manipulação de respostas base.
/// </summary>
/// <remarks>
/// Centraliza regras comuns para ResponseBase e ResponseBase<T>,
/// garantindo consistência, rastreabilidade e padronização
/// em todos os componentes da LibraryAwsIntegration.
/// </remarks>
public static class ResponseExtensions
{
    /// <summary>
    /// Inicializa uma resposta de sucesso com dados.
    /// </summary>
    /// <typeparam name="T">Tipo do payload.</typeparam>
    /// <param name="data">Dados da resposta.</param>
    /// <returns>Instância de ResponseBase<T> configurada como sucesso.</returns>
    public static ResponseBase<T> Success<T>(this T data)
    {
        return new SuccessResponse<T>(data);
    }

    /// <summary>
    /// Inicializa uma resposta de falha com mensagem e tipo de falha.
    /// </summary>
    /// <param name="exception">Exceção ocorrida.</param>
    /// <returns>Instância de ResponseBase configurada como falha.</returns>
    public static ResponseBase Fail(this Exception exception)
    {
        return new ResponseBase
        {
            Result = OperationResult.Failure(),
            Message = exception.ToResponseMessage(),
            CorrelationId = CorrelationId.New(),
            Timestamp = ResponseTimestamp.Now()
        };
    }

    /// <summary>
    /// Inicializa uma resposta de falha genérica com mensagem customizada.
    /// </summary>
    /// <param name="message">Mensagem da falha.</param>
    /// <returns>Instância de ResponseBase configurada como falha.</returns>
    public static ResponseBase Fail(this string message)
    {
        return new ResponseBase
        {
            Result = OperationResult.Failure(),
            Message = new ResponseMessage(message),
            CorrelationId = CorrelationId.New(),
            Timestamp = ResponseTimestamp.Now()
        };
    }

    /// <summary>
    /// Helper para criar ResponseBase<T> de sucesso.
    /// </summary>
    /// <typeparam name="T">Tipo de dado.</typeparam>
    private sealed class SuccessResponse<T> : ResponseBase<T>
    {
        public SuccessResponse(T data)
        {
            Data = data;
            Result = OperationResult.Success();
            Timestamp = ResponseTimestamp.Now();
            CorrelationId = CorrelationId.New();
        }
    }
}
