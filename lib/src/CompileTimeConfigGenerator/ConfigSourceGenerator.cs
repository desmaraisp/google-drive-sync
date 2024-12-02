using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CompileTimeConfigGenerator;

public record MetadataOnAccessorConfigRecordsToGenerate
{
    public string RecordFullClassName { get; set; } = "";
    public List<string> Properties { get; set; } = [];
}

public record MetadataOnAccessorToGenerate
{
    public List<MetadataOnAccessorConfigRecordsToGenerate> Records { get; set; } = [];
    public string AccessorClassName { get; set; } = "";
    public string AccessorNamespace { get; set; } = "";
}

[Generator]
public class ConfigSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var metadataOnAccessorsToGenerate = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                "CompileTimeConfigPublicMembers.GenerateConfigAccessorAttribute",
                predicate: static (_, _) => true,
                transform: (ctx, _) =>
                {
                    if (ctx.SemanticModel.GetDeclaredSymbol(ctx.TargetNode) is not INamedTypeSymbol generatorSymbol)
                        return null;

                    var records = ctx.Attributes
                        .Select(attributeData => attributeData.ConstructorArguments[0].Value)
                        .OfType<ITypeSymbol>()
                        .Select(recordSymbol =>
                        {
                            var properties = recordSymbol.GetMembers()
                                .OfType<IPropertySymbol>()
                                .Where(x => x.SetMethod?.DeclaredAccessibility == Accessibility.Public &&
                                            x.Type.Name == nameof(String));

                            return new MetadataOnAccessorConfigRecordsToGenerate
                            {
                                RecordFullClassName =
                                    recordSymbol.ToDisplayString(
                                        new SymbolDisplayFormat(SymbolDisplayGlobalNamespaceStyle.Included)),
                                Properties = properties.Select(x => x.Name).ToList()
                            };
                        }).ToList();


                    return new MetadataOnAccessorToGenerate
                    {
                        Records = records,
                        AccessorNamespace = generatorSymbol.ContainingNamespace.Name,
                        AccessorClassName = generatorSymbol.Name,
                    };
                }).Collect();

        var combine = metadataOnAccessorsToGenerate.Combine(context.AnalyzerConfigOptionsProvider);

        context.RegisterSourceOutput(combine,
            static (spc, tuple) =>
            {
                foreach (var metadata in tuple.Left)
                {
                    if (metadata == null) continue;

                    var interfacesToImplement = metadata.Records.Select(CreateInterfaceString);
                    var accessorMethods = metadata.Records.Select(x => GenerateRecordAccessMethod(x, tuple.Right));

                    string generatorString =
                        $$"""
                        using CompileTimeConfigPublicMembers;

                        namespace {{metadata.AccessorNamespace}} {
                            public partial class {{metadata.AccessorClassName}}: {{string.Join(", ", interfacesToImplement)}} {
                        {{string.Join("\n", accessorMethods)}}
                            }
                        }
                        """;

                    spc.AddSource(
                        $"CompileTimeConfigAccessors.{metadata.AccessorClassName}.g.cs",
                        generatorString);
                }
            });
    }

    private static string? GetBuildParam(string paramName, AnalyzerConfigOptionsProvider context)
    {
        context.GlobalOptions.TryGetValue($"build_property.CompileTimeConfig_{paramName}", out string? value);
        return value;
    }

    private static string CreateInterfaceString(MetadataOnAccessorConfigRecordsToGenerate record)
    {
        return $"ICompileTimeConfigAccessor<{record.RecordFullClassName}>";
    }

    private static string GenerateRecordAccessMethod(MetadataOnAccessorConfigRecordsToGenerate record,
        AnalyzerConfigOptionsProvider configOptionsProvider)
    {
        return $$"""
                        {{record.RecordFullClassName}} {{CreateInterfaceString(record)}}.GetConfig() {
                            return new {{record.RecordFullClassName}} {
                                {{
                                    string.Join("\n\t\t\t\t", record.Properties.Select(y => $"""{y} = "{GetBuildParam(y, configOptionsProvider)}","""))
                                }}
                            };
                        }
                """;
    }
}
