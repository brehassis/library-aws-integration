using System;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para criação,
/// validação e normalização de identificadores GUID.
/// </summary>
/// <remarks>
/// Centraliza regras de uso de GUIDs na arquitetura,
/// garantindo consistência de formato, segurança
/// para entradas externas e integração com
/// mecanismos de rastreabilidade.
/// </remarks>
public static class GuidExtensions
{
    /// <summary>
    /// Cria um novo <see cref="Guid"/> no formato
    /// normalizado sem separadores (<c>N</c>).
    /// </summary>
    /// <returns>
    /// String representando um GUID válido
    /// no formato <c>N</c>.
    /// </returns>
    /// <remarks>
    /// Este formato é preferido para headers,
    /// correlação e transmissão entre serviços.
    /// </remarks>
    public static string NewGuidString()
        => Guid.NewGuid().ToString("N");

    /// <summary>
    /// Verifica se a string representa um GUID válido.
    /// </summary>
    /// <param name="value">Valor textual.</param>
    /// <returns>
    /// <c>true</c> se for um GUID válido;
    /// caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsValidGuid(this string? value)
        => Guid.TryParse(value, out _);

    /// <summary>
    /// Garante que a string represente um GUID válido.
    /// </summary>
    /// <param name="value">Valor textual.</param>
    /// <param name="parameterName">Nome do parâmetro.</param>
    /// <returns>
    /// <see cref="Guid"/> correspondente.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Lançada quando o valor não representa um GUID válido.
    /// </exception>
    /// <remarks>
    /// Deve ser usado em boundaries de entrada
    /// (requests, headers, payloads externos).
    /// </remarks>
    public static Guid EnsureValidGuid(this string? value, string parameterName)
    {
        if (!Guid.TryParse(value, out var guid))
            throw new ArgumentException(
                $"{parameterName} deve conter um identificador GUID válido.",
                parameterName);

        return guid;
    }

    /// <summary>
    /// Normaliza um <see cref="Guid"/> para string
    /// no formato arquitetural padrão (<c>N</c>).
    /// </summary>
    /// <param name="guid">GUID a ser normalizado.</param>
    /// <returns>
    /// Representação textual normalizada.
    /// </returns>
    public static string ToNormalizedString(this Guid guid)
        => guid.ToString("N");
}
