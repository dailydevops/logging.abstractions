namespace NetEvolve.Logging.Abstractions;

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

/// <summary>
/// Represents a logged message, including the timestamp, log level, event ID, message, exception, and scopes.
/// </summary>
/// <param name="Timestamp">Timestamp of the logged message.</param>
/// <param name="LogLevel">LogLevel of the logged message.</param>
/// <param name="EventId">EventId of the logged message.</param>
/// <param name="Message">Logged message.</param>
/// <param name="Exception">Logged exception. (optional)</param>
/// <param name="Scopes">Logged scopes.</param>
public readonly record struct LoggedMessage(
    DateTimeOffset Timestamp,
    LogLevel LogLevel,
    EventId EventId,
    string Message,
    Exception? Exception = null,
    IReadOnlyCollection<object?>? Scopes = null
);
