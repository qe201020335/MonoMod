using System.Text.Json.Serialization;

namespace GenTestMatrix.Models;

internal sealed record Dotnet : Enableable
{
    public required string Name { get; init; }
    public string? Id { get; init; }
    public string? Sdk { get; init; }
    public required string TFM { get; init; }
    public bool NeedsRestore { get; init; }

    public bool IsFramework { get; init; }
    public bool IsMono { get; init; }
    [JsonPropertyName("systemMono")]
    public bool IsSystemMono { get; init; }


    [JsonPropertyName("pgo")]
    public bool HasPGO { get; init; }
    [JsonPropertyName("netMonoPkgVer")]
    public string? MonoPackageVersion { get; init; }
    [JsonPropertyName("netMonoPkgSrc")]
    public string? MonoPackageSource { get; init; }
    [JsonPropertyName("netMonoPkgName")]
    public string? MonoPackageName { get; init; }
    public string? MonoLibPath { get; init; }
    public string? MonoDllPath { get; init; }

    // NOTE: this is semantically required, but cannot be marked so for serialization
    [JsonIgnore]
    public ImmutableArray<string> RIDs { get; init; }

    public static readonly ImmutableArray<Dotnet> Versions = [
        new()
        {
            Name = ".NET Framework 4.x",
            Id = "fx",
            TFM = "net472",
            IsFramework = true,
            RIDs = ["win-x64"]
        }
    ];
}
