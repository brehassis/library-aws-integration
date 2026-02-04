namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa uma mensagem descritiva associada
/// ao resultado de uma operação.
///
/// Encapsula um texto explicativo utilizado para
/// fornecer contexto adicional sobre o sucesso
/// ou a falha controlada de uma execução,
/// garantindo padronização e clareza na comunicação
/// entre componentes da LibraryAwsIntegration.
///
/// Este Value Object existe para evitar o uso direto
/// de tipos primitivos como <see cref="string"/>
/// nos contratos de resposta da arquitetura.
/// </summary>
public sealed record ResponseMessage
{
    public string Value { get; }

    public ResponseMessage(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(
                "ResponseMessage não pode ser nula ou vazia.",
                nameof(value));

        Value = value;
    }

    public override string ToString() => Value;
}
