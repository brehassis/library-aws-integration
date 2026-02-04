using System;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para validação,
/// normalização e verificação semântica de strings.
/// </summary>
/// <remarks>
/// Centraliza regras comuns de manipulação de texto,
/// evitando duplicação de validações e garantindo
/// consistência em contratos públicos, requests,
/// value objects e integrações externas.
/// </remarks>
public static class StringExtensions
{
    /// <summary>
    /// Verifica se a string é nula, vazia ou composta
    /// apenas por espaços em branco.
    /// </summary>
    /// <param name="value">Valor da string.</param>
    /// <returns>
    /// <c>true</c> se a string for nula, vazia ou whitespace;
    /// caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsNullOrWhiteSpace(this string? value)
        => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Verifica se a string possui um valor significativo
    /// (não nulo, não vazio e não whitespace).
    /// </summary>
    /// <param name="value">Valor da string.</param>
    /// <returns>
    /// <c>true</c> se a string contiver conteúdo válido;
    /// caso contrário, <c>false</c>.
    /// </returns>
    public static bool HasValue(this string? value)
        => !string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Normaliza a string removendo espaços excedentes
    /// no início e no fim.
    /// </summary>
    /// <param name="value">Valor da string.</param>
    /// <returns>
    /// A string normalizada ou <c>null</c> caso o valor
    /// original seja nulo.
    /// </returns>
    /// <remarks>
    /// Não altera o conteúdo interno da string.
    /// Ideal para entrada de dados externos.
    /// </remarks>
    public static string? Normalize(this string? value)
        => value?.Trim();

    /// <summary>
    /// Retorna <c>null</c> caso a string seja nula,
    /// vazia ou whitespace; caso contrário, retorna
    /// o valor normalizado.
    /// </summary>
    /// <param name="value">Valor da string.</param>
    /// <returns>
    /// String normalizada ou <c>null</c>.
    /// </returns>
    /// <remarks>
    /// Útil para evitar persistência de strings vazias
    /// e simplificar validações em requests.
    /// </remarks>
    public static string? NullIfEmpty(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return value.Trim();
    }

    /// <summary>
    /// Garante que a string possua valor válido,
    /// lançando exceção caso contrário.
    /// </summary>
    /// <param name="value">Valor da string.</param>
    /// <param name="parameterName">Nome do parâmetro.</param>
    /// <returns>
    /// A string normalizada.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Lançada quando o valor é nulo, vazio ou whitespace.
    /// </exception>
    /// <remarks>
    /// Ideal para validação de contratos públicos,
    /// construtores de Value Objects e boundaries do Core.
    /// </remarks>
    public static string EnsureHasValue(this string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(
                $"{parameterName} não pode ser nulo, vazio ou conter apenas espaços.",
                parameterName);

        return value.Trim();
    }
}
