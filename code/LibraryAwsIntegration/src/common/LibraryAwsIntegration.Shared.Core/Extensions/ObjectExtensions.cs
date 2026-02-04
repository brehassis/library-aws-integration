using System;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão universais para objetos,
/// permitindo validação, comparações e operações seguras.
/// </summary>
/// <remarks>
/// Centraliza regras comuns de manipulação de objetos,
/// garantindo consistência, expressividade e segurança
/// em todos os componentes da LibraryAwsIntegration.
/// </remarks>
public static class ObjectExtensions
{
    /// <summary>
    /// Verifica se o objeto é nulo.
    /// </summary>
    /// <param name="obj">Objeto a ser verificado.</param>
    /// <returns>
    /// <c>true</c> se o objeto for nulo; caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsNull(this object? obj)
        => obj is null;

    /// <summary>
    /// Verifica se o objeto não é nulo.
    /// </summary>
    /// <param name="obj">Objeto a ser verificado.</param>
    /// <returns>
    /// <c>true</c> se o objeto não for nulo; caso contrário, <c>false</c>.
    /// </returns>
    public static bool IsNotNull(this object? obj)
        => obj is not null;

    /// <summary>
    /// Retorna o objeto ou lança uma exceção caso seja nulo.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto.</typeparam>
    /// <param name="obj">Objeto a ser validado.</param>
    /// <param name="paramName">Nome do parâmetro.</param>
    /// <returns>
    /// O objeto se não for nulo.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Lançada quando o objeto é nulo.
    /// </exception>
    public static T EnsureNotNull<T>(this T? obj, string paramName)
        where T : class
    {
        if (obj is null)
            throw new ArgumentNullException(paramName, $"{paramName} não pode ser nulo.");

        return obj;
    }

    /// <summary>
    /// Retorna o objeto ou o valor padrão caso seja nulo.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto.</typeparam>
    /// <param name="obj">Objeto a ser verificado.</param>
    /// <param name="defaultValue">Valor padrão.</param>
    /// <returns>
    /// O objeto ou o valor padrão se for nulo.
    /// </returns>
    public static T? OrDefault<T>(this T? obj, T? defaultValue = default)
        => obj ?? defaultValue;

    /// <summary>
    /// Executa uma ação sobre o objeto se ele não for nulo.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto.</typeparam>
    /// <param name="obj">Objeto alvo.</param>
    /// <param name="action">Ação a ser executada.</param>
    public static void IfNotNull<T>(this T? obj, Action<T> action)
        where T : class
    {
        if (obj is not null)
            action(obj);
    }
}
