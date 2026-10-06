using System.Reflection;
using NetArchTest.Rules;
using RideKeeper.Application.Health;
using RideKeeper.Infrastructure;

namespace RideKeeper.ArchitectureTests;

/// <summary>Enforces Clean Architecture: dependencies only point inwards.</summary>
public class DependencyRuleTests
{
    private const string Domain = "RideKeeper.Domain";
    private const string Application = "RideKeeper.Application";
    private const string Infrastructure = "RideKeeper.Infrastructure";
    private const string Api = "RideKeeper.Api";

    private static readonly Assembly DomainAssembly = typeof(RideKeeper.Domain.Common.Error).Assembly;
    private static readonly Assembly ApplicationAssembly = typeof(IHealthService).Assembly;
    private static readonly Assembly InfrastructureAssembly = typeof(DependencyInjection).Assembly;

    [Fact]
    public void Domain_DoesNotDependOnOtherLayers()
        => AssertNoDependency(DomainAssembly, Application, Infrastructure, Api);

    [Fact]
    public void Application_DoesNotDependOnInfrastructureOrApi()
        => AssertNoDependency(ApplicationAssembly, Infrastructure, Api);

    [Fact]
    public void Infrastructure_DoesNotDependOnApi()
        => AssertNoDependency(InfrastructureAssembly, Api);

    [Fact]
    public void Application_DoesNotDependOnEntityFramework()
        => AssertNoDependency(ApplicationAssembly, "Microsoft.EntityFrameworkCore");

    private static void AssertNoDependency(Assembly assembly, params string[] forbidden)
    {
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(forbidden)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(
            "forbidden dependencies found in: {0}",
            string.Join(", ", result.FailingTypeNames ?? []));
    }
}
