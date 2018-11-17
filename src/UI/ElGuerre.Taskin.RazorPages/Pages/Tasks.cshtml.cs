// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGuerre.Taskin.RazorPages.Pages
{
    public class TaskPageModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Task List for One Project.";
        }
    }
}
