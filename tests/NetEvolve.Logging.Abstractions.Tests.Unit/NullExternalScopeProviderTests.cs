namespace NetEvolve.Logging.Abstractions.Tests.Unit;

using System.Collections.Generic;
using System.Threading.Tasks;

public class NullExternalScopeProviderTests
{
    [Test]
    public async Task Instance_ReturnsSameInstance_Expected()
    {
        // Arrange
        var instance1 = NullExternalScopeProvider.Instance;
        var instance2 = NullExternalScopeProvider.Instance;

        // Assert
        _ = await Assert.That(instance1).IsSameReferenceAs(instance2);
    }

    [Test]
    public async Task ForEachScope_DoNothing_NoExceptionIsThrown()
    {
        // Arrange
        var provider = NullExternalScopeProvider.Instance;
        var state = new Dictionary<string, object?> { { "Hello World!", null } };

        // Act
        _ = await Assert.That(() => provider.ForEachScope((_, _) => { }, state)).ThrowsNothing();
    }

    [Test]
    public async Task Push_ReturnsNullScope_Expected()
    {
        // Arrange
        var provider = NullExternalScopeProvider.Instance;

        // Act
        _ = await Assert
            .That(async () =>
            {
                using var scope = provider.Push("Some State");
                _ = await Assert.That(scope).IsNotNull().And.IsTypeOf<NullScope>();
            })
            .ThrowsNothing();
    }
}
