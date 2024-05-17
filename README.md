# NetEvolve.Logging.Abstractions

This library provides some extensions to the `Microsoft.Extensions.Logging` library. It is intended to be used in conjunction further libraries that provide more specific logging implementations.

## Provided Types & Extensions

- `LoggedMessage` - A simple class that represents a message that has been logged. It contains the message, the log level, and the exception that was thrown (if any).
- `NullExternalScopeProvider` - An implementation of `IExternalScopeProvider` that does nothing.
- `NullScope` - An implementation of `IDisposable` that does nothing.