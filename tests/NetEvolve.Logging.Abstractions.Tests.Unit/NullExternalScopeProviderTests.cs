namespace NetEvolve.Logging.Abstractions.Tests.Unit;

using System.Collections.Generic;
using Xunit;

public class NullExternalScopeProviderTests
{
    [Fact]
    public void Instance_ReturnsSameInstance_Expected()
    {
        // Arrange
        var instance1 = NullExternalScopeProvider.Instance;
        var instance2 = NullExternalScopeProvider.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void ForEachScope_DoNothing_NoExceptionIsThrown()
    {
        // Arrange
        var provider = NullExternalScopeProvider.Instance;
        var state = new Dictionary<string, object?> { { "Hello World!", null } };

        // Act
        var ex = Record.Exception(() => provider.ForEachScope((_, _) => { }, state));

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void Push_ReturnsNullScope_Expected()
    {
        // Arrange
        var provider = NullExternalScopeProvider.Instance;

        // Act
        var ex = Record.Exception(() =>
        {
            using var scope = provider.Push(null);

            Assert.NotNull(scope);
            _ = Assert.IsType<NullScope>(scope);
        });

        // Assert
        Assert.Null(ex);
    }
}
