namespace NetEvolve.Logging.Abstractions;

using System;

/// <summary>
/// Scope that does nothing.
/// </summary>
public sealed class NullScope : IDisposable
{
    private static readonly Lazy<IDisposable> _instance = new(() => new NullScope());

    /// <summary>
    /// Returns a cached instance of <see cref="NullScope"/>.
    /// </summary>
    public static IDisposable Instance => _instance.Value;

    private NullScope() { }

    /// <inheritdoc cref="IDisposable.Dispose" />
    public void Dispose() { }
}
