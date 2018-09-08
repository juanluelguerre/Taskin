using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;

namespace ElGuerre.Taskin.Blazor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // TODO: Add any custom services here. 
                // Sample: services.Add(ServiceDescriptor.Singleton<IDataAccess, DataAccess>());
            });
            
            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
