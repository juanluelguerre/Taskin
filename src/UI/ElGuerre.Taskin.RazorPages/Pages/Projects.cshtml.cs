// ---------------------------------------------------------------------------------
// <copyright file="ProjectModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.Threading.Tasks;
using ElGuerre.ApplicationBlocks.Core.Http;
using ElGuerre.Taskin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ElGuerre.Taskin.RazorPages.Pages
{
    public class ProjectPageModel : PageModel
    {
        readonly StandardHttpClient _httpClient;
        readonly string _baseUrl;

        public int ProjId { get; set; }
        public ProjectModel[] Projects { get; set; } 

        public ProjectPageModel(IOptionsSnapshot<AppSettings> settings, IHttpContextAccessor httpContextAccessor)
        {
            _baseUrl = settings.Value.ServiceBaseUrl.TrimEnd('/');
            _httpClient = new StandardHttpClient(httpContextAccessor);
        }

        public async Task OnGet()
        {
            var json = await _httpClient.GetStringAsync($"{_baseUrl}/api/projects");
            Projects = JsonConvert.DeserializeObject<ProjectModel[]>(json);
        }
    }
}
