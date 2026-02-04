using System;
using System.Collections.Generic;

namespace LibraryAwsIntegration.Shared.Core.Extensions;

/// <summary>
/// Fornece métodos de extensão para manipulação
/// segura e padronizada de dicionários.
/// </summary>
/// <remarks>
/// Permite validação, inserção, remoção e recuperação
/// de valores de forma segura e consistente em todos
/// os componentes da LibraryAwsIntegration.
/// </remarks>
public static class DictionaryExtensions
{
    /// <summary>
    /// Retorna o valor associado à chave ou um valor padrão
    /// caso a chave não exista ou o dicionário seja nulo.
    /// </summary>
    /// <typeparam name="TKey">Tipo da chave.</typeparam>
    /// <typeparam name="TValue">Tipo do valor.</typeparam>
    /// <param name="dictionary">Dicionário alvo.</param>
    /// <param name="key">Chave a ser buscada.</param>
    /// <param name="defaultValue">Valor padrão a ser retornado.</param>
    /// <returns>Valor associado ou defaultValue.</returns>
    public static TValue? GetValueOrDefault<TKey, TValue>(
        this IDictionary<TKey, TValue>? dictionary,
        TKey key,
        TValue? defaultValue = default)
    {
        if (dictionary == null || key == null)
            return defaultValue;

        return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
    }

    /// <summary>
    /// Adiciona um par chave-valor ao dicionário apenas
    /// se a chave ainda não estiver presente.
    /// </summary>
    /// <typeparam name="TKey">Tipo da chave.</typeparam>
    /// <typeparam name="TValue">Tipo do valor.</typeparam>
    /// <param name="dictionary">Dicionário alvo.</param>
    /// <param name="key">Chave a ser adicionada.</param>
    /// <param name="value">Valor associado à chave.</param>
    /// <returns><c>true</c> se adicionado; <c>false</c> caso contrário.</returns>
    public static bool AddIfNotExists<TKey, TValue>(
        this IDictionary<TKey, TValue>? dictionary,
        TKey key,
        TValue value)
    {
        if (dictionary == null || key == null)
            return false;

        if (dictionary.ContainsKey(key))
            return false;

        dictionary.Add(key, value);
        return true;
    }

    /// <summary>
    /// Remove a chave do dicionário de forma segura,
    /// sem lançar exceção caso o dicionário seja nulo
    /// ou a chave não exista.
    /// </summary>
    /// <typeparam name="TKey">Tipo da chave.</typeparam>
    /// <typeparam name="TValue">Tipo do valor.</typeparam>
    /// <param name="dictionary">Dicionário alvo.</param>
    /// <param name="key">Chave a ser removida.</param>
    /// <returns><c>true</c> se a chave existia e foi removida; <c>false</c> caso contrário.</returns>
    public static bool RemoveSafe<TKey, TValue>(
        this IDictionary<TKey, TValue>? dictionary,
        TKey key)
    {
        if (dictionary == null || key == null)
            return false;

        return dictionary.Remove(key);
    }

    /// <summary>
    /// Verifica se o dicionário contém a chave de forma segura.
    /// </summary>
    /// <typeparam name="TKey">Tipo da chave.</typeparam>
    /// <typeparam name="TValue">Tipo do valor.</typeparam>
    /// <param name="dictionary">Dicionário alvo.</param>
    /// <param name="key">Chave a ser verificada.</param>
    /// <returns><c>true</c> se a chave existir; <c>false</c> caso contrário.</returns>
    public static bool ContainsKeySafe<TKey, TValue>(
        this IDictionary<TKey, TValue>? dictionary,
        TKey key)
    {
        if (dictionary == null || key == null)
            return false;

        return dictionary.ContainsKey(key);
    }
}
