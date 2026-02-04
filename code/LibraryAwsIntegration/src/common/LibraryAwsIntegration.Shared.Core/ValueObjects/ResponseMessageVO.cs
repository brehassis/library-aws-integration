using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Mensagem descritiva associada ao resultado da operação.
/// </summary>
public sealed record ResponseMessage
{
    public string Value { get; }

    public ResponseMessage(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ResponseMessage não pode ser nula ou vazia.", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;
}
