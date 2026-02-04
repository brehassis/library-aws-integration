using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Identificador de correlação utilizado para rastrear
/// uma operação ao longo de múltiplas camadas e serviços.
/// </summary>
public sealed record CorrelationId
{
    public string Value { get; }

    public CorrelationId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("CorrelationId não pode ser nulo ou vazio.", nameof(value));

        Value = value;
    }

    public static CorrelationId New() => new(Guid.NewGuid().ToString("N"));

    public override string ToString() => Value;
}
