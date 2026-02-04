using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Extensões utilitárias para manipulação segura e padronizada
/// de enums na LibraryAwsIntegration.
///
/// Centraliza operações comuns como conversão, validação
/// e leitura de metadados, evitando duplicação de lógica
/// entre componentes.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Verifica se o valor informado está definido
    /// no enum especificado.
    /// </summary>
    public static bool IsDefined<TEnum>(this TEnum value)
        where TEnum : struct, Enum
        => Enum.IsDefined(typeof(TEnum), value);

    /// <summary>
    /// Converte o enum para sua representação inteira.
    /// </summary>
    public static int ToInt<TEnum>(this TEnum value)
        where TEnum : struct, Enum
        => Convert.ToInt32(value, CultureInfo.InvariantCulture);

    /// <summary>
    /// Retorna o nome do enum ou uma string padrão
    /// caso o valor não esteja definido.
    /// </summary>
    public static string ToSafeString<TEnum>(
        this TEnum value,
        string fallback = "Unknown")
        where TEnum : struct, Enum
        => value.IsDefined() ? value.ToString() : fallback;

    /// <summary>
    /// Converte uma string para enum de forma segura.
    /// </summary>
    /// <typeparam name="TEnum">Tipo do enum</typeparam>
    /// <param name="value">Valor textual</param>
    /// <param name="ignoreCase">Ignorar case</param>
    public static TEnum ParseOrDefault<TEnum>(
        this string value,
        TEnum defaultValue,
        bool ignoreCase = true)
        where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            return defaultValue;

        return Enum.TryParse<TEnum>(value, ignoreCase, out var result)
            && result.IsDefined()
            ? result
            : defaultValue;
    }

    /// <summary>
    /// Tenta converter uma string para enum.
    /// </summary>
    public static bool TryParseEnum<TEnum>(
        this string value,
        out TEnum result,
        bool ignoreCase = true)
        where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, ignoreCase, out result)
            && result.IsDefined())
            return true;

        result = default;
        return false;
    }

    /// <summary>
    /// Retorna a descrição associada ao enum,
    /// caso exista o atributo <see cref="DescriptionAttribute"/>.
    /// </summary>
    public static string GetDescription<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        var member = typeof(TEnum)
            .GetMember(value.ToString());

        if (member.Length == 0)
            return value.ToString();

        var attribute = member[0]
            .GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
}
