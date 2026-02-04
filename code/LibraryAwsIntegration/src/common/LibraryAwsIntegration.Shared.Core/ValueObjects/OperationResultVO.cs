using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAwsIntegration.Shared.Core.ValueObjects;

/// <summary>
/// Representa o resultado de uma operação.
/// Encapsula o conceito de sucesso ou falha controlada.
/// </summary>
public sealed record OperationResult
{
    public bool IsSuccess { get; }

    private OperationResult(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public static OperationResult Success() => new(true);
    public static OperationResult Failure() => new(false);
}
