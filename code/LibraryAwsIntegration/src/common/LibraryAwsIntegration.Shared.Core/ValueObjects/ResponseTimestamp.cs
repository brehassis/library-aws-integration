using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa o instante em que a resposta foi gerada.
/// Padronizado em UTC.
/// </summary>
public sealed record ResponseTimestamp
{
    public DateTimeOffset Value { get; }

    public ResponseTimestamp(DateTimeOffset value)
    {
        Value = value.ToUniversalTime();
    }

    public static ResponseTimestamp Now() => new(DateTimeOffset.UtcNow);
}
