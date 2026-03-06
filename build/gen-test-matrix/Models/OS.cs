using System.Text.Json.Serialization;

namespace GenTestMatrix.Models;

internal sealed record OS : Enableable
{
    public required string Name { get; init; }
    public required string Runner { get; init; }

    [JsonIgnore]
    public bool UseContainer { get; init; }

    [JsonIgnore]
    public bool HasFramework { get; init; }
    [JsonIgnore]
    public bool HasSystemMono { get; init; }

    // NOTE: Most of these are actually semantically required, but we have to make them not for JSON serialization to be happy
    [JsonIgnore]
    public string RidName { get; init; } = "";
    [JsonIgnore]
    public string UnityDllName { get; init; } = "";
    [JsonIgnore]
    public string DllPrefix { get; init; } = "";
    [JsonIgnore]
    public string DllSuffix { get; init; } = "";

    [JsonIgnore]
    public ImmutableArray<Arch> Arch { get; init; } = [];

    public static readonly ImmutableArray<OS> OperatingSystems = [
        new()
        {
            Name = "Windows",
            Runner = "windows-latest",
            HasFramework = true,
            RidName = "win",
            UnityDllName = "mono-2.0-bdwgc",
            DllSuffix = ".dll",

            Arch = [
                new() { RidName = "x64", UnityName = "win64", IsRunnerArch = true },
            ]
        },
        new()
        {
            Name = "Linux",
            Runner = "ubuntu-latest",
            UseContainer = true,
            HasSystemMono = true,
            RidName = "linux",
            UnityDllName = "monobdwgc-2.0", // TODO: is this correct?
            DllPrefix = "lib",
            DllSuffix = ".so",

            Arch = [
                new() { RidName = "x64", UnityName = "linux64", IsRunnerArch = true }
            ]
        }
    ];
}

internal sealed record Arch : Enableable
{
    public required string RidName { get; init; }
    public required string? UnityName { get; init; }
    public bool IsRunnerArch { get; init; }
}
