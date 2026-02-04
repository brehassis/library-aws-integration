using LibraryAwsIntegration.Shared.Core.ValueObjects;

namespace LibraryAwsIntegration.Core.Request;

/// <summary>
/// Contrato base de requisição para todos os componentes
/// da LibraryAwsIntegration.
///
/// Representa a intenção de execução de uma operação,
/// encapsulando apenas metadados transversais necessários
/// para rastreabilidade, auditoria e padronização.
///
/// Não deve conter lógica de negócio nem dependência
/// de providers específicos.
/// </summary>
public abstract class RequestBase
{
    /// <summary>
    /// Identificador de correlação utilizado para rastrear
    /// a requisição ao longo de múltiplos componentes
    /// e serviços da aplicação.
    /// </summary>
    public CorrelationId? CorrelationId { get; init; }

    /// <summary>
    /// Origem da requisição.
    /// 
    /// Pode representar o sistema, serviço ou aplicação
    /// consumidora da LibraryAwsIntegration.
    /// </summary>
    public RequestSourceVO? Source { get; init; }

    /// <summary>
    /// Data e hora em que a requisição foi criada.
    /// 
    /// Utiliza UTC como padrão corporativo.
    /// </summary>
    public RequestTimestampVO Timestamp { get; init; } = RequestTimestampVO.Now();
}

/// <summary>
/// Contrato base de requisição para operações
/// que transportam dados.
///
/// Deve ser utilizado quando a operação exige
/// um payload explícito para execução.
/// </summary>
/// <typeparam name="T">
/// Tipo do payload transportado pela requisição.
/// </typeparam>
public abstract class RequestBase<T> : RequestBase
{
    /// <summary>
    /// Dados necessários para a execução da operação.
    /// </summary>
    public T Data { get; init; } = default!;
}

