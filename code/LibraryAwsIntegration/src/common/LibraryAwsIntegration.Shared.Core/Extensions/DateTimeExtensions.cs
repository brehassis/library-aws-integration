using System;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para manipulação,
/// normalização e comparação segura de datas e horários.
/// </summary>
/// <remarks>
/// Centraliza regras temporais da arquitetura,
/// garantindo padronização em UTC e evitando erros
/// comuns relacionados a fuso horário, comparação
/// imprecisa e uso inconsistente de tipos temporais.
/// </remarks>
public static class DateTimeExtensions
{
    /// <summary>
    /// Converte um <see cref="DateTime"/> para UTC,
    /// respeitando o <see cref="DateTimeKind"/>.
    /// </summary>
    /// <param name="dateTime">Data a ser convertida.</param>
    /// <returns>
    /// Instância de <see cref="DateTime"/> normalizada em UTC.
    /// </returns>
    /// <remarks>
    /// Caso o <see cref="DateTimeKind"/> seja <c>Unspecified</c>,
    /// o valor é tratado como UTC por convenção arquitetural.
    /// </remarks>
    public static DateTime ToUtc(this DateTime dateTime)
    {
        return dateTime.Kind switch
        {
            DateTimeKind.Utc => dateTime,
            DateTimeKind.Local => dateTime.ToUniversalTime(),
            _ => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
        };
    }

    /// <summary>
    /// Normaliza um <see cref="DateTimeOffset"/> para UTC.
    /// </summary>
    /// <param name="dateTimeOffset">Data a ser normalizada.</param>
    /// <returns>
    /// Instância de <see cref="DateTimeOffset"/> em UTC.
    /// </returns>
    public static DateTimeOffset ToUtc(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToUniversalTime();

    /// <summary>
    /// Verifica se a data representa um valor no passado
    /// em relação ao instante atual em UTC.
    /// </summary>
    /// <param name="dateTime">Data a ser avaliada.</param>
    /// <returns>
    /// <c>true</c> se estiver no passado; caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsInPast(this DateTimeOffset dateTime)
        => dateTime.ToUniversalTime() < DateTimeOffset.UtcNow;

    /// <summary>
    /// Verifica se a data representa um valor no futuro
    /// em relação ao instante atual em UTC.
    /// </summary>
    /// <param name="dateTime">Data a ser avaliada.</param>
    /// <returns>
    /// <c>true</c> se estiver no futuro; caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsInFuture(this DateTimeOffset dateTime)
        => dateTime.ToUniversalTime() > DateTimeOffset.UtcNow;

    /// <summary>
    /// Compara duas datas considerando apenas precisão
    /// de segundos.
    /// </summary>
    /// <param name="first">Primeira data.</param>
    /// <param name="second">Segunda data.</param>
    /// <returns>
    /// <c>true</c> se forem equivalentes em segundos.
    /// </returns>
    /// <remarks>
    /// Útil para integrações externas, logs e sistemas
    /// que não preservam precisão de milissegundos.
    /// </remarks>
    public static bool EqualsBySecond(this DateTimeOffset first, DateTimeOffset second)
    {
        var a = first.ToUniversalTime();
        var b = second.ToUniversalTime();

        return a.Year == b.Year
            && a.Month == b.Month
            && a.Day == b.Day
            && a.Hour == b.Hour
            && a.Minute == b.Minute
            && a.Second == b.Second;
    }

    /// <summary>
    /// Retorna o instante atual em UTC como <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <returns>
    /// Instante atual em UTC.
    /// </returns>
    /// <remarks>
    /// Deve ser preferido ao uso direto de
    /// <see cref="DateTimeOffset.UtcNow"/> fora do Core.
    /// </remarks>
    public static DateTimeOffset UtcNow()
        => DateTimeOffset.UtcNow;
}
