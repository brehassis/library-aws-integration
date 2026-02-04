using System.ComponentModel;

namespace LibraryAwsIntegration.Shared.Core.Enums;

/// <summary>
/// Define o tipo de falha associada a uma operação executada
/// por um componente da LibraryAwsIntegration.
///
/// Este enum é utilizado para classificar falhas de forma
/// padronizada, permitindo diferenciação clara entre
/// falhas de negócio e falhas técnicas, bem como suporte
/// a observabilidade, métricas e estratégias de resiliência.
/// </summary>
public enum EFailureType
{
    /// <summary>
    /// Indica que não houve falha associada à operação.
    /// Utilizado quando a execução é bem-sucedida.
    /// </summary>
    [DescriptionAttribute("Nenhuma falha")]
    None = 0,

    /// <summary>
    /// Representa uma falha de negócio esperada.
    ///
    /// Este tipo de falha não indica erro técnico e
    /// não deve gerar exceções, sendo normalmente
    /// refletido em respostas controladas.
    /// </summary>
    [DescriptionAttribute("Falha de negócio")]
    Business = 1,

    /// <summary>
    /// Representa uma falha técnica inesperada.
    ///
    /// Inclui erros de infraestrutura, falhas de execução
    /// ou comportamentos não previstos que devem ser
    /// tratados por exceções.
    /// </summary>
    [DescriptionAttribute("Falha técnica")]
    Technical = 2,

    /// <summary>
    /// Representa uma falha causada por estouro de tempo
    /// de execução (timeout).
    ///
    /// Pode ocorrer em chamadas externas, operações
    /// assíncronas ou dependências remotas.
    /// </summary>
    [DescriptionAttribute("Falha de timeout")]
    Timeout = 3,

    /// <summary>
    /// Representa uma falha originada em uma dependência
    /// externa ao componente.
    ///
    /// Exemplos incluem serviços de terceiros, bancos
    /// de dados, filas ou sistemas externos.
    /// </summary>
    [DescriptionAttribute("Falha de dependência")]
    Dependency = 4
}
