# Instruction

## .csproj

```
<Project>
  <ItemGroup>
    <PackageReference Include="Chris.Influx" Version="..." />
  </ItemGroup>

</Project>
```

## Startup

```
InfluxStartup.ConfigureSingleton(_config, services);
```

## Update nuget

1. `cd Influx`
2. `dotnet pack --configuration Release`
3. `dotnet nuget push "bin/Release/Chris.Influx.{version}.nupkg" --source github`