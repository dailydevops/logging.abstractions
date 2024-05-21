namespace NetEvolve.Logging.Abstractions;

using System.Collections.Generic;

/// <summary>
/// Gives access to the logged messages.
/// </summary>
public interface IHasLoggedMessages
{
    /// <summary>
    /// Gets the logged messages, in the order they were logged.
    /// </summary>
    IReadOnlyList<LoggedMessage> LoggedMessages { get; }
}
