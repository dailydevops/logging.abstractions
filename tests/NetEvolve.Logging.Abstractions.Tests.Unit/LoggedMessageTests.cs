namespace NetEvolve.Logging.Abstractions.Tests.Unit;

using System;
using Microsoft.Extensions.Logging;

public class LoggedMessageTests
{
    [Test]
    public async Task Constructor_WithoutScopes_Expected()
    {
        // Arrange
        var timestamp = DateTimeOffset.Now;
        var logLevel = LogLevel.Information;
        var message = "Hello World!";
        var eventId = new EventId(1, nameof(Constructor_WithoutScopes_Expected));

        // Act
        var loggedMessage = new LoggedMessage(timestamp, logLevel, eventId, message);

        // Assert
        using (Assert.Multiple())
        {
            _ = await Assert.That(loggedMessage.Timestamp).IsEqualTo(timestamp);
            _ = await Assert.That(loggedMessage.LogLevel).IsEqualTo(logLevel);
            _ = await Assert.That(loggedMessage.EventId).IsEqualTo(eventId);
            _ = await Assert.That(loggedMessage.Message).IsEqualTo(message);
            _ = await Assert.That(loggedMessage.Exception).IsNull();
            _ = await Assert.That(loggedMessage.Scopes).IsNull();
        }
    }

    [Test]
    public async Task Constructor_WithExceptionAndScopes_Expected()
    {
        // Arrange
        var exception = new InvalidOperationException();
        var scopes = new object?[] { "a", null };

        // Act
        var loggedMessage = new LoggedMessage(
            DateTimeOffset.Now,
            LogLevel.Error,
            new EventId(2, nameof(Constructor_WithExceptionAndScopes_Expected)),
            "Hello World!",
            exception,
            scopes
        );

        // Assert
        using (Assert.Multiple())
        {
            _ = await Assert.That(loggedMessage.Exception).IsSameReferenceAs(exception);
            _ = await Assert.That(loggedMessage.Scopes).IsSameReferenceAs(scopes);
        }
    }
}
