namespace NetEvolve.Logging.Abstractions;

using System;
using Microsoft.Extensions.Logging;

/// <summary>
/// Scope provider that does nothing, used when no scope provider is available.
/// </summary>
public sealed class NullExternalScopeProvider : IExternalScopeProvider
{
    private static readonly Lazy<IExternalScopeProvider> _instance = new(() => new NullExternalScopeProvider());

    private NullExternalScopeProvider() { }

    /// <summary>
    /// Returns a cached instance of <see cref="NullExternalScopeProvider"/>.
    /// </summary>
    public static IExternalScopeProvider Instance => _instance.Value;

    /// <inheritdoc cref="IExternalScopeProvider.ForEachScope{TState}(Action{object?, TState}, TState)" />
    public void ForEachScope<TState>(Action<object?, TState> callback, TState state) { }

    /// <inheritdoc cref="IExternalScopeProvider.Push(object?)" />
    public IDisposable Push(object? state) => new NullScope();
}
