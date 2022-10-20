using System.Net;
using ServiceStack;

[assembly: HostingStartup(typeof(EmptyServiceStackNuxt.ConfigureUi))]

namespace EmptyServiceStackNuxt;

public class ConfigureUi : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureAppHost(appHost => {
            // if wwwroot/ is empty, build Client App with 'npm run build'
            var svgDir = appHost.RootDirectory.GetDirectory("/svg") ?? appHost.ContentRootDirectory.GetDirectory("/public/svg"); 
            if (svgDir != null)
            {
                Svg.Load(svgDir);
            }
        });
}
