namespace NetEvolve.Logging.Abstractions.Tests.Unit;

using System;
using Microsoft.Extensions.Logging;
using Xunit;

public class LoggedMessageTests
{
    [Fact]
    public void Constructor_WithoutScopes_Expected()
    {
        // Arrange
        var timestamp = DateTimeOffset.Now;
        var logLevel = LogLevel.Information;
        var message = "Hello World!";
        var eventId = new EventId(1, nameof(Constructor_WithoutScopes_Expected));

        // Act
        var loggedMessage = new LoggedMessage(timestamp, logLevel, eventId, message);

        // Assert
        Assert.Equal(timestamp, loggedMessage.Timestamp);
        Assert.Equal(logLevel, loggedMessage.LogLevel);
        Assert.Equal(eventId, loggedMessage.EventId);
        Assert.Equal(message, loggedMessage.Message);
        Assert.Null(loggedMessage.Exception);
        Assert.Null(loggedMessage.Scopes);
    }
}
