using System.Reflection;
using ScyScaff.Core.Models.Plugins;

namespace ScyScaffPlugin.SvelteCrud;

public class SvelteCrud : IDashboardTemplatePlugin
{
    public string DashboardName => "svelte-crud";
    
    public string GetTemplateTreePath() => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "TemplateTree\\");
}