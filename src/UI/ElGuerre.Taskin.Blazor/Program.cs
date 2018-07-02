using ElGuerre.Taskin.Blazor.Utils;
using ElGuerre.Taskin.Models;
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
                // Add any custom services here
                // sample: services.Add(ServiceDescriptor.Singleton<IDataAccess, DataAccess>());
            });
            
            // new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
