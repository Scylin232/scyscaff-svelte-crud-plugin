using System.Reflection;
using ScyScaff.Core.Models.Parser;
using ScyScaff.Core.Models.Plugins;
using ScyScaff.Docker.Enums;
using ScyScaff.Docker.Models.Builder;
using ScyScaff.Docker.Models.Plugins;

namespace ScyScaffPlugin.SvelteCrud;

public class SvelteCrud : IDashboardTemplatePlugin, IDockerCompatible
{
    public string Name => "svelte-crud";

    public Dictionary<string, string[]> SupportedFlags { get; } = new();

    public IEnumerable<DockerComposeService> GetComposeServices(string projectName, IScaffolderEntity? entity, string serviceName, int serviceIndex)
    {
        List<DockerComposeService> dockerComposeServices = new()
        {
            new DockerComposeService
            {
                Type = DockerComposeServiceType.Dashboard,
                ContainerName = $"{projectName.ToLower()}-dashboard",
                Build = new ComposeBuild
                {
                    Context = $"./{projectName}.Dashboard/",
                    Dockerfile = "Dockerfile.dev"
                },
                Ports = new Dictionary<int, int?>
                {
                    { 5353, 5353 }
                }
            }
        };

        return dockerComposeServices;
    }
}