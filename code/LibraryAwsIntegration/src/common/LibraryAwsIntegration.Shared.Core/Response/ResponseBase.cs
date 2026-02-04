using LibraryAwsIntegration.Core.ValueObjects;
using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Core.Response;

/// <summary>
/// Define o contrato base de resposta para todas as operações
/// expostas pelos componentes da <c>LibraryAwsIntegration</c>.
///
/// Este contrato estabelece um padrão corporativo único para
/// comunicação de resultados, garantindo consistência,
/// rastreabilidade e previsibilidade entre todos os componentes.
///
/// O modelo de resposta separa explicitamente:
/// <list type="bullet">
///   <item>
///     <description>
///     Falhas esperadas de negócio, representadas por <see cref="OperationResult"/>.
///     </description>
///   </item>
///   <item>
///     <description>
///     Falhas técnicas, que devem ser propagadas exclusivamente
///     por meio de exceções.
///     </description>
///   </item>
/// </list>
///
/// O <see cref="ResponseBase"/> é neutro em relação a provider,
/// protocolo ou tecnologia, podendo ser utilizado de forma
/// consistente em qualquer componente da biblioteca.
/// </summary>
public abstract class ResponseBase
{
    /// <summary>
    /// Resultado da operação executada.
    ///
    /// Indica sucesso ou falha controlada, sem representar
    /// exceções técnicas ou erros inesperados.
    /// </summary>
    public OperationResult Result { get; init; } = OperationResult.Success();

    /// <summary>
    /// Mensagem descritiva associada ao resultado da operação.
    ///
    /// Pode ser utilizada para fins de logging, auditoria
    /// ou comunicação contextual com o consumidor.
    /// </summary>
    public ResponseMessage? Message { get; init; }

    /// <summary>
    /// Identificador de correlação utilizado para rastrear
    /// a execução da operação ao longo de múltiplas camadas
    /// e componentes do sistema.
    /// </summary>
    public CorrelationId? CorrelationId { get; init; }

    /// <summary>
    /// Instante em que a resposta foi gerada.
    ///
    /// O valor é padronizado em UTC para garantir
    /// consistência, auditoria e observabilidade.
    /// </summary>
    public ResponseTimestamp Timestamp { get; init; } = ResponseTimestamp.Now();
}

/// <summary>
/// Define o contrato base de resposta para operações
/// que produzem um resultado de dados.
///
/// Estende o <see cref="ResponseBase"/> adicionando
/// um payload tipado, mantendo o mesmo padrão corporativo
/// de comunicação de resultados.
/// </summary>
/// <typeparam name="T">
/// Tipo do dado retornado pela operação.
/// </typeparam>
public abstract class ResponseBase<T> : ResponseBase
{
    /// <summary>
    /// Dados retornados pela operação.
    ///
    /// Pode ser nulo em cenários de falha controlada
    /// ou quando a operação não produz um resultado.
    /// </summary>
    public T? Data { get; init; }
}
