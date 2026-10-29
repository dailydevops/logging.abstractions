namespace NetEvolve.Logging.Abstractions.Tests.Unit;

using System.Threading.Tasks;

public class NullScopeTests
{
    [Test]
    public async Task Instance_ReturnsSameInstance_Expected()
    {
        // Arrange
        var instance1 = NullScope.Instance;
        var instance2 = NullScope.Instance;

        // Assert
        using (Assert.Multiple())
        {
            _ = await Assert.That(instance1).IsTypeOf<NullScope>();
            _ = await Assert.That(instance1).IsSameReferenceAs(instance2);
        }
    }

    [Test]
    public async Task Dispose_CalledTwice_NoExceptionIsThrown()
    {
        // Arrange
        var scope = NullScope.Instance;

        // Act
        _ = await Assert
            .That(() =>
            {
                scope.Dispose();
                scope.Dispose();
            })
            .ThrowsNothing();
    }
}
