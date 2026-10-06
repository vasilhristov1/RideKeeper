using RideKeeper.Domain.Common;

namespace RideKeeper.Domain.UnitTests;

public class ResultTests
{
    [Fact]
    public void Success_ExposesValue()
    {
        var result = Result<int>.Success(42);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
        result.Error.Should().BeNull();
    }

    [Fact]
    public void Failure_ExposesErrorAndThrowsOnValue()
    {
        var result = Result<int>.Failure(new Error("bike.not_found", "Bike not found"));

        result.IsSuccess.Should().BeFalse();
        result.Error!.Code.Should().Be("bike.not_found");
        var read = () => result.Value;
        read.Should().Throw<InvalidOperationException>();
    }
}
