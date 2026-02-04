using System.ComponentModel;

namespace LibraryAwsIntegration.Shared.Core.Enums;

/// <summary>
/// Define o tipo de componente responsável pela execução
/// de uma operação dentro da LibraryAwsIntegration.
///
/// Este enum é utilizado para identificar de forma
/// padronizada o contexto funcional da operação,
/// auxiliando em logging, rastreabilidade, tratamento
/// de exceções e observabilidade entre componentes.
///
/// Os valores representam categorias lógicas de
/// componentes e não implementações específicas
/// ou tecnologias subjacentes.
/// </summary>
public enum EComponentType
{
    /// <summary>
    /// Tipo de componente não identificado ou não informado.
    /// </summary>
    [DescriptionAttribute("Desconecido")]
    Unknown = 0,

    /// <summary>
    /// Componente responsável por operações de armazenamento
    /// de dados, arquivos ou objetos.
    /// </summary>
    [DescriptionAttribute("Armazenamento")]
    Storage = 1,

    /// <summary>
    /// Componente responsável por operações de acesso,
    /// persistência e consulta a bases de dados.
    /// </summary>
    [DescriptionAttribute("Banco de dados")]
    Database = 2,

    /// <summary>
    /// Componente responsável por operações de mensageria,
    /// publicação e consumo de mensagens ou eventos.
    /// </summary>
    [DescriptionAttribute("Mensageria")]
    Messaging = 3,

    /// <summary>
    /// Componente responsável por operações de execução
    /// computacional, processamento ou workloads.
    /// </summary>
    [DescriptionAttribute("Computação")]
    Compute = 4
}
